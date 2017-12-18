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
public partial class Admin_IssueReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    void LoadData()
    {
        StringBuilder str = new StringBuilder();
        clsSitePartIssue obPI = new clsSitePartIssue();
        try { obPI.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obPI.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        obPI.Op = 7;
        clsMachineryUsage obMU = new clsMachineryUsage();
        try { obMU.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obMU.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        obMU.Op = 8;
        obMU.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        str.Append("<h5>Site: " + Request.Cookies["SiteName"].Value);
        str.Append("<h5>From " + txtDateFrom.Text + " To " + txtDateTo.Text + "</h5>");
        if (ddlMachine.SelectedValue == "0")
        {
            foreach (System.Web.UI.WebControls.ListItem li in ddlMachine.Items)
            {
                if (li.Value != "0")
                {
                    obPI.SiteMachineID = Convert.ToInt32(li.Value);
                    DataTable dtPI = obPI.SitePartIssue(obPI).Tables[0];
                    str.Append("<br>");
                    str.Append("<h5>Log No/Machine: " + li.Text + "</h5>");
                    str.Append("<br>");
                    int count = 0;
                    str.Append("<table width='100%' border='1' style='border-color:#00f; font-size:8;'>");
                    str.Append("<tr><td colspan='6'><h5>Spare Part Issue Detail</h5></td></tr>");
                    str.Append("<tr><td><b>SL</b></td><td><b>Date</b></td><td><b>Part No</b></td><td><b>Part Name</b></td><td><b>Price</b></td><td><b>Quantity</b></td></tr>");
                    foreach (DataRow dr in dtPI.Rows)
                    {
                        count++;
                        str.Append("<tr>");
                        str.Append("<td>" + count.ToString() + "</td>");
                        str.Append("<td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td>");
                        str.Append("<td>" + dr["PartNo"].ToString() + "</td>");
                        str.Append("<td>" + dr["PartName"].ToString() + "</td>");
                        str.Append("<td>" + dr["Price"].ToString() + "</td>");
                        str.Append("<td>" + dr["Quantity"].ToString() + "</td>");
                        str.Append("</tr>");
                    }
                    if (count == 0)
                    {
                        str.Append("<tr><td colspan='6'>No Records Found</td></tr>");
                    }
                    str.Append("</table>");
                    str.Append("<br>");
                    obMU.SiteMachineID = Convert.ToInt32(li.Value);
                    DataTable dtMU = obMU.MachineryUsage(obMU).Tables[0];
                    count = 0;
                    str.Append("<table width='100%' border='1' style='border-color:#0ff; font-size:8;'>");
                    str.Append("<tr><td colspan='3'><h5>Fuel Issue Detail</h5></td></tr>");
                    str.Append("<tr><td><b>SL</b></td><td><b>Date</b></td><td><b>Quantity</b></td></tr>");
                    foreach (DataRow dr in dtMU.Rows)
                    {
                        count++;
                        str.Append("<tr>");
                        str.Append("<td>" + count.ToString() + "</td>");
                        str.Append("<td>" + dr["EntryDate"].ToString() + "</td>");
                        str.Append("<td>" + dr["HSDIssue"].ToString() + "</td>");
                        str.Append("</tr>");
                    }
                    if (count == 0)
                    {
                        str.Append("<tr><td colspan='3'>No Records Found</td></tr>");
                    }
                    str.Append("</table>");
                }
            }
        }
        else
        {
            obPI.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
            DataTable dtPI = obPI.SitePartIssue(obPI).Tables[0];
            str.Append("<br>");
            str.Append("<h5>Log No/Machine: " + ddlMachine.SelectedItem.Text + "</h5>");
            str.Append("<br>");
            int count = 0;
            str.Append("<table width='100%' border='1' style='border-color:#00f; font-size:8;'>");
            str.Append("<tr><td colspan='6'><h5>Spare Part Issue Detail</h5></td></tr>");
            str.Append("<tr><td><b>SL</b></td><td><b>Date</b></td><td><b>Part No</b></td><td><b>Part Name</b></td><td><b>Price</b></td><td><b>Quantity</b></td></tr>");
            foreach (DataRow dr in dtPI.Rows)
            {
                count++;
                str.Append("<tr>");
                str.Append("<td>" + count.ToString() + "</td>");
                str.Append("<td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td>");
                str.Append("<td>" + dr["PartNo"].ToString() + "</td>");
                str.Append("<td>" + dr["PartName"].ToString() + "</td>");
                str.Append("<td>" + dr["Price"].ToString() + "</td>");
                str.Append("<td>" + dr["Quantity"].ToString() + "</td>");
                str.Append("</tr>");
            }
            if (count == 0)
            {
                str.Append("<tr><td colspan='6'>No Records Found</td></tr>");
            }
            str.Append("</table>");
            str.Append("<br>");
            obMU.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
            DataTable dtMU = obMU.MachineryUsage(obMU).Tables[0];
            count = 0;
            str.Append("<table width='100%' border='1' style='border-color:#0ff; font-size:8;'>");
            str.Append("<tr><td colspan='3'><h5>Fuel Issue Detail</h5></td></tr>");
            str.Append("<tr><td><b>SL</b></td><td><b>Date</b></td><td><b>Quantity</b></td></tr>");
            foreach (DataRow dr in dtMU.Rows)
            {
                count++;
                str.Append("<tr>");
                str.Append("<td>" + count.ToString() + "</td>");
                str.Append("<td>" + dr["EntryDate"].ToString() + "</td>");
                str.Append("<td>" + dr["HSDIssue"].ToString() + "</td>");
                str.Append("</tr>");
            }
            if (count == 0)
            {
                str.Append("<tr><td colspan='3'>No Records Found</td></tr>");
            }
            str.Append("</table>");
        }
        Label lbl = new Label();
        lbl.Text = str.ToString();
        pnlDetail.Controls.Add(lbl);
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
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
        ddlMachine.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
    }
    protected void btnExportToPdf_Click(object sender, EventArgs e)
    {
        try
        {
            LoadData();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/Panel.pdf");
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