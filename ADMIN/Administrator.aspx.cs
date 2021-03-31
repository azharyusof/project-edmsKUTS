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

    public partial class ADMIN_Administrator : System.Web.UI.Page
    {
        string queryString = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GEDMSConn"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staffno"] == null)
            {
                Response.Redirect("../Default.aspx", true);
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
           string strQuery = "select distinct staffno, staffname from vwStaff where edms_gdclevel='superadmin' order by StaffName";
            
            GridView1.DataSource = GetData(strQuery);
            GridView1.DataBind();

            
            lblMsg.Visible = false;
            lblNote.Visible = true;
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

        protected void AddNewRole(object sender, EventArgs e)
        {
            string UserName = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList1")).Text;
            
            if (!String.IsNullOrEmpty(UserName)) 
            {
                con.Open();
                
                string sql = "UPDATE tblLogin SET edms_gdclevel='superadmin' WHERE StaffNo = @username";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = UserName;
                cmd.ExecuteNonQuery();

                BindData();

                con.Close();
            }

            else
            {
                lblMsg.Visible = true;
                lblNote.Visible = false;
            }
        }

        protected void DeleteRole(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            con.Open();
            
            SqlCommand cmd = new SqlCommand("UPDATE tblLogin SET edms_gdclevel=null WHERE staffno=@ID", con);

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

    }



