using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    public SqlConnection con;
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int Results = 0;

        if (fldStaffID.Text != string.Empty && fldPass.Text != string.Empty)
        {
            Results = Validate_Login(fldStaffID.Text.Trim(), fldPass.Text.Trim());

            if (Results == 1)
            {
                Session["StaffNo"] = fldStaffID.Text;
                Response.Redirect("Home.aspx?ID=" + fldStaffID.Text);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
    }

    public int Validate_Login(String UserID, String Password)
    {
        connection();

        SqlCommand com = new SqlCommand("spLoginEDMS", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pUserID", fldStaffID.Text.ToString());
        com.Parameters.AddWithValue("@pPWD", fldPass.Text.ToString());
        com.Parameters.Add("@OutRes", SqlDbType.Int, 4);
        com.Parameters["@OutRes"].Direction = ParameterDirection.Output;

        int Results = 0;

        try
        {
            com.ExecuteNonQuery();

            Results = (int)com.Parameters["@OutRes"].Value;
        }
        catch (SqlException ex)
        {

        }
        finally
        {
            com.Dispose();

            if (con != null)
            {
                con.Close();
            }
        }

        return Results;
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}