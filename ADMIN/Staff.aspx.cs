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

    public partial class ADMIN_Staff : System.Web.UI.Page
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
            string strQuery = "select staffid, staffno, staffname, email from tblStaff order by StaffName";
            
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

        protected void AddNewUser(object sender, EventArgs e)
        {
            string UserNo = ((TextBox)GridView1.FooterRow.FindControl("txtStaffNo")).Text.Trim();
            string UserName = ((TextBox)GridView1.FooterRow.FindControl("txtStaffName")).Text.Trim();
            string Email = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text.Trim();
            
            if (!String.IsNullOrEmpty(UserNo)) 
            {
                con.Open();

                //Add into tblStaff
                string sql = "INSERT INTO tblStaff (STAFFNO, STAFFNAME, EMAIL) VALUES (@userno, @username, @email)";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@userno", SqlDbType.VarChar).Value = UserNo;
                cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = UserName;
                cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = Email;

                cmd.ExecuteNonQuery();

                //Add into tblLogin
                string sql1 = "INSERT INTO tblLogin (STAFFNO, PWD) VALUES (@userno, @userno)";

                SqlCommand cmd1 = new SqlCommand(sql1, con);

                cmd1.Parameters.AddWithValue("@userno", SqlDbType.VarChar).Value = UserNo;
               
                cmd1.ExecuteNonQuery();

                BindData();

                con.Close();
            }

            else
            {
                lblMsg.Visible = true;
                lblNote.Visible = false;
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            con.Open();
            
            SqlCommand cmd = new SqlCommand("DELETE tblLogin WHERE staffno=@ID", con);

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;

            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("DELETE tblStaff WHERE staffno=@ID", con);

            cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;

            cmd1.ExecuteNonQuery();

            BindData();

            con.Close();
        }

        protected void EditCompany(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void UpdateCompany(object sender, GridViewUpdateEventArgs e)
        {
            string ID = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID")).Text;
            string UserName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffName")).Text.Trim();
            string Email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail")).Text.Trim();

            con.Open();
            SqlCommand cmd = new SqlCommand("update tblStaff set StaffName=@username, Email=@email where staffid=@ID", con);

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UserName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;

            cmd.ExecuteNonQuery();

            GridView1.EditIndex = -1;

            BindData();

            con.Close();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            BindData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {
            LinkButton lnkReset = (LinkButton)sender;
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE tblLogin SET Pwd=@ID WHERE staffno=@ID", con);

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkReset.CommandArgument;

            cmd.ExecuteNonQuery();            

            BindData();

            con.Close();
        }
    }



