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

public partial class SITE_Outgoing_Out_View_Document : System.Web.UI.Page
{
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    DataRow row = null;
    DataRow row1 = null;
    DataRow row2 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }


        if (!Page.IsPostBack)
        {
            bindAddressee();
            hid_Year.Value = getCurrentYear();
            bindGridViewOutDoc(getCurrentYear());
        }
    }

    protected void bindAddressee()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldAddressee.DataSource = GetData(queryString);
        fldAddressee.DataTextField = "FLD_COMPANY";
        fldAddressee.DataValueField = "FLD_COMPANY";
        fldAddressee.DataBind();
        fldAddressee.Items.Insert(0, new ListItem("-- Please select Addressee --", ""));
    }

    protected void bindGridViewOutDoc(string yr)
    {
        if (fldAddressee.SelectedIndex != 0)
        {
            queryString = "";
            queryString = queryString + " SELECT        VWEDMS_OUT_DOCUMENT.*, tblStaff.StaffName As ORIGINATOR ";
            queryString = queryString + " FROM          VWEDMS_OUT_DOCUMENT ";
            queryString = queryString + " LEFT JOIN     tblStaff on tblStaff.StaffNo = VWEDMS_OUT_DOCUMENT.FLD_ORIGINATOR ";
            queryString = queryString + " WHERE         VWEDMS_OUT_DOCUMENT.PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
            queryString = queryString + " AND YEAR(VWEDMS_OUT_DOCUMENT.FLD_BOOK_DATE) = '" + yr + "' ";
            queryString = queryString + " AND VWEDMS_OUT_DOCUMENT.FLD_OUT_SERIAL IS NOT NULL ";
            queryString = queryString + "               AND VWEDMS_OUT_DOCUMENT.FLD_COMPANY = '" + fldAddressee.SelectedValue + "' ";
            queryString = queryString + " ORDER BY      YEAR(VWEDMS_OUT_DOCUMENT.FLD_BOOK_DATE) DESC,VWEDMS_OUT_DOCUMENT.FLD_OUT_SERIAL DESC ";
        }
        else
        {
            queryString = "";
            queryString = queryString + " SELECT        VWEDMS_OUT_DOCUMENT.*, tblStaff.StaffName As ORIGINATOR ";
            queryString = queryString + " FROM          VWEDMS_OUT_DOCUMENT ";
            queryString = queryString + " LEFT JOIN     tblStaff on tblStaff.StaffNo = VWEDMS_OUT_DOCUMENT.FLD_ORIGINATOR ";
            queryString = queryString + " WHERE         VWEDMS_OUT_DOCUMENT.PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
            queryString = queryString + " AND YEAR(VWEDMS_OUT_DOCUMENT.FLD_BOOK_DATE) = '" + yr + "' ";
            queryString = queryString + " AND VWEDMS_OUT_DOCUMENT.FLD_OUT_SERIAL IS NOT NULL ";
            queryString = queryString + " ORDER BY      YEAR(VWEDMS_OUT_DOCUMENT.FLD_BOOK_DATE) DESC,VWEDMS_OUT_DOCUMENT.FLD_OUT_SERIAL DESC ";
        }

        GridViewOutDoc.DataSource = GetData(queryString);
        GridViewOutDoc.DataBind();
    }

    protected string getCurrentYear()
    {
        // Check for current year
        string current_year = "";

        if (string.IsNullOrEmpty(Request.QueryString["Year"]))
        {
            // Select from database to get current year
            queryString = "";
            queryString = queryString + " SELECT        DISTINCT year(FLD_BOOK_DATE) as yr ";
            queryString = queryString + " FROM          VWEDMS_OUT_DOCUMENT ";
            queryString = queryString + " WHERE         PROJECT_CODE='" + Request.QueryString["ID1"] + "' AND FLD_BOOK_DATE IS NOT NULL ";
            queryString = queryString + " ORDER BY      yr DESC ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter daCY = new SqlDataAdapter(cmd);
            DataTable dtCY = new DataTable();
            daCY.Fill(dtCY);
            con.Close();

            if (dtCY.Rows.Count == 0)
            {
                current_year = DateTime.Now.ToString("yyyy");
            }
            else
            {
                DataRow row = dtCY.Rows[0];
                current_year = Convert.ToString(row["yr"]);
            }
        }
        else
        {
            current_year = Convert.ToString(Request.QueryString["Year"]);
        }

        return current_year;
    }

    protected void fldAddressee_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGridViewOutDoc(getCurrentYear());
    }

    protected void GridViewOutDoc_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewOutDoc.PageIndex = e.NewPageIndex;
        this.bindGridViewOutDoc(getCurrentYear());
    }


    protected void GridViewOutDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label fldoutserial = e.Row.FindControl("FLD_OUT_SERIAL") as Label;
            Label projectcode = e.Row.FindControl("PROJECT_CODE") as Label;
            Label attachment = e.Row.FindControl("lblAttachment") as Label;
            Label company = e.Row.FindControl("lblCompany") as Label;
            Label addressee = e.Row.FindControl("lblAddressee") as Label;
            Label yr = e.Row.FindControl("YR") as Label;
            Label track_no = e.Row.FindControl("TRACK_NO") as Label;

            Label Label2 = e.Row.FindControl("Label2") as Label;
            Label Label3 = e.Row.FindControl("Label3") as Label;
            Label lblFolder1 = e.Row.FindControl("lblFolder1") as Label;
            Label lblFolder2 = e.Row.FindControl("lblFolder2") as Label;

            Label cancel = e.Row.FindControl("lblCancelled") as Label;
            Label companycode = e.Row.FindControl("COMPANY_CODE") as Label;
            string iCancel = cancel.Text;

            if (iCancel == "1")
            {
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
            }


            var file2 = new System.IO.FileInfo(@"E:/Webapps/EDMS_STR/Document/" + projectcode.Text + "/" + companycode.Text + "/outgoing/" + yr.Text + "/" + fldoutserial.Text + ".pdf");

            if (file2.Exists)
            { }
            else
            {
                //find you image and hide it
                var element = e.Row.FindControl("imageid");
                //hide it
                Image img2 = (Image)e.Row.FindControl("img_all");
                img2.Visible = false;
            }
            
        }

    }

    private static DataTable GetData(string query)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
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