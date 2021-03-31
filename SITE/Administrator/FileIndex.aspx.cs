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

public partial class SITE_Administrator_FileIndex : System.Web.UI.Page
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

        SqlCommand com = new SqlCommand("spBindAdminFileIndex", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void AddNewIndex(object sender, EventArgs e)
    {
        string FileIndex = ((TextBox)GridView1.FooterRow.FindControl("txtIndex")).Text;

        if (!String.IsNullOrEmpty(FileIndex))
        {
            this.connection();

            SqlCommand com = new SqlCommand("spAddAdminFileIndex", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@index", SqlDbType.VarChar).Value = FileIndex;
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

    protected void EditIndex(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }

    protected void UpdateIndex(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID")).Text;
        string FileIndex = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtIndex")).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminFileIndex", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        com.Parameters.Add("@index", SqlDbType.VarChar).Value = FileIndex;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        GridView1.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeleteIndex(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        this.connection();

        SqlCommand com = new SqlCommand("spDeleteAdminFileIndex", con);
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
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

}