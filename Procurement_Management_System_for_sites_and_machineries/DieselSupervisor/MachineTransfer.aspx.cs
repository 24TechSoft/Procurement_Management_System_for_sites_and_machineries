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
public partial class Supervisor_MachineTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            LoadMachines();
            LoadSites();
        }
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
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (Convert.ToInt32(dt.Rows[i]["ID"]) == Convert.ToInt32(Request.Cookies["SiteID"].Value))
                {
                    dt.Rows[i].Delete();
                    i--;
                }
                else
                {
                    dt.Rows[i]["Name"] = dt.Rows[i]["Name"] + ", " + dt.Rows[i]["Location"];
                }
            }
            catch
            {
                break;
            }
        }
        ddlDestSite.DataSource = dt;
        ddlDestSite.DataTextField = "Name";
        ddlDestSite.DataValueField = "ID";
        ddlDestSite.DataBind();
    }
    void LoadData()
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 3;
        obj.SourceSiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.DestinationSiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.MachineTransfer(obj).Tables[0];
        grdMachines.DataSource = dt;
        grdMachines.DataBind();
        pnlUpdate.Visible = false;
        if (grdMachines.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        //ID, SourceSiteID, DestinationSiteID, SiteMachineID, StartDate, UpdateDate, UpdatedBy, Status, Remarks
        obj.SourceSiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.DestinationSiteID = Convert.ToInt32(ddlDestSite.SelectedValue);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        obj.StartDate = DateTime.Today.ToShortDateString();
        obj.UpdateDate = DateTime.Today.ToShortDateString();
        obj.UpdatedBy = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Status = 0;
       // obj.Remarks = txtRemarks.Text;
        obj.Op = 1;
        obj.MachineTransfer(obj);
        LoadData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 2;
        obj.UpdateDate = DateTime.Today.ToShortDateString();
        obj.UpdatedBy = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        //obj.Remarks = txtERemarks.Text;
        obj.ID = Convert.ToInt32(grdMachines.DataKeys[grdMachines.SelectedRow.RowIndex].Value);
        obj.MachineTransfer(obj);

        if (Convert.ToInt32(ddlStatus.SelectedValue) == 3)
        {
            obj.Op = 6;
            obj.ID = Convert.ToInt32(grdMachines.DataKeys[grdMachines.SelectedRow.RowIndex].Value);
            DataTable dt = obj.MachineTransfer(obj).Tables[0];
            clsSiteMachines objSM = new clsSiteMachines();
            objSM.Op = 4;
            objSM.ID = Convert.ToInt32(dt.Rows[0]["SiteMachineID"]);
            objSM.UpdateDate = DateTime.Today.ToShortDateString();
            objSM.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            objSM.SiteMachines(objSM);
        }
        grdMachines.SelectedIndex = 1;
        LoadData();
        
        pnlUpdate.Visible = false;
        pnlRequests.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grdMachines.SelectedIndex = -1;
        LoadData();
        pnlRequests.Visible = true;
        pnlUpdate.Visible = false;
    }
    protected void grdMachines_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 6;
        obj.ID = Convert.ToInt32(grdMachines.DataKeys[e.NewSelectedIndex].Value);
        DataTable dt = obj.MachineTransfer(obj).Tables[0];
        pnlUpdate.Visible = true;
        pnlRequests.Visible = false;
        if (grdMachines.Rows[e.NewSelectedIndex].Cells[6].Text == "Pending for Approval" || grdMachines.Rows[e.NewSelectedIndex].Cells[6].Text == "Canceled" || grdMachines.Rows[e.NewSelectedIndex].Cells[6].Text == "Delivered")
        {
            ddlStatus.Enabled=false;
            txtERemarks.Enabled=false;
            btnUpdate.Enabled=false;
        }
        else
        {
            ddlStatus.Enabled=true;
            txtERemarks.Enabled=true;
            btnUpdate.Enabled=true;
        }
        if (Convert.ToInt32(Request.Cookies["SiteID"].Value) == Convert.ToInt32(dt.Rows[0]["SourceSiteID"]))
        {
            ddlStatus.Items[0].Enabled = true;
            ddlStatus.Items[1].Enabled = false;
        }
        else
        {
            ddlStatus.Items[0].Enabled = false;
            ddlStatus.Items[1].Enabled = true;
        }
        txtERemarks.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[7].Text;
        lblMachineName.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[2].Text;
        lblSourceSite.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[0].Text;
        lblDestinationSite.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[1].Text;
        lblPlacedOn.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[3].Text;
        lblCurrentStatus.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[6].Text;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.ID = Convert.ToInt32(grdMachines.DataKeys[grdMachines.SelectedIndex].Value);
        obj.Op = 7;
        obj.MachineTransfer(obj);
        pnlUpdate.Visible = false;
        pnlRequests.Visible = true;
        grdMachines.SelectedIndex = -1;
        LoadData();
    }

    Panel LoadDetailForPDF()
    {
        try
        {
            clsMachineTransfer obj = new clsMachineTransfer();
            obj.Op = 6;
            obj.ID = Convert.ToInt32(grdMachines.DataKeys[grdMachines.SelectedRow.RowIndex].Value);
            DataTable dt = obj.MachineTransfer(obj).Tables[0];
            DataTable dtSourceSite, dtDestinationSite, dtMachineDetail;
            clsSite obSite = new clsSite();
            clsSiteMachines objSM = new clsSiteMachines();
            objSM.Op = 5;
            objSM.ID = Convert.ToInt32(dt.Rows[0]["SiteMachineID"]);
            dtMachineDetail = objSM.SiteMachines(objSM).Tables[0];

            obSite.Op = 5;
            obSite.ID = Convert.ToInt32(dt.Rows[0]["SourceSiteID"]);
            dtSourceSite = obSite.SiteMaster(obSite).Tables[0];
            obSite.ID = Convert.ToInt32(dt.Rows[0]["DestinationSiteID"]);
            dtDestinationSite = obSite.SiteMaster(obSite).Tables[0];
            LiteralControl lc = new LiteralControl();
            lc.Text = lc.Text + "<table width='100%'>";
            lc.Text = lc.Text + "<tr><td align='center' colspan='12'><h3>MACHINE TRANSFER RECEIPT</h3></td></tr>";
            lc.Text = lc.Text + "<tr><td align='center' colspan='12'><h4>T.K. Engineering Consortium Pvt. Ltd.</h4></td></tr>";
            lc.Text = lc.Text + "<tr><td colspan='3'>";
            if (dtSourceSite.Rows.Count > 0)
            {
                lc.Text = lc.Text + dtSourceSite.Rows[0]["Name"] + "<br>" + dtSourceSite.Rows[0]["Location"] + "<br>" + dtSourceSite.Rows[0]["Address"];
            }
            else
            {
                lc.Text = lc.Text + lblSourceSite.Text;
            }
            lc.Text = lc.Text + "</td><td colspan='6'></td><td colspan='3'>";
            if (dtDestinationSite.Rows.Count > 0)
            {
                lc.Text = lc.Text + dtDestinationSite.Rows[0]["Name"] + "<br>" + dtDestinationSite.Rows[0]["Location"] + "<br>" + dtDestinationSite.Rows[0]["Address"];
            }
            else
            {
                lc.Text = lc.Text + lblDestinationSite.Text;
            }
            lc.Text = lc.Text + "</td></tr>";

            lc.Text = lc.Text + "<tr><td colspan='3'><b>Machine</b></td><td colspan='2'><b>Serial No</b></td><td colspan='3'><b>Status</b></td><td colspan='2'><b>Thesis No</b></td><td colspan='2'><b>Engine No</b></td></tr>";
            lc.Text = lc.Text + "<tr><td colspan='3'>" + dtMachineDetail.Rows[0]["Machine"] + "</td><td colspan='2'>" + dtMachineDetail.Rows[0]["SerialNo"] + "</td><td colspan='3'>" + dtMachineDetail.Rows[0]["Status"] + "</td><td colspan='2'>" + dtMachineDetail.Rows[0]["ThesisNo"] + "</td><td colspan='2'>" + dtMachineDetail.Rows[0]["EngineNo"] + "</td></tr>";
            lc.Text = lc.Text + "</table>";
            Panel p = new Panel();
            p.Controls.Add(lc);
            return p;
        }
        catch
        {
            return null;
        }
    }
    protected void btnDownloadReport_Click(object sender, EventArgs e)
    {
        try
        {
            Panel p=LoadDetailForPDF();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=../PDF/Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            p.RenderControl(hw);
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
    }
}