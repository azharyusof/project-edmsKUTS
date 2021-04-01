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
using Microsoft.VisualBasic;
using System.IO;
using System.Net.Mail;


public partial class SITE_Incoming_In_Edit_Document : System.Web.UI.Page
{
    String queryString = "";
    DataRow row = null;
    DataRow row1 = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    DateTime varDt;
    String pnc_check = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        cmd = new SqlCommand();
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand("SELECT * FROM PROJECTUSERS WHERE STAFF_NO='" + Request.QueryString["ID"] + "' AND PROJECT_CODE='" + Request.QueryString["ID1"] + "'", con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);

        row1 = null;
        row1 = dt1.Rows[0];

        if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC")
        {
            lbtnAddAttach.Visible = true;
            lbtnAddActionee.Visible = true;

            GridViewAttach.Columns[2].Visible = true;
            GridViewActionee.Columns[3].Visible = true;
        }
        else
        {
            lbtnAddAttach.Visible = false;
            lbtnAddActionee.Visible = false;

            GridViewAttach.Columns[2].Visible = false;
            GridViewActionee.Columns[3].Visible = false;
        }

        con.Close();

        if (!IsPostBack)
        {
            bindOriginator();
            bindPackage();
            bindType();
            bindAuthor();
            bindSubjectFile();
            bindConfidential();
            bindActionee();

            bindGridViewDetails();
            bindGridViewAttach();
            bindGridViewActionee();

            bindOutRefNo();
        }
    }

    #region bindOriginator
    protected void bindOriginator()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldOriginator.DataSource = GetData(queryString);
        fldOriginator.DataTextField = "FLD_COMPANY";
        fldOriginator.DataValueField = "FLD_COMPANY";
        fldOriginator.DataBind();
        fldOriginator.Items.Insert(0, new ListItem("-- Please select Originator --", ""));
    }
    #endregion

    #region bindPackage
    protected void bindPackage()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_PACKAGE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_PACKAGE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_PACKAGE ";

        fldPackage.DataSource = GetData(queryString);
        fldPackage.DataTextField = "FLD_PACKAGE";
        fldPackage.DataValueField = "FLD_PACKAGE";
        fldPackage.DataBind();
        fldPackage.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please select Package --", ""));
        fldPackage.Items.Insert(1, new System.Web.UI.WebControls.ListItem("+ Add New Package +", "addNewPackage"));
    }

    protected void fldPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldPackage.SelectedIndex == 1)
            fldNewPackage.Visible = true;
        else
            fldNewPackage.Visible = false;
    }
    #endregion

    #region bindType
    protected void bindType()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_TYPE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_TYPE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_TYPE ";

        fldType.DataSource = GetData(queryString);
        fldType.DataTextField = "FLD_TYPE";
        fldType.DataValueField = "FLD_TYPE";
        fldType.DataBind();
        fldType.Items.Insert(0, new ListItem("-- Please select Type --", ""));
        fldType.Items.Insert(1, new ListItem("+ Add New Type +", "addNewType"));
    }

    protected void fldType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldType.SelectedIndex == 1)
            fldNewType.Visible = true;
        else
            fldNewType.Visible = false;
    }

    #endregion

    #region bindAuthor
    protected void bindAuthor()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_AUTHOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_AUTHOR IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_AUTHOR ";

        fldAuthor.DataSource = GetData(queryString);
        fldAuthor.DataTextField = "FLD_AUTHOR";
        fldAuthor.DataValueField = "FLD_AUTHOR";
        fldAuthor.DataBind();
        fldAuthor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please select Author --", ""));
        fldAuthor.Items.Insert(1, new System.Web.UI.WebControls.ListItem("+ Add New Author +", "addNewAuthor"));
    }

    protected void fldAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldAuthor.SelectedIndex == 1)
            fldNewAuthor.Visible = true;
        else
            fldNewAuthor.Visible = false;
    }
    #endregion

    #region bindSubjectFile
    protected void bindSubjectFile()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_SUBJECT_FILE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_SUBJECT_FILE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_SUBJECT_FILE ";

        fldSubjectFile.DataSource = GetData(queryString);
        fldSubjectFile.DataTextField = "FLD_SUBJECT_FILE";
        fldSubjectFile.DataValueField = "FLD_SUBJECT_FILE";
        fldSubjectFile.DataBind();
        fldSubjectFile.Items.Insert(0, new ListItem("-- Please select Subject File --", ""));
        fldSubjectFile.Items.Insert(1, new ListItem("+ Add New Subject File +", "addNewSubjectFile"));
    }

    protected void fldSubjectFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldSubjectFile.SelectedIndex == 1)
            fldNewSubjectFile.Visible = true;
        else
            fldNewSubjectFile.Visible = false;
    }
    #endregion

    #region bindConfidential
    protected void bindConfidential()
    {
        fldConfidential.Items.Insert(0, new ListItem("-- Please select Confidentiality  --", ""));
        fldConfidential.Items.Insert(1, new ListItem("SECRET", "SECRET"));
        fldConfidential.Items.Insert(2, new ListItem("CONFIDENTIAL", "CONFIDENTIAL"));
        fldConfidential.Items.Insert(3, new ListItem("CONTRACT", "CONTRACT"));
    }
    #endregion

    #region Attachment
    protected void bindGridViewAttach()
    {
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_IN_ATTACH ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        queryString = queryString + " ORDER BY      FILENAME ";

        GridViewAttach.DataSource = GetData(queryString);
        GridViewAttach.DataBind();

        for (int i = 0; i < GridViewAttach.Rows.Count; i++)
        {
            GridViewRow row2 = GridViewAttach.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row2.Cells[0].Style.Add("background-color", "#eeeeee");
                row2.Cells[1].Style.Add("background-color", "#eeeeee");
                row2.Cells[2].Style.Add("background-color", "#eeeeee");
            }
        }
    }

    protected void GridViewAttach_DataBound(object sender, EventArgs e)
    {
        int rowCount = GridViewAttach.Rows.Count;

        if (rowCount == 0)
        {
            GridViewAttach.Visible = false;
        }
        else
        {
            GridViewAttach.Visible = true;
        }
    }

    protected void GridViewAttach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("btnDelete");
            l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Attachment?')");
        }
    }

    protected void GridViewAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Delete the record.
            deleteAttachRecordByID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind attachment details.
        bindGridViewAttach();
    }

    protected void deleteAttachRecordByID(string recID)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        cmd = new SqlCommand("SELECT FILENAME FROM EDMS_IN_ATTACH WHERE RecID = @pRecID", con);
        cmd.Parameters.AddWithValue("@pRecID", recID);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);

        row = null;
        row = dtChck.Rows[0];

        string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["id1"] + "/incoming/attachment/" + Request.QueryString["id2"] + "/" + row["FILENAME"].ToString() + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        cmd1 = new SqlCommand("DELETE FROM EDMS_IN_ATTACH WHERE RecID = @pRecID", con);
        cmd1.CommandTimeout = 0;
        cmd1.Parameters.AddWithValue("@pRecID", recID);
        cmd1.ExecuteNonQuery();

        con.Close();
    }

    protected void btnAddNewAttach_Click(object sender, EventArgs e)
    {
        //Attachment
        HttpFileCollection hfc = Request.Files;
        string Msg = null;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                string pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["ID1"] + "/" + lblOriginatorCode.Text + "/incoming/attachment/" + Request.QueryString["ID2"] + "";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                }
                else
                {
                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                }

                Msg += "<b>" + System.IO.Path.GetFileName(hpf.FileName.ToString()) + "</b> uploaded successfully.<br> ";

            }
            lblMessage.Text = "<b>" + Msg + "</b>";
        }

        //-----------------------------------------------------------
        //Insert into database.
        queryString = "";
        queryString = queryString + " INSERT INTO   EDMS_IN_ATTACH ";
        queryString = queryString + "               (FLD_IN_SERIAL, COMPANY_CODE, FILENAME, ID) ";
        queryString = queryString + " VALUES        (@pFLD_IN_SERIAL, @pCOMPANY_CODE, @pFILENAME, @pID) ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pFLD_IN_SERIAL", lblTNoAttach.Text);
        cmd.Parameters.AddWithValue("@pCOMPANY_CODE", lblOriginatorCode.Text);

        //File Name
        cmd.Parameters.AddWithValue("@pFILENAME", FileUpload1.FileName);

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();
        con.Close();

        //Bind attachment details.
        bindGridViewAttach();

        //Bind actionee details.
        //bindGridViewActionee();
    }

    protected void btnCloseAttach_Click(object sender, EventArgs e)
    {
    }
    #endregion

    #region bindOutRefNo
    protected void bindOutRefNo()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " ORDER BY      FLD_OUT_SERIAL ";

        fldOutTrackNo.SelectedValue = null;

        fldOutTrackNo.DataSource = GetData(queryString);
        fldOutTrackNo.DataTextField = "FLD_OUT_SERIAL";
        fldOutTrackNo.DataValueField = "FLD_OUT_SERIAL";
        fldOutTrackNo.DataBind();
        fldOutTrackNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please select Outgoing Tracking No. --", ""));
    }

    protected void fldOutTrackNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Display outgoing details.
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         FLD_OUT_SERIAL='" + fldOutTrackNo.SelectedValue + "'";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);

        if (dt2.Rows.Count == 0)
        {
            //Check for empty record.       
            fldOutRefNo.Text = "";
            fldOutSubject.Text = "";
        }
        else
        {
            DataRow row1 = dt2.Rows[0];

            //Reference No.
            fldOutRefNo.Text = row1["FLD_REFERENCE"].ToString();

            //Subject
            fldOutSubject.Text = row1["FLD_TITLE"].ToString();
        }
        con.Close();
    }
    #endregion

    #region btnUrgency
    protected void btnHigh_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Parse(fldDateReceived.Value);
        fldDateRequired.Value = today.AddDays(3).ToString("dd-MMM-yyyy");
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

    protected void btnMedium_Click(object sender, EventArgs e)
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

    protected void btnLow_Click(object sender, EventArgs e)
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

    protected void btnInfo_Click(object sender, EventArgs e)
    {
        fldDateRequired.Value = "";
        fldDateRequired.Value = "4";
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

    #region bindActionee
    protected void bindActionee()
    {
        queryString = "";
        queryString = queryString + " SELECT        STAFFNO, UPPER(STAFFNAME) AS STAFFNAME  ";
        queryString = queryString + " FROM          TBLUSERLOGIN ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " ORDER BY      STAFFNAME ";

        fldActionee.DataSource = GetData(queryString);
        fldActionee.DataTextField = "STAFFNAME";
        fldActionee.DataValueField = "STAFFNO";
        fldActionee.DataBind();
        fldActionee.Items.Insert(0, new ListItem("-- Please select Actionee --", ""));
    }
    #endregion

    #region btnDeleteScannedDoc
    protected void btnDeleteScanDoc_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          VWEDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        row = null;
        row = dtChck.Rows[0];

        varDt = Convert.ToDateTime(row["FLD_IN_DATE"].ToString());

        string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["id1"] + "/incoming/" + varDt.ToString("yyyy") + "/" + row["TRACK_NO"].ToString() + ".pdf";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        Response.Redirect("In_Edit_Document.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"] + "&ID2=" + Request.QueryString["id2"] + "&url=" + Request.QueryString["url"]);

    }
    #endregion

    #region btnUpdate
    protected void updateOut()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

        con.Open();
        DateTime now = DateTime.Now;
        SqlCommand command = new SqlCommand("UPDATE EDMS_IN_DOCUMENT SET "
          + "FLD_IN_DATE = @rcvddt, "
          + "FLD_REFERENCE = @refno, "
          + "FLD_CORR_DATE = @docdt, "
          + "FLD_PACKAGE = @package, "
          + "FLD_TYPE = @typedoc, "
          + "FLD_TITLE = @subject, "
          + "FLD_AUTHOR = @author, "
          + "FLD_URGENCY = @urgency, "
          + "FLD_REQ_DATE = @reqdt, "
          + "FLD_SUBJECT_FILE = @subjectfile, "
          + "FLD_CONFIDENTIAL = @confidential, "
          + "REMARKS = @remarks, "
          + "FLD_ACTION_DATE = @actiondt, "
          + "FLD_OUT_TRACK_NO = @outtrackno, "
          + "FLD_OUT_REFERENCE = @outref, "
          + "FLD_ACTION_TAKEN = @action, "
          + "UpdatedBy = '" + Request.QueryString["ID"] + "', "
          + "UpdatedDt = '" + now.ToString("yyyy-MM-dd hh:mm:ss.000") + "' "
          + "WHERE id = '" + Request.QueryString["ID2"] + "'", con);

        //Date Received
        if (fldDateReceived.Value != "")
        {
            command.Parameters.AddWithValue("@rcvddt", Convert.ToDateTime(fldDateReceived.Value));
        }
        else
        {
            command.Parameters.AddWithValue("@rcvddt", DBNull.Value);
        }

        //In Reference No.
        command.Parameters.AddWithValue("@refno", fldRefNo.Text.Trim().ToUpper());

        //Date of Document
        if (fldDateDocument.Value != "")
        {
            command.Parameters.AddWithValue("@docdt", Convert.ToDateTime(fldDateDocument.Value));
        }
        else
        {
            command.Parameters.AddWithValue("@docdt", DBNull.Value);
        }

        //Package
        if (fldPackage.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@package", fldNewPackage.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_PACKAGE "
              + "(FLD_PACKAGE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_package, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_package", fldNewPackage.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldPackage.Text != "")
                command.Parameters.AddWithValue("@package", fldPackage.SelectedValue);
            else
                command.Parameters.AddWithValue("@package", DBNull.Value);
        }

        //Type of Document
        if (fldType.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@typedoc", fldNewType.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_TYPE "
              + "(FLD_TYPE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_type, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_type", fldNewType.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldType.Text != "")
                command.Parameters.AddWithValue("@typedoc", fldType.SelectedValue);
            else
                command.Parameters.AddWithValue("@typedoc", DBNull.Value);
        }

        //Subject
        command.Parameters.AddWithValue("@subject", fldSubject.Text.Trim().ToUpper());

        //Author
        if (fldAuthor.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@author", fldNewAuthor.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_AUTHOR "
              + "(FLD_AUTHOR, PROJECT_CODE) "
              + "VALUES "
              + "(@new_author, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_author", fldNewAuthor.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldAuthor.Text != "")
                command.Parameters.AddWithValue("@author", fldAuthor.SelectedValue);
            else
                command.Parameters.AddWithValue("@author", DBNull.Value);
        }

        //Urgency
        command.Parameters.AddWithValue("@urgency", fldUrgency.Value);

        //Date Required
        if (fldDateRequired.Value != "")
        {
            command.Parameters.AddWithValue("@reqdt", Convert.ToDateTime(fldDateRequired.Value));
        }
        else
        {
            command.Parameters.AddWithValue("@reqdt", DBNull.Value);
        }

        //Subject File
        if (fldSubjectFile.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@subjectfile", fldNewSubjectFile.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_SUBJECT_FILE "
              + "(FLD_SUBJECT_FILE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_subjectfile, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_subjectfile", fldNewSubjectFile.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldSubjectFile.Text != "")
                command.Parameters.AddWithValue("@subjectfile", fldSubjectFile.SelectedValue);
            else
                command.Parameters.AddWithValue("@subjectfile", DBNull.Value);
        }

        //Type of Confidentiality 
        if (fldConfidential.Text != "")
            command.Parameters.AddWithValue("@confidential", fldConfidential.SelectedValue);
        else
            command.Parameters.AddWithValue("@confidential", DBNull.Value);

        //DC Remarks        
        command.Parameters.AddWithValue("@remarks", fldRemarks.Text.Trim().ToUpper());

        //Response Date
        if (fldDateResponse.Value != "")
        {
            command.Parameters.AddWithValue("@actiondt", Convert.ToDateTime(fldDateResponse.Value));
        }
        else
        {
            command.Parameters.AddWithValue("@actiondt", DBNull.Value);
        }

        //Out Reference No.
        command.Parameters.AddWithValue("@outtrackno", fldOutTrackNo.Text);
        command.Parameters.AddWithValue("@outref", fldOutRefNo.Text.Trim().ToUpper());

        //Action Taken
        command.Parameters.AddWithValue("@action", fldActionTaken.Text.Trim().ToUpper());

        command.ExecuteNonQuery();

        con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateOut();
    }
    #endregion

    protected void bindGridViewDetails()
    {
        queryString = "";
        queryString = queryString + " SELECT        VWEDMS_IN_DOCUMENT.*,  ";
        queryString = queryString + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        queryString = queryString + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        queryString = queryString + " FROM          VWEDMS_IN_DOCUMENT ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblCREATEBY on tblCREATEBY.StaffNo = VWEDMS_IN_DOCUMENT.CreatedBy ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblUPDATEBY on tblUPDATEBY.StaffNo = VWEDMS_IN_DOCUMENT.UpdatedBy ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Check if file exist.
            var file2 = new System.IO.FileInfo(@"E:/Webapps/EDMS_STR/Document/" + row["PROJECT_CODE"].ToString() + "/" + row["COMPANY_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["FLD_IN_SERIAL"].ToString() + ".pdf");

            if (file2.Exists)
            {
                //Confidential
                if (row["FLD_CONFIDENTIAL"].ToString() == "1")
                {
                    cmd = new SqlCommand();
                    if (con.State == ConnectionState.Closed)
                    { con.Open(); }
                    cmd = new SqlCommand("SELECT * FROM PROJECTUSERS WHERE STAFF_NO='" + Request.QueryString["ID"] + "' AND PROJECT_CODE='" + Request.QueryString["ID1"] + "'", con);
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    row1 = null;
                    row1 = dt1.Rows[0];

                    if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC" || row1["TYPE"].ToString() == "PM")
                    {
                        lblNone.Visible = true;

                        lblNone.Text = row["FLD_IN_SERIAL"].ToString();

                        img_all.Visible = true;
                    }
                    else
                    {
                        lblNone.Visible = true;

                        lblNone.Text = row["FLD_IN_SERIAL"].ToString();
                    }
                }
                else
                {
                    lblNone.Visible = true;

                    lblNone.Text = row["FLD_IN_SERIAL"].ToString();

                    img_all.Visible = true;
                }
            }
            else
            {
                lblNone.Visible = true;

                lblNone.Text = row["FLD_IN_SERIAL"].ToString();
            }
            //end of check if file exist.

            //Tracking No.
            fldYr.Text = row["YR"].ToString();
            fldTrackNo.Text = row["FLD_IN_SERIAL"].ToString();
            fldCompanyCode.Text = row["COMPANY_CODE"].ToString();
            lblTNoAttach.Text = row["FLD_IN_SERIAL"].ToString();
            lblTNoActionee.Text = row["FLD_IN_SERIAL"].ToString();

            //Date Received
            fldDateReceived.Value = Convert.ToDateTime(row["FLD_IN_DATE"].ToString()).ToString("dd-MMM-yyyy");

            //Originator
            fldOriginator.Text = row["FLD_COMPANY"].ToString();
            lblOriginatorCode.Text = row["COMPANY_CODE"].ToString();

            //In Reference No.
            fldRefNo.Text = row["FLD_REFERENCE"].ToString();

            //Date of Document
            object value = row["FLD_CORR_DATE"];
            if (value == DBNull.Value)
            { }
            else
            { fldDateDocument.Value = Convert.ToDateTime(row["FLD_CORR_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Package
            fldPackage.Text = row["FLD_PACKAGE"].ToString();

            //Type of Document
            fldType.Text = row["FLD_TYPE"].ToString();

            //Subject
            fldSubject.Text = row["FLD_TITLE"].ToString();

            //Author
            fldAuthor.Text = row["FLD_AUTHOR"].ToString();

            //Urgency
            fldUrgency.Value = row["FLD_URGENCY"].ToString();

            object urgency1 = Convert.ToString(row["FLD_URGENCY"]);
            if (urgency1 as string == "1")
            {
                btnHigh.Font.Bold = true;
                btnHigh.Font.Underline = true;
            }
            else if ((String)urgency1 == "2")
            {
                btnMedium.Font.Bold = true;
                btnMedium.Font.Underline = true;
            }
            else if ((String)urgency1 == "3")
            {
                btnLow.Font.Bold = true;
                btnLow.Font.Underline = true;
            }
            else if ((String)urgency1 == "4")
            {
                btnInfo.Font.Bold = true;
                btnInfo.Font.Underline = true;
            }

            //Date Required
            object value1 = row["FLD_REQ_DATE"];
            if (value1 == DBNull.Value)
            { }
            else
            { fldDateRequired.Value = Convert.ToDateTime(row["FLD_REQ_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Subject File
            fldSubjectFile.Text = row["FLD_SUBJECT_FILE"].ToString();

            //Type of Confidentiality
            fldConfidential.Text = row["FLD_CONFIDENTIAL"].ToString();

            //DC Remarks
            fldRemarks.Text = row["REMARKS"].ToString();

            //Response Date
            object value2 = row["FLD_ACTION_DATE"];
            if (value2 == DBNull.Value)
            { }
            else
            { fldDateResponse.Value = Convert.ToDateTime(row["FLD_ACTION_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Out Reference No.
            fldOutTrackNo.Text = row["FLD_OUT_TRACK_NO"].ToString();

            //Created By
            if (row["CreatedDt"].ToString() != "")
            {
                varDt = Convert.ToDateTime(row["CreatedDt"].ToString());
                lblCreatedBy.Text = row["CREATEBYName"].ToString() + " on " + varDt.ToString("dd-MMM-yyyy");
            }
            else
                lblCreatedBy.Text = "";

            //Last Update
            if (row["UpdatedDt"].ToString() != "")
            {
                varDt = Convert.ToDateTime(row["UpdatedDt"].ToString());
                lblLastUpdate.Text = row["UPDATEBYName"].ToString() + " on " + varDt.ToString("dd-MMM-yyyy");
            }
            else
                lblLastUpdate.Text = "";

            con.Close();

            //Display outgoing details.
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
            queryString = queryString + " WHERE         FLD_OUT_SERIAL='" + row["FLD_OUT_TRACK_NO"].ToString() + "'";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count == 0)
            {
                //Check for empty record.       
                fldOutRefNo.Text = "";
                fldOutSubject.Text = "";
            }
            else
            {
                DataRow row2 = dt2.Rows[0];

                //Reference No.
                fldOutRefNo.Text = row2["FLD_REFERENCE"].ToString();

                //Subject
                fldOutSubject.Text = row2["FLD_TITLE"].ToString();
            }
            con.Close();

            //Action Taken
            fldActionTaken.Text = row["FLD_ACTION_TAKEN"].ToString();
        }
    }

    #region
    protected void bindGridViewActionee()
    {
        queryString = "";
        queryString = queryString + " SELECT        EDMS_IN_ACTIONEE.*, ";
        queryString = queryString + "               tblACTIONEE.StaffName As ACTIONEEName  ";
        queryString = queryString + " FROM          EDMS_IN_ACTIONEE ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblACTIONEE on tblACTIONEE.StaffNo = EDMS_IN_ACTIONEE.FLD_IN_ACTIONEE ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        queryString = queryString + " ORDER BY      ACTION DESC ";

        GridViewActionee.DataSource = GetData(queryString);
        GridViewActionee.DataBind();

        for (int i = 0; i < GridViewActionee.Rows.Count; i++)
        {
            GridViewRow row2 = GridViewActionee.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row2.Cells[0].Style.Add("background-color", "#eeeeee");
                row2.Cells[1].Style.Add("background-color", "#eeeeee");
                row2.Cells[2].Style.Add("background-color", "#eeeeee");
                row2.Cells[3].Style.Add("background-color", "#eeeeee");
                row2.Cells[4].Style.Add("background-color", "#eeeeee");
                row2.Cells[5].Style.Add("background-color", "#eeeeee");
                row2.Cells[6].Style.Add("background-color", "#eeeeee");
            }
        }
    }

    protected void GridViewActionee_DataBound(object sender, EventArgs e)
    {
        int rowCount = GridViewActionee.Rows.Count;

        if (rowCount == 0)
        {
            GridViewActionee.Visible = false;
        }
        else
        {
            GridViewActionee.Visible = true;
        }
    }

    protected void GridViewActionee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("btnDelete");
            l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Actionee?')");

            Label info = e.Row.FindControl("lblInfo") as Label;
            Label action = e.Row.FindControl("lblAction") as Label;

            System.Web.UI.WebControls.Image imgInfo = e.Row.FindControl("imgInfo") as System.Web.UI.WebControls.Image;
            System.Web.UI.WebControls.Image imgAction = e.Row.FindControl("imgAction") as System.Web.UI.WebControls.Image;

            string lblinfo = info.Text;
            string lblaction = action.Text;

            if (lblinfo == "1")
            {
                imgInfo.Visible = true;
            }
            else
            {
                info.Visible = true;
                info.Text = "-";
            }

            if (lblaction == "1")
            {
                imgAction.Visible = true;
            }
            else
            {
                action.Visible = true;
                action.Text = "-";
            }

        }
    }

    protected void GridViewActionee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Delete the record.
            deleteActioneeRecordByID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewActionee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind addressee details.
        bindGridViewActionee();
    }

    protected void deleteActioneeRecordByID(string recID)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand("DELETE FROM EDMS_IN_ACTIONEE WHERE RecID = @pRecID", con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pRecID", recID);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void btnAddNewActionee_Click(object sender, EventArgs e)
    {
        //updateOut();

        //Check project setup.
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          PROJECT_SETUP ";
        queryString = queryString + " WHERE         PROJECT_CODE='" + Request.QueryString["ID1"] + "'";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daQ = new SqlDataAdapter(cmd);
        DataTable dtQ = new DataTable();
        daQ.Fill(dtQ);

        row = null;
        row = dtQ.Rows[0];

        //Actionee
        //Insert into database.
        queryString = "";
        queryString = queryString + " INSERT INTO   EDMS_IN_ACTIONEE ";
        queryString = queryString + "               (FLD_IN_SERIAL, COMPANY_CODE, FLD_IN_ACTIONEE, ACTION, INFO, REQUIRED_ACTION, ID) ";
        queryString = queryString + " VALUES        (@pFLD_IN_SERIAL, @pCOMPANY_CODE, @pFLD_IN_ACTIONEE, @pACTION, @pINFO, @pREQUIRED_ACTION, @pID) ";

        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pFLD_IN_SERIAL", lblTNoActionee.Text);
        cmd.Parameters.AddWithValue("@pCOMPANY_CODE", lblOriginatorCode.Text);

        //Actionee
        cmd.Parameters.AddWithValue("@pFLD_IN_ACTIONEE", fldActionee.Text);

        //Action? 
        cmd.Parameters.AddWithValue("@pACTION", chkAction.Checked);

        //Info?
        cmd.Parameters.AddWithValue("@pINFO", chkInfo.Checked);

        //Action Required
        cmd.Parameters.AddWithValue("@pREQUIRED_ACTION", fldActionReq.Text.ToUpper());

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();

        if (row["IN_EMAIL_NOTIFY"].ToString() == "1")
        {
            //---------------------------------------- send email -----------------------------------------
            //Display incoming details.
            queryString = "";
            queryString = queryString + " SELECT        EMAIL, FLD_REFERENCE, FLD_CORR_DATE, FLD_TITLE, FLD_COMPANY, FLD_AUTHOR, PROJECT_CODE, COMPANY_CODE, YR, TRACK_NO, REQUIRED_ACTION, ID, FLD_IN_ACTIONEE, ACTION_ID, INFO, ACTION ";
            queryString = queryString + " FROM          VW_EDMS_IN_DOCUMENT_ACTIONEE ";
            queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "'";
            queryString = queryString + " AND           FLD_IN_ACTIONEE = '" + fldActionee.Text + "'";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter daChck = new SqlDataAdapter(cmd);
            DataTable dtChck = new DataTable();
            daChck.Fill(dtChck);
            con.Close();

            row = null;
            row = dtChck.Rows[0];

            MailMessage mail = new MailMessage();

            mail.To.Add(row["EMAIL"].ToString());

            mail.Bcc.Add("aida.nazri@uemedgenta.uemnet.com");

            mail.From = new MailAddress("system@edms.str.opusbhd.com", "STR - EDMS Administrator");

            mail.Subject = "EDMS - Incoming Notify : [" + lblTNoActionee.Text + "]";

            //**********************************************************

            if (row["INFO"].ToString() == "1")
            {
                string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:ARIAL,8PT;>"
                + "<B><U>Reference No. :</U> </B>" + row["FLD_REFERENCE"].ToString() + "<BR><BR>"
                + "<B><U>Date of Document :</U> </B>" + Convert.ToDateTime(row["FLD_CORR_DATE"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                + "<B><U>Subject :</U> </B>" + row["FLD_TITLE"].ToString() + "<BR><BR>"
                + "<B><U>Company :</U> </B>" + row["FLD_COMPANY"].ToString() + "<BR><BR>"
                + "<B><U>Author :</U> </B>" + row["FLD_AUTHOR"].ToString() + "<BR><BR>"
                + "<B><U>Type :</U> </B>FOR YOUR INFO<BR><BR><BR>"

                + "The above have been entered into Electronic Document Management System (EDMS).<BR><BR>"

                + "Please click <A HREF=http://edms.str.opusbhd.com/document/" + row["PROJECT_CODE"].ToString() + "/" + row["COMPANY_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>here</A> to see the attachment.<BR><BR><BR>"

                + "<BR><BR>If you are having technical difficulties, please email us at <A HREF=it.helpdesk@uemedgenta.uemnet.com>it.helpdesk@uemedgenta.uemnet.com</A><BR><BR>"

                + "<BR><BR><BR>Thank you.<BR><BR>"
                + "This is a system-generated message. Please do not reply.</BODY></HTML>";

                mail.Body = htmlText;
                mail.IsBodyHtml = true;
            }

            if (row["ACTION"].ToString() == "1")
            {
                string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:ARIAL,8PT;>"
                + "<B><U>Reference No. :</U> </B>" + row["FLD_REFERENCE"].ToString() + "<BR><BR>"
                + "<B><U>Date of Document :</U> </B>" + Convert.ToDateTime(row["FLD_CORR_DATE"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                + "<B><U>Subject :</U> </B>" + row["FLD_TITLE"].ToString() + "<BR><BR>"
                + "<B><U>Company :</U> </B>" + row["FLD_COMPANY"].ToString() + "<BR><BR>"
                + "<B><U>Author :</U> </B>" + row["FLD_AUTHOR"].ToString() + "<BR><BR>"
                + "<B><U>Type :</U> </B>FOR YOUR ACTION<BR><BR>"
                + "<B><U>Action Required :</U> </B>" + row["REQUIRED_ACTION"].ToString().ToUpper() + "<BR><BR><BR>"

                + "The above have been entered into Electronic Document Management System (EDMS).<BR><BR>"

                + "Please click <A HREF=http://edms.str.opusbhd.com/SITE/Incoming/In_Action_Document.aspx?id1=" + row["ID"].ToString() + "&id2=" + row["FLD_IN_ACTIONEE"].ToString() + "&id=" + Request.QueryString["ID"] + "&id3=" + row["ACTION_ID"].ToString() + ">here</A> to access an EDMS and response to the action required.<BR><BR>"

                + "Please click <A HREF=http://edms.str.opusbhd.com/document/" + row["PROJECT_CODE"].ToString() + "/" + row["COMPANY_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>here</A> to see the attachment.<BR><BR><BR>"

                + "<BR><BR>If you are having technical difficulties, please email us at <A HREF=it.helpdesk@uemedgenta.uemnet.com>it.helpdesk@uemedgenta.uemnet.com</A><BR><BR>"

                + "<BR><BR><BR>Thank you.<BR><BR>"
                + "This is a system-generated message. Please do not reply.</BODY></HTML>";

                mail.Body = htmlText;
                mail.IsBodyHtml = true;
            }

            //**********************************************************

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.uemedgenta.uemnet.com";
            smtp.Port = 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Send(mail);

            //---------------------------------- end of send email ----------------------------------------
        }

        con.Close();

        fldActionee.Text = "";

        chkInfo.Checked = false;

        chkAction.Checked = false;

        fldActionReq.Text = "";

        //Bind attachment details.
        bindGridViewAttach();

        //Bind actionee details.
        bindGridViewActionee();
    }


    protected void btnCloseActionee_Click(object sender, EventArgs e)
    {
        fldActionee.Text = "";

        chkInfo.Text = "";

        chkAction.Text = "";

        fldActionReq.Text = "";
    }
    #endregion

    public DataSet GetData(string queryString)
    {
        //Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
        DataSet ds = new DataSet();

        try
        {
            //Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            //Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }
}