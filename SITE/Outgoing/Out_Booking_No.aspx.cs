using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SITE_Outgoing_Out_Booking_No : System.Web.UI.Page
{
    string queryString = "";
    string varFileName = "";
    string errStr = "";
    DataRow row = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindAddressee();
            bindPackage();
            bindDepartment();
            bindIndex();
        }
    }


    #region fldAddressee
    protected void bindAddressee()
    {
        string queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldAddressee.DataSource = GetData(queryString);
        fldAddressee.DataTextField = "FLD_COMPANY";
        fldAddressee.DataValueField = "FLD_COMPANY";
        fldAddressee.DataBind();
        fldAddressee.Items.Insert(0, new ListItem("Please select Addressee", ""));
    }

    protected void fldAddressee_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Display Addressee Code 
        string queryString = "";
        queryString = queryString + " SELECT        COMPANY_CODE ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         FLD_COMPANY = '" + fldAddressee.SelectedValue + "'";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.       
            lblAddresseeCode.Text = "";
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Addressee Code
            lblAddresseeCode.Text = row["COMPANY_CODE"].ToString();
        }
        con.Close();
    }
    #endregion

    #region fldPackage
    protected void bindPackage()
    {
        queryString = "";
        queryString = queryString + " SELECT        distinct FLD_PACKAGE ";
        queryString = queryString + " FROM          EDMS_PACKAGE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_PACKAGE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_PACKAGE ";

        fldPackage.DataSource = GetData(queryString);
        fldPackage.DataTextField = "FLD_PACKAGE";
        fldPackage.DataValueField = "FLD_PACKAGE";
        fldPackage.DataBind();
        fldPackage.Items.Insert(0, new ListItem("Please select Package", ""));
        fldPackage.Items.Insert(1, new ListItem("+ Add New Package +", "addNewPackage"));
    }

    protected void fldPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldPackage.SelectedIndex == 1)
            fldNewPackage.Visible = true;
        else
            fldNewPackage.Visible = false;
    }
    #endregion

    #region fldDept
    protected void bindDepartment()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_DEPARTMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_DEPARTMENT IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_DEPARTMENT ";

        fldDepartment.DataSource = GetData(queryString);
        fldDepartment.DataTextField = "FLD_DEPARTMENT";
        fldDepartment.DataValueField = "FLD_DEPARTMENT";
        fldDepartment.DataBind();
        fldDepartment.Items.Insert(0, new ListItem("-- Please select Department --", ""));
        fldDepartment.Items.Insert(1, new ListItem("+ Add New Department +", "addNewDepartment"));
    }

    protected void fldDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldDepartment.SelectedIndex == 1)
            fldNewDepartment.Visible = true;
        else
            fldNewDepartment.Visible = false;
    }
    #endregion

    #region fldIndex
    protected void bindIndex()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_INDEX ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_INDEX IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_INDEX ";

        fldIndex.DataSource = GetData(queryString);
        fldIndex.DataTextField = "FLD_INDEX";
        fldIndex.DataValueField = "FLD_INDEX";
        fldIndex.DataBind();
        fldIndex.Items.Insert(0, new ListItem("Please select File Index", ""));
        fldIndex.Items.Insert(1, new ListItem("+ Add New File Index +", "addNewIndex"));
    }

    protected void fldIndex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldIndex.SelectedIndex == 1)
            fldNewIndex.Visible = true;
        else
            fldNewIndex.Visible = false;
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string varSerialNo = "";
        string varTrackNo = "";
        int setSerialNo = 0;

        if (fldDateTaken.Value == "" && fldOriginator.Text == "" && fldAddressee.SelectedIndex == 0)
        {
        }
        else if (fldDateTaken.Value == "")
        {
        }
        else if (fldAddressee.SelectedIndex == 0)
        {
        }
        else if (fldOriginator.Text == "")
        {
        }
        else
        {

            //Check for latest Outgoing No.
            queryString = "";
            queryString = queryString + " SELECT        *  ";
            queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
            queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
            queryString = queryString + "               AND YEAR(FLD_BOOK_DATE) = " + DateTime.Now.Year.ToString();
            queryString = queryString + "               AND COMPANY_CODE = '" + lblAddresseeCode.Text + "' ";
            queryString = queryString + " ORDER BY      FLD_OUT_TRACK_NO DESC, FLD_BOOK_DATE DESC";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //Insert new record
            queryString = "";
            queryString = queryString + " INSERT INTO   EDMS_OUT_DOCUMENT ";
            queryString = queryString + "               (COMPANY_CODE, FLD_COMPANY, PROJECT_CODE, FLD_OUT_SERIAL, FLD_BOOK_BY, FLD_BOOK_DATE, FLD_OUT_TRACK_NO, ";
            queryString = queryString + "               FLD_REFERENCE, FLD_DOC_DATE, FLD_PACKAGE, FLD_DEPARTMENT, FLD_TITLE, FLD_ORIGINATOR, FLD_INDEX, FLD_REMARKS, FLD_SENT_TO, CreatedBy, CreatedDt) ";
            queryString = queryString + " VALUES        (@companycode, @company, @projectcode, @trackno, @bookby, @bookdt, @serialno, ";
            queryString = queryString + "               @refno, @docdt, @package, @dept, @subject, @originator, @index, @remarks, @sentto, @createdby, @createddt) ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            if (dt.Rows.Count == 0)
            {
                //Record not found.
                setSerialNo = 1;
            }
            else
            {
                //Max Serial No.
                row = null;
                row = dt.Rows[0];
                setSerialNo = Convert.ToInt32(row["FLD_OUT_TRACK_NO"].ToString()) + 1;
            }

            varTrackNo = Convert.ToString(setSerialNo);
            varTrackNo = varTrackNo.PadLeft(5, '0');
            varSerialNo = lblAddresseeCode.Text + "-" + varTrackNo + "-" + DateTime.Now.ToString("yy") + "-OUT";

            //Tracking No.
            cmd.Parameters.AddWithValue("@trackno", varSerialNo);
            cmd.Parameters.AddWithValue("@serialno", setSerialNo);

            //Project Code
            cmd.Parameters.AddWithValue("@projectcode", Request.QueryString["ID1"]);

            //Booked By
            cmd.Parameters.AddWithValue("@bookby", Request.QueryString["ID"]);

            //Date Taken / Draft
            cmd.Parameters.AddWithValue("@bookdt", fldDateTaken.Value);

            //Addressee                
            if (fldOriginator.Text != "")
                cmd.Parameters.AddWithValue("@company", fldAddressee.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@company", DBNull.Value);

            //Addressee Code
            cmd.Parameters.AddWithValue("@companycode", lblAddresseeCode.Text);

            //Out Reference No.
            cmd.Parameters.AddWithValue("@refno", fldRefNo.Text.Trim().ToUpper());

            //Originator
            cmd.Parameters.AddWithValue("@originator", fldOriginator.Text.Trim().ToUpper());

            //Date of Document
            if (fldDocDate.Value != "")
            {
                cmd.Parameters.AddWithValue("@docdt", Convert.ToDateTime(fldDocDate.Value));
            }
            else
            {
                cmd.Parameters.AddWithValue("@docdt", DBNull.Value);
            }

            //Package
            if (fldPackage.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@package", fldNewPackage.Text.Trim().ToUpper());

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
                    cmd.Parameters.AddWithValue("@package", fldPackage.SelectedValue);
                else
                    cmd.Parameters.AddWithValue("@package", DBNull.Value);
            }

            //Department
            if (fldDepartment.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@dept", fldNewDepartment.Text.Trim().ToUpper());

                SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_DEPARTMENT "
                  + "(FLD_DEPARTMENT, PROJECT_CODE) "
                  + "VALUES "
                  + "(@new_dept, '" + Request.QueryString["ID1"] + "')", con);

                command1.Parameters.AddWithValue("@new_dept", fldNewDepartment.Text.Trim().ToUpper());

                command1.ExecuteNonQuery();
            }
            else
            {
                if (fldDepartment.Text != "")
                    cmd.Parameters.AddWithValue("@dept", fldDepartment.SelectedValue);
                else
                    cmd.Parameters.AddWithValue("@dept", DBNull.Value);
            }

            //Subject
            cmd.Parameters.AddWithValue("@subject", fldSubject.Text.Trim().ToUpper());

            //File Index
            if (fldIndex.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("@index", fldNewIndex.Text.Trim().ToUpper());

                SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_INDEX "
                  + "(FLD_INDEX, PROJECT_CODE) "
                  + "VALUES "
                  + "(@new_index, '" + Request.QueryString["ID1"] + "')", con);

                command1.Parameters.AddWithValue("@new_index", fldNewIndex.Text.Trim().ToUpper());

                command1.ExecuteNonQuery();
            }
            else
            {
                if (fldIndex.Text != "")
                    cmd.Parameters.AddWithValue("@index", fldIndex.SelectedValue);
                else
                    cmd.Parameters.AddWithValue("@index", DBNull.Value);
            }

            //DC Remarks
            cmd.Parameters.AddWithValue("@remarks", fldRemarks.Text.Trim().ToUpper());

            //Sent To
            cmd.Parameters.AddWithValue("@sentto", fldSentTo.Text.Trim().ToUpper());

            cmd.Parameters.AddWithValue("@createdby", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@createddt", DateTime.Now);

            cmd.ExecuteNonQuery();

            con.Close();

            //Capture Id from database.
            queryString = "";
            queryString = queryString + " SELECT        ID  ";
            queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
            queryString = queryString + " WHERE         FLD_OUT_SERIAL = '" + varSerialNo + "' ";

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

            //Redirect to edit page.
            Response.Redirect("Out_Edit_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"] + "&ID2=" + row["ID"].ToString());
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Out_Booking_No.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }

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