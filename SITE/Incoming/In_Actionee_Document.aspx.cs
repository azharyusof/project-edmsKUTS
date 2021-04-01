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

public partial class Incoming_In_Actionee_Document : System.Web.UI.Page
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
                        
            //Bind dropdown Actionee. 
            bindActionee();

            bindGridViewDetails();
        }
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
       
       
    protected void bindGridViewDetails()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          VW_EDMS_IN_DOCUMENT_ACTIONEE ";
        queryString = queryString + " WHERE         action_id = '" + Request.QueryString["ID3"] + "' ";

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
            lblTNo.Text = "";
            fldActionee.Text = "";
            fldActionReq.Text = "";         
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblTNo.Text = row["FLD_IN_SERIAL"].ToString();
                        
            //Actionee
            fldActionee.Text = row["FLD_IN_ACTIONEE"].ToString();

            if (row["INFO"].ToString() == "1")
            {
                chkInfo.Checked = true;
            }
            else if (row["ACTION"].ToString() == "1")
            {
                chkAction.Checked = true;
            }

            //Action Required
            fldActionReq.Text = row["REQUIRED_ACTION"].ToString();
            
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
        //Display message and error.
        dvStatus.Visible = false;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

        con.Open();
        DateTime now = DateTime.Now;
        SqlCommand command = new SqlCommand("UPDATE EDMS_IN_ACTIONEE SET "
          + "FLD_IN_ACTIONEE = @actionee, "
          + "ACTION = @action, "
          + "INFO = @info, "
          + "REQUIRED_ACTION = @req_action "
          + "WHERE recid = '" + Request.QueryString["ID3"] + "'", con);

        //Actionee
        command.Parameters.AddWithValue("@actionee", fldActionee.Text);
        
        //Action?
        command.Parameters.AddWithValue("@action", chkAction.Checked);

        //Info?
        command.Parameters.AddWithValue("@info", chkInfo.Checked);

        if (chkInfo.Checked == true)
        {
            //Action Required
            command.Parameters.AddWithValue("@req_action", DBNull.Value);
        }
        else if (chkAction.Checked == true)
        {
            //Action Required
            command.Parameters.AddWithValue("@req_action", fldActionReq.Text);
        }

        

        command.ExecuteNonQuery();

        //if (row["IN_EMAIL_NOTIFY"].ToString() == "1")
        //{
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

            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.opusbhd.com";
            //client.Timeout = 10000; (error : System.Net.Mail.SmtpException: The operation has timed out.)
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("user", "Password");

            objeto_mail.From = new MailAddress("gdc@opusbhd.uemnet.com", "Opus Group Berhad - EDMS");

            objeto_mail.To.Add(new MailAddress(row["EMAIL"].ToString()));
            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@uemedgenta.uemnet.com"));

            objeto_mail.Subject = "EDMS - Incoming Notify : [" + lblTNo.Text + "]";

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

                + "Please click on the link below to see the attachment:<BR><BR>"
                + "<A HREF=http://dc.opusbhd.com/gdc/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>http://dc.opusbhd.com/gdc/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf</A>"
                + "<BR><BR><BR>"

                + "<B><U>Note:</U></B><BR><BR>"
                + "<FONT COLOR=red>Please be informed that this application system can be accessed through the Opus's LAN only.</FONT><BR><BR>"
                + "<FONT COLOR=red>For remote users, please log on into SSLVPN at <A HREF=https://vpn.opusbhd.com>https://vpn.opusbhd.com</A>.</FONT><BR><BR>"

                + "<BR><BR><BR>Thank you.<BR><BR>"
                + "This is a system-generated message. Please do not reply.</BODY></HTML>";

                objeto_mail.Body = htmlText;
                objeto_mail.IsBodyHtml = true;

                client.Send(objeto_mail);
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

                + "Please click on the link below to access EDMS:<BR><BR>"
                + "<A HREF=http://gdc.opusbhd.com/SITE/admin/update_in_actionee_form.asp?id1=" + row["ID"].ToString() + "&id2=" + row["FLD_IN_ACTIONEE"].ToString() + "&id=" + Request.QueryString["ID"] + "&id3=" + row["ACTION_ID"].ToString() + ">http://gdc.opusbhd.com/SITE/admin/update_in_actionee_form.asp?id1=" + row["ID"].ToString() + "&id2=" + row["FLD_IN_ACTIONEE"].ToString() + "&id=" + Request.QueryString["ID"] + "&id3=" + row["ACTION_ID"].ToString() + "</A>"
                + "<BR><BR>"

                + "Please click on the link below to see the attachment:<BR><BR>"
                + "<A HREF=http://dc.opusbhd.com/gdc/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf>http://dc.opusbhd.com/gdc/" + row["PROJECT_CODE"].ToString() + "/incoming/" + row["YR"].ToString() + "/" + row["TRACK_NO"].ToString() + ".pdf</A>"
                + "<BR><BR><BR>"

                + "<B><U>Note:</U></B><BR><BR>"
                + "<FONT COLOR=red>Please be informed that this application system can be accessed through the Opus's LAN only.</FONT><BR><BR>"
                + "<FONT COLOR=red>For remote users, please log on into SSLVPN at <A HREF=https://vpn.opusbhd.com>https://vpn.opusbhd.com</A>.</FONT><BR><BR>"

                + "<BR><BR><BR>Thank you.<BR><BR>"
                + "This is a system-generated message. Please do not reply.</BODY></HTML>";

                objeto_mail.Body = htmlText;
                objeto_mail.IsBodyHtml = true;

                client.Send(objeto_mail);
            }

            //---------------------------------- end of send email ----------------------------------------
        //}

        con.Close();
        
        //Display message and error.
        dvStatus.Visible = true;
    }

    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("In_Edit_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"] + "&ID2=" + Request.QueryString["ID2"] + "&url=" + Request.QueryString["url"]);        
    }
}

