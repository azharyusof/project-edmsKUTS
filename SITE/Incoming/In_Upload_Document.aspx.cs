using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SITE_Incoming_In_Upload_Document : System.Web.UI.Page
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
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        HttpFileCollection hfc = Request.Files;
        string Msg = null;

        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];

            if (hpf.ContentLength > 0)
            {
                string serialno = System.IO.Path.GetFileName(hpf.FileName);
                serialno = serialno.Replace(".pdf", "");

                this.connection();

                SqlCommand com = new SqlCommand("spUploadInDocument", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@serialNo", serialno);
                com.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {

                }
                else
                {
                    DataRow row1 = null;
                    row1 = dt.Rows[0];

                    if (row1["FLD_CONFIDENTIAL"].ToString() == "1")
                    {
                        //string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["id1"] + "/incoming/20" + System.IO.Path.GetFileName(hpf.FileName).Substring(6, 2) + "/" + row1["ID"].ToString() + "";
                        string pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["id1"] + "/" + row1["COMPANY_CODE"].ToString() + "/incoming/" + row1["YEAR_CIN"].ToString() + "/" + row1["ID"].ToString() + "";

                        //Response.Write("yes");
                        if (!System.IO.File.Exists(pathString))
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }

                        Msg += "<b>" + System.IO.Path.GetFileName(hpf.FileName.ToString()) + "</b> uploaded successfully.<br> ";
                    }
                    else
                    {
                        //string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["id1"] + "/incoming/20" + System.IO.Path.GetFileName(hpf.FileName).Substring(6, 2) + "";
                        string pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["id1"] + "/" + row1["COMPANY_CODE"].ToString() + "/incoming/" + row1["YEAR_CIN"].ToString() + "";

                        //Response.Write("no");
                        if (!System.IO.File.Exists(pathString))
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }

                        Msg += "<b>" + System.IO.Path.GetFileName(hpf.FileName.ToString()) + "</b> uploaded successfully.<br> ";
                    }
                }

                con.Close();
            }

            lblMessage.Text = "<b>" + Msg + "</b>";
            DvFileUpload.Visible = true;
        }
    }
}