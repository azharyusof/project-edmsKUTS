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
using System.Drawing;


public partial class Outgoing_Out_Report : System.Web.UI.Page
{
    string queryString = "";
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
            // Reset error
            dvErrDate.Visible = false;
            Table2.Visible = false;
            dvErrMsg.Visible = false;

            // Bind Tracking No
            bindTrackingNo();
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        Boolean chckerror = true;

        // Reset error
        dvErrDate.Visible = false;
        Table2.Visible = true;
        dvErrMsg.Visible = false;

        if (fldDateFm.Text != "" && fldDateTo.Text == ""){
            dvErrDate.Visible = true;
            chckerror = false;

            GridViewResult.DataSource = new List<string>();
            GridViewResult.DataBind();
        }

        if (fldTNo.SelectedIndex == -1 && fldDateFm.Text == "" && fldDateTo.Text == ""){
            dvErrMsg.Visible = true;
            chckerror = false;

            GridViewResult.DataSource = new List<string>();
            GridViewResult.DataBind();
        }

        if (chckerror == true){
            GridViewResult.DataSource = GetdataGridview();
            GridViewResult.DataBind();
        }

        for (int i = 0; i < GridViewResult.Rows.Count; i++)
        {
            GridViewRow row = GridViewResult.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#EEEEEE");
                row.Cells[1].Style.Add("background-color", "#EEEEEE");
                row.Cells[2].Style.Add("background-color", "#EEEEEE");
                row.Cells[3].Style.Add("background-color", "#EEEEEE");
                row.Cells[4].Style.Add("background-color", "#EEEEEE");
                row.Cells[5].Style.Add("background-color", "#EEEEEE");
                row.Cells[6].Style.Add("background-color", "#EEEEEE");
                row.Cells[7].Style.Add("background-color", "#EEEEEE");
                row.Cells[8].Style.Add("background-color", "#EEEEEE");
                row.Cells[9].Style.Add("background-color", "#EEEEEE");
            }
        }

    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=outgoing_report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewResult.AllowPaging = false;
            GridViewResult.AllowSorting = false;
            GridViewResult.DataSource = GetdataGridview();
            GridViewResult.DataBind();

            //foreach (GridViewRow row in GridViewResult.Rows)
            //{
            //    foreach (TableCell cell in row.Cells)
            //    {
            //        if (row.RowIndex % 2 == 0)
            //        {
            //            cell.BackColor = Color.LightGoldenrodYellow;
            //        }
            //        else
            //        {
            //            cell.BackColor = Color.White;
            //        }
            //        cell.CssClass = "textmode";
            //        List<Control> controls = new List<Control>();

            //        //Add controls to be removed to Generic List
            //        foreach (Control control in cell.Controls)
            //        {
            //            controls.Add(control);
            //        }

            //        //Loop through the controls to be removed and replace then with Literal
            //        foreach (Control control in controls)
            //        {
            //            switch (control.GetType().Name)
            //            {
            //                case "HyperLink":
            //                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
            //                    break;
            //                case "TextBox":
            //                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
            //                    break;
            //                case "LinkButton":
            //                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
            //                    break;
            //                case "CheckBox":
            //                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
            //                    break;
            //                case "RadioButton":
            //                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
            //                    break;
            //                case "Label":
            //                    cell.Controls.Add(new Literal { Text = (control as Label).Text });
            //                    break;
            //            }
            //            cell.Controls.Remove(control);
            //        }
            //    }
            //}

            foreach (GridViewRow row in GridViewResult.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    row.Cells[0].VerticalAlign = VerticalAlign.Top;
                    row.Cells[1].VerticalAlign = VerticalAlign.Top;
                    row.Cells[2].VerticalAlign = VerticalAlign.Top;
                    row.Cells[3].VerticalAlign = VerticalAlign.Top;
                    row.Cells[4].VerticalAlign = VerticalAlign.Top;
                    row.Cells[5].VerticalAlign = VerticalAlign.Top;
                    row.Cells[6].VerticalAlign = VerticalAlign.Top;
                    row.Cells[7].VerticalAlign = VerticalAlign.Top;
                    row.Cells[8].VerticalAlign = VerticalAlign.Top;
                    row.Cells[9].VerticalAlign = VerticalAlign.Top;
                    //row.Cells[10].VerticalAlign = VerticalAlign.Top;
                }
            }

            //Loop through the rows and hide the cell in the first column.
            for (int i = 0; i < GridViewResult.Rows.Count; i++)
            {
                GridViewRow row = GridViewResult.Rows[i];

                //Apply text style to each row.
                row.Attributes.Add("class", "textmode");

                //Apply style to individual cells of alternating row.
                if (i % 2 != 0)
                {
                    row.Cells[0].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[1].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[2].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[3].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[4].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[5].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[6].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[7].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[8].Style.Add("background-color", "LightGoldenrodYellow");
                    row.Cells[9].Style.Add("background-color", "LightGoldenrodYellow");
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

            string header = @"<table><tr><td colspan='12'><b>Electronic Document Management System</b></td></tr> " +
            "<tr><td colspan='12'><b>Outgoing Listing Report</b></td></tr>" +
            "<tr><td colspan='12'><b>Project : " + row1["PROJECT_CODE"].ToString() + " - " + row1["DESCRIPTION"].ToString() + "</b></td></tr>" +
            "<tr><td colspan='12'></td></tr>" +
            "</table>";

            Response.Write(header);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);

            //string style = @"<style> .textmode { } </style>";
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
        queryString = queryString + " SELECT        *, nameOriginator.StaffName AS OriginatorName ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " LEFT JOIN     tblStaff AS nameOriginator ON nameOriginator.StaffNo = EDMS_OUT_DOCUMENT.FLD_ORIGINATOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + getPara();
        queryString = queryString + " ORDER BY      ID, FLD_OUT_SERIAL ";
        

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        DataView dv = new DataView(dt);
        return dv;
    }

    protected void bindTrackingNo()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        FLD_OUT_SERIAL  ";
        queryString = queryString + " FROM          EDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND  FLD_OUT_SERIAL IS NOT NULL ";
        queryString = queryString + "               AND FLD_OUT_SERIAL <> ' ' ";
        queryString = queryString + " ORDER BY      FLD_BOOK_DATE, ID, FLD_OUT_SERIAL ";

        fldTNo.AppendDataBoundItems = true;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = queryString;
        cmd.Connection = con;
        try{
            con.Open();
            fldTNo.DataSource = cmd.ExecuteReader();
            fldTNo.DataTextField = "FLD_OUT_SERIAL";
            fldTNo.DataValueField = "FLD_OUT_SERIAL";
            fldTNo.DataBind();
        }
        catch (Exception ex){
            throw ex;
        }
        finally{
            con.Close();
        }
    }
    public string getPara()
    {
        string paraCheck = "";
        string dataList = "";

        if (fldDateFm.Text != "" && fldDateTo.Text != "")
            paraCheck += " AND FLD_DOC_DATE >= '" + fldDateFm.Text + "' AND FLD_DOC_DATE <= '" + fldDateTo.Text + "' ";

        if (fldTNo.SelectedIndex != -1)
        {
            foreach (int i in fldTNo.GetSelectedIndices())
            {
                dataList += "'" + fldTNo.Items[i].Value + "',";
            }
            dataList = dataList.Remove(dataList.Length - 1);
            paraCheck += " AND FLD_OUT_SERIAL IN (" + dataList + ") ";
        }
            
        return paraCheck;
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Out_Report.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]); 
    }

    protected void GridViewResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label company = e.Row.FindControl("lblCompany") as Label;
            Label addressee = e.Row.FindControl("lblAddressee") as Label;

            string OutId = GridViewResult.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView GridViewCompany = e.Row.FindControl("GridViewCompany") as GridView;

            var dataSource = GetData(string.Format("select * from EDMS_OUT_ADDRESSEE where ID='{0}'", OutId));
            
            int count = dataSource.Rows.Count;
            if (count > 0)
            {
                GridViewCompany.DataSource = GetData(string.Format("select * from EDMS_OUT_ADDRESSEE where ID='{0}'", OutId));
                GridViewCompany.DataBind();
            }
            else
            {
                company.Visible = true;
                company.Text = "-";
            }

            GridView GridViewAddressee = e.Row.FindControl("GridViewAddressee") as GridView;

            var dataSource1 = GetData(string.Format("select * from EDMS_OUT_ADDRESSEE where ID='{0}'", OutId));
            
            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                GridViewAddressee.DataSource = GetData(string.Format("select * from EDMS_OUT_ADDRESSEE where ID='{0}'", OutId));
                GridViewAddressee.DataBind();
            }
            else
            {
                addressee.Visible = true;
                addressee.Text = "-";
            }

        }       
            
    }


    protected void GridViewResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header){
            GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert); 

            TableCell HeaderCell2 = new TableCell();
            HeaderCell2.Text = "Booking Details";
            HeaderCell2.ColumnSpan = 3;
            HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell2.Font.Bold = true;
            HeaderCell2.BackColor = Color.Gray;
            HeaderCell2.ForeColor = Color.White;
            HeaderRow.Cells.Add(HeaderCell2);
 
            HeaderCell2 = new TableCell();
            HeaderCell2.Text = "Outgoing Details";
            HeaderCell2.ColumnSpan = 7;
            HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell2.Font.Bold = true;
            HeaderCell2.BackColor = Color.Gray;
            HeaderCell2.ForeColor = Color.White;
            HeaderRow.Cells.Add(HeaderCell2);

            GridViewResult.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

}