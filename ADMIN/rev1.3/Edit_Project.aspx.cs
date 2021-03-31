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

public partial class ADMIN_Edit_Project : System.Web.UI.Page
{
    String queryString = ""; 
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DateTime varDt;
    protected void Page_Load(object sender, EventArgs e)
    {
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
                fldPDesc.Text = "";
                fldPMgr.Text = "";
                txtId.Text = "";
            }
            else
            {
                DataRow row = dt.Rows[0];

                lblPCode.Text = row["PROJECT_CODE"].ToString();
                fldPDesc.Text = row["DESCRIPTION"].ToString();
                fldPMgr.Text = row["PROJECT_MANAGER"].ToString();
                txtId.Text = row["PROJECTID"].ToString();
            }

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);

        con.Open();

        SqlCommand command = new SqlCommand("DELETE FROM PROJECT WHERE PROJECTID = @id", con);
        command.Parameters.AddWithValue("@id", txtId.Text);
        command.ExecuteNonQuery();

        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully deleted!');window.location='View_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);
       
    }
        
    protected void btnUpdate_Click(object sender, EventArgs e)
    {        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);

        con.Open();    
            
        SqlCommand command = new SqlCommand("UPDATE PROJECT SET "
          + "DESCRIPTION = @pdesc, "
          + "PROJECT_MANAGER = @pmgr "
          + "WHERE PROJECTID = @id", con);

        command.Parameters.AddWithValue("@pdesc", fldPDesc.Text);
        command.Parameters.AddWithValue("@pmgr", fldPMgr.Text);

        command.Parameters.AddWithValue("@id", txtId.Text);

        command.ExecuteNonQuery();

        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully updated!');window.location='View_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);
        
    }
}