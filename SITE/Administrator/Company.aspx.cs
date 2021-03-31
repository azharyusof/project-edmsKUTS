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

public partial class SITE_Administrator_Company : System.Web.UI.Page
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
            BindData();
        }
    }

    private void BindData()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindAdminCompany", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridCompany.DataSource = dt;
        GridCompany.DataBind();
    }

    protected void AddNewCompany(object sender, EventArgs e)
    {
        string Company = ((TextBox)GridCompany.FooterRow.FindControl("txtCompany")).Text;

        if (!String.IsNullOrEmpty(Company))
        {
            this.connection();

            SqlCommand com = new SqlCommand("spAddAdminCompany", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@company", SqlDbType.VarChar).Value = Company;
            com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            com.ExecuteNonQuery();

            BindData();

            con.Close();
        }

        else
        {
            
        }
    }

    protected void EditCompany(object sender, GridViewEditEventArgs e)
    {
        GridCompany.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridCompany.EditIndex = -1;
        BindData();
    }

    protected void UpdateCompany(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridCompany.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Company = ((TextBox)GridCompany.Rows[e.RowIndex].FindControl("txtCompany")).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminCompany", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        com.Parameters.Add("@company", SqlDbType.VarChar).Value = Company;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        GridCompany.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeleteCompany(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        this.connection();

        SqlCommand com = new SqlCommand("spDeleteAdminCompany", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        BindData();

        con.Close();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();
        GridCompany.PageIndex = e.NewPageIndex;
        GridCompany.DataBind();
    }
}