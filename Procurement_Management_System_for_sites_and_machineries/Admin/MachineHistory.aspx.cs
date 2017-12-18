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

public partial class Admin_MachineHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadMachines();
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSite.DataSource = dt;
        ddlSite.DataValueField = "ID";
        ddlSite.DataTextField = "Name";
        ddlSite.DataBind();
        LoadMachines();
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataTextField = "Machine";
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataBind();
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    void LoadData()
    {
        /*Site Machine Detail*/
        clsSiteMachines obSM = new clsSiteMachines();
        obSM.ID = Convert.ToInt32(ddlMachine.SelectedValue);
        obSM.Op = 5;
        DataTable dtSM = obSM.SiteMachines(obSM).Tables[0];
        /*ID,Site,MachineID,Machine,SerialNo,AddedOn,Status,UpdateDate,a.UsageUnit,a.ThesisNo,a.EngineNo,a.RegistrationNo*/
        /*Machine Damage History*/
        clsMachineDamage obMD = new clsMachineDamage();
        obMD.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        try { obMD.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obMD.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        obMD.Op = 6;
        DataTable dtMD = obMD.MachineDamage(obMD).Tables[0];
        /*ID, SiteID,Site,SiteMachineID,Machine,EntryDate,Remarks,IndentID,Indent*/
        /*Machine Progress History*/
        clsMachineryUsage obMU = new clsMachineryUsage();
        obMU.Op = 8;
        obMU.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obMU.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        try { obMU.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obMU.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        DataTable dtMU = obMU.MachineryUsage(obMU).Tables[0];
        obMU.Op = 14;
        DataTable dtFuel = obMU.MachineryUsage(obMU).Tables[0];
        obMU.Op = 13;
        DataTable dtBreakdown = obMU.MachineryUsage(obMU).Tables[0];
        /*ID,,EntryDate,Shift,ShiftText,SiteID,Site,SiteMachineID,Machine,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,CloseHRReading,TotalHRReading,OpenHSDReading,
         * CloseHSDReading,HSDIssue,TotalHSDReading,Breakdown,Idle,DriverName,Remarks,Status,EnteredBy*/
        /*Issue Slips*/
        clsSitePartIssue obSPI = new clsSitePartIssue();
        obSPI.Op = 7;
        try { obSPI.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obSPI.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        obSPI.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        DataTable dtSPI = obSPI.SitePartIssue(obSPI).Tables[0];
        /*ID,SiteID,Site,SiteMachineID,Machine,IssueDate,IssueType,Issue,Detail,Quantity,Rate,Total,Remarks*/
        /*Machine Transfer*/
        clsMachineTransfer obMT = new clsMachineTransfer();
        obMT.Op = 8;
        obMT.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        DataTable dtMT = obMT.MachineTransfer(obMT).Tables[0];
        DataTable dtMTFinal = new DataTable();
        dtMTFinal.Columns.Add("Site");
        dtMTFinal.Columns.Add("FromDate");
        dtMTFinal.Columns.Add("ToDate");
        if (dtMT.Rows.Count > 0)
        {
            dtMTFinal.Rows.Add();
            dtMTFinal.Rows[0]["Site"] = dtMT.Rows[0]["SourceSite"];
            dtMTFinal.Rows[0]["FromDate"] = Convert.ToDateTime(dtMT.Rows[0]["AddedOn"]).ToShortDateString();
            dtMTFinal.Rows[0]["ToDate"] = Convert.ToDateTime(dtMT.Rows[0]["StartDate"]).ToShortDateString();
            for (int i = 1; i < dtMT.Rows.Count; i++)
            {
                dtMTFinal.Rows.Add();
                dtMTFinal.Rows[i]["Site"] = dtMT.Rows[i]["SourceSite"];
                dtMTFinal.Rows[i]["FromDate"] = Convert.ToDateTime(dtMTFinal.Rows[i - 1]["UpdatedDate"]).ToShortDateString();
                dtMTFinal.Rows[i]["ToDate"] = Convert.ToDateTime(dtMTFinal.Rows[i]["StartDate"]).ToShortDateString();
            }
        }
        /*ID,SourceSiteID,AddedOn,SourceSite,DestinationSiteID,DestinationSite,SiteMachineID,StartDate,UpdateDate,UpdatedBy,Status,Remarks*/
        LiteralControl lc = new LiteralControl();
        lc.Text = "<h4>T K ENGINEERING CONSORTIUM PVT. LTD.</h4>";
        lc.Text = lc.Text + "<br><br><h5>Basic Detail:</h5>";
        lc.Text = lc.Text + "<table width='100%' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td>Site: " + dtSM.Rows[0]["Site"] + "</td><td>Machine: " + dtSM.Rows[0]["Machine"] + "</td><td>Log No: " + dtSM.Rows[0]["SerialNo"] + "</td><td>Registration No: " + dtSM.Rows[0]["RegistrationNo"] + "</td></tr>";
        lc.Text = lc.Text + "<tr><td>Engine No: " + dtSM.Rows[0]["EngineNo"] + "</td><td>Current Status: " + dtSM.Rows[0]["Status"] + "</td><td colspan='2'>Chessis No: " + dtSM.Rows[0]["ThesisNo"] + "</td></tr>";
        lc.Text = lc.Text + "</table>";

        lc.Text = lc.Text + "<h5>List of locations of the machine:</h5><br>";
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td><b>From Date</b></td><td><b>To Date</b></td><td><b>Location</b></td></tr>";
        foreach (DataRow dr in dtMTFinal.Rows)
        {
            lc.Text = lc.Text + "<tr><td>" + dr["FromDate"] + "</td><td>" + dr["ToDate"] + "</b></td><td>" + dr["Site"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<h5>Fuel Issues</h5><br>";
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td><b>Date</b></td><td><b>Site</b></td><td><b>Amount</b></td></tr>";
        foreach (DataRow dr in dtFuel.Rows)
        {

            lc.Text = lc.Text + "<tr><td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td><td>" + dr["Site"] + "</td><td>" + Convert.ToInt32(dr["HSDIssue"]) + "</td></tr>";

        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<h5>Spare Part Issue:</h5><br>";
        //ID,SiteID,Site,SiteMachineID,Machine,IssueDate,IssueType,Issue,Detail,Quantity,Rate,Total,Remarks
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td><b>Date</b></td><td><b>Site</b></td><td><b>Part No</b></td><td><b>Part Name</b></td><td><b>Quantity</b></td></tr>";
        foreach (DataRow dr in dtSPI.Rows)
        {
            if (Convert.ToInt32(dr["IssueType"]) == 2)
            {
                lc.Text = lc.Text + "<tr><td>" + Convert.ToDateTime(dr["IssueDate"]).ToShortDateString() + "</td><td>" + Convert.ToDateTime(dr["Site"]) + "</td><td>" + dr["PartNo"] + "</td><td>" + Convert.ToInt32(dr["PartName"]) + "</td><td>" + dr["Quantity"] + "</td></tr>";
            }
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<h5>Breakdowns:</h5><br>";
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:8'>";
        lc.Text = lc.Text + "<tr><td><b>Date</b></td><td><b>Remarks</b></td><td><b>Indent</b></td></tr>";
        foreach (DataRow dr in dtMD.Rows)
        {
            lc.Text = lc.Text + "<tr><td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td><td>" + dr["Remarks"] + "</td><td>" + dr["Indent"] + "</td></tr>";
        }
        lc.Text = lc.Text + "</table>";
        lc.Text = lc.Text + "<h5>Daily Progress Report:</h5><br>";
        /*ID,EntryDate,Shift,ShiftText,SiteID,Site,SiteMachineID,Machine,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,CloseHRReading,TotalHRReading,OpenHSDReading,
         * CloseHSDReading,HSDIssue,TotalHSDReading,Breakdown,Idle,DriverName,Remarks,Status,EnteredBy*/
        lc.Text = lc.Text + "<table width='100%' border='1' style='font-size:6'>";
        lc.Text = lc.Text + "<tr><td><b>Site</b></td><td><b>Entry Date</b></td><td><b>Shift</b></td><td><b>Open KM Reading</b></td><td><b>Close KM Reading</b></td><td><b>Total KM Reading</b></td>";
        lc.Text = lc.Text + "<td><b>Open HR Reading</b></td><td><b>Close HR Reading</b></td><td><b>Total HR Reading</b></td><td><b>Open HSD Reading</b></td><td><b>Close HSD Reading</b></td>";
        lc.Text = lc.Text + "<td><b>HSD Issue</b></td><td><b>Total HSD Reading</b></td><td><b>Breakdown</b></td><td><b>Idle</b></td><td><b>Driver Name</b></td><td><b>Remarks</b></td>";
        foreach (DataRow dr in dtMU.Rows)
        {
            lc.Text = lc.Text + "<tr>";
            lc.Text = lc.Text + "<td>" + dr["Site"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["EntryDate"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["ShiftText"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["OpenKMReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["CloseKMReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["TotalKMReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["OpenHRReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["CloseHRReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["TotalHRReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["OpenHSDReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["CloseHSDReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["HSDIssue"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["TotalHSDReading"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["Breakdown"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["Idle"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["DriverName"] + "</td>";
            lc.Text = lc.Text + "<td>" + dr["Remarks"] + "</td>";
            lc.Text = lc.Text + "</tr>";
        }
        lc.Text = lc.Text + "</table>";

        pnlDetail.Controls.Add(lc);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            LoadData();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/MachineHistory.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlDetail.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 20f, 20f, 20f, 20f);

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