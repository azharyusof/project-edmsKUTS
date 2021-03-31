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

public partial class ADMIN_Add_Project : System.Web.UI.Page
{
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();   
 
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            // Reset error.
            errDvfldPCode.Visible = false;
            errDvfldPDesc.Visible = false;
            errDvfldPMgr.Visible = false;
            dvReset.Visible = false;
               
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_Project.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        
        if (fldPCode.Text == "" && fldPDesc.Text == "" && fldPMgr.Text == "")
        {
            errDvfldPCode.Visible = true;
            errDvfldPDesc.Visible = true;
            errDvfldPMgr.Visible = true;
        }
        else if (fldPCode.Text == "")
        {
            errDvfldPCode.Visible = true;
        }
        else if (fldPDesc.Text == "")
        {
            errDvfldPDesc.Visible = true;
        }
        else if (fldPMgr.Text == "")
        {
            errDvfldPMgr.Visible = true;
        }
        else
        {            
            con.Open();
            
            //Check for duplicate project
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          PROJECT ";
            queryString = queryString + " WHERE         PROJECT_CODE='" + fldPCode.Text.Trim() + "'";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter daQ = new SqlDataAdapter(cmd);
            DataTable dtQ = new DataTable();
            daQ.Fill(dtQ);

            if (dtQ.Rows.Count == 0)
            {
                createFolder();
                
                //Insert new project 
                SqlCommand command = new SqlCommand("INSERT INTO PROJECT (PROJECT_CODE, DESCRIPTION, PROJECT_MANAGER, TEMPLATE, STATUS, TYPE) VALUES "
                  + "(@pcode, "
                  + "@pdesc, "
                  + "@pmgr, "
                  + "'C', "
                  + "'Active', "
                  + "'Internal')", con);

                command.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());
                command.Parameters.AddWithValue("@pdesc", fldPDesc.Text.Trim());
                command.Parameters.AddWithValue("@pmgr", fldPMgr.Text.Trim());

                command.ExecuteNonQuery();

                //Insert project setup
                SqlCommand command1 = new SqlCommand("INSERT INTO PROJECT_SETUP (PROJECT_CODE, IN_FLD_REFERENCE, IN_FLD_CORR_DATE, IN_FLD_PACKAGE, IN_FLD_AUTHOR, IN_FLD_COMPANY, IN_REMARKS, IN_FLD_URGENCY, IN_FLD_REQ_DATE, IN_FLD_ACTION_DATE, IN_FLD_OUT_TRACK_NO, IN_FLD_ACTION_TAKEN, IN_ATTACHMENT, IN_TRANSMITTAL, OUT_FLD_REFERENCE, OUT_FLD_DOC_DATE, OUT_FLD_PACKAGE, OUT_FLD_TITLE1, OUT_FLD_REMARKS, OUT_ADDRESSEE, OUT_ATTACHMENT, IN_ACTIONEE, IN_STATUS) VALUES "
                  + "(@pcode, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)", con);

                command1.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());

                command1.ExecuteNonQuery();

                //Insert Super Admin user
                SqlCommand command2 = new SqlCommand("INSERT INTO PROJECTUSERS (PROJECT_CODE, STAFF_NO, TYPE) VALUES (@pcode, '50424' ,'SUPERADMIN')", con);

                command2.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());

                command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand("INSERT INTO PROJECTUSERS (PROJECT_CODE, STAFF_NO, TYPE) VALUES (@pcode, 'RH' ,'SUPERADMIN')", con);

                command3.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());

                command3.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully saved!');window.location='Add_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('This project already exist!');window.location='Add_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);
            }
        }
    }

    protected void createFolder()
    {
        DateTime now = DateTime.Now;

        //Location at server BHPEDMSWEB -> D:\EDMS_BHP\Document
        string pathString = @"d:/EDMS_BHP/Document/" + fldPCode.Text.Trim() + "";

        // You can extend the depth of your path if you want to. 
        // pathString = System.IO.Path.Combine(pathString, "SubSubFolder");

        // Create the subfolder. You can verify in File Explorer that you have this 
        // structure in the C: drive. 
        //    Local Disk (C:) 
        //        Top-Level Folder
        //            SubFolder

        //Response.Write(pathString);

        //if (!System.IO.File.Exists(pathString))
        if (!System.IO.Directory.Exists(pathString))
        {
            System.IO.Directory.CreateDirectory(pathString);

            string pathIn = @"d:/EDMS_BHP/Document/" + fldPCode.Text.Trim() + "/incoming/" + DateTime.Now.ToString("yyyy") + "";
            string pathOut = @"d:/EDMS_BHP/Document/" + fldPCode.Text.Trim() + "/outgoing/" + DateTime.Now.ToString("yyyy") + "";

            string pathInAttach = @"d:/EDMS_BHP/Document/" + fldPCode.Text.Trim() + "/incoming/attachment";
            string pathOutAttach = @"d:/EDMS_BHP/Document/" + fldPCode.Text.Trim() + "/outgoing/attachment";

            System.IO.Directory.CreateDirectory(pathIn);
            System.IO.Directory.CreateDirectory(pathOut);
            System.IO.Directory.CreateDirectory(pathInAttach);
            System.IO.Directory.CreateDirectory(pathOutAttach);
        }

    }
}