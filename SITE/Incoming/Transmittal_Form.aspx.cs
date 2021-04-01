using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ZebraDatePickerDotNet.Dates;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text.xml.simpleparser;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.text;
using Microsoft.VisualBasic;

public partial class Incoming_Transmittal_Form : System.Web.UI.Page
{
    DataRow row = null;
    DataRow rowA = null;
    
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GDCConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    int count;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        //Select from database - Section A     
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          PROJECT ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daM = new SqlDataAdapter(cmd);
        DataTable dtM = new DataTable();
        daM.Fill(dtM);
        con.Close();

        row = null;
        row = dtM.Rows[0];
        //String documentDate = Convert.ToString(Convert.ToDateTime(row["DocDate"]).ToString("dd MMM yyyy"));

        //Select from database - Section A     
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_IN_DOCUMENT ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daA = new SqlDataAdapter(cmd);
        DataTable dtA = new DataTable();
        daA.Fill(dtA);
        con.Close();
        rowA = null;
        rowA = dtA.Rows[0];
        
        //Select from database - Section B
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          EDMS_IN_ATTACH ";
        queryString = queryString + " WHERE         ID = '" + Request.QueryString["ID2"] + "' ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daB = new SqlDataAdapter(cmd);
        DataTable dtB = new DataTable();
        daB.Fill(dtB);
        con.Close();

        //Select from database - Section C
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          PROJECTUSERS ";
        queryString = queryString + " WHERE         PROJECT_CODE = '" + Request.QueryString["ID1"] + "' ";
        queryString = queryString + " AND           STAFF_INITIAL IS NOT NULL ";
        queryString = queryString + " ORDER BY      SORTING ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);

