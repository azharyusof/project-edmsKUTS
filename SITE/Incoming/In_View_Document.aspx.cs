using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class SITE_Incoming_In_View_Document : System.Web.UI.Page
{
    public SqlConnection con;
    public string spname = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            lblProjectCode.Text = Request.QueryString["ID1"];
            hid_Year.Value = getCurrentYear();

            this.bindOriginator();

            this.bindGridViewInDoc(getCurrentYear());
        }
    }

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        con = new SqlConnection(constr);
        con.Open();
    }

    protected void bindOriginator()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindOriginator", con);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);
        fldOriginator.DataSource = dt;
        fldOriginator.DataTextField = "FLD_COMPANY";
        fldOriginator.DataValueField = "FLD_COMPANY";
        fldOriginator.DataBind();
        fldOriginator.Items.Insert(0, new ListItem("Please select Originator", ""));
    }

    protected void bindGridViewInDoc(string yr)
    {
        this.connection();

        SqlCommand cmd = new SqlCommand();

        if (fldOriginator.SelectedIndex != 0)
        {
            spname = "spbindGridViewInDocSelected";

            cmd = new SqlCommand(spname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
            cmd.Parameters.AddWithValue("@company", fldOriginator.SelectedValue);
            cmd.Parameters.AddWithValue("@year", yr);
            cmd.CommandTimeout = 0;
        }
        else
        {
            spname = "spbindGridViewInDocAll";

            cmd = new SqlCommand(spname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);
            cmd.Parameters.AddWithValue("@year", yr);
            cmd.CommandTimeout = 0;
        }

        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        GridViewInDoc.DataSource = dt;
        GridViewInDoc.DataBind();
    }

    protected string getCurrentYear()
    {
        string current_year = "";

        if (string.IsNullOrEmpty(Request.QueryString["Year"]))
        {
            this.connection();

            SqlCommand cmd = new SqlCommand("spGetCurrentYear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@projectCode", lblProjectCode.Text);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 0)
            {
                current_year = DateTime.Now.ToString("yyyy");
            }
            else
            {
                DataRow row = dt.Rows[0];
                current_year = Convert.ToString(row["yr"]);
            }
        }
        else
        {
            current_year = Convert.ToString(Request.QueryString["Year"]);
        }
        return current_year;
    }

    protected void fldOriginator_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGridViewInDoc(getCurrentYear());
    }

    protected void GridViewInDoc_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewInDoc.PageIndex = e.NewPageIndex;
        this.bindGridViewInDoc(getCurrentYear());
    }

    protected void GridViewInDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label projectcode = e.Row.FindControl("PROJECT_CODE") as Label;
            Label companycode = e.Row.FindControl("COMPANY_CODE") as Label;
            Label year = e.Row.FindControl("YR") as Label;
            Label serialno = e.Row.FindControl("FLD_IN_SERIAL") as Label;
            Label noid = e.Row.FindControl("ID") as Label;
            Label confidential = e.Row.FindControl("lblConfidential") as Label;
            Label attach = e.Row.FindControl("lblAttach") as Label;

            string pnc = confidential.Text;
            string id = noid.Text;

            if (pnc == "1")
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Closed)
                { 
                    con.Open(); 
                }

                cmd = new SqlCommand("spInViewDocCheckUserType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", Request.QueryString["ID"]);
                cmd.Parameters.AddWithValue("@projectCode", Request.QueryString["ID1"]);

                cmd.CommandTimeout = 0;
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                DataRow row1 = dt1.Rows[0];

                var file1 = new System.IO.FileInfo(@"E:/Webapps/EDMS_STR/Document/" + projectcode.Text + "/" + companycode.Text + "/incoming/" + year.Text + "/" + id + "/" + serialno.Text + ".pdf");

                if (file1.Exists)
                {
                    if (row1["TYPE"].ToString() == "SUPERADMIN" || row1["TYPE"].ToString() == "DC" || row1["TYPE"].ToString() == "PM")
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
                var file2 = new System.IO.FileInfo(@"E:/Webapps/EDMS_STR/Document/" + projectcode.Text + "/" + companycode.Text + "/incoming/" + year.Text + "/" + serialno.Text + ".pdf");

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

            string CINId = GridViewInDoc.DataKeys[e.Row.RowIndex].Value.ToString();

            GridView GridViewAttach = e.Row.FindControl("GridViewAttach") as GridView;

            var dataSource1 = GetData(string.Format("select * from EDMS_IN_ATTACH where ID='{0}'", CINId));

            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                GridViewAttach.DataSource = GetData(string.Format("select * from EDMS_IN_ATTACH where ID='{0}'", CINId));
                GridViewAttach.DataBind();
                attach.Visible = false;
            }
            else
            {
                attach.Visible = true;
                attach.Text = "-";
            }

            Image imgActionee = (Image)e.Row.FindControl("img_actionee");

            var dataSource2 = GetData(string.Format("select * from EDMS_IN_ACTIONEE where ID='{0}'", CINId));

            int count2 = dataSource2.Rows.Count;
            if (count2 > 0)
            {
                imgActionee.Visible = true;
            }
            else
            {
                imgActionee.Visible = false;
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