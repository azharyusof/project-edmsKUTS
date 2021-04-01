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

    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        bindGridView();        
    }

    protected void bindGridView()
    {
        queryString = "";
        queryString = queryString + " SELECT * ";
        queryString = queryString + " FROM PROJECT ";
        queryString = queryString + " ORDER BY      PROJECT_CODE ";

        SqlCommand cmd = new SqlCommand(queryString, con);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

            var dataSource = GetData(string.Format("SELECT * FROM TBLUSERLOGIN WHERE TYPE<>'SUPERADMIN' AND PROJECT_CODE='{0}' ORDER BY STAFFNAME", customerId));
                        
            int count = dataSource.Rows.Count;
            if (count > 0)
            {
                GridViewUser.DataSource = GetData(string.Format("SELECT * FROM TBLUSERLOGIN WHERE TYPE<>'SUPERADMIN' AND PROJECT_CODE='{0}' ORDER BY STAFFNAME", customerId));
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
