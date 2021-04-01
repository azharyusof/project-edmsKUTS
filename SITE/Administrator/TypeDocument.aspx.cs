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

public partial class SITE_Administrator_TypeDocument : System.Web.UI.Page
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

        SqlCommand com = new SqlCommand("spBindAdminTypeDoc", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridTypeDoc.DataSource = dt;
        GridTypeDoc.DataBind();
    }

    protected void AddNewType(object sender, EventArgs e)
    {
        string DocType = ((TextBox)GridTypeDoc.FooterRow.FindControl("txtType")).Text;

        if (!String.IsNullOrEmpty(DocType))
        {
            this.connection();

            SqlCommand com = new SqlCommand("spAddAdminTypeDoc", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = DocType;
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

    protected void EditType(object sender, GridViewEditEventArgs e)
    {
        GridTypeDoc.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridTypeDoc.EditIndex = -1;
        BindData();
    }

    protected void UpdateType(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridTypeDoc.Rows[e.RowIndex].FindControl("lblID")).Text;
        string DocType = ((TextBox)GridTypeDoc.Rows[e.RowIndex].FindControl("txtType")).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminTypeDoc", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        com.Parameters.Add("@type", SqlDbType.VarChar).Value = DocType;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        GridTypeDoc.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeleteType(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        this.connection();

        SqlCommand com = new SqlCommand("spDeleteAdminTypeDoc", con);
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
        GridTypeDoc.PageIndex = e.NewPageIndex;
        GridTypeDoc.DataBind();
    }
}