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
using System.Data.Common;

public partial class ADMIN_View_UserRole : System.Web.UI.Page
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
            bindGridView();
        }
    }

    protected void bindGridView()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindProject", con);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridViewProject.DataSource = dt;
        GridViewProject.DataBind();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string customerId = GridViewProject.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView GridViewUser = e.Row.FindControl("GridViewUser") as GridView;

            var dataSource = GetData(string.Format("SELECT * FROM TBLUSERLOGIN WHERE TYPE<>'SUPERADMIN' AND PROJECT_CODE='{0}' ORDER BY TYPE", customerId));

            int count = dataSource.Rows.Count;
            if (count > 0)
            {
                GridViewUser.DataSource = GetData(string.Format("SELECT * FROM TBLUSERLOGIN WHERE TYPE<>'SUPERADMIN' AND PROJECT_CODE='{0}' ORDER BY TYPE", customerId));
                GridViewUser.DataBind();

            }
            else
            {
                //find you image and hide it
                var element = e.Row.FindControl("imageid");
                //hide it
                Image img = (Image)e.Row.FindControl("img_expand");
                img.Visible = false;
            }

        }
    }

    private static DataTable GetData(string query)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}