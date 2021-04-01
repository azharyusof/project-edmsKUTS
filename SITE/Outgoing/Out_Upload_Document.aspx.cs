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

public partial class SITE_Outgoing_Out_Upload_Document : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    DateTime varDt;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DataRow row1 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {

        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        HttpFileCollection hfc = Request.Files;
        String msgEx = null;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                string serialno = System.IO.Path.GetFileName(hpf.FileName);
                serialno = serialno.Replace(".pdf", "");

                queryString = "";
                queryString = queryString + " SELECT        ID, COMPANY_CODE, YEAR(FLD_DOC_DATE) AS YEAR_OUT ";
                queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
                queryString = queryString + " WHERE         FLD_OUT_SERIAL='" + serialno + "'";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand(queryString, con);
                cmd.CommandTimeout = 0;

                SqlDataAdapter daTN = new SqlDataAdapter(cmd);
                DataTable dtTN = new DataTable();
                daTN.Fill(dtTN);

                if (dtTN.Rows.Count == 0)
                {

                }
                else
                {
                    row1 = null;
                    row1 = dtTN.Rows[0];

                    String pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["id1"] + "/" + row1["COMPANY_CODE"].ToString() + "/outgoing/" + row1["YEAR_OUT"].ToString() + "";


                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        //Response.Write("not exist");
                    }
                    else
                    {

                        hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        //Response.Write("exist");
                    }

                    msgEx += "<b>" + System.IO.Path.GetFileName(hpf.FileName.ToString()) + "</b> uploaded successfully.<br> ";
                }
            }

            lblMessage.Text = "<b>" + msgEx + "</b>";
        }

    }
}