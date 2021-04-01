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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public static class Extensions
{
    /// <summary>
    /// Wraps matched strings in HTML span elements styled with a background-color
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
    /// <param name="cssClass">The Css color to apply</param>
    /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
    /// <returns>string</returns>
    public static string HighlightKeyWords(this string text, string keywords, string cssClass, bool fullMatch)
    {
        if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
            return text;
        var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (!fullMatch)
            return words.Select(word => word.Trim()).Aggregate(text,
                         (current, pattern) =>
                         Regex.Replace(current,
                                         pattern,
                                           string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                           cssClass,
                                           "$0"),
                                           RegexOptions.IgnoreCase));
        return words.Select(word => "\\b" + word.Trim() + "\\b")
                    .Aggregate(text, (current, pattern) =>
                              Regex.Replace(current,
                              pattern,
                                string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                cssClass,
                                "$0"),
                                RegexOptions.IgnoreCase));
    }
}

public partial class Incoming_In_Search_Document : System.Web.UI.Page
{
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected string search_Word = String.Empty;
    protected string search_Word1 = String.Empty;
    protected string search_Word2 = String.Empty;
    DataRow row2 = null; 
    DataRow row1 = null;
    DataRow row = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        Table2.Visible = false;

        if (!Page.IsPostBack)
        {
            Table2.Visible = false;

            tblResultNote.Visible = false;

            //Bind dropdown Package. 
            bindPackage();

            //Bind Type of Document
            bindType();

            //Bind dropdown Company. 
            bindCompany();

            //Bind dropdown Author. 
            bindAuthor();

            //Bind dropdown File Index. 
            bindIndex();

            // Bind Year
            bindYear();

            // Check Session
            chckSession();
        }        
    }

    protected void chckSession()
    {
        Boolean chckSession = false;
        
        if (Session["ITrackNo"] != null)
        {
            fldTrackNo.Text = Session["ITrackNo"].ToString();
            chckSession = true;
        }

        if (Session["IRefNo"] != null)
        {
            fldRefNo.Text = Session["IRefNo"].ToString();
            chckSession = true;
        }

        if (Session["IDate1"] != null)
        {
            fldDate1.Text = Session["IDate1"].ToString();
            chckSession = true;
        }

        if (Session["IDate2"] != null)
        {
            fldDate2.Text = Session["IDate2"].ToString();
            chckSession = true;
        }

        if (Session["IPackage"] != null)
        {
            dropPackage.SelectedValue = Session["IPackage"].ToString();
            chckSession = true;
        }

        if (Session["IType"] != null)
        {
            fldType.SelectedValue = Session["IType"].ToString();
            chckSession = true;
        }

        if (Session["ISubject"] != null)
        {
            fldSubject.Text = Session["ISubject"].ToString();
            chckSession = true;
        }

        if (Session["IAuthor"] != null)
        {
            dropAuthor.SelectedValue = Session["IAuthor"].ToString();
            chckSession = true;
        }
        
        if (Session["ICompany"] != null)
        {
            dropCompany.SelectedValue = Session["ICompany"].ToString();
            chckSession = true;
        }

        if (Session["IIndex"] != null)
        {
            dropIndex.SelectedValue = Session["IIndex"].ToString();
            chckSession = true;
        }

        if (Session["IYear"] != null)
        {
            dropYear.SelectedValue = Session["IYear"].ToString();
            chckSession = true;
        }

        if (Session["IAttach"] != null)
        {
            fldAttach.Text = Session["IAttach"].ToString();
            chckSession = true;
        }
        
        if (chckSession == true)
        {
            //Session.RemoveAll();

            // Reset error
            Table2.Visible = true;

            // Bind gridview
            GridViewBind();
        }
    }

    protected void bindPackage()
    {        
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_PACKAGE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_PACKAGE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_PACKAGE ";

        dropPackage.DataSource = GetData(queryString);
        dropPackage.DataTextField = "FLD_PACKAGE";
        dropPackage.DataValueField = "FLD_PACKAGE";
        dropPackage.DataBind();
        dropPackage.Items.Insert(0, new ListItem("-- Please select Package --", ""));
    }

    protected void bindType()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_TYPE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_TYPE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_TYPE ";

        fldType.DataSource = GetData(queryString);
        fldType.DataTextField = "FLD_TYPE";
        fldType.DataValueField = "FLD_TYPE";
        fldType.DataBind();
        fldType.Items.Insert(0, new ListItem("-- Please select Type --", ""));
    }

    protected void bindCompany()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        dropCompany.DataSource = GetData(queryString);
        dropCompany.DataTextField = "FLD_COMPANY";
        dropCompany.DataValueField = "FLD_COMPANY";
        dropCompany.DataBind();
        dropCompany.Items.Insert(0, new ListItem("-- Please select Company --", ""));
    }

    protected void bindAuthor()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_AUTHOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_AUTHOR IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_AUTHOR ";

        dropAuthor.DataSource = GetData(queryString);
        dropAuthor.DataTextField = "FLD_AUTHOR";
        dropAuthor.DataValueField = "FLD_AUTHOR";
        dropAuthor.DataBind();
        dropAuthor.Items.Insert(0, new ListItem("-- Please select Author --", ""));
    }

    protected void bindIndex()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_INDEX ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_INDEX IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_INDEX ";

        dropIndex.DataSource = GetData(queryString);
        dropIndex.DataTextField = "FLD_INDEX";
        dropIndex.DataValueField = "FLD_INDEX";
        dropIndex.DataBind();
        dropIndex.Items.Insert(0, new ListItem("-- Please select File Index --", ""));
    }

    protected void bindYear()
    {
        queryString = "";
        queryString = queryString + " SELECT        distinct YEAR(FLD_IN_DATE) AS FLD_IN_DATE  ";
        queryString = queryString + " FROM          EDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_IN_DATE IS NOT NULL ";
        queryString = queryString + "               AND FLD_IN_DATE <> ' ' ";
        queryString = queryString + " ORDER BY      FLD_IN_DATE ";

        dropYear.DataSource = GetData(queryString);
        dropYear.DataTextField = "FLD_IN_DATE";
        dropYear.DataValueField = "FLD_IN_DATE";
        dropYear.DataBind();
        dropYear.Items.Insert(0, new ListItem("-- Please select Year --", ""));
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

    

    protected void GridViewResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        var row = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
        
        var serialnoLabel = row.FindControl("FLD_IN_SERIAL") as Label;        
        lblMessage.Text = serialnoLabel.Text;
        
        var projectLabel = row.FindControl("PROJECT_CODE") as Label;
        lblMessage1.Text = projectLabel.Text;

        var file = new System.IO.FileInfo(@"c:/dc/" + lblMessage1.Text + "/incoming/20" + lblMessage.Text.Substring(10, 2) + "/" + lblMessage.Text.Substring(4, 8) + ".pdf");
       
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('No document found! Please contact your Document Controller.')", true);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session.Remove("ITrackNo");
        Session.Remove("IRefNo");
        Session.Remove("IDate1");
        Session.Remove("IDate2");
        Session.Remove("IPackage");
        Session.Remove("IType");
        Session.Remove("ISubject");
        Session.Remove("IAuthor");
        Session.Remove("ICompany");
        Session.Remove("IIndex");
        Session.Remove("IYear");
        Session.Remove("IAttach");

        Table2.Visible = false;
            
        Response.Redirect("In_Search_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]);
    }
            
    public void GridViewBind()
    {
        String str;
        
        search_Word = fldSubject.Text.Trim();
        search_Word1 = fldRefNo.Text.Trim();
        search_Word2 = fldAttach.Text.Trim();

        String sql_dt, sql_company, sql_package, sql_type, sql_author, sql_index, sql_year;

        if (fldDate1.Text != "" && fldDate2.Text != "")
        { sql_dt = " AND FLD_CORR_DATE >= '" + fldDate1.Text + "' AND FLD_CORR_DATE <= '" + fldDate2.Text + "' "; }
        else
        { sql_dt = "AND 1=1 "; }

        if (dropCompany.SelectedIndex != 0)
        {   sql_company = "AND (FLD_COMPANY = '" + dropCompany.SelectedValue + "') "; }
        else
        {   sql_company = "AND 1=1 "; }

        if (dropPackage.SelectedIndex != 0)
        {   sql_package = "AND (FLD_PACKAGE = '" + dropPackage.SelectedValue + "') "; }
        else
        {   sql_package = "AND 1=1 "; }

        if (fldType.SelectedIndex != 0)
        {   sql_type = "AND (FLD_TYPE = '" + fldType.SelectedValue + "') "; }
        else
        {   sql_type = "AND 1=1 "; }

        if (dropAuthor.SelectedIndex != 0)
        {   sql_author = "AND (FLD_AUTHOR = '" + dropAuthor.SelectedValue + "') "; }
        else
        {   sql_author = "AND 1=1 "; }

        if (dropIndex.SelectedIndex != 0)
        {   sql_index = "AND (FLD_INDEX = '" + dropIndex.SelectedValue + "') "; }
        else
        {   sql_index = "AND 1=1 "; }

        if (dropYear.SelectedIndex != 0)
        {   sql_year = "AND (YEAR(FLD_IN_DATE) = '" + dropYear.SelectedValue + "') "; }
        else
        {   sql_year = "AND 1=1 "; }

        if (fldAttach.Text != "")
        {
            str = "SELECT DISTINCT YR, YEAR([FLD_IN_DATE]), PROJECT_CODE, FLD_IN_DATE, TRACK_NO, FLD_IN_SERIAL, ID, FLD_REFERENCE, FLD_CORR_DATE, FLD_PACKAGE, FLD_TITLE1, FLD_AUTHOR, FLD_COMPANY, CONFIDENTIAL, FLD_TYPE, FLD_INDEX FROM VW_EDMS_IN_DOCUMENT_ATTACH WHERE PROJECT_CODE = '" + Request.QueryString["ID1"] + "' "
                + "AND (FLD_IN_SERIAL LIKE '%' + @search2 + '%') "
                + "AND (FLD_TITLE1 LIKE '%' + @search + '%') "
                + "AND (FLD_REFERENCE LIKE '%' + @search1 + '%') "
                + "AND (FLD_ATCH_TITLE LIKE '%' + @search3 + '%') "
                + "" + sql_dt + " "
                + "" + sql_company + " "
                + "" + sql_package + " "
                + "" + sql_type + " "
                + "" + sql_author + " "
                + "" + sql_index + " "
                + "" + sql_year + " "
                + "ORDER BY YEAR([FLD_IN_DATE]) DESC, FLD_IN_SERIAL DESC";

            SqlCommand xp = new SqlCommand(str, con);

            xp.Parameters.Add("@search3", ((object)fldAttach.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search2", ((object)fldTrackNo.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search", ((object)fldSubject.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search1", ((object)fldRefNo.Text.Trim()) ?? DBNull.Value);

            con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewResult.DataSource = ds;
            GridViewResult.DataBind();
            con.Close();
        }
        else if (fldDate1.Text != "" || fldDate2.Text != "" || dropCompany.SelectedIndex != 0 || dropPackage.SelectedIndex != 0 || fldType.SelectedIndex != 0 || dropAuthor.SelectedIndex != 0 || dropIndex.SelectedIndex != 0 || dropYear.SelectedIndex != 0)
        {
            str = "SELECT * FROM VWEDMS_IN_DOCUMENT WHERE PROJECT_CODE = '" + Request.QueryString["ID1"] + "' "
                + "AND (FLD_IN_SERIAL LIKE '%' + @search2 + '%') "
                + "AND (FLD_TITLE1 LIKE '%' + @search + '%') "
                + "AND (FLD_REFERENCE LIKE '%' + @search1 + '%') "
                + "" + sql_dt + " "
                + "" + sql_company + " "
                + "" + sql_package + " "
                + "" + sql_type + " "
                + "" + sql_author + " "
                + "" + sql_index + " "
                + "" + sql_year + " "
                + "ORDER BY YEAR([FLD_IN_DATE]) DESC, FLD_IN_SERIAL DESC";

            SqlCommand xp = new SqlCommand(str, con);

            xp.Parameters.Add("@search3", ((object)fldAttach.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search2", ((object)fldTrackNo.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search", ((object)fldSubject.Text.Trim()) ?? DBNull.Value);
            xp.Parameters.Add("@search1", ((object)fldRefNo.Text.Trim()) ?? DBNull.Value);

            con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridViewResult.DataSource = ds;
            GridViewResult.DataBind();
            con.Close();
        }

        
    }
         
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean chckerror = true; 
        
        Table2.Visible = true;
        tblResultNote.Visible = true;
        GridViewBind();

        if (chckerror == true)
        {
            Session["ITrackNo"] = fldTrackNo.Text; 
            Session["IRefNo"] = fldRefNo.Text;
            Session["IDate1"] = fldDate1.Text;
            Session["IDate2"] = fldDate2.Text;
            Session["IPackage"] = dropPackage.SelectedValue;
            Session["IType"] = fldType.SelectedValue;
            Session["ISubject"] = fldSubject.Text;
            Session["IAuthor"] = dropAuthor.SelectedValue;
            Session["ICompany"] = dropCompany.SelectedValue;
            Session["IIndex"] = dropIndex.SelectedValue;
            Session["IYear"] = dropYear.SelectedValue;
            Session["IAttach"] = fldAttach.Text;

            // Bind gridview
            GridViewBind();
        }

        for (int i = 0; i < GridViewResult.Rows.Count; i++)
        {
            
            GridViewRow row = GridViewResult.Rows[i];

            GridViewResult.HeaderRow.Cells[3].Visible = false;

            row.Cells[3].Visible = false;

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
                row.Cells[10].Style.Add("background-color", "#FFECEC");
                row.Cells[11].Style.Add("background-color", "#FFECEC");
                row.Cells[12].Style.Add("background-color", "#FFECEC");
                row.Cells[13].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=incoming_search_result.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        
        //Hides the first column in the grid (zero-based index).
        GridViewResult.HeaderRow.Cells[1].Visible = false;
        GridViewResult.HeaderRow.Cells[2].Visible = false;
        GridViewResult.HeaderRow.Cells[3].Visible = true;
        GridViewResult.HeaderRow.Cells[13].Visible = false;

        foreach (GridViewRow row in GridViewResult.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                row.Cells[0].VerticalAlign = VerticalAlign.Top;
                row.Cells[3].VerticalAlign = VerticalAlign.Top;                
                row.Cells[4].VerticalAlign = VerticalAlign.Top;
                row.Cells[5].VerticalAlign = VerticalAlign.Top;
                row.Cells[6].VerticalAlign = VerticalAlign.Top;
                row.Cells[7].VerticalAlign = VerticalAlign.Top;
                row.Cells[8].VerticalAlign = VerticalAlign.Top;
                row.Cells[9].VerticalAlign = VerticalAlign.Top;
                row.Cells[10].VerticalAlign = VerticalAlign.Top;
                row.Cells[11].VerticalAlign = VerticalAlign.Top;
                row.Cells[12].VerticalAlign = VerticalAlign.Top;
            }
        }

        //Loop through the rows and hide the cell in the first column.
        for (int i = 0; i < GridViewResult.Rows.Count; i++)
        {
            GridViewRow row = GridViewResult.Rows[i];
            row.Cells[1].Visible = false;
            row.Cells[2].Visible = false;
            row.Cells[3].Visible = true;
            row.Cells[13].Visible = false;

            //Apply text style to each row.
            row.Attributes.Add("class", "textmode");

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[3].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[4].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[5].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[6].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[7].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[8].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[9].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[10].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[11].Style.Add("background-color", "LightGoldenrodYellow");
                row.Cells[12].Style.Add("background-color", "LightGoldenrodYellow");
            }
        }

        //Display project details.
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          PROJECT ";
        queryString = queryString + " WHERE         PROJECT_CODE='" + Request.QueryString["ID1"] + "'";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        row1 = null;
        row1 = dtChck.Rows[0];

        GridViewResult.RenderControl(htw);

        string header = @"<table><tr><td colspan='11'><b>Electronic Document Management System</b></td></tr> " +
            "<tr><td colspan='11'><b>Incoming Module : Search Result</b></td></tr>" +
            "<tr><td colspan='11'><b>Project : " + row1["PROJECT_CODE"].ToString() + " - " + row1["DESCRIPTION"].ToString() + "</b></td></tr>" +
            "<tr><td colspan='11'></td></tr>" +
            "</table>";

        Response.Write(header);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);

        Response.Write(sw.ToString());
        Response.End();
    }
    
    protected void GridViewResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            Label fldinserial = e.Row.FindControl("FLD_IN_SERIAL") as Label;
            Label projectcode = e.Row.FindControl("PROJECT_CODE") as Label;
            Label urgency = e.Row.FindControl("FLD_URGENCY") as Label;
            Label attachment = e.Row.FindControl("lblAttachment") as Label;

            Label yr = e.Row.FindControl("YR") as Label;
            Label track_no = e.Row.FindControl("TRACK_NOS") as Label;
            Label lblConfidential = e.Row.FindControl("lblConfidential") as Label;
            Label lblID = e.Row.FindControl("lblID") as Label;

            string pnc = lblConfidential.Text;
            string id = lblID.Text;
                            
                //var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + projectcode.Text + "/incoming/" + yr.Text + "/" + track_no.Text + ".pdf");

                //if (file2.Exists)
                //{ }
                //else
                //{
                //    //find you image and hide it
                //    var element = e.Row.FindControl("imageid");
                //    //hide it
                //    Image img2 = (Image)e.Row.FindControl("img_all");
                //    img2.Visible = false;
                //}

            //check for confidential documents by user role
            //restricted to DC & PM/HOD only
            if (pnc == "1")
            {
                cmd = new SqlCommand();
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                cmd = new SqlCommand("SELECT * FROM PROJECTUSERS WHERE STAFF_NO='" + Request.QueryString["ID"] + "' AND PROJECT_CODE='" + Request.QueryString["ID1"] + "'", con);
                cmd.CommandTimeout = 0;

                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                row1 = null;
                row1 = dt1.Rows[0];

                var file1 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + projectcode.Text + "/incoming/" + yr.Text + "/" + id + "/" + track_no.Text + ".pdf");

                if (file1.Exists)
                {

                    if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC" || row1["TYPE"].ToString() == "PM")
                    //if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "PM")
                    {
                        Image img2 = (Image)e.Row.FindControl("img_all");
                        img2.Visible = false;

                        Image imgSecure = (Image)e.Row.FindControl("imgSecure");
                        imgSecure.Visible = true;

                    }
                    else
                    {
                        Image img2 = (Image)e.Row.FindControl("img_all");
                        img2.Visible = false;

                        Image imgSecure = (Image)e.Row.FindControl("imgSecure");
                        imgSecure.Visible = false;

                    }
                }

                con.Close();
            }

            else
            {

                var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + projectcode.Text + "/incoming/" + yr.Text + "/" + track_no.Text + ".pdf");

                if (file2.Exists)
                {
                    Image img2 = (Image)e.Row.FindControl("img_all");
                    img2.Visible = true;

                    Image imgSecure = (Image)e.Row.FindControl("imgSecure");
                    imgSecure.Visible = false;
                }
                else
                {
                    Image img2 = (Image)e.Row.FindControl("img_all");
                    img2.Visible = false;

                    Image imgSecure = (Image)e.Row.FindControl("imgSecure");
                    imgSecure.Visible = false;
                }
            }
                

            string OutId = GridViewResult.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView GridViewAttachment = e.Row.FindControl("GridViewAttachment") as GridView;

            var dataSource1 = GetData(string.Format("select * from EDMS_IN_ATTACH where ID='{0}'", OutId));
            
            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                GridViewAttachment.DataSource = GetData(string.Format("select * from EDMS_IN_ATTACH where ID='{0}'", OutId));
                GridViewAttachment.DataBind();
                attachment.Visible = false;
            }
            else
            {
                attachment.Visible = true;
                attachment.Text = "-";
            }

            //Enable @ disable link to edit page by user role
            Label lblTNo = e.Row.FindControl("lblTNo") as Label;

            cmd = new SqlCommand();
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand("SELECT * FROM PROJECTUSERS WHERE STAFF_NO='" + Request.QueryString["ID"] + "' AND PROJECT_CODE='" + Request.QueryString["ID1"] + "'", con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            row1 = null;
            row1 = dt2.Rows[0];

            if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC")
            {
                lblTNo.Visible = true;
                fldinserial.Visible = false;
            }
            else
            {
                lblTNo.Visible = true;
                fldinserial.Visible = false;
            }
                        
            con.Close();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
      /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
         server control at run time. */
    }
    
}

    