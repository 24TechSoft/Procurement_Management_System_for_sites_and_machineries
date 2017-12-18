using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
public partial class Admin_PartTransferData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
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
        ddlSite.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    void LoadData()
    {
        clsPartTransfer obj = new clsPartTransfer();
        if (ddlSite.SelectedValue != "0")
        {
            obj.Op = 4;
            obj.DestinationSite = Convert.ToInt32(ddlSite.SelectedValue);
            obj.SourceSite = Convert.ToInt32(ddlSite.SelectedValue);
        }
        else
        {
            obj.Op = 3;
        }
        try { obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        DataTable dt = obj.PartTransfer(obj).Tables[0];
        grdData.DataSource = dt;
        grdData.DataBind();
        foreach (GridViewRow dr in grdData.Rows)
        {
            LiteralControl lc = new LiteralControl();
            lc.Text = "<a href='PTReport.aspx?RefNo=" + grdData.DataKeys[dr.RowIndex].Value + "' target='_blank'>View</a>";
            dr.Cells[8].Controls.Add(lc);
        }
    }
    protected void grdData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsPartTransfer obj = new clsPartTransfer();
        obj.Reference = grdData.DataKeys[e.RowIndex].Value.ToString();
        obj.Status=2;
        obj.Op = 2;
        obj.PartTransfer(obj);
        LoadData();
        SendSMS(grdData.DataKeys[e.RowIndex].Value.ToString());
    }
    void SendSMS(string Reference)
    {
        clsPartTransfer obj = new clsPartTransfer();
        obj.Op = 5;
        obj.Reference = Reference;
        DataTable dt = obj.PartTransfer(obj).Tables[0];
        string Mobile = "";
        try
        {
            if (dt.Rows[0]["SSiteInchargePh"].ToString().Trim() != "")
            {
                Mobile = Mobile + dt.Rows[0]["SSiteInchargePh"].ToString();
            }
            if (dt.Rows[0]["DSiteInchargePh"].ToString().Trim() != "")
            {
                if (Mobile != "")
                {
                    Mobile = Mobile + ",";
                }
                Mobile = Mobile + dt.Rows[0]["DSiteInchargePh"].ToString();
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
            string Message = "Reference No: " + Reference + ", From: " + dt.Rows[0]["SourceSiteName"] + ", To: " + dt.Rows[0]["DestSiteName"] + ", Quantity: " + total.ToString() + ", Vehicle No: " + dt.Rows[0]["VehicleNo"];
            Message = Message + ", Driver Name:" + dt.Rows[0]["DriverName"] + ", Driver Phone: " + dt.Rows[0]["DriverPhone"] + ", Status: Delivered";
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