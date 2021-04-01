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

public partial class ADMIN_Manage_UserRole : System.Web.UI.Page
{
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);

    public SqlConnection conn;

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GDCConn"].ToString();
        conn = new SqlConnection(constr);
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!IsPostBack)
        {
            bindfldFilter();
        }
    }

    protected void fldFilter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fldFilter.Text = fldFilter.SelectedItem.Text;

        if (fldFilter.SelectedValue == "Project Name")
        {
            dvProject.Visible = true;
            dvStaff.Visible = false;
            dvfldProject.Visible = true;
            dvfldStaff.Visible = false;

            bindProject();
        }
        else if(fldFilter.SelectedValue == "Staff Name")
        {
            dvProject.Visible = false;
            dvStaff.Visible = true;
            dvfldProject.Visible = false;
            dvfldStaff.Visible = true;

            bindStaff();
        }
    }

    protected void bindProject()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindAdminProject", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldPName.DataSource = dt;
        fldPName.DataTextField = "mycolumn";
        fldPName.DataValueField = "PROJECT_CODE";
        fldPName.DataBind();
        fldPName.Items.Insert(0, new ListItem("-- Please select Project Name --", ""));
    }

    protected void bindStaff()
    {
        this.connection();

        SqlCommand com = new SqlCommand("spBindStaff", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        fldSName.DataSource = dt;
        fldSName.DataTextField = "STAFFNAME";
        fldSName.DataValueField = "STAFFNO";
        fldSName.DataBind();
        fldSName.Items.Insert(0, new ListItem("-- Please select Staff Name --", ""));
    }

    protected void bindfldFilter()
    {
        // Bind data to the Dropdownlist control.
        fldFilter.Items.Insert(0, new ListItem("Please Filter Type", ""));
        fldFilter.Items.Insert(1, new ListItem("Project Name", "Project Name"));
        fldFilter.Items.Insert(2, new ListItem("Staff Name", "Staff Name"));
    }

    private void BindData()
    {
        if (fldPName.SelectedIndex != 0 && fldSName.Text == "")
        {
            fldSName.SelectedIndex = -1;

            String strQuery = "SELECT * FROM TBLUSERLOGIN WHERE PROJECT_CODE = '" + fldPName.SelectedValue + "' AND TYPE <> 'superadmin' ORDER BY STAFFNAME";
            GridView1.DataSource = GetData(strQuery);
            GridView1.DataBind();

            fldSName.SelectedIndex = -1;
        }
        else if (fldSName.SelectedIndex != 0 && fldPName.Text == "")
        {
            fldPName.SelectedIndex = -1;
            String strQuery = "SELECT * FROM TBLUSERLOGIN WHERE STAFFNO = '" + fldSName.SelectedValue + "' AND TYPE <> 'superadmin' ORDER BY STAFFNAME";
            GridView1.DataSource = GetData(strQuery);
            GridView1.DataBind();

            fldPName.SelectedIndex = -1;
        }

        else
        {
            fldSName.SelectedIndex = -1;
            fldPName.SelectedIndex = -1;
        }

    }

    public DataSet GetData(string queryString)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);

            // Fill the DataSet.
            adapter.Fill(ds);
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_UserRole.aspx?ID=" + Request.QueryString["id"]);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (fldPName.Text == "" && fldSName.Text == "")
        {
        }
        else

        {
            BindData();
        }
    }

    protected void EditModel(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }

    protected void UpdateModel(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Type = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("dropType")).Text;
        string Initial = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("fldInitial")).Text;
        string Sorting = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("fldSorting")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE PROJECTUSERS SET Type=@type, STAFF_INITIAL=@initial, SORTING=@sorting WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = Type;
        cmd.Parameters.Add("@initial", SqlDbType.VarChar).Value = Initial;
        cmd.Parameters.Add("@sorting", SqlDbType.VarChar).Value = Sorting;

        cmd.ExecuteNonQuery();

        GridView1.EditIndex = -1;

        BindData();

        con.Close();
    }

    protected void DeleteModel(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from PROJECTUSERS where ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;

        cmd.ExecuteNonQuery();

        BindData();

        con.Close();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];

            if (fldPName.SelectedIndex != 0 && fldSName.Text == "")
            {
                row.Cells[2].Visible = false;
            }
            else if (fldSName.SelectedIndex != 0 && fldPName.Text == "")
            {
                row.Cells[2].Visible = true;
            }

        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (fldPName.SelectedIndex != 0 && fldSName.Text == "")
            {
                e.Row.Cells[2].Visible = false;
            }
            else if (fldSName.SelectedIndex != 0 && fldPName.Text == "")
            {
                e.Row.Cells[2].Visible = true;
            }
        }
    }
}