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

public partial class SITE2_Incoming_In_Action_Document : System.Web.UI.Page
{
    String queryString = "";
    DataRow row = null;
    DataRow row1 = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DateTime varDt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!IsPostBack)
        {
            //Reset message and error.
            dvStatus.Visible = false;
            dvErrUpload.Visible = false;
            errDvfldActionDt.Visible = false;
            errDvfldAction.Visible = false;

            //Bind incoming details.
            bindGridViewDetails();

            //Bind attachment details.
            bindGridViewAttachment();

            //Bind actionee details.
            bindGridViewActionee();
        }
    }

    
    protected void bindGridViewAttachment()
    {
        queryString = "";
        queryString = queryString + " SELECT        EDMS_IN_ATTACH.*, ";
        queryString = queryString + "               EDMS_IN_DOCUMENT.PROJECT_CODE, EDMS_IN_DOCUMENT.ID  ";
        queryString = queryString + " FROM          EDMS_IN_ATTACH ";
        queryString = queryString + " INNER JOIN    EDMS_IN_DOCUMENT ON EDMS_IN_ATTACH.ID = EDMS_IN_DOCUMENT.ID ";
        queryString = queryString + " WHERE         EDMS_IN_ATTACH.ID = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " ORDER BY      EDMS_IN_ATTACH.FLD_ATCH_TITLE ";

        GridViewAttachment.DataSource = GetData(queryString);
        GridViewAttachment.DataBind();
    }

    protected void GridViewAttachment_DataBound(object sender, EventArgs e)
    {
        int rowCount = GridViewAttachment.Rows.Count;

        if (rowCount == 0)
        {
            GridViewAttachment.Visible = false;
        }
        else
        {
            GridViewAttachment.Visible = true;
        }
    }
    
    protected void bindGridViewActionee()
    {
        queryString = "";
        queryString = queryString + " SELECT        EDMS_IN_ACTIONEE.*, ";
        queryString = queryString + "               tblACTIONEE.StaffName As ACTIONEEName  ";
        queryString = queryString + " FROM          EDMS_IN_ACTIONEE ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblACTIONEE on tblACTIONEE.StaffNo = EDMS_IN_ACTIONEE.FLD_IN_ACTIONEE ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " AND           FLD_IN_ACTIONEE NOT IN ('" + Request.QueryString["ID2"] + "')";
        queryString = queryString + " ORDER BY      ACTION DESC ";

        GridViewActionee.DataSource = GetData(queryString);
        GridViewActionee.DataBind();
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
    
    protected void bindGridViewDetails()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          VW_EDMS_IN_DOCUMENT_ACTIONEE ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " AND           FLD_IN_ACTIONEE = '" + Request.QueryString["ID2"] + "' ";

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
            fldDateReceived.Text = "";
            fldRefNo.Text = "";
            fldDateDocument.Text = "";
            fldPackage.Text = "";
            fldSubject.Text = "";
            fldAuthor.Text = "";
            fldCompany.Text = "";
            
            fldDateRequired.Text = "";
            fldActionRequired.Text = "";
            fldActionee.Text = "";

            fldDateResponse.Text = "";
            fldActionTaken.Text = "";

            txtYr.Text = "";
            txtTrackNo.Text = "";
            txtCode.Text = "";
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Check if file exist.            
            var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf");


                if (file2.Exists)
                {
                    Label1.Visible = true;

                    Label1.Text = row["FLD_IN_SERIAL"].ToString();

                    img_all.Visible = true;
                    img_all.ImageUrl = "http://192.168.50.41/document/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf";
                }
                else
                {
                    dvErrUpload.Visible = true;

                    Label1.Visible = true;

                    Label1.Text = row["FLD_IN_SERIAL"].ToString();
                }
            //end of check if file exist.

            txtYr.Text = row["YR"].ToString();
            txtTrackNo.Text = row["TRACK_NO"].ToString();
            txtCode.Text = row["PROJECT_CODE"].ToString();

            //Date Received
            fldDateReceived.Text = Convert.ToDateTime(row["FLD_IN_DATE"].ToString()).ToString("dd-MMM-yyyy");

            //Reference No.
            fldRefNo.Text = row["FLD_REFERENCE"].ToString();

            //Date of Document
            object value = row["FLD_CORR_DATE"];
            if (value == DBNull.Value)
            { }
            else
            { fldDateDocument.Text = Convert.ToDateTime(row["FLD_CORR_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Package
            fldPackage.Text = row["FLD_PACKAGE"].ToString();

            //Subject
            fldSubject.Text = row["FLD_TITLE1"].ToString();

            //Author
            fldAuthor.Text = row["FLD_AUTHOR"].ToString();

            //Company
            fldCompany.Text = row["FLD_COMPANY"].ToString();
                         
            //Date Required
            object value1 = row["FLD_REQ_DATE"];
            if (value1 == DBNull.Value)
            { }
            else
            { fldDateRequired.Text = Convert.ToDateTime(row["FLD_REQ_DATE"].ToString()).ToString("dd-MMM-yyyy"); }
            
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

            //Action Required
            fldActionRequired.Text = row["REQUIRED_ACTION"].ToString();

            //Type
            fldType.Text = "For Your Action";

            //Action Taken Date
            object value2 = row["ACTION_TAKEN_DT"];
            if (value2 == DBNull.Value)
            { }
            else
            { fldDateResponse.Text = Convert.ToDateTime(row["ACTION_TAKEN_DT"].ToString()).ToString("dd-MMM-yyyy"); }

            //Action Taken
            fldActionTaken.Text = row["ACTION_TAKEN"].ToString();

            //Actionee
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          tblUserLogin ";
            queryString = queryString + " WHERE         StaffNo='" + row["FLD_IN_ACTIONEE"].ToString() + "'";
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

            fldActionee.Text = row["StaffName"].ToString();
        }

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

    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (fldDateResponse.Text == "" && fldActionTaken.Text == "")
        {
            errDvfldActionDt.Visible = true;
            errDvfldAction.Visible = true;
        }
        else if (fldDateResponse.Text == "")
        {
            errDvfldActionDt.Visible = true;
        }
        else if (fldActionTaken.Text == "")
        {
            errDvfldAction.Visible = true;
        }
        else
        {
            //Reset error.
            errDvfldActionDt.Visible = false;
            errDvfldAction.Visible = false;
            dvStatus.Visible = false;
            dvErrUpload.Visible = false;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

            con.Open();
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand("UPDATE EDMS_IN_ACTIONEE SET "
              + "ACTION_TAKEN_DT = @actiondt, "
              + "ACTION_TAKEN = @action "
              + "WHERE id = '" + Request.QueryString["ID1"] + "' AND FLD_IN_ACTIONEE = '" + Request.QueryString["ID2"] + "'", con);

            //Action Taken Date
            if (fldDateResponse.Text != "")
            {
                command.Parameters.AddWithValue("@actiondt", Convert.ToDateTime(fldDateResponse.Text));
            }
            else
            {
                command.Parameters.AddWithValue("@actiondt", DBNull.Value);
            }

            //Action Taken
            command.Parameters.AddWithValue("@action", fldActionTaken.Text.ToUpper());

            command.ExecuteNonQuery();

            //Display message and error.
            dvStatus.Visible = true;

            con.Close();
        }
    }

    
}

