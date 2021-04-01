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
    protected void Page_Load(object sender, EventArgs e)
    {
        // Reset error.
        errDvfldStaffID.Visible = false;
        errDvfldPass.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(fldStaffID.Text) & string.IsNullOrEmpty(fldPass.Text))
        {
            errDvfldStaffID.Visible = true;
            errDvfldPass.Visible = true;
        }
        else if (string.IsNullOrEmpty(fldStaffID.Text))
        {
            errDvfldStaffID.Visible = true;
        }
        else if (string.IsNullOrEmpty(fldPass.Text))
        {
            errDvfldPass.Visible = true;
        }
        else
        {
            // Reset error.
            errDvfldStaffID.Visible = false;
            errDvfldPass.Visible = false;

            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, fldPass.Text);
                string queryString = "";
                string url = "";

                queryString = queryString + " SELECT        StaffNo, Pwd, UserLevel, EDMS_GDCLevel ";
                queryString = queryString + " FROM          tblLogin ";
                queryString = queryString + " WHERE         StaffNo =  @pUserID ";

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@pUserID", fldStaffID.Text);
                cmd.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 0)
                {
                    // Check for no record found.
                    url = "Error/Website_Under_Maintainance.html";
                }
                else
                {
                    DataRow row = dt.Rows[0];
                    // Check for password.
                    if (row["Pwd"].ToString() == hash || row["Pwd"].ToString() == fldPass.Text)
                    {
                        // Redirect to main page.
                        Session["StaffNo"] = fldStaffID.Text;
                        Session["Level"] = row["UserLevel"];
                        Session["GDCLevel"] = row["EDMS_GDCLevel"];
                        url = "EDMS_Main_Page.aspx" + "?ID=" + fldStaffID.Text + "&ID1=OQS";
                    }
                    else
                    {
                        // Redirect to error page.
                        url = "Error/Website_Under_Maintainance.html";
                    }
                }

                if (url != "")
                {
                    Response.Redirect(url);
                }
            }
        }
    }

    public static string GetMd5Hash(MD5 md5Hash, string input)
    {
        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes and create a string. 
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data and format each one as a hexadecimal string. 
        int i = 0;
        for (i = 0; i <= data.Length - 1; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
    }

}