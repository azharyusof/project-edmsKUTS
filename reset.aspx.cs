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
using System.Net.Mail;

public partial class _Reset : System.Web.UI.Page
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        int Results = 0;

        if (fldEmail.Text != string.Empty)
        {
            Results = Validate_Email(fldEmail.Text.Trim());

            if (Results == 1)
            {
                this.SendEmail();
                fldEmail.Text = String.Empty;
            }
            else
            {
                ShowMessage("Invalid Email!", MessageType.Error);
                fldEmail.Text = String.Empty;
            }
        }
    }

    public int Validate_Email(String Email)
    {
        connection();

        SqlCommand com = new SqlCommand("spForgetPwd", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@pEmail", fldEmail.Text.ToString());
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

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(fldEmail.Text.Trim());
        //mail.Bcc.Add("pbs.edms@gmail.com");

        mail.From = new MailAddress("pbs.edms@gmail.com", "Sabah Pan Borneo - EDMS");
        mail.Subject = "EDMS: Change Password";

        //Start - Email Body
        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:ARIAL,8PT;>"
            + "Your new password is : <B>3dm5_2016</B><BR><BR>"

            + "Please click <A HREF=http://192.168.50.41/change.aspx>here</A> to change your password.<BR><BR>"

            + "<BR><BR><BR>Thank you.<BR><BR>"
            + "This is a system-generated message. Please do not reply.</BODY></HTML>";

        mail.Body = htmlText;
        mail.IsBodyHtml = true;
        //End - Email Body

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp2.edgenta.com";
        smtp.Port = 25;

        //smtp.Credentials = new System.Net.NetworkCredential
        //     ("pbs.edms@gmail.com", "uniCorn16");

        smtp.EnableSsl = true;
        smtp.Send(mail);
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}