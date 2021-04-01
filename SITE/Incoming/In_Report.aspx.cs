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

public partial class Incoming_In_Report : System.Web.UI.Page
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

            //Bind Status
            bindStatus();
            
            //Bind Tracking No
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

        if (fldTNo.SelectedIndex == -1 && fldDateFm.Text == "" && fldDateTo.Text == "" && fldDateFm1.Text == "" && fldDateTo1.Text == "")
        {
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

            if (fldDateFm.Text != "" && fldDateTo.Text != "" || fldTNo.SelectedIndex != -1)
            {

                GridViewResult.HeaderRow.Cells[9].Visible = false;
                GridViewResult.HeaderRow.Cells[10].Visible = false;

                row.Cells[9].Visible = false;
                row.Cells[10].Visible = false;
            }

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
                row.Cells[10].Style.Add("background-color", "#EEEEEE");
                
            }
        }
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=incoming_report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewResult.AllowPaging = false;
            GridViewResult.AllowSorting = false;
            GridViewResult.DataSource = GetdataGridview();
            GridViewResult.DataBind();

            foreach (GridViewRow row in GridViewResult.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = Color.LightGoldenrodYellow;
                    }
                    else
                    {
                        cell.BackColor = Color.White;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }

                    //Loop through the controls to be removed and replace then with Literal
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                            case "Label":
                                cell.Controls.Add(new Literal { Text = (control as Label).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }

            foreach (GridViewRow row in GridViewResult.Rows)
            {

                if (fldDateFm.Text != "" && fldDateTo.Text != "" || fldTNo.SelectedIndex != -1)
                {

                    GridViewResult.HeaderRow.Cells[9].Visible = false;
                    GridViewResult.HeaderRow.Cells[10].Visible = false;

                    row.Cells[9].Visible = false;
                    row.Cells[10].Visible = false;
                }
                
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
                    row.Cells[10].VerticalAlign = VerticalAlign.Top;
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

            if (fldDateFm.Text != "" && fldDateTo.Text != "" || fldTNo.SelectedIndex != -1)
            {
                string header = @"<table><tr><td colspan='9'><b>Electronic Document Management System</b></td></tr> " +
                "<tr><td colspan='9'><b>Incoming Listing Report</b></td></tr>" +
                "<tr><td colspan='9'><b>Project : " + row1["PROJECT_CODE"].ToString() + " - " + row1["DESCRIPTION"].ToString() + "</b></td></tr>" +
                "<tr><td colspan='9'></td></tr>" +
                "</table>";

                Response.Write(header);
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                string header = @"<table><tr><td colspan='11'><b>Electronic Document Management System</b></td></tr> " +
                "<tr><td colspan='11'><b>Incoming Listing Report</b></td></tr>" +
                "<tr><td colspan='11'><b>Project : " + row1["PROJECT_CODE"].ToString() + " - " + row1["DESCRIPTION"].ToString() + "</b></td></tr>" +
                "<tr><td colspan='11'></td></tr>" +
                "</table>";

                Response.Write(header);
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private DataView GetdataGridview()
    {
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + getPara();
        queryString = queryString + " ORDER BY      FLD_IN_TRACK_NO ";
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


    protected void bindStatus()
    {
        //Bind data to the Dropdownlist control.
        dropStatus.Items.Insert(0, new ListItem("-- Please select Status --", ""));
        dropStatus.Items.Insert(1, new ListItem("ALL", "ALL"));
        dropStatus.Items.Insert(2, new ListItem("Completed", "Completed"));
        dropStatus.Items.Insert(3, new ListItem("Pending", "Pending"));
    }

    protected void bindTrackingNo()
    {
        // Bind data to the Dropdownlist control.
        queryString = "";
        queryString = queryString + " SELECT        FLD_IN_SERIAL  ";
        queryString = queryString + " FROM          EDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND  FLD_IN_SERIAL IS NOT NULL ";
        queryString = queryString + "               AND FLD_IN_SERIAL <> ' ' ";
        queryString = queryString + " ORDER BY      RIGHT(FLD_IN_SERIAL,2), FLD_IN_SERIAL ";

        fldTNo.AppendDataBoundItems = true;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = queryString;
        cmd.Connection = con;
        try{
            con.Open();
            fldTNo.DataSource = cmd.ExecuteReader();
            fldTNo.DataTextField = "FLD_IN_SERIAL";
            fldTNo.DataValueField = "FLD_IN_SERIAL";
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
        {
            paraCheck += " AND FLD_IN_DATE >= '" + fldDateFm.Text + "' AND FLD_IN_DATE <= '" + fldDateTo.Text + "' ";
        }

        else if (fldDateFm.Text == "" && fldDateTo.Text == "" && fldTNo.SelectedIndex != -1)
        {
            foreach (int i in fldTNo.GetSelectedIndices())
            {
                dataList += "'" + fldTNo.Items[i].Value + "',";
            }
            dataList = dataList.Remove(dataList.Length - 1);
            paraCheck += " AND FLD_IN_SERIAL IN (" + dataList + ") ";
        }

        else if (fldDateFm.Text == "" && fldDateTo.Text == "" && fldTNo.SelectedIndex == -1 && fldDateFm1.Text != "" && fldDateTo1.Text != "") // && dropStatus.SelectedIndex != -1
        {
            if (dropStatus.SelectedValue == "ALL")
            {
                paraCheck += " AND FLD_IN_DATE >= '" + fldDateFm1.Text + "' AND FLD_IN_DATE <= '" + fldDateTo1.Text + "' AND (FLD_URGENCY IN ('1','2','3')) ";
            }
            else if (dropStatus.SelectedValue == "Completed")
            {
                paraCheck += " AND FLD_IN_DATE >= '" + fldDateFm1.Text + "' AND FLD_IN_DATE <= '" + fldDateTo1.Text + "' AND (FLD_URGENCY IN ('1','2','3')) AND (FLD_ACTION_DATE IS NOT NULL OR FLD_OUT_REFERENCE IS NOT NULL OR FLD_ACTION_TAKEN IS NOT NULL) ";
                               
            }
            else if (dropStatus.SelectedValue == "Pending")
            {
                paraCheck += " AND (FLD_IN_DATE >= '" + fldDateFm1.Text + "' AND FLD_IN_DATE <= '" + fldDateTo1.Text + "') AND (FLD_URGENCY IN ('1','2','3')) AND (FLD_ACTION_DATE IS NULL AND FLD_OUT_REFERENCE IS NULL AND FLD_ACTION_TAKEN IS NULL) ";
               
            }
        }
    
        return paraCheck;
    }

    public DataSet GetData(string queryString)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
        DataSet ds = new DataSet();

        try{
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx){
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("In_Report.aspx?ID=" + Request.QueryString["ID"] + "&ID1=" + Request.QueryString["ID1"]); 
    }
    
    protected void GridViewResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header){
            GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

            if (fldDateFm.Text != "" && fldDateTo.Text != "" || fldTNo.SelectedIndex != -1)
            {
                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Incoming Details";
                HeaderCell2.ColumnSpan = 11;
                HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell2.Font.Bold = true;
                HeaderCell2.BackColor = Color.Gray;
                HeaderCell2.ForeColor = Color.White;
                HeaderRow.Cells.Add(HeaderCell2);
            }
            else
            {
                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Incoming Details";
                HeaderCell2.ColumnSpan = 11;
                HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell2.Font.Bold = true;
                HeaderCell2.BackColor = Color.Gray;
                HeaderCell2.ForeColor = Color.White;
                HeaderRow.Cells.Add(HeaderCell2);
            }

            GridViewResult.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

    protected void GridViewResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            Label FLD_ACTION_DATE = e.Row.FindControl("FLD_ACTION_DATE") as Label;
            Label FLD_OUT_REFERENCE = e.Row.FindControl("FLD_OUT_REFERENCE") as Label;
            Label FLD_ACTION_TAKEN = e.Row.FindControl("FLD_ACTION_TAKEN") as Label;
            Label urgency1 = e.Row.FindControl("lblUrgency") as Label;
            string iText = urgency1.Text;
            string action_dt = FLD_ACTION_DATE.Text;
            string out_ref = FLD_OUT_REFERENCE.Text;
            string action_taken = FLD_ACTION_TAKEN.Text;
                        
            if (iText == "1")
            { 
                e.Row.Cells[9].Text = "High";
                e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            }
            else if (iText == "2")
            { 
                e.Row.Cells[9].Text = "Medium";
                e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
            }
            else if (iText == "3")
            { 
                e.Row.Cells[9].Text = "Low";
                e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
            }
            else if (iText == "4")
            { 
                e.Row.Cells[9].Text = "Info"; 
            }
            else 
            { 
                e.Row.Cells[9].Text = "-"; 
            }


            if (iText == null)
            {
                e.Row.Cells[10].Text = "-";                 
            }            
            else
            {

                if (Request.QueryString["ID1"] == "ATI" || Request.QueryString["ID1"] == "ATI-SO" || Request.QueryString["ID1"]=="NSE-API" || Request.QueryString["ID1"]=="NSE-APIP2" || Request.QueryString["ID1"]=="NSE-APIP2-SO" || Request.QueryString["ID1"]=="NSE-API-SO" || Request.QueryString["ID1"]=="NSE-BGI" || Request.QueryString["ID1"]=="NSE-BGIP2-SO" || Request.QueryString["ID1"]=="NSE-BGI-SO" || Request.QueryString["ID1"]=="NSE-SBI" || Request.QueryString["ID1"] == "NSE-SBI-SO")
                {
                    if (iText == "1" || iText == "2" || iText == "3")
                    {
                        if (action_dt == "" && action_taken == "")
                        {
                            e.Row.Cells[10].Text = "Pending";
                        }
                        else if (action_dt != "" || action_taken != "")
                        {
                            e.Row.Cells[10].Text = "Closed";
                        }
                    }
                    else
                    {
                        e.Row.Cells[10].Text = "-";
                    }
                }
                else
                {
                    if (iText == "1" || iText == "2" || iText == "3")
                    {
                        if (action_dt == "" && out_ref == "" && action_taken == "")
                        {
                            e.Row.Cells[10].Text = "Pending";
                        }
                        else
                        {
                            e.Row.Cells[10].Text = "Closed";
                        }
                    }
                    else
                    {
                        e.Row.Cells[10].Text = "-";
                    }
                }
                
            }

            
        }
    }
}