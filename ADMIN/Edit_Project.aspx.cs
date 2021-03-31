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

        if (!IsPostBack)
        {
            this.connection();

            SqlCommand com = new SqlCommand("spBindAdminModuleProject", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectID", Request.QueryString["ID1"]);
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count != 0)
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

        con.Close();

        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully deleted!');window.location='View_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminModuleProject", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pdesc", fldPDesc.Text);
        com.Parameters.AddWithValue("@pmgr", fldPMgr.Text);
        com.Parameters.AddWithValue("@id", txtId.Text);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        
        com.ExecuteNonQuery();

        con.Close();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "successModal();", true);

        //ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully updated!');window.location='View_Project.aspx?ID=" + Request.QueryString["id"] + "';", true);

    }

    protected void btnSuccess_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_Project.aspx?ID=" + Request.QueryString["id"]);
    }
}