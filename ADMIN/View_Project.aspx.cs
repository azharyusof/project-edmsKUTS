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
using System.IO;
using System.Text;

public partial class ADMIN_View_Project : System.Web.UI.Page
{
    public SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!IsPostBack)
        {
            connection();

            string StaffID = Request.QueryString["ID"];
            SqlCommand com = new SqlCommand("spProjectList", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pUserID", StaffID.ToString());
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            con.Close();
        }
    }

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }

    protected void btnEditProject_Click(object Source, EventArgs e)
    {
        RepeaterItem item = (Source as Button).NamingContainer as RepeaterItem;
        string ProjectCode = (item.FindControl("lblProjectCode") as Label).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spProjectCode", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", ProjectCode.ToString());
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        DataRow row = null;
        row = dt.Rows[0];

        string ProjectID = row["ProjectID"].ToString();
        Response.Redirect("~/ADMIN/Edit_Project.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + ProjectID.ToString());
    }
}