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
using System.Text;
public partial class Admin_MachineryUsageStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadMachines();
                txtDateFrom.Text = DateTime.Today.AddDays(-1).ToShortDateString();
                txtDateTo.Text = DateTime.Today.AddDays(1).ToShortDateString();
            }
            catch
            {

            }
        }
    }
    void LoadAllMachineData()
    {
        DataTable dtAll = new DataTable();
        dtAll.Columns.Add("Machine");
        dtAll.Columns.Add("TotalKMReading");
        dtAll.Columns.Add("TotalHRReading");
        dtAll.Columns.Add("TotalHSDIssue");
        dtAll.Columns.Add("TotalHSDReading");
        dtAll.Columns.Add("Breakdown");
        dtAll.Columns.Add("Idle");
        dtAll.Columns.Add("NoOfRecords");

        StringBuilder lc = new StringBuilder();
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 8;
        try { obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        foreach (System.Web.UI.WebControls.ListItem li in ddlMachine.Items)
        {
            if (li.Value != "0")
            {
                double TotalKMReading = 0, TotalHSDIssue = 0, TotalHSDReading = 0;
                int Breakdown = 0, Idle = 0, NoOfRecords = 0;
                string Machine = "", TotalHRReading = "00:00";
                obj.SiteMachineID = Convert.ToInt32(li.Value);
                DataTable dt = obj.MachineryUsage(obj).Tables[0];
                //ID,,EntryDate,Shift,SiteID,Site,SiteMachineID,Machine,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,
                //CloseHRReading,TotalHRReading,OpenHSDReading,CloseHSDReading,HSDIssue,TotalHSDReading,Breakdown,Idle,DriverName,Remarks,Status,
                //EnteredBy
                NoOfRecords = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    Machine = dr["Machine"].ToString();
                    TotalKMReading = TotalKMReading + Convert.ToDouble(dr["TotalKMReading"]);
                    TotalHSDIssue = TotalHSDIssue + Convert.ToDouble(dr["HSDIssue"]);
                    TotalHSDReading = TotalHSDReading + Convert.ToDouble(dr["TotalHSDReading"]);
                    TotalHRReading = SumTime(TotalHRReading, dr["TotalHRReading"].ToString());
                    if (Convert.ToInt32(dr["Breakdown"]) == 1)
                    {
                        Breakdown++;
                    }
                    else if (Convert.ToInt32(dr["Idle"]) == 1)
                    {
                        Idle++;
                    }
                }
                dtAll.Rows.Add();
                dtAll.Rows[dtAll.Rows.Count - 1]["Machine"] = Machine;
                dtAll.Rows[dtAll.Rows.Count - 1]["TotalKMReading"] = TotalKMReading;
                dtAll.Rows[dtAll.Rows.Count - 1]["TotalHRReading"] = TotalHRReading;
                dtAll.Rows[dtAll.Rows.Count - 1]["TotalHSDIssue"] = TotalHSDIssue;
                dtAll.Rows[dtAll.Rows.Count - 1]["TotalHSDReading"] = TotalHSDReading;
                dtAll.Rows[dtAll.Rows.Count - 1]["Breakdown"] = Breakdown;
                dtAll.Rows[dtAll.Rows.Count - 1]["Idle"] = Idle;
                dtAll.Rows[dtAll.Rows.Count - 1]["NoOfRecords"] = NoOfRecords;
            }
        }
        lc.Append("<h5>Site:" + Request.Cookies["SiteName"].Value + "</h5>");
        lc.Append("From " + obj.EntryDate1 + " To " + obj.EntryDate2);
        if (dtAll.Rows.Count == 0)
        {
            lc.Append("<h6>NO RECORDS FOUND</h6>");
        }
        else
        {
            lc.Append("<table width='100%' border='1' style='font-size:8'>");
            lc.Append("<tr><td><b>SL</b></td><td><b>Machine</b></td><td><b>Total KM Reading</b></td><td><b>Total HR Reading</b></td>");
            lc.Append("<td><b>Total HSD Issue</b></td><td><b>Total HSD Reading</b></td><td><b>Breakdown</b></td><td><b>Idle</b></td>");
            lc.Append("<td><b>No of Records</b></td></tr>");
            int sl=0;
            foreach (DataRow dr in dtAll.Rows)
            {
                sl++;
                lc.Append("<tr>");
                lc.Append("<td>" + sl.ToString() + "</td>");
                lc.Append("<td>" + dr["Machine"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalKMReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalHRReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalHSDIssue"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalHSDReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["Breakdown"].ToString() + "</td>");
                lc.Append("<td>" + dr["Idle"].ToString() + "</td>");
                lc.Append("<td>" + dr["NoOfRecords"].ToString() + "</td>");
                lc.Append("</tr>");
            }
            lc.Append("</table>");
        }
        Label label=new Label();
        label.Text=lc.ToString();
        pnlData.Controls.Add(label);
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataTextField = "Machine";
        ddlMachine.DataBind();
        ddlMachine.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
    }
    string SumTime(string Time1, string Time2)
    {
        int H = Convert.ToInt32(Time1.Substring(0, Time1.IndexOf(":"))) + Convert.ToInt32(Time2.Substring(0, Time2.IndexOf(":")));
        int M = Convert.ToInt32(Time1.Substring(Time1.IndexOf(":") + 1)) + Convert.ToInt32(Time2.Substring(Time2.IndexOf(":") + 1));
        if (M > 59)
        {
            M = 59;
            H = H + 1;
        }
        string H1 = "";
        string M1 = "";
        if (H < 10)
        {
            H1 = "0" + H.ToString();
        }
        else
        {
            H1 = H.ToString();
        }
        if (M < 10)
        {
            M1 = "0" + M.ToString();
        }
        else
        {
            M1 = M.ToString();
        }
        return H1.ToString() + ":" + M1.ToString();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlMachine.SelectedValue == "0")
        {
            LoadAllMachineData();
        }
        else
        {
            LoadData();
        }
    }
    void LoadData()
    {
        StringBuilder lc = new StringBuilder();
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 8;
        try { obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        double TotalKMReading = 0, TotalHSDIssue = 0, TotalHSDReading = 0;
        int Breakdown = 0, Idle = 0, NoOfRecords = 0;
        string Machine = "", TotalHRReading = "00:00";
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        DataTable dt = obj.MachineryUsage(obj).Tables[0];
        //ID,,EntryDate,Shift,SiteID,Site,SiteMachineID,Machine,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,
        //CloseHRReading,TotalHRReading,OpenHSDReading,CloseHSDReading,HSDIssue,TotalHSDReading,Breakdown,Idle,DriverName,Remarks,Status,
        //EnteredBy
        lc.Append("<h5>Site: " + Request.Cookies["SiteName"].Value + "</h5>");
        lc.Append("<h5>Machine: " + ddlMachine.SelectedItem.Text + "</h5>");
        lc.Append("<h6>From " + obj.EntryDate1 + " To " + obj.EntryDate2 + "</h6>");
        if (dt.Rows.Count == 0)
        {
            lc.Append("<h6>NO RECORDS FOUND</h6>");
        }
        else
        {
            lc.Append("<br><table width='100%' border='1' style='font-size:8'>");
            lc.Append("<tr><td><b>SL</b></td><td><b>Date</b></td><td><b>Shift</b></td><td><b>Opening KM Reading</b></td>");
            lc.Append("<td><b>Closing KM Reading</b></td><td><b>Total KM Reading</b></td><td><b>Opening HR Reading</b></td>");
            lc.Append("<td><b>Closing HR Reading</b></td><td><b>Total HR Reading</b></td><td><b>Opening HSD Reading</b></td>");
            lc.Append("<td><b>Closing HSD Reading</b></td><td><b>HSD Issue</b></td><td><b>Total HSD Reading</b></td>");
            lc.Append("<td><b>Breakdown</b></td><td><b>Idle</b></td><td><b>Driver Name</b></td><td><b>Remarks</b></td>");
            lc.Append("<td><b>Entered By</b></td></tr>");
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                lc.Append("<tr>");
                count++;
                lc.Append("<td>" + count.ToString() + "</td>");
                lc.Append("<td>" + dr["EntryDate"].ToString() + "</td>");
                lc.Append("<td>" + dr["ShiftText"].ToString() + "</td>");
                lc.Append("<td>" + dr["OpenKMReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["CloseKMReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalKMReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["OpenHRReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["CloseHRReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalHRReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["OpenHSDReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["CloseHSDReading"].ToString() + "</td>");
                lc.Append("<td>" + dr["HSDIssue"].ToString() + "</td>");
                lc.Append("<td>" + dr["TotalHSDReading"].ToString() + "</td>");
                if (Convert.ToInt32(dr["Breakdown"]) == 1)
                {
                    Breakdown++;
                    lc.Append("<td>Yes</td>");
                }
                else
                {
                    lc.Append("<td>No</td>");
                }
                if (Convert.ToInt32(dr["Idle"]) == 1)
                {
                    Idle++;
                    lc.Append("<td>Yes</td>");
                }
                else
                {
                    lc.Append("<td>No</td>");
                }
                lc.Append("<td>" + dr["DriverName"].ToString() + "</td>");
                lc.Append("<td>" + dr["Remarks"].ToString() + "</td>");
                lc.Append("<td>" + dr["EnteredBy"].ToString() + "</td></tr>");
                Machine = dr["Machine"].ToString();
                TotalKMReading = TotalKMReading + Convert.ToDouble(dr["TotalKMReading"]);
                TotalHSDIssue = TotalHSDIssue + Convert.ToDouble(dr["HSDIssue"]);
                TotalHSDReading = TotalHSDReading + Convert.ToDouble(dr["TotalHSDReading"]);
                TotalHRReading = SumTime(TotalHRReading, dr["TotalHRReading"].ToString());
            }
            lc.Append("<tr><td colspan='5'><b>Total</b></td>");
            lc.Append("<td><b>" + TotalKMReading.ToString() + "</b></td>");
            lc.Append("<td colspan='2'></td>");
            lc.Append("<td><b>" + TotalHRReading.ToString() + "</b></td>");
            lc.Append("<td colspan='2'></td>");
            lc.Append("<td><b>" + TotalHSDIssue.ToString() + "</b></td>");
            lc.Append("<td><b>" + TotalHSDReading.ToString() + "</b></td>");
            lc.Append("<td><b>" + Breakdown.ToString() + "</b></td>");
            lc.Append("<td><b>" + Idle.ToString() + "</b></td>");
            lc.Append("<td colspan='3'></td>");
            lc.Append("</tr>");
            lc.Append("</table>");
        }
        Label label=new Label();
        label.Text=lc.ToString();
        pnlData.Controls.Add(label);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMachine.SelectedValue == "0")
            {
                LoadAllMachineData();
            }
            else
            {
                LoadData();
            }
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 3f, 3f, 3f, 3f);
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
    string AverageTime(string Time, int Count)
    {
        int min = Convert.ToInt32(Time.Substring(Time.IndexOf(":") + 1));
        int hr = Convert.ToInt32(Time.Substring(0, Time.IndexOf(":")));
        int totalmin = min + (hr * 60);
        int avgHR = (totalmin / Count) / 60;
        int avgMin = (totalmin / Count) % 60;
        string hr1 = "", min1 = "";
        if (avgHR < 10)
        {
            hr1 = "0" + avgHR.ToString();
        }
        else
        {
            hr1 = avgHR.ToString();
        }
        if (avgMin < 10)
        {
            min1 = "0" + avgMin.ToString();
        }
        else
        {
            min1 = avgMin.ToString();
        }
        return hr1 + ":" + min1;
    }
    string GetMinTime(string Time1, string Time2)
    {
        int h1 = Convert.ToInt32(Time1.Substring(0, Time1.IndexOf(":")));
        int m1 = Convert.ToInt32(Time1.Substring(Time1.IndexOf(":") + 1));
        int h2 = Convert.ToInt32(Time2.Substring(0, Time2.IndexOf(":")));
        int m2 = Convert.ToInt32(Time2.Substring(Time2.IndexOf(":") + 1));
        if (h1 == h2)
        {
            if (m1 > m2)
            {
                return Time2;
            }
            else
            {
                return Time1;
            }
        }
        else
        {
            if (h1 > h2)
            {
                return Time2;
            }
            else
            {
                return Time1;
            }
        }
    }
    string GetMaxTime(string Time1, string Time2)
    {
        int h1 = Convert.ToInt32(Time1.Substring(0, Time1.IndexOf(":")));
        int m1 = Convert.ToInt32(Time1.Substring(Time1.IndexOf(":") + 1));
        int h2 = Convert.ToInt32(Time2.Substring(0, Time2.IndexOf(":")));
        int m2 = Convert.ToInt32(Time2.Substring(Time2.IndexOf(":") + 1));
        if (h1 == h2)
        {
            if (m1 < m2)
            {
                return Time2;
            }
            else
            {
                return Time1;
            }
        }
        else
        {
            if (h1 < h2)
            {
                return Time2;
            }
            else
            {
                return Time1;
            }
        }
    }
    double MaxAmount(double Item1, double Item2)
    {
        if (Item1 > Item2)
        {
            return Item1;
        }
        else
        {
            return Item2;
        }
    }
    double MinAmount(double Item1, double Item2)
    {
        if (Item1 < Item2)
        {
            return Item1;
        }
        else
        {
            return Item2;
        }
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
}