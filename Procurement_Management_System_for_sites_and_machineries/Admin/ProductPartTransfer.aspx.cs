using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.ClientServices;
using System.Net;
public partial class Admin_ProductPartTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadGrid();
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSourceSite.DataSource = dt;
        ddlSourceSite.DataValueField = "ID";
        ddlSourceSite.DataTextField = "Name";
        ddlSourceSite.DataBind();

        ddlDestSite.DataSource = dt;
        ddlDestSite.DataValueField = "ID";
        ddlDestSite.DataTextField = "Name";
        ddlDestSite.DataBind();
    }
    void LoadGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SL");
        for (int i = 0; i < 20; i++)
        {
            dt.Rows.Add();
            dt.Rows[i]["SL"] = i + 1;
        }
        grd.DataSource = dt;
        grd.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsPartTransfer obj = new clsPartTransfer();
        try { obj.Reference = Convert.ToDateTime(txtDate.Text).Year.ToString() + Convert.ToDateTime(txtDate.Text).Day.ToString() + Convert.ToDateTime(txtDate.Text).Month.ToString() + ddlSourceSite.SelectedValue + ddlDestSite.SelectedValue; }
        catch { obj.Reference = DateTime.Today.Year.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + ddlSourceSite.SelectedValue + ddlDestSite.SelectedValue; }
        obj.SourceSite = Convert.ToInt32(ddlSourceSite.SelectedValue);
        obj.DestinationSite = Convert.ToInt32(ddlDestSite.SelectedValue);
        try { obj.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
        catch { }
        obj.VehicleNo = txtVehicleNo.Text;
        obj.DriverName = txtDriverName.Text;
        obj.DriverPh = txtDriverPh.Text;
        obj.Status = 1;
        obj.Op = 1;
        obj.PartTransfer(obj);
        obj.Op = 6;
        DataTable dt = obj.PartTransfer(obj).Tables[0];
        int ID = Convert.ToInt32(dt.Rows[0][0]);
        SaveItems(ID);
        SendSMS(obj.Reference);
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPartNo = (TextBox)sender;
        GridViewRow row = txtPartNo.NamingContainer as GridViewRow;
        TextBox txtPartName = grd.Rows[row.RowIndex].FindControl("txtPartName") as TextBox;
        TextBox txtMachineName = grd.Rows[row.RowIndex].FindControl("txtMachineName") as TextBox;
        TextBox txtRate = grd.Rows[row.RowIndex].FindControl("txtRate") as TextBox;
        HiddenField hdPartID = grd.Rows[row.RowIndex].FindControl("hdPartID") as HiddenField;
        clsPart obj = new clsPart();
        obj.PartName = txtPartNo.Text.Trim();
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtPartNo.Text = txtPartNo.Text.Trim();
            hdPartID.Value = dt.Rows[0]["ID"].ToString();
            txtMachineName.Text = dt.Rows[0]["ModelNo"].ToString();
            txtPartName.Text = dt.Rows[0]["PartName"].ToString();
            txtRate.Text = dt.Rows[0]["Price"].ToString();
            if (txtRate.Text.Trim() == "")
            {
                txtRate.Text = "0";
            }
        }
        else
        {
            txtPartNo.Text = "";
            hdPartID.Value = "0";
            txtPartName.Text = "";
            txtPartName.Text = "";
            txtPartNo.Focus();
        }
    }

    protected void txtQuantity_TextChange(object sender, EventArgs e)
    {
        TextBox txtQuantity = sender as TextBox;
        GridViewRow dr = txtQuantity.NamingContainer as GridViewRow;
        TextBox txtRate = dr.FindControl("txtRate") as TextBox;
        TextBox txtTotal = dr.FindControl("txtTotal") as TextBox;
        try
        {
            txtTotal.Text = (Convert.ToInt32(txtQuantity.Text) * Convert.ToDouble(txtRate.Text)).ToString();
        }
        catch
        {
            txtTotal.Text = "0";
        }
    }

    protected void txtRate_TextChange(object sender, EventArgs e)
    {
        TextBox txtRate = sender as TextBox;
        GridViewRow dr = txtRate.NamingContainer as GridViewRow;
        TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
        TextBox txtTotal = dr.FindControl("txtTotal") as TextBox;
        try
        {
            txtTotal.Text = (Convert.ToInt32(txtQuantity.Text) * Convert.ToDouble(txtRate.Text)).ToString();
        }
        catch
        {
            txtTotal.Text = "0";
        }
    }
    void SaveItems(int PTID)
    {
        try
        {
            clsPTItems obj = new clsPTItems();
            obj.Op = 1;
            obj.PTID = PTID;
            foreach (GridViewRow dr in grd.Rows)
            {
                TextBox txtPartNo = dr.FindControl("txtPartNo") as TextBox;
                HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
                TextBox txtPartName = dr.FindControl("txtPartName") as TextBox;
                TextBox txtMachineName = dr.FindControl("txtMachineName") as TextBox;
                TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
                TextBox txtRate = dr.FindControl("txtRate") as TextBox;
                TextBox txtTotal = dr.FindControl("txtTotal") as TextBox;
                if (hdPartID.Value != "" && hdPartID.Value != "0" && txtQuantity.Text != "" && Convert.ToInt32(txtQuantity.Text) != 0)
                {
                    obj.PartNo = txtPartNo.Text.Trim();
                    obj.PartName = txtPartName.Text.Trim();
                    obj.MachineName = txtMachineName.Text.Trim();
                    try { obj.Quantity = Convert.ToInt32(txtQuantity.Text); }
                    catch { }
                    try { obj.Rate = Convert.ToDouble(txtRate.Text); }
                    catch { }
                    try { obj.Total = Convert.ToDouble(txtTotal.Text); }
                    catch { }
                    obj.PTITems(obj);
                }
            }
        }
        catch { }
    }
    protected void btnViewExisting_Click(object sender, EventArgs e)
    {
        Response.Redirect("PartTransferData.aspx");
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
