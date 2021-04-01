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

public partial class SITE_Incoming_In_View_Status : System.Web.UI.Page
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

        this.connection();

        SqlCommand com = new SqlCommand("spCountIncomingStatus", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
        com.Parameters.AddWithValue("@fldInActionee", Request.QueryString["ID"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DataRow row = null;
        row = dt.Rows[0];

        lblPending.Text = row["TOTAL_PENDING"].ToString();
        lblCompleted.Text = row["TOTAL_COMPLETED"].ToString();
        lblInfo.Text = row["TOTAL_INFO"].ToString();

        con.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GridViewInStatus.Visible = true;
        RB1.Enabled = false;
        RB2.Enabled = false;
        RB3.Enabled = false;

        btnSubmit.Visible = false;

        this.connection();

        //Assigned Task - Pending
        if (RB1.Checked)
        {
            SqlCommand com = new SqlCommand("spInStatusSubmitPending", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
            com.Parameters.AddWithValue("@fldInActionee", Request.QueryString["ID"]);
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewInStatus.DataSource = dt;
            GridViewInStatus.DataBind();

            GridViewInStatus.HeaderRow.Cells[12].Visible = false;
            GridViewInStatus.HeaderRow.Cells[13].Visible = false;

            foreach (GridViewRow row in GridViewInStatus.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                }
            }
        }

        //Assigned Task - Completed
        if (RB2.Checked)
        {
            SqlCommand com = new SqlCommand("spInStatusSubmitCompleted", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
            com.Parameters.AddWithValue("@fldInActionee", Request.QueryString["ID"]);
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewInStatus.DataSource = dt;
            GridViewInStatus.DataBind();
        }

        //Info Only
        if (RB3.Checked)
        {
            SqlCommand com = new SqlCommand("spInStatusSubmitInfo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectCode", Request.QueryString["ID1"]);
            com.Parameters.AddWithValue("@fldInActionee", Request.QueryString["ID"]);
            com.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewInStatus.DataSource = dt;
            GridViewInStatus.DataBind();

            GridViewInStatus.HeaderRow.Cells[9].Visible = false;
            GridViewInStatus.HeaderRow.Cells[10].Visible = false;
            GridViewInStatus.HeaderRow.Cells[11].Visible = false;
            GridViewInStatus.HeaderRow.Cells[12].Visible = false;
            GridViewInStatus.HeaderRow.Cells[13].Visible = false;

            foreach (GridViewRow row in GridViewInStatus.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    row.Cells[9].Visible = false;
                    row.Cells[10].Visible = false;
                    row.Cells[11].Visible = false;
                    row.Cells[12].Visible = false;
                    row.Cells[13].Visible = false;
                }
            }
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("In_View_Status.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }

    protected void GridViewInStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label fldinserial = e.Row.FindControl("FLD_IN_SERIAL") as Label;
            Label lblTNo = e.Row.FindControl("lblTNo") as Label;
            Label projectcode = e.Row.FindControl("PROJECT_CODE") as Label;
            Label urgency1 = e.Row.FindControl("lblUrgency") as Label;

            Label yr = e.Row.FindControl("YR") as Label;
            Label track_no = e.Row.FindControl("TRACK_NO") as Label;

            Label FLD_ACTION_DATE = e.Row.FindControl("FLD_ACTION_DATE") as Label;
            Label FLD_OUT_REFERENCE = e.Row.FindControl("FLD_OUT_REFERENCE") as Label;
            Label FLD_ACTION_TAKEN = e.Row.FindControl("FLD_ACTION_TAKEN") as Label;

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

            if (RB2.Checked)
            {
                lblTNo.Visible = false;
                fldinserial.Visible = true;
            }

            if (RB3.Checked)
            {
                lblTNo.Visible = false;
                fldinserial.Visible = true;
            }

            var file2 = new System.IO.FileInfo(@"d:/EDMS_BHP/Document/" + projectcode.Text + "/incoming/" + yr.Text + "/" + track_no.Text + ".pdf");

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
}