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
using System.IO;

public partial class _Change : System.Web.UI.Page
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

    protected void btnChange_Click(object sender, EventArgs e)
    {
        int Results = 0;

        if (fldStaffID.Text != string.Empty && fldOldPwd.Text != string.Empty && fldNewPwd.Text != string.Empty)
        {
            Results = Validate_Change(fldStaffID.Text.Trim(), fldOldPwd.Text.Trim(), fldNewPwd.Text.Trim());

            if (Results == 1)
            {
                ShowMessage("Password successfully changed! Please login again.", MessageType.Success);

                fldStaffID.Text = String.Empty;
                fldOldPwd.Text = String.Empty;
                fldNewPwd.Text = String.Empty;
            }
            else
            {
                ShowMessage("Invalid password!", MessageType.Error);
            }
        }
    }

    public int Validate_Change(String userID, String oldPwd, String newPwd)
    {
        connection();

        SqlCommand com = new SqlCommand("spChangePwd", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pUserID", fldStaffID.Text.ToString());
        com.Parameters.AddWithValue("@pOldPwd", fldOldPwd.Text.ToString());
        com.Parameters.AddWithValue("@pNewPwd", fldNewPwd.Text.ToString());
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