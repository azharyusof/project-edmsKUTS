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

public partial class ADMIN_Add_UserRole : System.Web.UI.Page
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
            Response.Redirect("../../Default.aspx", true);
        }

        if (!IsPostBack)
        {         
            bindUser();
            bindProject();
            bindRole();
        }
    }

    protected void bindUser()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindAdminUser", con);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldStaffNo.DataSource = dt;
        fldStaffNo.DataTextField = "STAFFNAME";
        fldStaffNo.DataValueField = "STAFFNO";
        fldStaffNo.DataBind();
        fldStaffNo.Items.Insert(0, new ListItem("Please Select Staff Name", ""));
    }

    protected void bindProject()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindAdminProject", con);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldPName.DataSource = dt;
        fldPName.DataTextField = "mycolumn";
        fldPName.DataValueField = "PROJECT_CODE";
        fldPName.DataBind();
        fldPName.Items.Insert(0, new ListItem("Please Select Project Name", ""));
    }

    protected void bindRole()
    {
        // Bind data to the Dropdownlist control.
        fldRole.Items.Insert(0, new ListItem("Please Select Role", ""));
        fldRole.Items.Insert(1, new ListItem("Document Controller", "DC"));
        fldRole.Items.Insert(2, new ListItem("Project Manager", "PM"));
        fldRole.Items.Insert(3, new ListItem("Project Team", "PT"));
        fldRole.Items.Insert(3, new ListItem("COO", "COO"));
        fldRole.Items.Insert(3, new ListItem("Project Coordinator", "PC"));
        fldRole.Items.Insert(3, new ListItem("Procurement & Contract", "PNC"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.connection();

        SqlCommand com = new SqlCommand("spAddUserRole", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pname", fldPName.Text);
        com.Parameters.AddWithValue("@staffno", fldStaffNo.Text);
        com.Parameters.AddWithValue("@role", fldRole.Text.ToLower());
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        con.Close();

        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully saved!');window.location='Add_UserRole.aspx?ID=" + Request.QueryString["id"] + "';", true);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_UserRole.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }
}