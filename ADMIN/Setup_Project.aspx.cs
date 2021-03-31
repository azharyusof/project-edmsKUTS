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
using System.Text;

public partial class ADMIN_Setup_Project : System.Web.UI.Page
{
    String queryString = ""; 
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DateTime varDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (Request.QueryString["mode"] == "out")
        {
            tblIncoming.Visible = false;
            tblInNote.Visible = false;
            tblOutgoing.Visible = true;
            tblOutNote.Visible = true;
        }

        if (Request.QueryString["mode"] == null)
        {
            tblIncoming.Visible = true;
            tblInNote.Visible = true;
            tblOutgoing.Visible = false;
            tblOutNote.Visible = false;
        }
        
        if (!IsPostBack)
        {            
            queryString = "";
            queryString = queryString + " SELECT        *  ";
            queryString = queryString + " FROM          PROJECT ";
            queryString = queryString + " WHERE         PROJECTID = '" + Request.QueryString["ID1"] + "' ";

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
                // Check for no record found. 
                lblPCode.Text = "";
                lblPDesc.Text = "";
                lblPMgr.Text = "";
                lblTemplate.Text = "";
                txtCode.Text = "";
            }
            else
            {
                DataRow row = dt.Rows[0];

                lblPCode.Text = row["PROJECT_CODE"].ToString();
                lblPDesc.Text = row["DESCRIPTION"].ToString();
                lblPMgr.Text = row["PROJECT_MANAGER"].ToString();
                lblTemplate.Text = row["TEMPLATE"].ToString();
                txtCode.Text = row["PROJECT_CODE"].ToString();
            }

