using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class Admin_ViewPurchaseOrder : System.Web.UI.Page
{
    private int _POID = 0;

    public int POID
    {
        get { return _POID; }
        set { _POID = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtMessage.Text = "Dear sir/madam, \n We are pleased to Place this Purchase Order for Supply of spares at our project. This letter of Indent has been raised in the reference of following:";
            //LoadOrder();
            LoadOrderForPDF();

        }
    }
    void LoadOrder()
    {
        clsIndent obIndent = new clsIndent();
        clsCustomer obCustomer = new clsCustomer();
        clsSite obSite = new clsSite();
        clsPurchaseOrder obPO = new clsPurchaseOrder();
        clsPOParticulars obPOP = new clsPOParticulars();
        clsPOTerms obPOT = new clsPOTerms();
        clsUser obU = new clsUser();
        clsCompany obC = new clsCompany();
        clsSiteMachines obSM = new clsSiteMachines();
        DataTable dtCustomer;
        //Company Detail
        obC.Op = 3;
        DataTable dtCompany = obC.CompanyMster(obC).Tables[0];
        //Purchase Order Detail
        obPO.Op=3;
        obPO.ID=Convert.ToInt32(Request.QueryString["ID"]);
        DataTable dtPO = obPO.PurchaseOrderMaster(obPO).Tables[0];
        //Indent detail
        obIndent.RefNo = dtPO.Rows[0]["IndentRefNo"].ToString();
        obIndent.Op = 8;
        DataTable dtIndent = obIndent.IndentMaster(obIndent).Tables[0];
        //Purchase Order Particulars
        obPOP.POID=Convert.ToInt32(Request.QueryString["ID"]);
        obPOP.Op=2;
        DataTable dtPOItems = obPOP.POParticularsMaster(obPOP).Tables[0];
        //Purchase Order terms
        obPOT.POID = Convert.ToInt32(Request.QueryString["ID"]);
        obPOT.Op = 3;
        DataTable dtPOTerms = obPOT.POTermsMaster(obPOT).Tables[0];
        //User Detail
        obU.Op = 5;
        obU.ID = Convert.ToInt32(dtPO.Rows[0]["PreparedBy"]);
        DataTable dtPreparedBy = obU.UserMaster(obU).Tables[0];
        obU.ID = Convert.ToInt32(dtPO.Rows[0]["CheckedBy"]);
        DataTable dtCheckedBy = obU.UserMaster(obU).Tables[0];

            //Site Detail
            obSite.Op = 5;
            obSite.ID = Convert.ToInt32(dtPO.Rows[0]["SiteID"]);
            dtCustomer = obSite.SiteMaster(obSite).Tables[0];

        //Machine Detail
            obSM.Op = 5;
            obSM.ID = Convert.ToInt32(dtPO.Rows[0]["SiteMachineID"]);
            DataTable dtSM = obSM.SiteMachines(obSM).Tables[0];
        //Machine Detail
        LiteralControl lc = new LiteralControl();
        lc.Text = "";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<div class='col-lg-9'>";
        lc.Text = lc.Text + "<h3>" + dtCompany.Rows[0]["Name"] + "<br>" + dtCompany.Rows[0]["Address"].ToString().Replace("\n","<br>") + "</h3>";
        lc.Text = lc.Text + "<h4>TIN:" + dtCompany.Rows[0]["Tin"] + "<br>CST:" + dtCompany.Rows[0]["Cst"] + "</h4>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-3'>";

        lc.Text = lc.Text + "<img src='../" + dtCompany.Rows[0]["Logo"] + "' height='150' width='150' />";

        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<center><h4><b>Purchase Order</b></h4></center>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<div class='col-lg-9'>";
        lc.Text = lc.Text + "PO Ref No: " + dtPO.Rows[0]["PORefNo"] + "<br />";
        lc.Text = lc.Text + "To,<br />";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Name"] + "<br>";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Location"] + "<br>";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Address"].ToString().Replace("\n","<br>") + "<br>";
            if (dtCustomer.Rows[0]["PhoneNo"].ToString() != "")
            {
                lc.Text = lc.Text + "Phone No:" + dtCustomer.Rows[0]["PhoneNo"] + "<br>";
            }
            if (dtCustomer.Rows[0]["Email"].ToString() != "")
            {
                lc.Text = lc.Text + "Email ID:" + dtCustomer.Rows[0]["Email"] + "<br>";
            }

        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-3'>";
        lc.Text = lc.Text + "Date:" + Convert.ToDateTime(dtPO.Rows[0]["PODate"]).ToShortDateString();
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<div class='col-lg-4'>Machine: "+dtSM.Rows[0]["Machine"]+"</div>";
        lc.Text = lc.Text + "<div class='col-lg-4'>Log No: "+dtSM.Rows[0]["SerialNo"]+"</div>";
        lc.Text = lc.Text + "<div class='col-lg-4'>Registration No: " + dtSM.Rows[0]["RegistrationNo"] + "</div>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<table width='95%' align='center' border='1'><tr><td>";
        lc.Text = lc.Text + "Quotation No:"+dtPO.Rows[0]["QuotationNo"] + "<br />";
        lc.Text = lc.Text + "Date:" + Convert.ToDateTime(dtPO.Rows[0]["QuotationDate"]).ToShortDateString();
        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "<td>";
        if (dtIndent.Rows.Count > 0)
        {
            lc.Text = lc.Text + "Indent Date:" + Convert.ToDateTime(dtIndent.Rows[0]["IndentDate"]).ToShortDateString();
        }
        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "</tr></table>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "Subject:" + dtPO.Rows[0]["Subject"];
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + txtMessage.Text.Replace("\n", "<br>");
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12' style='min-height:300'>";
        //Items//
        lc.Text = lc.Text + "<table width='98%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr><td>Serial No</td><td>Part No</td><td>Item</td><td>Current Stock</td><td>Quantity</td><td>UOM</td><td>Remarks</td><td>Rate</td><td>Tax</td><td>Amount</td></tr>";
        int i = 0;
        foreach (DataRow drItems in dtPOItems.Rows)
        {
            i++;
            lc.Text = lc.Text + "<tr>";
            lc.Text = lc.Text + "<td>" + i.ToString() + "</td>";
            lc.Text = lc.Text + "<td>"+drItems["PartNo"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Item"].ToString().Replace("\n", "<br>") + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["CurrentStock"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Qty"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["UGM"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Remark"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Rate"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Tax"] + " %</td>";
            lc.Text = lc.Text + "<td width='75' align='right'>" + drItems["Amount"] + "</td>";  
            lc.Text = lc.Text + "</tr>";
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<table width='98%' align='center'>";
        lc.Text = lc.Text + "<tr><td colspan='9' align='right'>Total Amount</td><td width='50'></td><td width='75' align='right'>" + dtPO.Rows[0]["TotalAmount"] + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='9' align='right'>" + dtPO.Rows[0]["TaxName"] + "</td><td></td><td align='right'>" + (Convert.ToDouble(dtPO.Rows[0]["TotalAmount"]) * Convert.ToDouble(dtPO.Rows[0]["TaxPercentage"]) / 100).ToString() + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='9' align='right'>Discount " + dtPO.Rows[0]["DiscountPercentage"] + "%</td><td></td><td align='right'>" + (Convert.ToDouble(dtPO.Rows[0]["TotalAmount"]) * Convert.ToDouble(dtPO.Rows[0]["DiscountPercentage"]) / 100).ToString() + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='9' align='right'>Net Payable</td><td></td><td align='right'>" + dtPO.Rows[0]["NetPayable"] + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        //Items
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'><h4><i>Terms & Conditions:</i></h4><br>";
        //Terms
        lc.Text = lc.Text + "<table width='98%' border='1' align='center'>";
        foreach (DataRow drTerms in dtPOTerms.Rows)
        {
            lc.Text = lc.Text + "<tr><td>" + drTerms["Heading"] + "</td><td>" + drTerms["Detail"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        //Terms
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'><br><br>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<table width='98%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr height='100'><td width='25%'>";


        lc.Text = lc.Text + "<img src='../" + dtPreparedBy.Rows[0]["Signature"] + "' height='50' width='120'/>";

        lc.Text = lc.Text + "<br>Prepared By</td>";
        lc.Text = lc.Text + "<td width='25%'>";

        lc.Text = lc.Text + "<img src='../" + dtCheckedBy.Rows[0]["Signature"] + "' height='50' width='120'/>";

        lc.Text = lc.Text + "<br>Checked By</td>";
        lc.Text = lc.Text + "<td width='48%'><center>Authorized Signatory<br /><br /><br />" + dtCompany.Rows[0]["Name"] + "</center></td></tr></table>";
        lc.Text = lc.Text + "</div>";
        Label lb = new Label();
        lb.Text = lc.ToString();
        pnlDetail.Controls.Add(lc);
    }

    void LoadOrderForPDF()
    {
        clsIndent obIndent = new clsIndent();
        clsCustomer obCustomer = new clsCustomer();
        clsSite obSite = new clsSite();
        clsPurchaseOrder obPO = new clsPurchaseOrder();
        clsPOParticulars obPOP = new clsPOParticulars();
        clsPOTerms obPOT = new clsPOTerms();
        clsUser obU = new clsUser();
        clsCompany obC = new clsCompany();
        clsSiteMachines obSM = new clsSiteMachines();
        DataTable dtCustomer;
        //Company Detail
        obC.Op = 3;
        DataTable dtCompany = obC.CompanyMster(obC).Tables[0];
        //Purchase Order Detail
        obPO.Op = 3;
        obPO.ID = Convert.ToInt32(Request.QueryString["ID"]);
        DataTable dtPO = obPO.PurchaseOrderMaster(obPO).Tables[0];
        //Indent detail
        obIndent.RefNo = dtPO.Rows[0]["IndentRefNo"].ToString();
        obIndent.Op = 8;
        DataTable dtIndent = obIndent.IndentMaster(obIndent).Tables[0];
        //Purchase Order Particulars
        obPOP.POID = Convert.ToInt32(Request.QueryString["ID"]);
        obPOP.Op = 2;
        DataTable dtPOItems = obPOP.POParticularsMaster(obPOP).Tables[0];
        //Purchase Order terms
        obPOT.POID = Convert.ToInt32(Request.QueryString["ID"]);
        obPOT.Op = 3;
        DataTable dtPOTerms = obPOT.POTermsMaster(obPOT).Tables[0];
        //User Detail
        obU.Op = 5;
        obU.ID = Convert.ToInt32(dtPO.Rows[0]["PreparedBy"]);
        DataTable dtPreparedBy = obU.UserMaster(obU).Tables[0];
        obU.ID = Convert.ToInt32(dtPO.Rows[0]["CheckedBy"]);
        DataTable dtCheckedBy = obU.UserMaster(obU).Tables[0];

            //Site Detail
            obSite.Op = 5;
            obSite.ID = Convert.ToInt32(dtPO.Rows[0]["SiteID"]);
            dtCustomer = obSite.SiteMaster(obSite).Tables[0];

        //Machine Detail
        obSM.Op = 5;
        obSM.ID = Convert.ToInt32(dtPO.Rows[0]["SiteMachineID"]);
        DataTable dtSM = obSM.SiteMachines(obSM).Tables[0];
        //Machine Detail
        //Purchase Order To detail//
        clsCustomer ObPOTo = new clsCustomer();
        ObPOTo.Op = 4;
        ObPOTo.ID = Convert.ToInt32(dtPO.Rows[0]["POTo"]);
        DataTable dtPOTo = ObPOTo.CustomerMaster(ObPOTo).Tables[0];
        //Purchase order to detail//
        LiteralControl lc = new LiteralControl();
        lc.Text = "<div style='width:100%; margin:50 padding:50;'>";
        lc.Text = lc.Text + "<table width='100%' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td align='left' colspan='9'>";
        lc.Text = lc.Text + "<h5>" + dtCompany.Rows[0]["Name"] + "<br>" + dtCompany.Rows[0]["Address"].ToString().Replace("\n", "<br>") + "</h5>";
        lc.Text = lc.Text + "<h6>TIN:" + dtCompany.Rows[0]["Tin"] + "<br>CST:" + dtCompany.Rows[0]["Cst"] + "</h6>";
        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "<td align='right' colspan='3'>";
        try
        {
            lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtCompany.Rows[0]["Logo"]) + "' height='100' width='100' />";
        }
        catch
        {
            lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtCompany.Rows[0]["Logo"]) + "' height='100' width='100' />";
        }
        lc.Text = lc.Text + "</td></tr>";

        lc.Text = lc.Text + "<tr><td align='center' colspan='12'><h5><b>Purchase Order</b></h5></td></tr>";

        lc.Text = lc.Text + "<tr><td align='left' colspan='6'>";
        lc.Text = lc.Text + "PO Ref No: " + dtPO.Rows[0]["PORefNo"] + "<br />";
        lc.Text = lc.Text + "To,<br />";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Name"] + "<br>";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Location"] + "<br>";
            lc.Text = lc.Text + dtCustomer.Rows[0]["Address"].ToString().Replace("\n", "<br>") + "<br>";
            if (dtCustomer.Rows[0]["PhoneNo"].ToString() != "")
            {
                lc.Text = lc.Text + "Phone No:" + dtCustomer.Rows[0]["PhoneNo"] + "<br>";
            }
            if (dtCustomer.Rows[0]["Email"].ToString() != "")
            {
                lc.Text = lc.Text + "Email ID:" + dtCustomer.Rows[0]["Email"] + "<br>";
            }
            if (dtPOTo.Rows.Count > 0)
            {
                lc.Text = lc.Text + "<b>Purchase Order To,</b><br>";
                lc.Text = lc.Text + dtPOTo.Rows[0]["Name"].ToString() + "<br>";
                lc.Text = lc.Text + "Phone No:" + dtPOTo.Rows[0]["Phone"].ToString() + "<br>";
                lc.Text = lc.Text + dtPOTo.Rows[0]["Address"].ToString().Replace("\n", "<br>");
            }

        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "<td align='right' colspan='6'>";
        lc.Text = lc.Text + "Date:" + Convert.ToDateTime(dtPO.Rows[0]["PODate"]).ToShortDateString();
        lc.Text = lc.Text + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12'><br></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='4'>Machine: " + dtSM.Rows[0]["Machine"] + "</td><td colspan='4'>Log No: " + dtSM.Rows[0]["SerialNo"] + "</td><td colspan='4'>Registration No: " + dtSM.Rows[0]["RegistrationNo"] + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12'>";
        lc.Text = lc.Text + "<table width='100%' align='center' border='1'><tr align='left'><td colspan='6'>";
        lc.Text = lc.Text + "Quotation No:" + dtPO.Rows[0]["QuotationNo"] + "<br />";
        lc.Text = lc.Text + "Date:" + Convert.ToDateTime(dtPO.Rows[0]["QuotationDate"]).ToShortDateString();
        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "<td colspan='6'>";
        if (dtIndent.Rows.Count > 0)
        {
            lc.Text = lc.Text + "Indent Date:" + Convert.ToDateTime(dtIndent.Rows[0]["IndentDate"]).ToShortDateString();
        }
        lc.Text = lc.Text + "</td>";
        lc.Text = lc.Text + "</tr></table></td></tr>";

        lc.Text = lc.Text + "<tr><td align='left' colspan='12'>Subject:" + dtPO.Rows[0]["Subject"] + "</td></tr>";

        lc.Text = lc.Text + "<tr><td align='left' colspan='12'>";
        lc.Text = lc.Text + txtMessage.Text.Replace("\n", "<br>");
        lc.Text = lc.Text + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        /*TEST*/
        lc.Text = lc.Text + "<table width='100%' style='font-size:8' border='1'>";
        lc.Text = lc.Text + "<tr align='left'><td>SL</td><td>Part No</td><td colspan='2'>Item</td><td>Stock</td><td>Qty</td><td>UOM</td><td>Rate</td><td>Tax</td><td>Amount</td><td colspan='2'>Remarks</td></tr>";
        int i = 0;
        foreach (DataRow drItems in dtPOItems.Rows)
        {
            i++;
            lc.Text = lc.Text + "<tr align='left'><td>" + i.ToString() + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["PartNo"] + "</td>";
            lc.Text = lc.Text + "<td colspan='2'>" + drItems["Item"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["CurrentStock"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Qty"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["UGM"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Rate"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Tax"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Amount"] + "</td>";
            lc.Text = lc.Text + "<td colspan='2'>" + drItems["Remark"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<table width='100%' style='font-size:8'>";

        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<table width='100%' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td colspan='12'><h6>Summery</h6></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='8' align='right'>Total Amount</td><td></td><td align='right' colspan='3'>" + dtPO.Rows[0]["TotalAmount"] + "/- INR</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='8' align='right'>" + dtPO.Rows[0]["TaxName"] + "</td><td></td><td align='right' colspan='3'>" + (Convert.ToDouble(dtPO.Rows[0]["TotalAmount"]) * Convert.ToDouble(dtPO.Rows[0]["TaxPercentage"]) / 100).ToString() + "/- INR</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='8' align='right'>Discount " + dtPO.Rows[0]["DiscountPercentage"] + "%</td><td></td><td align='right' colspan='3'>" + (Convert.ToDouble(dtPO.Rows[0]["TotalAmount"]) * Convert.ToDouble(dtPO.Rows[0]["DiscountPercentage"]) / 100).ToString() + "/-INR</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='8' align='right'>Net Payable</td><td></td><td align='right' colspan='3'>" + dtPO.Rows[0]["NetPayable"] + "/-INR</td></tr>";
        lc.Text = lc.Text + "</table>";
        /*TEST*/
        lc.Text = lc.Text + "<table width='100%' style='font-size:8' border='1'>";

        //----------------
        lc.Text = lc.Text + "<tr><td colspan='12' align='left'><h6><i>Terms & Conditions:</i></h6></td></tr>";
        //Terms
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<table width='100%' style='font-size:8' border='1'>";
        foreach (DataRow drTerms in dtPOTerms.Rows)
        {
            lc.Text = lc.Text + "<tr align='left'><td colspan='3'>" + drTerms["Heading"] + "</td><td colspan='9'>" + drTerms["Detail"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";

        //Terms
        lc.Text = lc.Text + "<table width='100%' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td colspan='12' align='center'><br><br></td></tr>";
        lc.Text = lc.Text + "<tr height='100'><td colspan='4'>";

        if (dtPreparedBy.Rows[0]["Signature"].ToString().Trim() != "")
        {
            lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtPreparedBy.Rows[0]["Signature"]) + "' height='50' width='120'/>";
        }
        lc.Text = lc.Text + "<br>Prepared By</td>";
        lc.Text = lc.Text + "<td colspan='4' align='center'>";
        if (dtCheckedBy.Rows[0]["Signature"].ToString().Trim() != "")
        {
            lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtCheckedBy.Rows[0]["Signature"]) + "' height='50' width='120'/>";
        }
        
        lc.Text = lc.Text + "<br>Checked By</td>";
        lc.Text = lc.Text + "<td colspan='4' align='right'>Authorized Signatory<br /><br /><br />" + dtCompany.Rows[0]["Name"] + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "</div>";
        Label lb = new Label();
        lb.Text = lc.ToString();
        pnlDetail.Controls.Add(lc);
    }
    protected void btnMessage_Click(object sender, EventArgs e)
    {
        //LoadOrder();
        LoadOrderForPDF();
    }
    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            LoadOrderForPDF();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/PurchaseOrder" + Request.QueryString["ID"].ToString() + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlDetail.RenderControl(hw);
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
        LoadOrder();

    }
}