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
public partial class Supervisor_ViewIndent : System.Web.UI.Page
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
            
            LoadOrder();
        }
    }
    void LoadOrder()
    {
        clsIndent obIndent = new clsIndent();
        clsCustomer obCustomer = new clsCustomer();
        clsSite obSite = new clsSite();
        clsIndentItems obIndentItems = new clsIndentItems();
        clsUser obU = new clsUser();
        clsCompany obC = new clsCompany();
        DataTable dtCustomer;
        //Company Detail
        obC.Op = 3;
        DataTable dtCompany = obC.CompanyMster(obC).Tables[0];

        //Indent detail
        obIndent.ID = Convert.ToInt32(Request.QueryString["ID"]);
        obIndent.Op = 4;
        DataTable dtIndent = obIndent.IndentMaster(obIndent).Tables[0];

        //User Detail
        obU.Op = 5;
        obU.ID = Convert.ToInt32(dtIndent.Rows[0]["Indentor"]);
        DataTable dtIndentor = obU.UserMaster(obU).Tables[0];
        obU.ID = Convert.ToInt32(dtIndent.Rows[0]["ApprovedBy"]);
        DataTable dtApprovedBy = obU.UserMaster(obU).Tables[0];
        //Customer Detail
        if (Convert.ToInt32(dtIndent.Rows[0]["OrderFrom"]) == 1)
        {
            //Site Detail
            obSite.Op = 5;
            obSite.ID = Convert.ToInt32(dtIndent.Rows[0]["OrderFromID"]);
            dtCustomer = obSite.SiteMaster(obSite).Tables[0];
        }
        else
        {
            //Customer Detail
            obCustomer.ID = Convert.ToInt32(dtIndent.Rows[0]["OrderFromID"]);
            obCustomer.Op = 4;
            dtCustomer = obCustomer.CustomerMaster(obCustomer).Tables[0];
        }
        //Indent Items
        obIndentItems.IndentID = Convert.ToInt32(Request.QueryString["ID"]);
        obIndentItems.Op = 2;
        DataTable dtIndentItems = obIndentItems.IndentItemMaster(obIndentItems).Tables[0];
        LiteralControl lc = new LiteralControl();
        lc.Text = "";
        lc.Text = lc.Text + "<div class='row'>";
        lc.Text = lc.Text + "<div class='col-lg-12'><center><h3>" + dtCompany.Rows[0]["Name"] + "</h3></center></div>";
        lc.Text = lc.Text + "<div class='col-lg-12'><center>Project Name: " + dtIndent.Rows[0]["ProjectNo"] + "</center></div>";
        lc.Text = lc.Text + "<div class='col-lg-12'><center>Job No: " + dtIndent.Rows[0]["JobNo"] + "</center></div>";
        lc.Text = lc.Text + "<div class='col-lg-12'><center><h3><u>INDENT FORM</u></h3></center></div>";
        lc.Text = lc.Text + "<div class='col-lg-9'>Ref No:" + dtIndent.Rows[0]["RefNo"] + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-3'>Date:" + Convert.ToDateTime(dtIndent.Rows[0]["IndentDate"]).ToShortDateString() + "</div>";
        lc.Text = lc.Text + "<div class='col-lg-12' style='height:50px'></div>";

        lc.Text = lc.Text + "<div class='col-lg-12' style='height:500px'>";
        //Items//
        lc.Text = lc.Text + "<table width='100%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr><td>Serial No</td><td>Part No</td><td>Particular Description</td><td>Current Stock</td><td>Quantity</td><td>Remarks</td></tr>";
        int i = 0;
        foreach (DataRow drItems in dtIndentItems.Rows)
        {
            i++;
            lc.Text = lc.Text + "<tr>";
            lc.Text = lc.Text + "<td>" + i.ToString() + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["PartNo"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Particular"].ToString().Replace("\n", "<br>") + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["CurrentStock"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Quantity"] + "</td>";
            lc.Text = lc.Text + "<td>" + drItems["Remarks"] + "</td>";
            lc.Text = lc.Text + "</tr>";
        }
        lc.Text = lc.Text + "</table>";

        //Items
        lc.Text = lc.Text + "</div>";

        lc.Text = lc.Text + "<div class='col-lg-12'>";
        lc.Text = lc.Text + "<table width='100%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr height='100' align='center'><td>";


        lc.Text = lc.Text + "<img src='../" + dtIndentor.Rows[0]["Signature"] + "' height='50' width='120'/>";

        lc.Text = lc.Text + "<br>Indentor: " + dtIndentor.Rows[0]["Name"] + "</td>";
        lc.Text = lc.Text + "<td>";
        if (dtApprovedBy.Rows.Count > 0)
        {
            lc.Text = lc.Text + "<img src='../" + dtApprovedBy.Rows[0]["Signature"] + "' height='50' width='120'/>";

            lc.Text = lc.Text + "<br>Approved By: " + dtApprovedBy.Rows[0]["Name"];
            
        }
        lc.Text = lc.Text + "</td></tr></table>";
        lc.Text = lc.Text + "</div>";
        lc.Text = lc.Text + "</div>";
        Label lb = new Label();
        lb.Text = lc.ToString();
        pnlDetail.Controls.Add(lc);
        if (dtApprovedBy.Rows.Count == 0)
        {
            pnlApprove.Visible = true;
        }
        else
        {
            pnlApprove.Visible = false;
        }
    }

    void LoadOrderForPDF()
    {
        clsIndent obIndent = new clsIndent();
        clsCustomer obCustomer = new clsCustomer();
        clsSite obSite = new clsSite();
        clsIndentItems obIndentItems = new clsIndentItems();
        clsUser obU = new clsUser();
        clsCompany obC = new clsCompany();
        DataTable dtCustomer;
        //Company Detail
        obC.Op = 3;
        DataTable dtCompany = obC.CompanyMster(obC).Tables[0];

        //Indent detail
        obIndent.ID = Convert.ToInt32(Request.QueryString["ID"]);
        obIndent.Op = 4;
        DataTable dtIndent = obIndent.IndentMaster(obIndent).Tables[0];

        //User Detail
        obU.Op = 5;
        obU.ID = Convert.ToInt32(dtIndent.Rows[0]["Indentor"]);
        DataTable dtIndentor = obU.UserMaster(obU).Tables[0];
        obU.ID = Convert.ToInt32(dtIndent.Rows[0]["ApprovedBy"]);
        DataTable dtApprovedBy = obU.UserMaster(obU).Tables[0];
        //Customer Detail
        if (Convert.ToInt32(dtIndent.Rows[0]["OrderFrom"]) == 1)
        {
            //Site Detail
            obSite.Op = 5;
            obSite.ID = Convert.ToInt32(dtIndent.Rows[0]["OrderFromID"]);
            dtCustomer = obSite.SiteMaster(obSite).Tables[0];
        }
        else
        {
            //Customer Detail
            obCustomer.ID = Convert.ToInt32(dtIndent.Rows[0]["OrderFromID"]);
            obCustomer.Op = 4;
            dtCustomer = obCustomer.CustomerMaster(obCustomer).Tables[0];
        }
        //Indent Items
        obIndentItems.IndentID = Convert.ToInt32(Request.QueryString["ID"]);
        obIndentItems.Op = 2;
        DataTable dtIndentItems = obIndentItems.IndentItemMaster(obIndentItems).Tables[0];
        LiteralControl lc = new LiteralControl();
        lc.Text = "";
        lc.Text = lc.Text + "<table width='100%'>";
        lc.Text = lc.Text + "<tr><td colspan='12' align='center'><h3>" + dtCompany.Rows[0]["Name"] + "</h3></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12' align='center'>Project Name: " + dtIndent.Rows[0]["ProjectNo"] + "</h3></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12' align='center'>Job No: " + dtIndent.Rows[0]["JobNo"] + "</h3></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12' align='center'><h3><u>INDENT FORM</u></h3></td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='9' align='left'>Ref No:" + dtIndent.Rows[0]["RefNo"] + "</td>";
        lc.Text = lc.Text + "<td colspan='3' align='right'>Date:" + Convert.ToDateTime(dtIndent.Rows[0]["IndentDate"]).ToShortDateString() + "</td></tr>";
        lc.Text = lc.Text + "<tr><td colspan='12' style='height:50'></td></tr>";

        lc.Text = lc.Text + "<tr><td colspan='12'>";
        //Items//
        lc.Text = lc.Text + "<table width='100%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr><td colspan='1' align='center'>Serial No</td><td colspan='2' align='left'>Part No</td><td colspan='4' align='left'>Particular Description</td><td colspan='1' align='center'>Current Stock</td><td colspan='1' align='center'>Quantity</td><td colspan='3' align='left'>Remarks</td></tr>";
        int i = 0;
        foreach (DataRow drItems in dtIndentItems.Rows)
        {
            i++;
            lc.Text = lc.Text + "<tr>";
            lc.Text = lc.Text + "<td colspan='1' align='center'>" + i.ToString() + "</td>";
            lc.Text = lc.Text + "<td colspan='2' align='left'>" + drItems["PartNo"] + "</td>";
            lc.Text = lc.Text + "<td colspan='4' align='left'>" + drItems["Particular"].ToString().Replace("\n", "<br>") + "</td>";
            lc.Text = lc.Text + "<td colspan='1' align='center'>" + drItems["CurrentStock"] + "</td>";
            lc.Text = lc.Text + "<td colspan='1' align='center'>" + drItems["Quantity"] + "</td>";
            lc.Text = lc.Text + "<td colspan='3' align='left'>" + drItems["Remarks"] + "</td>";
            lc.Text = lc.Text + "</tr>";
        }
        if (i < 20)
        {
            i = 20 - i;
            while (i > 0)
            {
                lc.Text = lc.Text + "<tr border='0'><td colspan='12' border='0'><br></td></tr>";
                i--;
            }
        }
        lc.Text = lc.Text + "</table>";

        //Items
        lc.Text = lc.Text + "</td></tr>";

        lc.Text = lc.Text + "<tr><td colspan='12'>";
        lc.Text = lc.Text + "<table width='100%' border='1' align='center'>";
        lc.Text = lc.Text + "<tr height='100'><td align='center'>";

        try
        {
            if (dtIndentor.Rows[0]["Signature"].ToString().Trim() != "")
            {
                lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtIndentor.Rows[0]["Signature"]) + "' height='50' width='120'/>";
            }

            lc.Text = lc.Text + "<br>Indentor: " + dtIndentor.Rows[0]["Name"] + "</td>";
        }
        catch
        {

        }
        lc.Text = lc.Text + "<td align='center'>";
        if (dtApprovedBy.Rows.Count > 0)
        {
            try
            {
                if (dtApprovedBy.Rows[0]["Signature"].ToString().Trim() != "")
                {
                    lc.Text = lc.Text + "<img src='" + MapPath("~/" + dtApprovedBy.Rows[0]["Signature"]) + "' height='50' width='120'/>";
                }
                lc.Text = lc.Text + "<br>Approved By: " + dtApprovedBy.Rows[0]["Name"];
            }
            catch
            {

            }
        }
        lc.Text = lc.Text + "</td></tr></table>";
        lc.Text = lc.Text + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        Label lb = new Label();
        lb.Text = lc.ToString();
        pnlDetail.Controls.Add(lc);
    }
    protected void btnMessage_Click(object sender, EventArgs e)
    {
        LoadOrder();
    }
    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            LoadOrderForPDF();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlDetail.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
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