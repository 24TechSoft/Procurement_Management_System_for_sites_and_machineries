using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblTotalNewPart.Text = NewParts();
            lblTotalIndents.Text = Indents();
            lblTotalPurchaseOrders.Text = PurchaseOrders();
            lblTotalRenewal.Text = Renewal();
        }
    }
    string NewParts()
    {
        try
        {
            clsAlerts obj = new clsAlerts();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 8;
            DataTable dt = obj.Alerts(obj).Tables[0];
            return dt.Rows.Count.ToString();
        }
        catch
        {
            return "";
        }
    }
    string Indents()
    {
        try
        {
            clsAlerts obj = new clsAlerts();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 6;
            DataTable dt = obj.Alerts(obj).Tables[0];
            return dt.Rows.Count.ToString();
        }
        catch
        {
            return "";
        }
    }
    string PurchaseOrders()
    {
        try
        {
            clsAlerts obj = new clsAlerts();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 3;
            DataTable dt = obj.Alerts(obj).Tables[0];
            return dt.Rows.Count.ToString();
        }
        catch
        {
            return "";
        }
    }
    string Renewal()
    {
        try
        {
            clsAlerts obj = new clsAlerts();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 7;
            DataTable dt = obj.Alerts(obj).Tables[0];
            return dt.Rows.Count.ToString();
        }
        catch
        {
            return "";
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lblTotalNewPart.Text = NewParts();
        lblTotalIndents.Text = Indents();
        lblTotalRenewal.Text = Renewal();
    }
}