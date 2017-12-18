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
using System.Net;
public partial class Admin_MachineTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            LoadSites();
            LoadMachines();
        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(ddlSourceSite.SelectedValue);
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

        ddlSourceSite.DataSource = dt;
        ddlSourceSite.DataValueField = "ID";
        ddlSourceSite.DataTextField = "Name";
        ddlSourceSite.DataBind();
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
            lblError.Text = "No Records Found";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        //ID, SourceSiteID, DestinationSiteID, SiteMachineID, StartDate, UpdateDate, UpdatedBy, Status, Remarks
        obj.SourceSiteID = Convert.ToInt32(ddlSourceSite.Text);
        obj.DestinationSiteID = Convert.ToInt32(ddlDestSite.SelectedValue);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        try { obj.StartDate = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
        catch { }
        try { obj.UpdateDate = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
        catch { }
        obj.UpdatedBy = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Status = 0;
        obj.DriverName = txtDriverName.Text;
        obj.DriverPhone = txtDriverPhone.Text;
        obj.Op = 1;
        obj.MachineTransfer(obj);
        obj.Op = 9;
        DataTable dt = obj.MachineTransfer(obj).Tables[0];
        SendSMS(Convert.ToInt32(dt.Rows[0][0]));
        LoadData();
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 2;
        obj.UpdateDate = DateTime.Today.ToShortDateString();
        obj.UpdatedBy = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Status = Convert.ToInt32(ddlStatus.SelectedValue);
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
            //select a.ID,a.SourceSiteID,SourceSiteName,SourceSiteAddress,SourceSitePhoneNo,SourceSiteEmail,SSiteIncharge,SSiteInchargePh,a.DestinationSiteID,DestSiteName,
            //DestSiteAddress,DestSitePhoneNo,DestSiteEmail,DSiteIncharge,DSiteInchargePh,a.SiteMachineID,Machine,StartDate,UpdateDate,UpdatedBy,Status,a.DriverName,a.DriverPhone 
            StringBuilder str = new StringBuilder();
            str.Append("<table width='100%' style='font-size:8;'>");
            str.Append("<tr><td colspan='8'>");
            str.Append("<h4>TK Engineering Consortium Pvt. Limited</h4>");
            str.Append("<h5>Date: " + dt.Rows[0]["StartDate"] + "</h5>");
            str.Append("</td><td colspan='4'>");
            str.Append("<img src='" + MapPath("~/images/logo.jpg") + "' width='150'/>");
            str.Append("</tr>");
            str.Append("<tr><td colspan='4'>");
            str.Append("Source Site:<br><b>" + dt.Rows[0]["SourceSiteName"] + "</b><br>");
            str.Append("Address: " + dt.Rows[0]["SourceSiteAddress"].ToString().Replace("\n", "<br>") + "<br>");
            str.Append("Phone No: " + dt.Rows[0]["SourceSitePhoneNo"] + "<br>");
            str.Append("Email: " + dt.Rows[0]["SourceSiteEmail"] + "<br>");
            str.Append("Site Incharge: " + dt.Rows[0]["SSiteIncharge"] + "<br>Phone No" + dt.Rows[0]["SSiteInchargePh"]);
            str.Append("</td><td colspan='4'></td><td align='right' colspan='4'><div style='text-align:left;'>");
            str.Append("Destination Site:<br><b>" + dt.Rows[0]["DestSiteName"] + "</b><br>");
            str.Append("Address: " + dt.Rows[0]["DestSiteAddress"].ToString().Replace("\n", "<br>") + "<br>");
            str.Append("Phone No: " + dt.Rows[0]["DestSitePhoneNo"] + "<br>");
            str.Append("Email: " + dt.Rows[0]["DestSiteEmail"] + "<br>");
            str.Append("Site Incharge: " + dt.Rows[0]["DSiteIncharge"] + "<br>Phone No" + dt.Rows[0]["DSiteInchargePh"]);
            str.Append("</div></td></tr>");
            str.Append("</table>");
            str.Append("<h5>Machine Log No / Model: " + dt.Rows[0]["Machine"]+"</h5>");
            str.Append("<h5>Driver Name: " + dt.Rows[0]["DriverName"] + "</h5>");
            str.Append("<h5>Driver Phone No: " + dt.Rows[0]["DriverPhone"] + "</h5>");
            str.Append("<h5>Current Status: " + dt.Rows[0]["CurrStatus"] + "</h5>");
            Label lbl = new Label();
            lbl.Text = str.ToString();
            Panel pnl = new Panel();
            pnl.Controls.Add(lbl);
            return pnl;
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
    protected void ddlSourceSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    void SendSMS(int ID)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 5;
        obj.ID = ID;
        DataTable dt = obj.MachineTransfer(obj).Tables[0];
        string Mobile = "";
        try
        {
            if (dt.Rows[0]["SourceSitePhoneNo"].ToString().Trim() != "")
            {
                Mobile = Mobile + dt.Rows[0]["SourceSitePhoneNo"].ToString();
            }
            if (dt.Rows[0]["DestSitePhoneNo"].ToString().Trim() != "")
            {
                if (Mobile != "")
                {
                    Mobile = Mobile + ",";
                }
                Mobile = Mobile + dt.Rows[0]["DestSitePhoneNo"].ToString();
            }
            clsPTItems obPTI = new clsPTItems();
            obPTI.PTID = Convert.ToInt32(dt.Rows[0]["ID"]);
            obPTI.Op = 2;
            DataTable dtPTI = obPTI.PTITems(obPTI).Tables[0];
            int total = 0;
            foreach (DataRow dr in dtPTI.Rows)
            {
                total = total + Convert.ToInt32(dr["Quantity"]);
            }
            string Message = "From: " + dt.Rows[0]["SourceSiteName"] + ", To: " + dt.Rows[0]["DestSiteName"] + ", Machine: " + dt.Rows[0]["Machine"] + ", Vehicle No: " + dt.Rows[0]["VehicleNo"];
            Message = Message + ", Driver Name:" + dt.Rows[0]["DriverName"] + ", Driver Phone: " + dt.Rows[0]["DriverPhone"] + ", Status: Dispatched";
            string URL = "http://sambsms.com/app/smsapi/index.php?key=458AD34748890B&campaign=0&routeid=7&type=text&contacts=" + Mobile + "&senderid=TKECON&msg=" + Message + "";
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            //optional
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        }
        catch
        {
        }
    }
}