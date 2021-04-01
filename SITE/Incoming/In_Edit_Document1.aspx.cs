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

public partial class Incoming_In_Edit_Document : System.Web.UI.Page
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

            rowRefNo.Visible = false;
            rowDateDocument.Visible = false;
            rowPackage.Visible = false;
            rowAuthor.Visible = false;
            rowCompany.Visible = false;
            rowRemarks.Visible = false;
            rowUrgency.Visible = false;
            rowDateRequired.Visible = false;
            rowDateResponse.Visible = false;
            rowOutTrackNo.Visible = false;
            rowActionTaken.Visible = false;
            rowAttachment.Visible = false;
            rowActionee.Visible = false;
            rowEmailActionee.Visible = false;
            rowOutTrackNoAV.Visible = false;

            //Reference No.
            if (row["IN_FLD_REFERENCE"].ToString() == "1")
            { rowRefNo.Visible = true; }

            //Date of Document
            if (row["IN_FLD_CORR_DATE"].ToString() == "1")
            { rowDateDocument.Visible = true; }

            //Package
            if (row["IN_FLD_PACKAGE"].ToString() == "1")
            { rowPackage.Visible = true; }

            //Author
            if (row["IN_FLD_AUTHOR"].ToString() == "1")
            { rowAuthor.Visible = true; }

            //Company
            if (row["IN_FLD_COMPANY"].ToString() == "1")
            { rowCompany.Visible = true; }

            //DC Remarks
            if (row["IN_REMARKS"].ToString() == "1")
            { rowRemarks.Visible = true; }

            //Urgency
            if (row["IN_FLD_URGENCY"].ToString() == "1")
            { rowUrgency.Visible = true; }
            	
            //Date Required
            if (row["IN_FLD_REQ_DATE"].ToString() == "1")
            { rowDateRequired.Visible = true; }

            //Response Date
            if (row["IN_FLD_ACTION_DATE"].ToString() == "1")
            { rowDateResponse.Visible = true; }
            	
            //Out Reference No.
            if (row["IN_FLD_OUT_TRACK_NO"].ToString() == "1")
            {
                if (Request.QueryString["ID1"] == "AV")
                {
                    rowOutTrackNoAV.Visible = true;
                }
                else
                {
                    rowOutTrackNo.Visible = true;
                }
            }        
            	
            //Action Taken
            if (row["IN_FLD_ACTION_TAKEN"].ToString() == "1")
            { rowActionTaken.Visible = true; }
            	
            //Attachment
            if (row["IN_ATTACHMENT"].ToString() == "1")
            { rowAttachment.Visible = true; }

            //Actionee
            if (row["IN_ACTIONEE"].ToString() == "1")
            { rowActionee.Visible = true; }

            //Actionee - Email Notification
            if (row["IN_EMAIL_NOTIFY"].ToString() == "1")
            { rowEmailActionee.Visible = true; }

            //Transmittal Form
            if (row["IN_TRANSMITTAL"].ToString() == "1")
            { 
                btnTransmittal.Visible = true;
            }
            
        con.Close();

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
            lbtnAdd.Visible = true;
            lbtnAddActionee.Visible = true;
            GridViewAttachment.Columns[3].Visible = true;
            GridViewActionee.Columns[3].Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            if (row1["PROJECT_CODE"].ToString() == "AV" || row1["PROJECT_CODE"].ToString() == "CYB")
                { btnDeleteScanDoc.Visible = false; }
            else
                { btnDeleteScanDoc.Visible = true; }            
        }
        else
        {
            lbtnAdd.Visible = false;
            lbtnAddActionee.Visible = false;
            GridViewAttachment.Columns[3].Visible = false;
            GridViewActionee.Columns[3].Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnDeleteScanDoc.Visible = false;
            btnHigh.Enabled = false;
            btnMedium.Enabled = false;
            btnLow.Enabled = false;
            btnInfo.Enabled = false;
        }

        con.Close();

        if (!IsPostBack)
        {
            //Reset message and error.
            dvStatus.Visible = false;
            dvErrUpload.Visible = false;

            //Hide message and error.
            fldNewPackage.Visible = false;
            fldNewType.Visible = false;
            fldNewAuthor.Visible = false;
            fldNewCompany.Visible = false;

            //Bind dropdown Package. 
            bindPackage();

            //Bind dropdown Type of Document. 
            bindType();

            //Bind dropdown Company. 
            bindCompany();

            //Bind dropdown Author. 
            bindAuthor();
                        
            //Bind dropdown Out Reference No. 
            bindOutRefNo();

            //Bind incoming details.
            bindGridViewDetails();

            //Bind attachment details.
            bindGridViewAttachment();

            //Bind actionee details.
            bindGridViewActionee();

            //Bind dropdown Actionee. 
            bindActionee();
        }
    }

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
    
    protected void bindCompany()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldCompany.DataSource = GetData(queryString);
        fldCompany.DataTextField = "FLD_COMPANY";
        fldCompany.DataValueField = "FLD_COMPANY";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please select Company --", ""));
        fldCompany.Items.Insert(1, new System.Web.UI.WebControls.ListItem("+ Add New Company +", "addNewCompany"));
    }

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

    
    protected void bindOutRefNo()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " ORDER BY      FLD_OUT_SERIAL ";

        fldOutTrackNo.DataSource = GetData(queryString);
        fldOutTrackNo.DataTextField = "FLD_OUT_SERIAL";
        fldOutTrackNo.DataValueField = "FLD_OUT_SERIAL";
        fldOutTrackNo.DataBind();
        fldOutTrackNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please select Outgoing Tracking No. --", ""));
    }
    
    protected void bindActionee()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          TBLUSERLOGIN ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " ORDER BY      STAFFNAME ";
        
        fldActionee.DataSource = GetData(queryString);
        fldActionee.DataTextField = "STAFFNAME";
        fldActionee.DataValueField = "STAFFNO";
        fldActionee.DataBind();
        fldActionee.Items.Insert(0, new ListItem("-- Please select Actionee --", ""));
    }

    
    protected void bindGridViewAttachment()
    {
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_IN_ATTACH ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        queryString = queryString + " ORDER BY      FLD_ATCH_TITLE ";

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

    protected void GridViewAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("btnDelete");
            l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Attachment?')");
        }
    }

    protected void GridViewAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Delete the record.
            deleteRecordByID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind addressee details.
        bindGridViewAttachment();
    }

    protected void deleteRecordByID(string recID)
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
            deleteRecordByActioneeID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewActionee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind addressee details.
        bindGridViewActionee();
    }

    protected void deleteRecordByActioneeID(string recID)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand("DELETE FROM EDMS_IN_ACTIONEE WHERE RecID = @pRecID", con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pRecID", recID);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //Attachment
        HttpFileCollection hfc = Request.Files;
        string Msg = null;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["ID1"] + "/incoming/attachment/" + Request.QueryString["ID2"] + "";

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
        queryString = queryString + "               (FILENAME, FLD_IN_SERIAL, FLD_ATCH_TITLE, FLD_ATCH_COPY, ID) ";
        queryString = queryString + " VALUES        (@pFILENAME, @pFLD_IN_SERIAL, @pFLD_ATCH_TITLE, @pFLD_ATCH_COPY, @pID) ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pFLD_IN_SERIAL", lblTNo.Text);

        //File Name
        cmd.Parameters.AddWithValue("@pFILENAME", FileUpload1.FileName);

        //Title
        cmd.Parameters.AddWithValue("@pFLD_ATCH_TITLE", fldAttachTitle.Text);
        
        //Copy
        cmd.Parameters.AddWithValue("@pFLD_ATCH_COPY", fldAttachCopy.Text);
        
        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();
        con.Close();

        fldAttachTitle.Text = "";

        fldAttachCopy.Text = "";

        //Bind attachment details.
        bindGridViewAttachment();

        //Bind actionee details.
        bindGridViewActionee();
    }
    
    protected void btnSaveAddNew_Click(object sender, EventArgs e)
    {
        //Attachment
        HttpFileCollection hfc = Request.Files;
        string Msg = null;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["ID1"] + "/incoming/attachment";

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

        //Insert into database.
        queryString = "";
        queryString = queryString + " INSERT INTO   EDMS_IN_ATTACH ";
        queryString = queryString + "               (FILENAME, FLD_IN_SERIAL, FLD_ATCH_TITLE, FLD_ATCH_COPY, ID) ";
        queryString = queryString + " VALUES        (@pFILENAME, @pFLD_IN_SERIAL, @pFLD_ATCH_TITLE, @pFLD_ATCH_COPY, @pID) ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pFLD_IN_SERIAL", lblTNo.Text);

        //File Name
        cmd.Parameters.AddWithValue("@pFILENAME", FileUpload1.FileName);

        //Title
        cmd.Parameters.AddWithValue("@pFLD_ATCH_TITLE", fldAttachTitle.Text);

        //Copy
        cmd.Parameters.AddWithValue("@pFLD_ATCH_COPY", fldAttachCopy.Text);

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();
        con.Close();

        fldAttachTitle.Text = "";

        fldAttachCopy.Text = "";
    }
    
    protected void btnAddNew1_Click(object sender, EventArgs e)
    {
        updateOut();
        
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
        queryString = queryString + "               (FLD_IN_SERIAL, FLD_IN_ACTIONEE, ACTION, INFO, REQUIRED_ACTION, ID) ";
        queryString = queryString + " VALUES        (@pFLD_IN_SERIAL, @pFLD_IN_ACTIONEE, @pACTION, @pINFO, @pREQUIRED_ACTION, @pID) ";
        
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pFLD_IN_SERIAL", lblTNo1.Text);
                
        //Actionee
        cmd.Parameters.AddWithValue("@pFLD_IN_ACTIONEE", fldActionee.Text);

        //Action? 
        cmd.Parameters.AddWithValue("@pACTION", chkAction.Checked);

        //Info?
        cmd.Parameters.AddWithValue("@pINFO", chkInfo.Checked);

        //Action Required
        cmd.Parameters.AddWithValue("@pREQUIRED_ACTION", fldActionReq.Text);

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();

        if (row["IN_EMAIL_NOTIFY"].ToString() == "1")
        {
            //---------------------------------------- send email -----------------------------------------
            //Display incoming details.
            queryString = "";
            queryString = queryString + " SELECT        * ";
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

            mail.Bcc.Add("edmsadmin@sabahpanborneo.com");

            mail.From = new MailAddress("edmsadmin@sabahpanborneo.com", "BHP - EDMS Administrator");
            
            mail.Subject = "EDMS - Incoming Notify : [" + lblTNo1.Text + "]";

            //**********************************************************

            if (row["INFO"].ToString() == "1")
            {
                string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:ARIAL,8PT;>"
                + "<B><U>Reference No. :</U> </B>" + row["FLD_REFERENCE"].ToString() + "<BR><BR>"
                + "<B><U>Date of Document :</U> </B>" + Convert.ToDateTime(row["FLD_CORR_DATE"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                + "<B><U>Subject :</U> </B>" + row["FLD_TITLE1"].ToString() + "<BR><BR>"
                + "<B><U>Company :</U> </B>" + row["FLD_COMPANY"].ToString() + "<BR><BR>"
                + "<B><U>Author :</U> </B>" + row["FLD_AUTHOR"].ToString() + "<BR><BR>"
                + "<B><U>Type :</U> </B>FOR YOUR INFO<BR><BR><BR>"

                + "The above have been entered into Electronic Document Management System (EDMS).<BR><BR>"

                + "Please click <A HREF=http://192.168.50.41/document/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>here</A> to see the attachment.<BR><BR><BR>"

                + "<BR><BR>If you are having technical difficulties, please email us at <A HREF=pbsedms@opusbhd.uemnet.com>pbsedms@opusbhd.uemnet.com</A><BR><BR>"

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
                + "<B><U>Subject :</U> </B>" + row["FLD_TITLE1"].ToString() + "<BR><BR>"
                + "<B><U>Company :</U> </B>" + row["FLD_COMPANY"].ToString() + "<BR><BR>"
                + "<B><U>Author :</U> </B>" + row["FLD_AUTHOR"].ToString() + "<BR><BR>"
                + "<B><U>Type :</U> </B>FOR YOUR ACTION<BR><BR>"
                + "<B><U>Action Required :</U> </B>" + row["REQUIRED_ACTION"].ToString().ToUpper() + "<BR><BR><BR>"

                + "The above have been entered into Electronic Document Management System (EDMS).<BR><BR>"

                + "Please click <A HREF=http://192.168.50.41/SITE/Incoming/In_Action_Document.aspx?id1=" + row["ID"].ToString() + "&id2=" + row["FLD_IN_ACTIONEE"].ToString() + "&id=" + Request.QueryString["ID"] + "&id3=" + row["ACTION_ID"].ToString() + ">here</A> to access an EDMS and response to the action required.<BR><BR>"

                + "Please click <A HREF=http://192.168.50.41/document/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>here</A> to see the attachment.<BR><BR><BR>"

                + "<BR><BR>If you are having technical difficulties, please email us at <A HREF=pbsedms@opusbhd.uemnet.com>pbsedms@opusbhd.uemnet.com</A><BR><BR>"

                + "<BR><BR><BR>Thank you.<BR><BR>"
                + "This is a system-generated message. Please do not reply.</BODY></HTML>";

                mail.Body = htmlText;
                mail.IsBodyHtml = true;
            }

            //**********************************************************

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "relay.uemedgenta.com";
	    //smtp.Host = "127.0.0.1";
            smtp.Port = 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("q43VD8L2dM@sabahpanborneo.local", "j6%Gk77%aM");
            smtp.Credentials = new System.Net.NetworkCredential("q43VD8L2dM@uemedgenta.com", "j6%Gk77%aM");
                       
            //smtp.EnableSsl = true;
            smtp.EnableSsl = false;
            smtp.Send(mail);
            
            //---------------------------------- end of send email ----------------------------------------
        }

        con.Close();

        fldActionee.Text = "";

        chkInfo.Checked = false;

        chkAction.Checked = false;

        fldActionReq.Text = "";

        //Bind attachment details.
        bindGridViewAttachment();

        //Bind actionee details.
        bindGridViewActionee();
    }

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
            fldDateReceived.Text = "";
            fldRefNo.Text = "";
            fldDateDocument.Text = "";
            fldPackage.Text = "";
            fldType.Text = "";
            fldSubject.Text = "";
            fldAuthor.Text = "";
            fldCompany.Text = "";
            fldRemarks.Text = "";

            fldDateRequired.Text = "";
            fldUrgent.Text = "";
            
            fldDateResponse.Text = "";
            fldOutTrackNo.Text = "";
            fldOutRefNo.Text = "";
            fldOutRefNoAV.Text = "";
            fldOutSubject.Text = "";
            fldActionTaken.Text = "";
            
            txtYr.Text = "";
            txtTrackNo.Text = "";
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Check if file exist.

                var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf");
            
                if (file2.Exists)
                {
                    //Confidential
                    if (row["CONFIDENTIAL"].ToString() == "1")
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
                            Label1.Visible = true;

                            Label1.Text = row["FLD_IN_SERIAL"].ToString();

                            img_all.Visible = true;
                        }
                        else
                        {
                            Label1.Visible = true;

                            Label1.Text = row["FLD_IN_SERIAL"].ToString();
                        }
                    }
                    else
                    {
                        Label1.Visible = true;

                        Label1.Text = row["FLD_IN_SERIAL"].ToString();

                        img_all.Visible = true;
                    }
                    
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

            //Tracking No.
            lblTNo.Text = row["FLD_IN_SERIAL"].ToString();
            lblTNo1.Text = row["FLD_IN_SERIAL"].ToString();

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

            //Type of Document
            fldType.Text = row["FLD_TYPE"].ToString();

            //Subject
            fldSubject.Text = row["FLD_TITLE1"].ToString();

            //Author
            fldAuthor.Text = row["FLD_AUTHOR"].ToString();

            //Company
            fldCompany.Text = row["FLD_COMPANY"].ToString();
                        
            //DC Remarks
            fldRemarks.Text = row["REMARKS"].ToString();

            //Confidential
            if (row["CONFIDENTIAL"].ToString() == "1")
            {
                chkConfidential.Checked = true;
            }

            //Date Required
            object value1 = row["FLD_REQ_DATE"];
            if (value1 == DBNull.Value)
            { }
            else
            { fldDateRequired.Text = Convert.ToDateTime(row["FLD_REQ_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Urgency
            fldUrgent.Text = row["FLD_URGENCY"].ToString();

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

            //Response Date
            object value2 = row["FLD_ACTION_DATE"];
            if (value2 == DBNull.Value)
            { }
            else
            { fldDateResponse.Text = Convert.ToDateTime(row["FLD_ACTION_DATE"].ToString()).ToString("dd-MMM-yyyy"); }

            //Out Reference No.
            fldOutTrackNo.Text = row["FLD_OUT_TRACK_NO"].ToString();

            //Out Reference No. (AV)
            fldOutRefNoAV.Text = row["FLD_OUT_REFERENCE"].ToString();

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
                fldOutSubject.Text = row2["FLD_TITLE1"].ToString();
            }
            con.Close();

            //Action Taken
            fldActionTaken.Text = row["FLD_ACTION_TAKEN"].ToString();

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

    protected void fldPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldPackage.SelectedIndex == 1)
            fldNewPackage.Visible = true;
        else
            fldNewPackage.Visible = false;
    }

    protected void fldType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldType.SelectedIndex == 1)
            fldNewType.Visible = true;
        else
            fldNewType.Visible = false;
    }

    protected void fldAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldAuthor.SelectedIndex == 1)
            fldNewAuthor.Visible = true;
        else
            fldNewAuthor.Visible = false;
    }

    protected void fldCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldCompany.SelectedIndex == 1)
            fldNewCompany.Visible = true;
        else
            fldNewCompany.Visible = false;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
        
        con.Open();

        SqlCommand command = new SqlCommand("DELETE FROM EDMS_IN_ACTIONEE WHERE ID = '" + Request.QueryString["ID2"] + "'", con);
        command.ExecuteNonQuery();

        SqlCommand command1 = new SqlCommand("DELETE FROM EDMS_IN_ATTACH WHERE ID = '" + Request.QueryString["ID2"] + "'", con);
        command1.ExecuteNonQuery();

        SqlCommand command2 = new SqlCommand("DELETE FROM EDMS_IN_DOCUMENT WHERE ID = '" + Request.QueryString["ID2"] + "'", con);
        command2.ExecuteNonQuery();

        con.Close();

        Response.Redirect("In_View_Document.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }

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

    protected void btnHigh_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Parse(fldDateReceived.Text);
        fldDateRequired.Text = today.AddDays(3).ToString("dd-MMM-yyyy");
        fldUrgent.Text = "1";
        btnHigh.Font.Bold = true;
        btnHigh.Font.Underline = true;
    }

    protected void btnMedium_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Parse(fldDateReceived.Text);
        fldDateRequired.Text = today.AddDays(7).ToString("dd-MMM-yyyy");
        fldUrgent.Text = "2";
        btnMedium.Font.Bold = true;
        btnMedium.Font.Underline = true;
    }

    protected void btnLow_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Parse(fldDateReceived.Text);
        fldDateRequired.Text = today.AddDays(14).ToString("dd-MMM-yyyy");
        fldUrgent.Text = "3";
        btnLow.Font.Bold = true;
        btnLow.Font.Underline = true;
    }

    protected void btnInfo_Click(object sender, EventArgs e)
    {
        fldDateRequired.Text = "";
        fldUrgent.Text = "4";
        btnInfo.Font.Bold = true;
        btnInfo.Font.Underline = true;
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
            fldOutSubject.Text = row1["FLD_TITLE1"].ToString();
        }
        con.Close();
    }
    
    protected void updateOut()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

        con.Open();
        DateTime now = DateTime.Now;
        SqlCommand command = new SqlCommand("UPDATE EDMS_IN_DOCUMENT SET "
          + "FLD_IN_DATE = @rcvddt, "
          + "FLD_PACKAGE = @package, "
          + "FLD_TYPE = @typedoc, "
          + "FLD_CORR_DATE = @docdt, "
          + "FLD_REFERENCE = @refno, "
          + "FLD_COMPANY = @company, "
          + "FLD_AUTHOR = @author, "
          + "FLD_TITLE1 = @subject, "
          + "REMARKS = @remarks, "
          + "CONFIDENTIAL = @confidential, "
          + "FLD_REQ_DATE = @reqdt, "
          + "FLD_URGENCY = @urgency, "
          + "FLD_ACTION_DATE = @actiondt, "
          + "FLD_OUT_TRACK_NO = @outtrackno, "
          + "FLD_OUT_REFERENCE = @outref, "
          + "FLD_ACTION_TAKEN = @action, "
          + "UpdatedBy = '" + Request.QueryString["ID"] + "', "
          + "UpdatedDt = '" + now.ToString("yyyy-MM-dd hh:mm:ss.000") + "' "
          + "WHERE id = '" + Request.QueryString["ID2"] + "'", con);

        //Date Received
        if (fldDateReceived.Text != "")
        {
            command.Parameters.AddWithValue("@rcvddt", Convert.ToDateTime(fldDateReceived.Text));
        }
        else
        {
            command.Parameters.AddWithValue("@rcvddt", DBNull.Value);
        }

        //Reference No.
        command.Parameters.AddWithValue("@refno", fldRefNo.Text);

        //Date of Document
        if (fldDateDocument.Text != "")
        {
            command.Parameters.AddWithValue("@docdt", Convert.ToDateTime(fldDateDocument.Text));
        }
        else
        {
            command.Parameters.AddWithValue("@docdt", DBNull.Value);
        }

        //Package
        if (fldPackage.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@package", fldNewPackage.Text);

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_PACKAGE "
              + "(FLD_PACKAGE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_package, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_package", fldNewPackage.Text);

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
            command.Parameters.AddWithValue("@typedoc", fldNewType.Text);

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_TYPE "
              + "(FLD_TYPE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_type, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_type", fldNewType.Text);

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
        command.Parameters.AddWithValue("@subject", fldSubject.Text);

        //Author
        if (fldAuthor.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@author", fldNewAuthor.Text);

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_AUTHOR "
              + "(FLD_AUTHOR, PROJECT_CODE) "
              + "VALUES "
              + "(@new_author, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_author", fldNewAuthor.Text);

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldAuthor.Text != "")
                command.Parameters.AddWithValue("@author", fldAuthor.SelectedValue);
            else
                command.Parameters.AddWithValue("@author", DBNull.Value);
        }

        //Company
        if (fldCompany.SelectedIndex == 1)
        {
            command.Parameters.AddWithValue("@company", fldNewCompany.Text);

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_COMPANY "
              + "(FLD_COMPANY, PROJECT_CODE) "
              + "VALUES "
              + "(@new_company, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_company", fldNewCompany.Text);

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldCompany.Text != "")
                command.Parameters.AddWithValue("@company", fldCompany.SelectedValue);
            else
                command.Parameters.AddWithValue("@company", DBNull.Value);
        }

        
        //DC Remarks        
        command.Parameters.AddWithValue("@remarks", fldRemarks.Text);

        //Confidential?
        if (chkConfidential.Checked)
        { pnc_check = "1"; }
        else
        { pnc_check = "0"; }

        command.Parameters.AddWithValue("@confidential", pnc_check);

        //Urgency
        command.Parameters.AddWithValue("@urgency", fldUrgent.Text);

        //Date Required
        if (fldDateRequired.Text != "")
        {
            command.Parameters.AddWithValue("@reqdt", Convert.ToDateTime(fldDateRequired.Text));
        }
        else
        {
            command.Parameters.AddWithValue("@reqdt", DBNull.Value);
        }

        //Response Date
        if (fldDateResponse.Text != "")
        {
            command.Parameters.AddWithValue("@actiondt", Convert.ToDateTime(fldDateResponse.Text));
        }
        else
        {
            command.Parameters.AddWithValue("@actiondt", DBNull.Value);
        }

        //Out Reference No.
        command.Parameters.AddWithValue("@outtrackno", fldOutTrackNo.Text);

        //Out Reference No. (AV)
        command.Parameters.AddWithValue("@outref", fldOutRefNoAV.Text);

        //Action Taken
        command.Parameters.AddWithValue("@action", fldActionTaken.Text);

        command.ExecuteNonQuery();

        con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Display message and error.
        dvStatus.Visible = false;
        dvErrUpload.Visible = false;

        updateOut();

        //Display message and error.
        dvStatus.Visible = true;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        fldAttachTitle.Text = "";

        fldAttachCopy.Text = "";
    }

    protected void btnClose1_Click(object sender, EventArgs e)
    {
        fldActionee.Text = "";

        chkInfo.Text = "";

        chkAction.Text = "";

        fldActionReq.Text = "";
    }

    protected void btnTransmittal_Click(object sender, EventArgs e)
    {
        Response.Redirect("Transmittal_Form.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"] + "&ID2=" + Request.QueryString["id2"]);
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["url"] == "IVD")
        {
            if (hidYear.Value != "")
                Response.Redirect("In_View_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"] + "&Year=" + hidYear.Value);
            else
                Response.Redirect("In_View_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]);
        }
        else if (Request.QueryString["url"] == "ISD")
        {
            Response.Redirect("In_Search_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]);
        }
        else if (Request.QueryString["url"] == "IRD")
        {
            Response.Redirect("In_Report.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]);
        }
        else
        {
            Response.Redirect("In_View_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]);
        }
    }
}