            queryString = "";
            queryString = queryString + " SELECT        *  ";
            queryString = queryString + " FROM          PROJECT_SETUP ";
            queryString = queryString + " WHERE         PROJECT_CODE = '" + txtCode.Text + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count == 0)
            {
                // Check for no record found.   
                // Incoming
                chkInRefNo.Checked = false;
                chkInDateDocument.Checked = false;
                chkInPackage.Checked = false;
                chkInAuthor.Checked = false;
                chkInCompany.Checked = false;                
                chkInRemarks.Checked = false;
                chkInAttach.Checked = false;
                chkInUrgency.Checked = false;
                chkInStatus.Checked = false;
                chkInDateReq.Checked = false;
                chkInActionee.Checked = false;
                chkInEmail.Checked = false;
                chkInResponDate.Checked = false;
                chkInOutRefNo.Checked = false;
                chkInActionTaken.Checked = false;
                chkInTransmittal.Checked = false;

                // Outgoing
                chkOutRefNo.Checked = false;
                chkOutDateDocument.Checked = false;
                chkOutPackage.Checked = false;
                chkOutTitle.Checked = false;                
                chkOutRemarks.Checked = false;                
                chkAddressee.Checked = false;
                chkOutAttach.Checked = false;
            }
            else
            {
                DataRow row = dt1.Rows[0];

                // Incoming
                if (row["IN_FLD_REFERENCE"].ToString() == "1")
                { chkInRefNo.Checked = true; }

                if (row["IN_FLD_CORR_DATE"].ToString() == "1")
                { chkInDateDocument.Checked = true; }

                if (row["IN_FLD_PACKAGE"].ToString() == "1")
                { chkInPackage.Checked = true; }

                if (row["IN_FLD_AUTHOR"].ToString() == "1")
                { chkInAuthor.Checked = true; }

                if (row["IN_FLD_COMPANY"].ToString() == "1")
                { chkInCompany.Checked = true; }
                
                if (row["IN_REMARKS"].ToString() == "1")
                { chkInRemarks.Checked = true; }

                if (row["IN_ATTACHMENT"].ToString() == "1")
                { chkInAttach.Checked = true; }

                if (row["IN_FLD_URGENCY"].ToString() == "1")
                { chkInUrgency.Checked = true; }

                if (row["IN_STATUS"].ToString() == "1")
                { chkInStatus.Checked = true; }

                if (row["IN_FLD_REQ_DATE"].ToString() == "1")
                { chkInDateReq.Checked = true; }

                if (row["IN_ACTIONEE"].ToString() == "1")
                { chkInActionee.Checked = true; }

                if (row["IN_EMAIL_NOTIFY"].ToString() == "1")
                { chkInEmail.Checked = true; }

                if (row["IN_FLD_ACTION_DATE"].ToString() == "1")
                { chkInResponDate.Checked = true; }

                if (row["IN_FLD_OUT_TRACK_NO"].ToString() == "1")
                { chkInOutRefNo.Checked = true; }

                if (row["IN_FLD_ACTION_TAKEN"].ToString() == "1")
                { chkInActionTaken.Checked = true; }

                if (row["IN_TRANSMITTAL"].ToString() == "1")
                { chkInTransmittal.Checked = true; }

                // Outgoing
                if (row["OUT_FLD_REFERENCE"].ToString() == "1")
                { chkOutRefNo.Checked = true; }

                if (row["OUT_FLD_DOC_DATE"].ToString() == "1")
                { chkOutDateDocument.Checked = true; }

                if (row["OUT_FLD_PACKAGE"].ToString() == "1")
                { chkOutPackage.Checked = true; }

                if (row["OUT_FLD_TITLE1"].ToString() == "1")
                { chkOutTitle.Checked = true; }

                if (row["OUT_FLD_REMARKS"].ToString() == "1")
                { chkOutRemarks.Checked = true; }
                
                if (row["OUT_ADDRESSEE"].ToString() == "1")
                { chkAddressee.Checked = true; }

                if (row["OUT_ATTACHMENT"].ToString() == "1")
                { chkOutAttach.Checked = true; }
            }
        }
    }
        
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);

        con.Open();  
        
        SqlCommand command = new SqlCommand("UPDATE PROJECT_SETUP SET "
          + "IN_FLD_REFERENCE = @in_refno, "
          + "IN_FLD_CORR_DATE = @in_dtdoc, "
          + "IN_FLD_PACKAGE = @in_pkg, "
          + "IN_FLD_AUTHOR = @in_author, "
          + "IN_FLD_COMPANY = @in_company, "
          + "IN_REMARKS = @in_remarks, "
          + "IN_ATTACHMENT = @in_attach, "
          + "IN_FLD_URGENCY = @in_urgency, "
          + "IN_STATUS = @in_status, "
          + "IN_FLD_REQ_DATE = @in_dtreq, "
          + "IN_ACTIONEE = @in_actionee, "
          + "IN_EMAIL_NOTIFY = @in_email, "
          + "IN_FLD_ACTION_DATE = @in_resdt, "
          + "IN_FLD_OUT_TRACK_NO = @in_outrefno, "
          + "IN_FLD_ACTION_TAKEN = @in_action, "
          + "IN_TRANSMITTAL = @in_transmittal, "
          + "OUT_FLD_REFERENCE = @out_refno, "
          + "OUT_FLD_DOC_DATE = @out_dtdoc, "
          + "OUT_FLD_PACKAGE = @out_pkg, "
          + "OUT_FLD_TITLE1 = @out_title, "
          + "OUT_FLD_REMARKS = @out_remarks, "
          + "OUT_ADDRESSEE = @out_addressee, "
          + "OUT_ATTACHMENT = @out_attach "
          + "WHERE PROJECT_CODE = @id", con);

        command.Parameters.AddWithValue("@in_refno", chkInRefNo.Checked);
        command.Parameters.AddWithValue("@in_dtdoc", chkInDateDocument.Checked);
        command.Parameters.AddWithValue("@in_pkg", chkInPackage.Checked);
        command.Parameters.AddWithValue("@in_author", chkInAuthor.Checked);
        command.Parameters.AddWithValue("@in_company", chkInCompany.Checked);
       
        command.Parameters.AddWithValue("@in_remarks", chkInRemarks.Checked);
        command.Parameters.AddWithValue("@in_attach", chkInAttach.Checked);

        command.Parameters.AddWithValue("@in_urgency", chkInUrgency.Checked);
        command.Parameters.AddWithValue("@in_status", chkInStatus.Checked);
        command.Parameters.AddWithValue("@in_dtreq", chkInDateReq.Checked);
        
        command.Parameters.AddWithValue("@in_actionee", chkInActionee.Checked);
        command.Parameters.AddWithValue("@in_email", chkInEmail.Checked);

        command.Parameters.AddWithValue("@in_resdt", chkInResponDate.Checked);
        command.Parameters.AddWithValue("@in_outrefno", chkInOutRefNo.Checked);
        command.Parameters.AddWithValue("@in_action", chkInActionTaken.Checked);
        command.Parameters.AddWithValue("@in_transmittal", chkInTransmittal.Checked);

        command.Parameters.AddWithValue("@out_refno", chkOutRefNo.Checked);
        command.Parameters.AddWithValue("@out_dtdoc", chkOutDateDocument.Checked);
        command.Parameters.AddWithValue("@out_pkg", chkOutPackage.Checked);
        command.Parameters.AddWithValue("@out_title", chkOutTitle.Checked);
        command.Parameters.AddWithValue("@out_remarks", chkOutRemarks.Checked);
        
        command.Parameters.AddWithValue("@out_addressee", chkAddressee.Checked);
        command.Parameters.AddWithValue("@out_attach", chkOutAttach.Checked);
                
        command.Parameters.AddWithValue("@id", txtCode.Text);

        command.ExecuteNonQuery();

        con.Close();

        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully updated!');window.location='Setup_Project.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"] + "';", true);

    }
}