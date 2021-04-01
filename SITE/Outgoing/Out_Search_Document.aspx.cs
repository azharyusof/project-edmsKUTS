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

public partial class Outgoing_Out_Search_Document : System.Web.UI.Page
{
    String queryString = "";
    string Sort_Direction = "ID DESC";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected string search_Word = String.Empty;
    protected string search_Word1 = String.Empty;
    protected string search_Word2 = String.Empty;
    DataView dtVw;
    DataRow row1 = null;
    DataRow row = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        search_Word = fldSubject.Text.Trim();
        search_Word1 = fldCompany.Text;
        search_Word2 = fldAddressee.Text;

        if(!Page.IsPostBack)
        {
            // Reset error
            dvErrDate.Visible = false;
            Table2.Visible = false;
            tblResultNote.Visible = false;

            // Bind Package
            bindPackage();

            //Bind Type of Document
            bindType();

            // Bind Addressee
            bindAddressee();

            // Bind Company
            bindCompany();

            // Bind Originator
            bindOriginator();

            //Bind dropdown File Index. 
            bindIndex();

            // Bind Year
            bindYear();

            // Check Session
            chckSession();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean chckerror = true;

        // Reset error
        dvErrDate.Visible = false;
        Table2.Visible = true;
        tblResultNote.Visible = true;

        if(fldDateFm.Text != "" && fldDateTo.Text == ""){
            dvErrDate.Visible = true;
            chckerror = false;

            GridViewResult.DataSource = new List<string>();
            GridViewResult.DataBind();
        }

        if(chckerror == true){

            Session["TrackNo"] = fldTrackNo.Text;
            Session["RefNo"] = fldRefNo.Text;
            Session["DateFm"] = fldDateFm.Text;
            Session["DateTo"] = fldDateTo.Text;
            Session["Package"] = fldPackage.SelectedValue;
            Session["Type"] = fldType.SelectedValue;
            Session["Subject"] = fldSubject.Text.Trim();
            Session["Originator"] = fldOriginator.SelectedValue;
            Session["Index"] = dropIndex.SelectedValue;
            Session["Company"] = fldCompany.SelectedValue;
            Session["Addressee"] = fldAddressee.SelectedValue;
            Session["Year"] = fldYear.SelectedValue;

            // Bind gridview
            ViewState["SortExpr"] = Sort_Direction;
            DataView dv = GetdataGridview();
            GridViewResult.DataSource = dv;
            GridViewResult.DataBind();
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

    protected void btnReset_Click(object sender, EventArgs e)
    {        
        Session.Remove("TrackNo");
        Session.Remove("RefNo");
        Session.Remove("DateFm");
        Session.Remove("DateTo");
        Session.Remove("Package");
        Session.Remove("Type");
        Session.Remove("Subject");
        Session.Remove("Originator");
        Session.Remove("Index");
        Session.Remove("Company");
        Session.Remove("Addressee");
        Session.Remove("Year");

        Table2.Visible = false;

        Response.Redirect("Out_Search_Document.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"] + "&SeN=N");
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=outgoing_search_result.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter()){
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewResult.AllowPaging = false;
            GridViewResult.AllowSorting = false;
            GridViewResult.DataSource = GetdataGridview();
            GridViewResult.DataBind();

            // Hide column
            GridViewResult.HeaderRow.Cells[1].Visible = false;
            GridViewResult.HeaderRow.Cells[2].Visible = false;
            GridViewResult.HeaderRow.Cells[3].Visible = true;
            GridViewResult.HeaderRow.Cells[13].Visible = false;

            foreach (GridViewRow row in GridViewResult.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                    row.Cells[3].Visible = true;

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
                    row.Cells[13].VerticalAlign = VerticalAlign.Top;
                }
            }

            //Loop through the rows and hide the cell in the first column.
            for (int i = 0; i < GridViewResult.Rows.Count; i++)
            {
                GridViewRow row = GridViewResult.Rows[i];
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
                    row.Cells[13].Style.Add("background-color", "LightGoldenrodYellow");
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
                  
            GridViewResult.RenderControl(hw);

            string header = @"<table><tr><td colspan='13'><b>Electronic Document Management System</b></td></tr> " +
            "<tr><td colspan='13'><b>Outgoing Module : Search Result</b></td></tr>" +
            "<tr><td colspan='13'><b>Project : " + row1["PROJECT_CODE"].ToString() + " - " + row1["DESCRIPTION"].ToString() + "</b></td></tr>" +
            "<tr><td colspan='13'></td></tr>" +
            "</table>";

            Response.Write(header);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private DataView GetdataGridview()
    {
        queryString = "";
        queryString = queryString + " SELECT        DISTINCT VW_EDMS_OUT_DOCUMENT_ADDRESSEE.ID, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.YR, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.TRACK_NO, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.PROJECT_CODE, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_OUT_SERIAL, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_REFERENCE, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_DOC_DATE, YEAR(VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_DOC_DATE), VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_PACKAGE, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_TYPE, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_TITLE1, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_ORIGINATOR, VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_INDEX, ";
        queryString = queryString + "               tblStaff.StaffName ";
        queryString = queryString + " FROM          VW_EDMS_OUT_DOCUMENT_ADDRESSEE ";
        queryString = queryString + " LEFT JOIN     tblStaff on tblStaff.StaffNo = VW_EDMS_OUT_DOCUMENT_ADDRESSEE.FLD_ORIGINATOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_OUT_SERIAL IS NOT NULL ";
        queryString = queryString + getPara();
        queryString = queryString + " ORDER BY      YEAR([FLD_DOC_DATE]) DESC,FLD_OUT_SERIAL DESC ";


        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (fldSubject.Text.Trim() != ""){
            foreach (DataRow row in dt.Rows){
                row["FLD_TITLE1"] = HighlightText(fldSubject.Text.Trim(), row["FLD_TITLE1"].ToString());
            }
        }

        if (fldRefNo.Text != "")
        {
            foreach (DataRow row in dt.Rows)
            {
                row["FLD_REFERENCE"] = HighlightText(fldRefNo.Text, row["FLD_REFERENCE"].ToString());
            }
        }

        if (fldTrackNo.Text != "")
        {
            foreach (DataRow row in dt.Rows)
            {
                row["FLD_OUT_SERIAL"] = HighlightText(fldTrackNo.Text, row["FLD_OUT_SERIAL"].ToString());
            }
        }
        con.Close();
        DataView dv = new DataView(dt);
        dv.Sort = ViewState["SortExpr"].ToString();
        return dv;
    }

    protected void chckSession()
    {
        Boolean chckSession = false;
        
        if (Session["TrackNo"] != null)
        {
            fldTrackNo.Text = Session["TrackNo"].ToString();
            chckSession = true;
        }

        if (Session["RefNo"] != null){
            fldRefNo.Text = Session["RefNo"].ToString();
            chckSession = true;
        }

        if (Session["DateFm"] != null){
            fldDateFm.Text = Session["DateFm"].ToString();
            chckSession = true;
        }

        if (Session["DateTo"] != null){
            fldDateTo.Text = Session["DateTo"].ToString();
            chckSession = true;
        }

        if (Session["Package"] != null){
            fldPackage.SelectedValue = Session["Package"].ToString();
            chckSession = true;
        }

        if (Session["Type"] != null)
        {
            fldType.SelectedValue = Session["Type"].ToString();
            chckSession = true;
        }

        if (Session["Subject"] != null){
            fldSubject.Text = Session["Subject"].ToString();
            chckSession = true;
        }

        if (Session["Originator"] != null){
            fldOriginator.SelectedValue = Session["Originator"].ToString();
            chckSession = true;
        }

        if (Session["Index"] != null)
        {
            dropIndex.SelectedValue = Session["Index"].ToString();
            chckSession = true;
        }

        if (Session["Company"] != null){
            fldCompany.SelectedValue = Session["Company"].ToString();
            chckSession = true;
        }

        if (Session["Addressee"] != null){
            fldAddressee.SelectedValue = Session["Addressee"].ToString();
            chckSession = true;
        }

        if (Session["Year"] != null){
            fldYear.SelectedValue = Session["Year"].ToString();
            chckSession = true;
        }

        if (chckSession == true){

            // Reset error
            dvErrDate.Visible = false;
            Table2.Visible = true;

            // Bind gridview
            ViewState["SortExpr"] = Sort_Direction;
            DataView dv = GetdataGridview();
            GridViewResult.DataSource = dv;
            GridViewResult.DataBind();
        }
    }

    protected void bindPackage()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        FLD_PACKAGE  ";
        queryString = queryString + " FROM          EDMS_PACKAGE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_PACKAGE IS NOT NULL ";
        queryString = queryString + "               AND FLD_PACKAGE <> '- Others -' ";
        queryString = queryString + " ORDER BY      FLD_PACKAGE ";

        fldPackage.DataSource = GetData(queryString);
        fldPackage.DataTextField = "FLD_PACKAGE";
        fldPackage.DataValueField = "FLD_PACKAGE";
        fldPackage.DataBind();
        fldPackage.Items.Insert(0, new ListItem("-- Please select Package --", ""));
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

    protected void bindAddressee()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_AUTHOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_AUTHOR IS NOT NULL ";
        queryString = queryString + "               AND FLD_AUTHOR <> ' ' ";
        queryString = queryString + " ORDER BY      FLD_AUTHOR ";

        fldAddressee.DataSource = GetData(queryString);
        fldAddressee.DataTextField = "FLD_AUTHOR";
        fldAddressee.DataValueField = "FLD_AUTHOR";
        fldAddressee.DataBind();
        fldAddressee.Items.Insert(0, new ListItem("-- Please select Addressee --", ""));
    }

    protected void bindCompany()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_COMPANY ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_COMPANY IS NOT NULL ";
        queryString = queryString + "               AND FLD_COMPANY <> ' ' ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldCompany.DataSource = GetData(queryString);
        fldCompany.DataTextField = "FLD_COMPANY";
        fldCompany.DataValueField = "FLD_COMPANY";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- Please select Company --", ""));
    }

