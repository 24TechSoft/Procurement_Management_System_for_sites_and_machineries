using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class Admin_PTReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Panel pnl = LoadData();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/PurchaseOrder" + Request.QueryString["RefNo"].ToString() + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnl.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch
        {

        }
    }
    Panel LoadData()
    {
        clsPartTransfer obPT = new clsPartTransfer();
        clsPTItems obPTI = new clsPTItems();
        obPT.Reference = Request.QueryString["RefNo"].ToString();
        obPT.Op = 5;
        DataTable dtPT = obPT.PartTransfer(obPT).Tables[0];
        obPTI.PTID = Convert.ToInt32(dtPT.Rows[0]["ID"]);
        obPTI.Op = 2;
        DataTable dtPTI = obPTI.PTITems(obPTI).Tables[0];
        StringBuilder str = new StringBuilder();
        //select a.ID,a.Reference,a.SourceSite,SourceSiteName,SourceSiteAddress,SourceSitePhoneNo,SourceSiteEmail,a.DestinationSite,
//DestSiteName,DestSiteAddress,DestSitePhoneNo,DestSiteEmail,EntryDate,a.VehicleNo,a.DriverName,a.DriverPh,a.Status,CurrStatus
        str.Append("<table width='100%' style='font-size:8;'>");
        str.Append("<tr><td colspan='8'>");
        str.Append("<h4>TK Engineering Consortium Pvt. Limited</h4>");
        str.Append("<h5>Date: " + dtPT.Rows[0]["EntryDate"] + "</h5>");
        str.Append("</td><td colspan='4'>");
        str.Append("<img src='"+MapPath("~/images/logo.jpg")+"' width='150'/>");
        str.Append("</tr>");
        str.Append("<tr><td colspan='4'>");
        str.Append("Source Site:<br><b>"+dtPT.Rows[0]["SourceSiteName"]+"</b><br>");
        str.Append("Address: "+dtPT.Rows[0]["SourceSiteAddress"].ToString().Replace("\n","<br>") + "<br>");
        str.Append("Phone No: "+dtPT.Rows[0]["SourceSitePhoneNo"] + "<br>");
        str.Append("Email: "+dtPT.Rows[0]["SourceSiteEmail"] + "<br>");
        str.Append("Site Incharge: " + dtPT.Rows[0]["SSiteIncharge"] + "<br>Phone No" + dtPT.Rows[0]["SSiteInchargePh"]);
        str.Append("</td><td colspan='4'></td><td align='right' colspan='4'><div style='text-align:left;'>");
        str.Append("Destination Site:<br><b>" + dtPT.Rows[0]["DestSiteName"] + "</b><br>");
        str.Append("Address: " + dtPT.Rows[0]["DestSiteAddress"].ToString().Replace("\n", "<br>") + "<br>");
        str.Append("Phone No: " + dtPT.Rows[0]["DestSitePhoneNo"] + "<br>");
        str.Append("Email: " + dtPT.Rows[0]["DestSiteEmail"] + "<br>");
        str.Append("Site Incharge: " + dtPT.Rows[0]["DSiteIncharge"] + "<br>Phone No" + dtPT.Rows[0]["DSiteInchargePh"]);
        str.Append("</div></td></tr>");
        str.Append("</table>");
        str.Append("<table width='100%' style='font-size:8;' border='1'>");
        //PartNo, PartName, MachineName, Quantity, Rate, Total
        int i = 0;
        str.Append("<tr><td><b>SL</b></td><td colspan='2'><b>Part No</b></td><td colspan='3'><b>Part Name</b></td><td colspan='3'><b>Machine Name</b></td><td><b>Quantity</b></td><td><b>Rate</b></td><td><b>Total</b></td></tr>");
        int TQ = 0;
        foreach (DataRow dr in dtPTI.Rows)
        {
            i++;
            str.Append("<tr>");
            str.Append("<td>" + i + "</td>");
            str.Append("<td colspan='2'>" + dr["PartNo"] + "</td>");
            str.Append("<td colspan='3'>" + dr["PartName"] + "</td>");
            str.Append("<td colspan='3'>" + dr["MachineName"] + "</td>");
            str.Append("<td>" + dr["Quantity"] + "</td>");
            str.Append("<td>" + dr["Rate"] + "</td>");
            str.Append("<td>" + dr["Total"] + "</td>");
            str.Append("</tr>");
            TQ = TQ + Convert.ToInt32(dr["Quantity"]);
        }
        str.Append("</table>");
        str.Append("<h5>Total Quantity Dispatched: " + TQ.ToString() + "</h5>");
        str.Append("<h5>Driver Name: " + dtPT.Rows[0]["DriverName"] + "</h5>");
        str.Append("<h5>Driver Phone No: " + dtPT.Rows[0]["DriverPh"] + "</h5>");
        str.Append("<h5>Current Status: " + dtPT.Rows[0]["CurrStatus"] + "</h5>");
        Label lbl = new Label();
        lbl.Text = str.ToString();
        Panel pnl = new Panel();
        pnl.Controls.Add(lbl);
        return pnl;
    }
}