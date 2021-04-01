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

public partial class SITE_Outgoing_Out_Edit_Document : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    DataRow row1 = null;
    DateTime varDt;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["staffno"] == null)
        {
            Response.Redirect("../../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindPackage();
            bindDepartment();
            bindIndex();

            bindGridViewDetails();
            bindGridViewAttachment();
            bindGridViewAddressee();

            bindAddressee1();
        }
    }

    #region package
    protected void bindPackage()
    {
        queryString = "";
        queryString = queryString + " SELECT        distinct FLD_PACKAGE ";
        queryString = queryString + " FROM          EDMS_PACKAGE ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_PACKAGE IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_PACKAGE ";

        fldPackage.DataSource = GetData(queryString);
        fldPackage.DataTextField = "FLD_PACKAGE";
        fldPackage.DataValueField = "FLD_PACKAGE";
        fldPackage.DataBind();
        fldPackage.Items.Insert(0, new ListItem("-- Please select Package --", ""));
        fldPackage.Items.Insert(1, new ListItem("+ Add New Package +", "addNewPackage"));
    }

    protected void fldPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldPackage.SelectedIndex == 1)
            fldNewPackage.Visible = true;
        else
            fldNewPackage.Visible = false;
    }
    #endregion

    #region department
    protected void bindDepartment()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_DEPARTMENT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_DEPARTMENT IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_DEPARTMENT ";

        fldDepartment.DataSource = GetData(queryString);
        fldDepartment.DataTextField = "FLD_DEPARTMENT";
        fldDepartment.DataValueField = "FLD_DEPARTMENT";
        fldDepartment.DataBind();
        fldDepartment.Items.Insert(0, new ListItem("-- Please select Department --", ""));
        fldDepartment.Items.Insert(1, new ListItem("+ Add New Department +", "addNewDepartment"));
    }

    protected void fldDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldDepartment.SelectedIndex == 1)
            fldNewDepartment.Visible = true;
        else
            fldNewDepartment.Visible = false;
    }
    #endregion

    #region FileIndex
    protected void bindIndex()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_INDEX ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_INDEX IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_INDEX ";

        fldIndex.DataSource = GetData(queryString);
        fldIndex.DataTextField = "FLD_INDEX";
        fldIndex.DataValueField = "FLD_INDEX";
        fldIndex.DataBind();
        fldIndex.Items.Insert(0, new ListItem("-- Please select File Index --", ""));
        fldIndex.Items.Insert(1, new ListItem("+ Add New File Index +", "addNewIndex"));
    }

    protected void fldIndex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldIndex.SelectedIndex == 1)
            fldNewIndex.Visible = true;
        else
            fldNewIndex.Visible = false;
    }
    #endregion

    #region ddlAddressee
    protected void bindAddressee1()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_AUTHOR ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + "               AND FLD_AUTHOR IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_AUTHOR ";

        fldAddressee1.DataSource = GetData(queryString);
        fldAddressee1.DataTextField = "FLD_AUTHOR";
        fldAddressee1.DataValueField = "FLD_AUTHOR";
        fldAddressee1.DataBind();
        fldAddressee1.Items.Insert(0, new ListItem("-- Please select Addressee --", ""));
        fldAddressee1.Items.Insert(1, new ListItem("+ Add New Addressee +", "addNewAddressee"));
    }

    protected void fldAddressee1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldAddressee1.SelectedIndex == 1)
            fldNewAddressee.Visible = true;
        else
            fldNewAddressee.Visible = false;
    }
    #endregion

    #region ddlCompany
    protected void bindCompany()
    {
        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          EDMS_AUTHOR_COMPANY ";
        queryString = queryString + " WHERE         FLD_COMPANY IS NOT NULL ";
        queryString = queryString + " ORDER BY      FLD_COMPANY ";

        fldCompany.DataSource = GetData(queryString);
        fldCompany.DataTextField = "FLD_COMPANY";
        fldCompany.DataValueField = "FLD_COMPANY";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- Please select Company --", ""));
        fldCompany.Items.Insert(1, new ListItem("+ Add New Company +", "addNewCompany"));
    }

    protected void fldCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldCompany.SelectedIndex == 1)
            fldNewCompany.Visible = true;
        else
            fldNewCompany.Visible = false;
    }
    #endregion

    #region Attachment
    protected void bindGridViewAttachment()
    {
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_OUT_ATTACH ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        queryString = queryString + " ORDER BY      FLD_ATCH_TITLE ";

        GridViewAttachment.DataSource = GetData(queryString);
        GridViewAttachment.DataBind();

        for (int i = 0; i < GridViewAttachment.Rows.Count; i++)
        {
            GridViewRow row2 = GridViewAttachment.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row2.Cells[0].Style.Add("background-color", "#eeeeee");
                row2.Cells[1].Style.Add("background-color", "#eeeeee");
                row2.Cells[2].Style.Add("background-color", "#eeeeee");
            }
        }
    }

    protected void GridViewAttachment_DataBound(object sender, EventArgs e)
    {
        int rowCount = GridViewAttachment.Rows.Count;

        if (rowCount == 0)
        {
            GridViewAttachment.Visible = false;
        }
        else
        {
            GridViewAttachment.Visible = true;
        }
    }

    protected void GridViewAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("btnDelete");
            l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Attachment?')");
        }
    }

    protected void GridViewAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Delete the record.
            deleteRecordByAttachID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind addressee details.
        bindGridViewAttachment();
    }

    protected void deleteRecordByAttachID(string recID)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        cmd = new SqlCommand("SELECT FILENAME FROM EDMS_OUT_ATTACH WHERE RecID = @pRecID", con);
        cmd.Parameters.AddWithValue("@pRecID", recID);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);

        row = null;
        row = dtChck.Rows[0];

        string pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["id1"] + "/outgoing/attachment/" + Request.QueryString["id2"] + "/" + row["FILENAME"].ToString() + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        cmd1 = new SqlCommand("DELETE FROM EDMS_OUT_ATTACH WHERE RecID = @pRecID", con);
        cmd1.CommandTimeout = 0;
        cmd1.Parameters.AddWithValue("@pRecID", recID);
        cmd1.ExecuteNonQuery();

        con.Close();
    }

    protected void btnAddNewAttachment_Click(object sender, EventArgs e)
    {
        updateOut();

        //Attachment
        HttpFileCollection hfc = Request.Files;
        string Msg = null;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                string pathString = @"E:/Webapps/EDMS_STR/Document/" + Request.QueryString["ID1"] + "/outgoing/attachment/" + Request.QueryString["ID2"] + "";

                //E:\Webapps\EDMS_STR\Document\STR-HQ\outgoing\attachment\98

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                }
                else
                {
                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                }

                Msg += "<b>" + System.IO.Path.GetFileName(hpf.FileName.ToString()) + "</b> uploaded successfully.<br> ";

            }
            lblMessage.Text = "<b>" + Msg + "</b>";
        }

        //Insert into database.
        queryString = "";
        queryString = queryString + " INSERT INTO   EDMS_OUT_ATTACH ";
        queryString = queryString + "               (FILENAME, FLD_OUT_SERIAL, ID) ";
        queryString = queryString + " VALUES        (@pFILENAME, @pFLD_OUT_SERIAL, @pID) ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pFLD_OUT_SERIAL", lblTNo1.Text);

        //File Name
        cmd.Parameters.AddWithValue("@pFILENAME", FileUpload1.FileName);

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();
        con.Close();

        //Bind attachment details.
        bindGridViewAttachment();

        //Bind addressee details.
        bindGridViewAddressee();
    }
    #endregion

    #region Addressee
    protected void bindGridViewAddressee()
    {
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_OUT_ADDRESSEE ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        queryString = queryString + " ORDER BY      FLD_ADDRESSEE ";

        GridViewAddressee.DataSource = GetData(queryString);
        GridViewAddressee.DataBind();

        for (int i = 0; i < GridViewAddressee.Rows.Count; i++)
        {
            GridViewRow row2 = GridViewAddressee.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row2.Cells[0].Style.Add("background-color", "#eeeeee");
                row2.Cells[1].Style.Add("background-color", "#eeeeee");
                row2.Cells[2].Style.Add("background-color", "#eeeeee");
                row2.Cells[3].Style.Add("background-color", "#eeeeee");
            }
        }
    }

    protected void GridViewAddressee_DataBound(object sender, EventArgs e)
    {
        int rowCount = GridViewAddressee.Rows.Count;

        if (rowCount == 0)
        {
            GridViewAddressee.Visible = false;
        }
        else
        {
            GridViewAddressee.Visible = true;
        }
    }

    protected void GridViewAddressee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("btnDelete");
            l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Addressee?')");
        }
    }

    protected void GridViewAddressee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Delete the record.
            deleteRecordByID(Convert.ToString(e.CommandArgument));
        }
    }

    protected void GridViewAddressee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Bind addressee details.
        bindGridViewAddressee();
    }

    protected void deleteRecordByID(string recID)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand("DELETE FROM EDMS_OUT_ADDRESSEE WHERE RecID = @pRecID", con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pRecID", recID);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        updateOut();

        //Insert into database.
        queryString = "";
        queryString = queryString + " INSERT INTO   EDMS_OUT_ADDRESSEE ";
        queryString = queryString + "               (FLD_OUT_SERIAL, FLD_ADDRESSEE, FLD_COMPANY, ID) ";
        queryString = queryString + " VALUES        (@pFLD_OUT_SERIAL, @pFLD_ADDRESSEE, @pFLD_COMPANY, @pID) ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@pFLD_OUT_SERIAL", lblTNo.Text);

        //Addressee
        if (fldAddressee1.SelectedIndex == 1)
        {
            cmd.Parameters.AddWithValue("@pFLD_ADDRESSEE", fldNewAddressee.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_AUTHOR "
              + "(FLD_AUTHOR, PROJECT_CODE) "
              + "VALUES "
              + "(@new_addressee, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_addressee", fldNewAddressee.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldAddressee1.Text != "")
                cmd.Parameters.AddWithValue("@pFLD_ADDRESSEE", fldAddressee1.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@pFLD_ADDRESSEE", DBNull.Value);
        }

        //Company
        if (fldCompany.SelectedIndex == 1)
        {
            cmd.Parameters.AddWithValue("@pFLD_COMPANY", fldNewCompany.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_AUTHOR_COMPANY "
              + "(FLD_COMPANY, PROJECT_CODE) "
              + "VALUES "
              + "(@new_company, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_company", fldNewCompany.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldCompany.Text != "")
                cmd.Parameters.AddWithValue("@pFLD_COMPANY", fldCompany.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@pFLD_COMPANY", DBNull.Value);
        }

        cmd.Parameters.AddWithValue("@pID", Request.QueryString["ID2"]);
        cmd.ExecuteNonQuery();
        con.Close();

        //Reset dropdown.
        fldAddressee.SelectedIndex = 0;
        fldCompany.SelectedIndex = 0;

        //Bind attachment details.
        bindGridViewAttachment();

        //Bind addressee details.
        bindGridViewAddressee();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        fldAddressee.SelectedIndex = 0;
        fldNewAddressee.Text = "";
        fldNewAddressee.Visible = false;

        fldCompany.SelectedIndex = 0;
        fldNewCompany.Text = "";
        fldNewCompany.Visible = false;
    }
    #endregion

    #region btnUpdate
    protected void updateOut()
    {
        //Update details.
        queryString = "";
        queryString = queryString + " UPDATE        EDMS_OUT_DOCUMENT ";
        queryString = queryString + " SET           FLD_REFERENCE = @refno, ";
        queryString = queryString + "               FLD_ORIGINATOR = @originator, ";
        queryString = queryString + "               FLD_DOC_DATE = @docdt, ";
        queryString = queryString + "               FLD_PACKAGE = @package, ";
        queryString = queryString + "               FLD_DEPARTMENT = @dept, ";
        queryString = queryString + "               FLD_TITLE = @subject, ";
        queryString = queryString + "               FLD_INDEX = @index, ";
        queryString = queryString + "               FLD_REMARKS = @remarks, ";
        queryString = queryString + "               FLD_SENT_TO = @sentto, ";
        queryString = queryString + "               UpdatedBy = @updatedby, ";
        queryString = queryString + "               UpdatedDt = @updateddt ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        //Out Reference No.
        cmd.Parameters.AddWithValue("@refno", fldRefNo.Text.Trim().ToUpper());

        //Originator
        cmd.Parameters.AddWithValue("@originator", fldOriginator.Text.Trim().ToUpper());

        //Date of Document
        if (fldDocDate.Value != "")
        {
            cmd.Parameters.AddWithValue("@docdt", Convert.ToDateTime(fldDocDate.Value));
        }
        else
        {
            cmd.Parameters.AddWithValue("@docdt", DBNull.Value);
        }

        //Package
        if (fldPackage.SelectedIndex == 1)
        {
            cmd.Parameters.AddWithValue("@package", fldNewPackage.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_PACKAGE "
              + "(FLD_PACKAGE, PROJECT_CODE) "
              + "VALUES "
              + "(@new_package, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_package", fldNewPackage.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldPackage.Text != "")
                cmd.Parameters.AddWithValue("@package", fldPackage.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@package", DBNull.Value);
        }

        //Department
        if (fldDepartment.SelectedIndex == 1)
        {
            cmd.Parameters.AddWithValue("@dept", fldNewDepartment.Text);

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_DEPARTMENT "
              + "(FLD_DEPARTMENT, PROJECT_CODE) "
              + "VALUES "
              + "(@new_dept, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_dept", fldNewDepartment.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldDepartment.Text != "")
                cmd.Parameters.AddWithValue("@dept", fldDepartment.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@dept", DBNull.Value);
        }

        //Subject
        cmd.Parameters.AddWithValue("@subject", fldSubject.Text.Trim().ToUpper());

        //File Index
        if (fldIndex.SelectedIndex == 1)
        {
            cmd.Parameters.AddWithValue("@index", fldNewIndex.Text.Trim().ToUpper());

            SqlCommand command1 = new SqlCommand("INSERT INTO EDMS_INDEX "
              + "(FLD_INDEX, PROJECT_CODE) "
              + "VALUES "
              + "(@new_index, '" + Request.QueryString["ID1"] + "')", con);

            command1.Parameters.AddWithValue("@new_index", fldNewIndex.Text.Trim().ToUpper());

            command1.ExecuteNonQuery();
        }
        else
        {
            if (fldIndex.Text != "")
                cmd.Parameters.AddWithValue("@index", fldIndex.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@index", DBNull.Value);
        }

        //DC Remarks
        cmd.Parameters.AddWithValue("@remarks", fldRemarks.Text.Trim().ToUpper());

        //Sent To
        cmd.Parameters.AddWithValue("@sentto", fldSentTo.Text.Trim().ToUpper());

        cmd.Parameters.AddWithValue("@updatedby", Request.QueryString["ID"]);
        cmd.Parameters.AddWithValue("@updateddt", DateTime.Now);

        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateOut();
    }
    #endregion

    #region btnDeleteScannedDoc
    protected void btnDeleteScanDoc_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);

        queryString = "";
        queryString = queryString + " SELECT        *  ";
        queryString = queryString + " FROM          VWEDMS_OUT_DOCUMENT ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        row = null;
        row = dtChck.Rows[0];

        varDt = Convert.ToDateTime(row["FLD_BOOK_DATE"].ToString());

        string pathString = @"d:/EDMS_BHP/Document/" + Request.QueryString["id1"] + "/outgoing/" + varDt.ToString("yyyy") + "/" + row["TRACK_NO"].ToString() + ".pdf";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        con.Close();

        Response.Redirect("Out_Edit_Document.aspx?ID=" + Request.QueryString["id"] + "&ID1=" + Request.QueryString["id1"] + "&ID2=" + Request.QueryString["id2"] + "&url=" + Request.QueryString["url"]);

    }
    #endregion

    protected void bindGridViewDetails()
    {
        queryString = "";
        queryString = queryString + " SELECT        VWEDMS_OUT_DOCUMENT.*,  ";
        queryString = queryString + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        queryString = queryString + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        queryString = queryString + " FROM          VWEDMS_OUT_DOCUMENT ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblCREATEBY on tblCREATEBY.StaffNo = VWEDMS_OUT_DOCUMENT.CreatedBy ";
        queryString = queryString + " LEFT JOIN     tblStaff As tblUPDATEBY on tblUPDATEBY.StaffNo = VWEDMS_OUT_DOCUMENT.UpdatedBy ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
        DataTable dtChck = new DataTable();
        daChck.Fill(dtChck);
        con.Close();

        row = null;
        row = dtChck.Rows[0];

        //Tracking No.
        lblTNo.Text = row["FLD_OUT_SERIAL"].ToString();
        lblTNo1.Text = row["FLD_OUT_SERIAL"].ToString();

        //Booked Date
        varDt = Convert.ToDateTime(row["FLD_BOOK_DATE"].ToString());
        fldDateTaken.Value = varDt.ToString("dd-MMM-yyyy");

        //Addressee
        fldAddressee.Text = row["FLD_COMPANY"].ToString();
        lblAddresseeCode.Text = row["COMPANY_CODE"].ToString();

        //Year
        hidYear.Value = varDt.ToString("yyyy");

        //Out Reference No.
        fldRefNo.Text = row["FLD_REFERENCE"].ToString();

        //Date of Document
        if (row["FLD_DOC_DATE"].ToString() != "")
        {
            varDt = Convert.ToDateTime(row["FLD_DOC_DATE"].ToString());
            fldDocDate.Value = varDt.ToString("dd-MMM-yyyy");
        }
        else
            fldDocDate.Value = "";

        //Package
        fldPackage.Text = row["FLD_PACKAGE"].ToString();

        //Department
        fldDepartment.Text = row["FLD_DEPARTMENT"].ToString();

        //Subject
        fldSubject.Text = row["FLD_TITLE"].ToString();

        //Originator
        fldOriginator.Text = row["FLD_ORIGINATOR"].ToString();

        //File Index
        fldIndex.Text = row["FLD_INDEX"].ToString();

        //Remarks
        fldRemarks.Text = row["FLD_REMARKS"].ToString();

        //Sent To
        fldSentTo.Text = row["FLD_SENT_TO"].ToString();

        //Created By
        if (row["CreatedDt"].ToString() != "")
        {
            varDt = Convert.ToDateTime(row["CreatedDt"].ToString());
            lblCreatedBy.Text = row["CREATEBYName"].ToString() + " on " + varDt.ToString("dd-MMM-yyyy");
        }
        else
            lblCreatedBy.Text = "";

        //Last Update
        if (row["UpdatedDt"].ToString() != "")
        {
            varDt = Convert.ToDateTime(row["UpdatedDt"].ToString());
            lblLastUpdate.Text = row["UPDATEBYName"].ToString() + " on " + varDt.ToString("dd-MMM-yyyy");
        }
        else
            lblLastUpdate.Text = "";

        //Check if file exist.        
        var file2 = new System.IO.FileInfo(@"E:/Webapps/EDMS_STR/Document/" + row["PROJECT_CODE"].ToString() + "/" + row["COMPANY_CODE"].ToString() + "/outgoing/" + row["YR"].ToString() + "/" + row["FLD_OUT_SERIAL"].ToString() + ".pdf");

        if (file2.Exists)
        {
            lblTrackNo.Visible = true;

            lblTrackNo.Text = row["FLD_OUT_SERIAL"].ToString();

            img_all.Visible = true;
        }
        else
        {
            lblTrackNo.Visible = true;

            lblTrackNo.Text = row["FLD_OUT_SERIAL"].ToString();
        }
        //end of check if file exist.

        fldYr.Text = row["YR"].ToString();
        fldTrackNo.Text = row["TRACK_NO"].ToString();
        fldCompanyCode.Text = row["COMPANY_CODE"].ToString();
    }

    public DataSet GetData(string queryString)
    {
        //Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString;
        DataSet ds = new DataSet();

        try
        {
            //Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            //Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }
}