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
            Response.Redirect("../Default.aspx", true);
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_Project.aspx?ID=" + Request.QueryString["id"]);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fldPCode.Text == "" | fldPDesc.Text == "" | fldPMgr.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "errorModal();", true);
        }
        else
        {
            this.connection();

            SqlCommand com = new SqlCommand("spCheckDuplicateProject", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                createFolder();

                com = new SqlCommand("spAddProject", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@pcode", fldPCode.Text.Trim());
                com.Parameters.AddWithValue("@pdesc", fldPDesc.Text.Trim());
                com.Parameters.AddWithValue("@pmgr", fldPMgr.Text.Trim());
                com.CommandTimeout = 0;

                com.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "successModal();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('This project already exist!');window.location='Add_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);
            }

            con.Close();
        }
    }

    protected void btnSuccess_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_Project.aspx?ID=" + Request.QueryString["id"]);
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