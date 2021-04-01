using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_MasterPage : System.Web.UI.MasterPage
{
    string queryString = "";
    DataRow row = null;
    DateTime varDt;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        queryString = "";
        queryString = queryString + " SELECT        TYPE ";
        queryString = queryString + " FROM          PROJECTUSERS ";
        queryString = queryString + " WHERE         STAFF_NO = '" + Request.QueryString["ID"] + "'";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        row = null;
        row = dtChck.Rows[0];

        if (row["TYPE"].ToString() == "SUPERADMIN")
            lblUser.Text = "Administrator";
        else if (row["TYPE"].ToString() == "DC")
            lblUser.Text = "Document Controller";
        else if (row["TYPE"].ToString() == "PM")
            lblUser.Text = "Project Manager";
        else if (row["TYPE"].ToString() == "PT")
            lblUser.Text = "Project Team";
        else
            lblUser.Text = "No Status";
    }
}