    protected void bindOriginator()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        distinct FLD_ORIGINATOR, StaffName  ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " LEFT JOIN     tblStaff on tblStaff.StaffNo = EDMS_OUT_DOCUMENT.FLD_ORIGINATOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_ORIGINATOR IS NOT NULL ";
        queryString = queryString + "               AND FLD_ORIGINATOR <> ' ' ";
        queryString = queryString + " ORDER BY      StaffName ";
        
        fldOriginator.DataSource = GetData(queryString);
        fldOriginator.DataTextField = "StaffName";
        fldOriginator.DataValueField = "FLD_ORIGINATOR";
        fldOriginator.DataBind();
        fldOriginator.Items.Insert(0, new ListItem("-- Please select Originator --", ""));
    }

    protected void bindYear()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        distinct YEAR(FLD_DOC_DATE) AS FLD_DOC_DATE  ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_DOC_DATE IS NOT NULL ";
        queryString = queryString + "               AND FLD_DOC_DATE <> ' ' ";
        queryString = queryString + " ORDER BY      FLD_DOC_DATE ";

        fldYear.DataSource = GetData(queryString);
        fldYear.DataTextField = "FLD_DOC_DATE";
        fldYear.DataValueField = "FLD_DOC_DATE";
        fldYear.DataBind();
        fldYear.Items.Insert(0, new ListItem("-- Please select Year --", ""));
    }

    protected void GridViewResult_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewResult.PageIndex = 0;
        string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression){
            if (SortOrder[1] == "ASC"){
                ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            }
            else{
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
        }
        else{
            ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
        }
        GridViewResult.DataSource = GetdataGridview();
        GridViewResult.DataBind();
    }

    public string getPara()
    {
        string paraCheck = "";

        if (fldDateFm.Text != "" && fldDateTo.Text != "")
            paraCheck += " AND FLD_DOC_DATE >= '" + fldDateFm.Text + "' AND FLD_DOC_DATE <= '" + fldDateTo.Text + "' ";

        if (fldSubject.Text != "")
            paraCheck += " AND FLD_TITLE1 LIKE '%" + fldSubject.Text.Trim() + "%' ";

        if (fldPackage.SelectedIndex != 0)
            paraCheck += " AND FLD_PACKAGE = '" + fldPackage.SelectedValue + "' ";

        if (fldType.SelectedIndex != 0)
            paraCheck += " AND FLD_TYPE = '" + fldType.SelectedValue + "' ";

        if (fldTrackNo.Text != "")
            paraCheck += " AND FLD_OUT_SERIAL LIKE '%" + fldTrackNo.Text.Trim() + "%' ";

        if (fldRefNo.Text != "")
            paraCheck += " AND FLD_REFERENCE LIKE '%" + fldRefNo.Text.Trim() + "%' ";

        if (fldAddressee.SelectedIndex != 0)
            paraCheck += " AND FLD_ADDRESSEE = '" + fldAddressee.SelectedValue + "' ";

        if (fldCompany.SelectedIndex != 0)
            paraCheck += " AND FLD_COMPANY = '" + fldCompany.SelectedValue + "' ";

        if (fldOriginator.SelectedIndex != 0)
            paraCheck += " AND FLD_ORIGINATOR = '" + fldOriginator.SelectedValue + "' ";

        if (dropIndex.SelectedIndex != 0)
            paraCheck += " AND FLD_INDEX = '" + dropIndex.SelectedValue + "' ";

        if (fldYear.SelectedIndex != 0)
            paraCheck += " AND DATEPART(yyyy, FLD_DOC_DATE) LIKE '" + fldYear.SelectedValue + "' ";

        return paraCheck;
    }

    protected void GridViewResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[3].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Visible = false;

            Label fldoutserial = e.Row.FindControl("FLD_OUT_SERIAL") as Label;
            Label projectcode = e.Row.FindControl("PROJECT_CODE") as Label;
            Label yr = e.Row.FindControl("YR") as Label;
            Label track_no = e.Row.FindControl("TRACK_NO") as Label;
            Label attachment = e.Row.FindControl("lblAttachment") as Label;                 

                //var file2 = new System.IO.FileInfo(@"e:/dc/gdc/" + projectcode.Text + "/outgoing/" + yr.Text + "/" + track_no.Text + ".pdf");
                var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + projectcode.Text + "/outgoing/" + yr.Text + "/" + track_no.Text + ".pdf");

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
            
            
            string ID = GridViewResult.DataKeys[e.Row.RowIndex].Value.ToString();

            GridView GridViewCompany = e.Row.FindControl("GridViewCompany") as GridView;

            GridViewCompany.DataSource = SelectData("SELECT * FROM EDMS_OUT_ADDRESSEE WHERE ID = '" + ID + "'");
            GridViewCompany.DataBind();
            
            GridView GridViewAddressee = e.Row.FindControl("GridViewAddressee") as GridView;

            GridViewAddressee.DataSource = SelectData("SELECT * FROM EDMS_OUT_ADDRESSEE WHERE ID = '" + ID + "'");
            GridViewAddressee.DataBind();

            string OutId = GridViewResult.DataKeys[e.Row.RowIndex].Value.ToString();
            
            GridView GridViewAttachment = e.Row.FindControl("GridViewAttachment") as GridView;

            var dataSource2 = SelectData(string.Format("select * from EDMS_OUT_ATTACH where ID='{0}' and (FILENAME IS NOT NULL and FILENAME <> '')", OutId));
            //check number of rows here using count
            int count2 = dataSource2.Rows.Count;
            if (count2 > 0)
            {
                GridViewAttachment.DataSource = SelectData(string.Format("select * from EDMS_OUT_ATTACH where ID='{0}' and (FILENAME IS NOT NULL and FILENAME <> '')", OutId));
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

            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            row1 = null;
            row1 = dt1.Rows[0];

            if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC")
            {
                lblTNo.Visible = true;
                fldoutserial.Visible = false;
            }
            else
            {
                lblTNo.Visible = true;
                fldoutserial.Visible = false;
            }

            con.Close();
        }

    }

    private DataTable SelectData(string sqlQuery)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, connectionString))
        {
            DataTable dt = new DataTable("EDMS_OUT_DOCUMENT");
            sqlDataAdapter.Fill(dt);
            return dt;
        }
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

    protected string HighlightText(string searchWord, string inputText)
    {
        // Replace spaces by | for Regular Expressions
        Regex expression = new Regex(searchWord.Replace(" ", "|"), RegexOptions.IgnoreCase);
        return expression.Replace(inputText, new MatchEvaluator(ReplaceKeywords));
    }

    public string ReplaceKeywords(Match m)
    {
        return "<span style='background-color:yellow'>" + m.Value + "</span>";
    }
}