using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SITE_Incoming_In_Add_Document : System.Web.UI.Page
{
    public SqlConnection con;

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            fldNewPackage.Visible = false;
            fldNewType.Visible = false;
            fldNewAuthor.Visible = false;
            fldNewSubjectFile.Visible = false;

            bindOriginator();
            bindPackage();
            bindType();
            bindAuthor();
            bindSubjectFile();
            bindConfidential();
        }
    }

    #region ddlOriginator
    protected void bindOriginator()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindOriginator", con);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldOriginator.DataSource = dt;
        fldOriginator.DataTextField = "FLD_COMPANY";
        fldOriginator.DataValueField = "FLD_COMPANY";
        fldOriginator.DataBind();
        fldOriginator.Items.Insert(0, new ListItem("Please select Originator", "Please select Originator"));
    }

    protected void fldOriginator_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.connection();

        SqlCommand com = new SqlCommand("[spfldOriginator_SelectedIndexChanged]", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@company", fldOriginator.SelectedValue);
        com.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.       
            lblOriginatorCode.Text = "";
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Originator Code
            lblOriginatorCode.Text = row["COMPANY_CODE"].ToString();
        }
        con.Close();
    }
    #endregion

    #region ddlPackage
    protected void bindPackage()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindPackage", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldPackage.DataSource = dt;
        fldPackage.DataTextField = "FLD_PACKAGE";
        fldPackage.DataValueField = "FLD_PACKAGE";
        fldPackage.DataBind();
        fldPackage.Items.Insert(0, new ListItem("Please select Package", ""));
        fldPackage.Items.Insert(1, new ListItem("Add New Package", "addNewPackage"));
    }

    protected void fldPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldPackage.SelectedIndex == 1)
            fldNewPackage.Visible = true;
        else
            fldNewPackage.Visible = false;
    }
    #endregion

    #region ddlType
    protected void bindType()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindType", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldType.DataSource = dt;
        fldType.DataTextField = "FLD_TYPE";
        fldType.DataValueField = "FLD_TYPE";
        fldType.DataBind();
        fldType.Items.Insert(0, new ListItem("Please select Type", ""));
        fldType.Items.Insert(1, new ListItem("Add New Type", "addNewType"));
    }

    protected void fldType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldType.SelectedIndex == 1)
            fldNewType.Visible = true;
        else
            fldNewType.Visible = false;
    }
    #endregion

    #region ddlAuthor
    protected void bindAuthor()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindAuthor", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldAuthor.DataSource = dt;
        fldAuthor.DataTextField = "FLD_AUTHOR";
        fldAuthor.DataValueField = "FLD_AUTHOR";
        fldAuthor.DataBind();
        fldAuthor.Items.Insert(0, new ListItem("Please select Author", ""));
        fldAuthor.Items.Insert(1, new ListItem("Add New Author", "addNewAuthor"));
    }

    protected void fldAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldAuthor.SelectedIndex == 1)
            fldNewAuthor.Visible = true;
        else
            fldNewAuthor.Visible = false;
    }
    #endregion

    #region ddlSubject
    protected void bindSubjectFile()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindSubjectFile", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldSubjectFile.DataSource = dt;
        fldSubjectFile.DataTextField = "FLD_SUBJECT_FILE";
        fldSubjectFile.DataValueField = "FLD_SUBJECT_FILE";
        fldSubjectFile.DataBind();
        fldSubjectFile.Items.Insert(0, new ListItem("Please select Subject File", ""));
        fldSubjectFile.Items.Insert(1, new ListItem("Add New Subject File", "addNewSubjectFile"));
    }

    protected void fldSubjectFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldSubjectFile.SelectedIndex == 1)
            fldNewSubjectFile.Visible = true;
        else
            fldNewSubjectFile.Visible = false;
    }
    #endregion

    #region ddlConfidential
    protected void bindConfidential()
    {
        fldConfidential.Items.Insert(0, new ListItem("Please select Confidentiality", ""));
        fldConfidential.Items.Insert(1, new ListItem("SECRET", "SECRET"));
        fldConfidential.Items.Insert(2, new ListItem("CONFIDENTIAL", "CONFIDENTIAL"));
        fldConfidential.Items.Insert(3, new ListItem("CONTRACT", "CONTRACT"));
    }
    #endregion

    #region Urgency
    protected void btnHigh_Click(object sender, EventArgs e)
    {
        if (fldDateReceived.Value== "")
        {
            
        }
        else
        {
            DateTime today = DateTime.Parse(fldDateReceived.Value);
            fldDateRequired.Value = today.AddDays(3).ToString("dd-MM-yyyy");
            fldUrgency.Value = "1";
            btnHigh.Font.Bold = true;
            btnHigh.Font.Underline = true;

            btnMedium.Font.Bold = false;
            btnMedium.Font.Underline = false;

            btnLow.Font.Bold = false;
            btnLow.Font.Underline = false;

            btnInfo.Font.Bold = false;
            btnInfo.Font.Underline = false;
        }
    }

    protected void btnMedium_Click(object sender, EventArgs e)
    {
        if (fldDateReceived.Value == "")
        {

        }
        else
        {
            DateTime today = DateTime.Parse(fldDateReceived.Value);
            fldDateRequired.Value = today.AddDays(7).ToString("dd-MMM-yyyy");
            fldUrgency.Value = "2";
            btnMedium.Font.Bold = true;
            btnMedium.Font.Underline = true;

            btnHigh.Font.Bold = false;
            btnHigh.Font.Underline = false;

            btnLow.Font.Bold = false;
            btnLow.Font.Underline = false;

            btnInfo.Font.Bold = false;
            btnInfo.Font.Underline = false;
        }
    }

    protected void btnLow_Click(object sender, EventArgs e)
    {
        if (fldDateReceived.Value == "")
        {
            
        }
        else
        {
            DateTime today = DateTime.Parse(fldDateReceived.Value);
            fldDateRequired.Value = today.AddDays(14).ToString("dd-MMM-yyyy");
            fldUrgency.Value = "3";
            btnLow.Font.Bold = true;
            btnLow.Font.Underline = true;

            btnHigh.Font.Bold = false;
            btnHigh.Font.Underline = false;

            btnMedium.Font.Bold = false;
            btnMedium.Font.Underline = false;

            btnInfo.Font.Bold = false;
            btnInfo.Font.Underline = false;
        }
    }

    protected void btnInfo_Click(object sender, EventArgs e)
    {
        fldDateRequired.Value = "";
        fldUrgency.Value = "4";
        btnInfo.Font.Bold = true;
        btnInfo.Font.Underline = true;

        btnHigh.Font.Bold = false;
        btnHigh.Font.Underline = false;

        btnMedium.Font.Bold = false;
        btnMedium.Font.Underline = false;

        btnLow.Font.Bold = false;
        btnLow.Font.Underline = false;
    }
    #endregion

    #region btnCheckDuplicate
    protected void btnCheckRefNo_Click(object sender, EventArgs e)
    {
        this.connection();

        SqlCommand com = new SqlCommand("spCheckRefNo", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@RefNo", fldRefNo.Text.Trim());
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            dvAvailable.Visible = true;
        }
        else
        {
            dvDuplicate.Visible = true;
        }
    }
    #endregion

    #region btnSave
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (fldDateReceived.Value == "")
        {
            errDvfldDateReceived.Visible = true;
        }
        else if (fldOriginator.SelectedIndex == 0)
        {
            errDvfldOriginator.Visible = true;
        }
        else if (fldDateDocument.Value == "")
        {
            errDvfldDateDoc.Visible = true;
        }
        else if (fldSubject.Text == "")
        {
            errDvfldSubject.Visible = true;
        }
        else
        {
            this.connection();

            SqlCommand cmd = new SqlCommand("spSaveInDocument", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffNo", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
            cmd.Parameters.AddWithValue("@OriginatorCode", lblOriginatorCode.Text);
            cmd.Parameters.AddWithValue("@refno", fldRefNo.Text.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@subject", fldSubject.Text.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@urgency", fldUrgency.Value);

            if (fldDateReceived.Value != "")
            {
                cmd.Parameters.AddWithValue("@rcvddt", Convert.ToDateTime(fldDateReceived.Value));
            }
            else
            {
                cmd.Parameters.AddWithValue("@rcvddt", DBNull.Value);
            }
              
            if (fldOriginator.Text != "")
                cmd.Parameters.AddWithValue("@company", fldOriginator.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@company", DBNull.Value);

            if (fldDateDocument.Value != "")
            {
                cmd.Parameters.AddWithValue("@docdt", Convert.ToDateTime(fldDateDocument.Value));
            }
            else
            {
                cmd.Parameters.AddWithValue("@docdt", DBNull.Value);
            }

            if (fldPackage.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@package", fldNewPackage.Text.ToUpper());
                cmd.Parameters.AddWithValue("@new_package", fldNewPackage.Text.ToUpper());
            }
            else
            {
                if (fldPackage.Text != "")
                {
                    cmd.Parameters.AddWithValue("@package", fldPackage.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@package", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@new_package", DBNull.Value);
            }

            if (fldType.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@typedoc", fldNewType.Text.ToUpper());
                cmd.Parameters.AddWithValue("@new_type", fldNewType.Text.ToUpper());
            }
            else
            {
                if (fldType.Text != "")
                {
                    cmd.Parameters.AddWithValue("@typedoc", fldType.SelectedValue);
                } 
                else
                {
                    cmd.Parameters.AddWithValue("@typedoc", DBNull.Value);
                }
                    
                cmd.Parameters.AddWithValue("@new_type", DBNull.Value);
            }

            if (fldAuthor.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@author", fldNewAuthor.Text.ToUpper());
                cmd.Parameters.AddWithValue("@new_author", fldNewAuthor.Text.ToUpper());
            }
            else
            {
                if (fldAuthor.Text != "")
                {
                    cmd.Parameters.AddWithValue("@author", fldAuthor.SelectedValue);
                }                   
                else
                {
                    cmd.Parameters.AddWithValue("@author", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@new_author", DBNull.Value);
            }

            if (fldDateRequired.Value != "")
            {
                cmd.Parameters.AddWithValue("@reqdt", Convert.ToDateTime(fldDateRequired.Value));
            }
            else
            {
                cmd.Parameters.AddWithValue("@reqdt", DBNull.Value);
            }

            if (fldSubjectFile.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@subjectfile", fldNewSubjectFile.Text.ToUpper());
                cmd.Parameters.AddWithValue("@new_subjectfile", fldNewSubjectFile.Text.ToUpper());
            }
            else
            {
                if (fldSubjectFile.Text != "")
                {
                    cmd.Parameters.AddWithValue("@subjectfile", fldSubjectFile.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@subjectfile", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@new_subjectfile", DBNull.Value);
            }

            if (fldConfidential.Text != "")
                cmd.Parameters.AddWithValue("@confidential", fldConfidential.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@confidential", DBNull.Value);

            cmd.Parameters.AddWithValue("@remarks", fldRemarks.Text.Trim().ToUpper());

            cmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow row = null;
            row = dt.Rows[0];

            //Redirect to edit page.
            Response.Redirect("In_Edit_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"] + "&ID2=" + row["ID"].ToString());
        }
    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("In_Add_Document.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }
}