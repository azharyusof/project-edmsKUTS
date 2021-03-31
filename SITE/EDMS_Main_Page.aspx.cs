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

public partial class EDMS_Main_Page : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack){

            // Select database - project
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          PROJECT ";
            queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
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

            lblDepartment.Text = "Department / Project : " + row["DESCRIPTION"].ToString();
            lblHodPm.Text = "HOD / PM : " + row["PROJECT_MANAGER"].ToString();

            // Bind Incoming
            bindIncoming();

            // Bind Outgoing
            bindOutgoing();
        }
    }
    protected void bindIncoming()
    {
        queryString = "";
        queryString = queryString + " SELECT        COUNT(FLD_IN_SERIAL) AS totalInDoc, YEAR(FLD_IN_DATE) As InYr ";
        queryString = queryString + " FROM          EDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "'";
        queryString = queryString + " GROUP BY      YEAR(FLD_IN_DATE) ";
        queryString = queryString + " ORDER BY      YEAR(FLD_IN_DATE) DESC ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daIn = new SqlDataAdapter(cmd);
        DataTable dtIn = new DataTable();
        daIn.Fill(dtIn);

        GridViewResultIncoming.DataSource = dtIn;
        GridViewResultIncoming.DataBind();
    }
    protected void bindOutgoing()
    {
        queryString = "";
        queryString = queryString + " SELECT        COUNT(FLD_OUT_SERIAL) AS totalOutDoc, YEAR(FLD_BOOK_DATE) As OutYr ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "'";
        queryString = queryString + " GROUP BY      YEAR(FLD_BOOK_DATE) ";
        queryString = queryString + " ORDER BY      YEAR(FLD_BOOK_DATE) DESC ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daOut = new SqlDataAdapter(cmd);
        DataTable dtOut = new DataTable();
        daOut.Fill(dtOut);

        GridViewResultOutgoing.DataSource = dtOut;
        GridViewResultOutgoing.DataBind();
    }
    public DataSet GetData(string queryString)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
        DataSet ds = new DataSet();
        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }
}