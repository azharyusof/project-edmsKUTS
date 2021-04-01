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
using Microsoft.VisualBasic;

public partial class ADMIN_Add_UserRole : System.Web.UI.Page
{
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
        
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            // Reset error.
            errDvfldPName.Visible = false;
            errDvfldStaffNo.Visible = false;
            errDvfldRole.Visible = false;
            dvReset.Visible = false;
                        
            // Bind dropdownlist template.            
            bindUser();
            bindProject();
            bindRole();
        }
    }

    protected void bindUser()
    {
        queryString = "";
        queryString = queryString + " SELECT * ";
        queryString = queryString + " FROM TBLSTAFF ";
        queryString = queryString + " ORDER BY STAFFNAME";

        fldStaffNo.DataSource = GetData(queryString);
        fldStaffNo.DataTextField = "STAFFNAME";
        fldStaffNo.DataValueField = "STAFFNO";
        fldStaffNo.DataBind();
        fldStaffNo.Items.Insert(0, new ListItem("-- Please select Staff Name --", ""));
    }

    protected void bindProject()
    {
        queryString = "";
        queryString = queryString + " SELECT PROJECT_CODE, PROJECT_CODE + ' - ' + DESCRIPTION as 'mycolumn' ";
        queryString = queryString + " FROM PROJECT ";
        queryString = queryString + " ORDER BY PROJECT_CODE";

        fldPName.DataSource = GetData(queryString);
        fldPName.DataTextField = "mycolumn";
        fldPName.DataValueField = "PROJECT_CODE";
        fldPName.DataBind();
        fldPName.Items.Insert(0, new ListItem("-- Please select Project Name --", "")); 
    }

    protected void bindRole()
    {
        // Bind data to the Dropdownlist control.
        fldRole.Items.Insert(0, new ListItem("-- Please select Role --", ""));
        fldRole.Items.Insert(1, new ListItem("Document Controller", "DC"));
        fldRole.Items.Insert(2, new ListItem("Project Manager", "PM"));
        fldRole.Items.Insert(3, new ListItem("Project Team", "PT"));
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
        Response.Redirect("Add_UserRole.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"]);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fldPName.Text == "" && fldStaffNo.Text == "" && fldRole.Text == "")
        {
            errDvfldPName.Visible = true;
            errDvfldStaffNo.Visible = true;
            errDvfldRole.Visible = true; 
        }
        else if (fldPName.Text == "")
        {
            errDvfldPName.Visible = true;
        }
        else if (fldStaffNo.Text == "")
        {
            errDvfldStaffNo.Visible = true;
        }
        else if (fldRole.Text == "")
        {
            errDvfldRole.Visible = true;
        }
        else
        {
            con.Open();
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand("INSERT INTO PROJECTUSERS (PROJECT_CODE, STAFF_NO, TYPE) VALUES "
              + "(@pname, "
              + "@staffno, "
              + "@role)", con);

            command.Parameters.AddWithValue("@pname", fldPName.Text);
            command.Parameters.AddWithValue("@staffno", fldStaffNo.Text);
            command.Parameters.AddWithValue("@role", fldRole.Text);            

            command.ExecuteNonQuery();

            //Update role
            SqlCommand command1 = new SqlCommand("UPDATE tblLogin SET EDMS_GDCLevel=@role WHERE StaffNo='" + fldStaffNo.Text + "'", con);

            command1.Parameters.AddWithValue("@role", fldRole.Text.ToLower());

            command1.ExecuteNonQuery();
            con.Close();
            
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Record has been successfully saved!');window.location='Add_UserRole.aspx?ID=" + Request.QueryString["id"] + "';", true);

        }
    }
    

}