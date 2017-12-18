using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_RenewalAlerts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAlerts();
    }
    void LoadAlerts()
    {
        clsAlerts obj = new clsAlerts();
        obj.Op = 7;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.Alerts(obj).Tables[0];
        grdAlerts.DataSource = dt;
        grdAlerts.DataBind();
        if (grdAlerts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
}