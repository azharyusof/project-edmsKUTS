using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        String StaffID = Request.QueryString["ID"];

        this.connection();

        SqlCommand com = new SqlCommand("spUsername", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pUserID", StaffID.ToString());
        SqlDataAdapter daChck = new SqlDataAdapter(com);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        DataRow row = dtChck.Rows[0]; ;

        lblUser.Text = row["StaffName"].ToString();
    }

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }
}
