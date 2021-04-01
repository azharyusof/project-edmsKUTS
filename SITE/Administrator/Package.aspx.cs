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

public partial class SITE_Administrator_Package : System.Web.UI.Page
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

        SqlCommand com = new SqlCommand("spBindAdminPackage", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridPackage.DataSource = dt;
        GridPackage.DataBind();
    }

    public DataSet GetData(string queryString)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);

            // Fill the DataSet.
            adapter.Fill(ds);
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }

    protected void AddNewPackage(object sender, EventArgs e)
    {
        string Package = ((TextBox)GridPackage.FooterRow.FindControl("txtPackage")).Text;

        if (!String.IsNullOrEmpty(Package))
        {
            this.connection();

            SqlCommand com = new SqlCommand("spAddAdminPackage", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@package", SqlDbType.VarChar).Value = Package;
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

    protected void EditPackage(object sender, GridViewEditEventArgs e)
    {
        GridPackage.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridPackage.EditIndex = -1;
        BindData();
    }

    protected void UpdatePackage(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridPackage.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Package = ((TextBox)GridPackage.Rows[e.RowIndex].FindControl("txtPackage")).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminPackage", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        com.Parameters.Add("@package", SqlDbType.VarChar).Value = Package;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        GridPackage.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeletePackage(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        this.connection();

        SqlCommand com = new SqlCommand("spDeleteAdminPackage", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = lnkRemove.CommandArgument;
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
        GridPackage.PageIndex = e.NewPageIndex;
        GridPackage.DataBind();
    }
}