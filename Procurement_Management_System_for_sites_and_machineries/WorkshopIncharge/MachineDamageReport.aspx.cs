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
public partial class Admin_MachineDamageReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataTextField = "Machine";
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataBind();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LoadData();   
    }
    void LoadData()
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"]);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        try { obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        if (rdType.SelectedValue == "1")
        {
            obj.Op = 7;
        }
        else if (rdType.SelectedValue == "2")
        {
            obj.Op = 6;
        }
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        LiteralControl lc = new LiteralControl();
        lc.Text = "<table width='100%'>";
        lc.Text = lc.Text + "<tr><td><h5>T K ENGINEERING CONSORTIUM PVT. LTD.</h5></td></tr>";
        lc.Text = lc.Text + "<tr><td><h6>Site: " + Request.Cookies["SiteName"].Value + "</h6></td></tr>";
        if (rdType.SelectedValue == "2")
        {
            lc.Text = lc.Text + "<tr><td><h5>Log No/Machine: " + ddlMachine.SelectedItem.Text + "</h5></td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:8;'>";
        lc.Text = lc.Text + "<tr>";
        if (rdType.SelectedValue == "1")
        {
            lc.Text = lc.Text + "<td><b>Log No/Machine</b></td>";
        }
        lc.Text = lc.Text + "<td><b>Date</b></td><td><b>Remarks</b></td><td><b>Indent</b></td></tr>";
        foreach (DataRow dr in dt.Rows)
        {
            if (rdType.SelectedValue == "1")
            {
                lc.Text = lc.Text + "<td>" + dr["Machine"] + "</td>";
            }
            lc.Text = lc.Text + "<td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td><td>" + dr["Remarks"] + "</td><td>" + dr["Indent"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        pnlDetail.Controls.Add(lc);
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            LoadData();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/DamageReport.pdf");
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
        LoadData();
    }
}