        cmd.CommandTimeout = 0;
        SqlDataAdapter daC = new SqlDataAdapter(cmd);
        DataTable dtC = new DataTable();
        daC.Fill(dtC);
        con.Close();

        Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "inline;filename=Transmittal_Form.pdf");
        Response.AddHeader("content-disposition", "attachment;filename=Transmittal_Form.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.Page.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        TextReader xmlString = sr;
        //size (left, right, top, bottom)
        //Document pdfDoc = new Document(PageSize.A4, 15.0F, 15.0F, 135.0F, 15.0F); //landscape

        //Document pdfDoc = new Document(PageSize.A4, 60f, 60f, 90f, 50f); //left, right, top, bottom
        ////Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 100f, 50f); //left, right, top, bottom
        Document pdfDoc = new Document(PageSize.A4, 38f, 38f, 90f, 50f); //left, right, top, bottom
        //Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 88f, 88f, 10f, 10f);

        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //iTextSharp.text.Image imgKKM = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Img/opus_logo.jpg"));
        iTextSharp.text.Image imgKKM = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Img/bhp_logo.png"));
        //iTextSharp.text.Image imgAV = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Img/blank.png"));

        itsEvents ev = new itsEvents();
        //ev.getVal(documentDate, ref imgKKM, ref imgAV);
        ev.getVal(ref imgKKM);
        writer.PageEvent = ev;
        pdfDoc.Open();

        HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
        htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
        htmlContext.SetImageProvider(new ImageProvider());

        dynamic fontHeader = FontFactory.GetFont("Verdana", 8, Font.NORMAL, BaseColor.BLACK);
        dynamic fontHeaderB = FontFactory.GetFont("Verdana", 8, Font.BOLD, BaseColor.BLACK);
        dynamic fontHeaderU = FontFactory.GetFont("Verdana", 8, Font.UNDERLINE, BaseColor.BLACK);

        PdfPTable headerTbl = new PdfPTable(7);
        headerTbl.WidthPercentage = 100;
        float[] cfWidths = new float[] {
            48f,
            80f,
            15f,
            15f,
            15f,
            15f,
            25f
        };

        headerTbl.SetWidths(cfWidths);

        //DOCUMENT DETAILS
        PdfPCell cell = new PdfPCell(new Phrase("DOCUMENT DETAILS" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.BorderWidth = 1;
        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell);

        //ROW 1
        cell = new PdfPCell(new Phrase("Project Name", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(row["DESCRIPTION"].ToString().ToUpper() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 6;
        headerTbl.AddCell(cell);

        //ROW 2
        cell = new PdfPCell(new Phrase("Reference No." + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["FLD_REFERENCE"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Tracking No." + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["FLD_IN_SERIAL"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        //ROW 3
        cell = new PdfPCell(new Phrase("Date Received", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        DateTime varDt;
        varDt = Convert.ToDateTime(rowA["FLD_IN_DATE"].ToString());        
        cell = new PdfPCell(new Phrase(varDt.ToString("dd-MMM-yyyy") + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 6;
        headerTbl.AddCell(cell);

        //ROW 4
        cell = new PdfPCell(new Phrase("Package", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["FLD_PACKAGE"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 6;
        headerTbl.AddCell(cell);

        //ROW 5
        cell = new PdfPCell(new Phrase("Subject", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["FLD_TITLE1"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 6;
        headerTbl.AddCell(cell);

        //ROW 6
        cell = new PdfPCell(new Phrase("DC Remarks", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["REMARKS"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 6;
        headerTbl.AddCell(cell);

        //ATTACHMENT
        cell = new PdfPCell(new Phrase("ATTACHMENT" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell);

        //ROW 1
        cell = new PdfPCell(new Phrase("Title" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Copy" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 4;
        headerTbl.AddCell(cell);

        if (dtB.Rows.Count > 0)
        {
            for (int i = 0; i < dtB.Rows.Count; i++)
            {
                DataRow rowB = dtB.Rows[i];

                cell = new PdfPCell(new Phrase(rowB["FLD_ATCH_TITLE"].ToString() + Environment.NewLine + " ", fontHeader));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Colspan = 3;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase(rowB["FLD_ATCH_COPY"].ToString() + Environment.NewLine + " ", fontHeader));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Colspan = 4;
                headerTbl.AddCell(cell);
            }
        }
        else
        {
            cell = new PdfPCell(new Phrase("-" + Environment.NewLine + " ", fontHeader));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Colspan = 3;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("-" + Environment.NewLine + " ", fontHeader));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Colspan = 4;
            headerTbl.AddCell(cell);
        }              

        //DISTRIBUTION DETAILS
        cell = new PdfPCell(new Phrase("DISTRIBUTION DETAILS" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell);

        //ROW 1
        cell = new PdfPCell(new Phrase("COORDINATOR/ACTIONEE" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        headerTbl.AddCell(cell);

        //ROW 2
        cell = new PdfPCell(new Phrase("Initial" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Instruction" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Info" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Urgency" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Required" + Environment.NewLine + "Date" + Environment.NewLine + "", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        headerTbl.AddCell(cell);

        //ROW 3
        cell = new PdfPCell(new Phrase("Hi" + Environment.NewLine + " (3d)", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Me" + Environment.NewLine + " (7d)", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Low" + Environment.NewLine + " (14d)", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        headerTbl.AddCell(cell);

        //ROW 4
        if (dtC.Rows.Count == 0)
        {
            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 100;
            headerTbl.AddCell(cell);
        }
        else
        {
            //for (int i = 0; i < dtC.Rows.Count - 1; i++)
            for (int i = 0; i < dtC.Rows.Count; i++)
            {
                DataRow rowC = dtC.Rows[i];
                

                cell = new PdfPCell(new Phrase(rowC["STAFF_INITIAL"].ToString() + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                cell = new PdfPCell(new Phrase("" + Environment.NewLine + " ", fontHeaderB));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);

                //DataRow nextRow = dtC.Rows[i + 1];
            }
        }                

        //ROW 5
        cell = new PdfPCell(new Phrase("Name :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Signature :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Date :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        //RESPONSE DETAILS
        cell = new PdfPCell(new Phrase("RESPONSE DETAILS" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell);

        //ROW 1
        cell = new PdfPCell(new Phrase("Description of Response :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.MinimumHeight = 40;
        cell.Colspan = 5;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Acknowledge by :" + Environment.NewLine + " (Coordinator)", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        cell.Rowspan = 3;
        headerTbl.AddCell(cell);

        //ROW 2
        cell = new PdfPCell(new Phrase("Reply Reference :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 5;
        headerTbl.AddCell(cell);

        //ROW 3
        cell = new PdfPCell(new Phrase("Name :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 2;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Signature/Date :" + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        pdfDoc.Add(headerTbl);
        
        pdfDoc.Close();
        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        Response.Write(pdfDoc);
        Response.End();
    }
}
public class ImageProvider : AbstractImageProvider
{
    public ImageProvider()
    {
    }
    public override string GetImageRootPath()
    {
        return "/";
    }
}
public class itsEvents : PdfPageEventHelper
{
    string hdrStr = "ELECTRONIC DOCUMENT MANAGEMENT SYSTEM";
    string hdrSubStr = "TRANSMITTAL FORM";
    iTextSharp.text.Image logoKKM;

    public void getVal(ref iTextSharp.text.Image KKMlogo)
    {        
        logoKKM = KKMlogo;
    }

    public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    {
        dynamic fontHeader = FontFactory.GetFont("Verdana", 10, Font.NORMAL, BaseColor.BLACK);
        dynamic fontHeaderB = FontFactory.GetFont("Verdana", 10, Font.BOLD, BaseColor.BLACK);
        dynamic fontHeaderU = FontFactory.GetFont("Verdana", 10, Font.UNDERLINE, BaseColor.BLACK);

        //logoKKM.ScaleToFit(100.0F, 80.0F);
        logoKKM.ScaleToFit(80.0F, 60.0F);

        PdfPTable headerTbl = new PdfPTable(3);
        headerTbl.TotalWidth = 550f;
        float[] cfWidths = new float[] {
			50f,
			50f,
			50f
		};
        headerTbl.SetWidths(cfWidths);

        //PdfPCell cell = new PdfPCell(new Phrase());
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //cell.BorderWidth = 0;
        //headerTbl.AddCell(cell);

        PdfPCell cell = new PdfPCell(logoKKM);
        //cell = new PdfPCell(logoKKM);
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Border = PdfPCell.NO_BORDER;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(hdrStr + Environment.NewLine + Environment.NewLine + hdrSubStr, fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2; // 3;
        cell.BorderWidth = 0;
        headerTbl.AddCell(cell);
        
        //size (left, right, top, bottom)
        //headerTbl.WriteSelectedRows(0, -1, 20, (document.PageSize.Height - 20), writer.DirectContent);
        headerTbl.WriteSelectedRows(0, -1, 20, (document.PageSize.Height - 40), writer.DirectContent);
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {

    }
}
