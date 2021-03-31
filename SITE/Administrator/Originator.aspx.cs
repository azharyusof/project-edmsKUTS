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

public partial class SITE_Administrator_Originator : System.Web.UI.Page
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

        SqlCommand com = new SqlCommand("spBindAdminOriginator", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridOriginator.DataSource = dt;
        GridOriginator.DataBind();
    }

    protected void AddNewOriginator(object sender, EventArgs e)
    {
        string Originator = ((TextBox)GridOriginator.FooterRow.FindControl("txtOriginator")).Text;

        if (!String.IsNullOrEmpty(Originator))
        {
            this.connection();

            SqlCommand com = new SqlCommand("spAddAdminOriginator", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@originator", SqlDbType.VarChar).Value = Originator;
            com.Parameters.AddWithValue("@StaffNo", Request.QueryString["ID1"]);
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

    protected void EditOriginator(object sender, GridViewEditEventArgs e)
    {
        GridOriginator.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridOriginator.EditIndex = -1;
        BindData();
    }

    protected void UpdateOriginator(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridOriginator.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Originator = ((TextBox)GridOriginator.Rows[e.RowIndex].FindControl("txtOriginator")).Text;

        this.connection();

        SqlCommand com = new SqlCommand("spUpdateAdminOriginator", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        com.Parameters.Add("@originator", SqlDbType.VarChar).Value = Originator;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();

        com.ExecuteNonQuery();

        GridOriginator.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeleteOriginator(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        this.connection();

        SqlCommand com = new SqlCommand("spDeleteAdminOriginator", con);
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
        GridOriginator.PageIndex = e.NewPageIndex;
        GridOriginator.DataBind();
    }
}