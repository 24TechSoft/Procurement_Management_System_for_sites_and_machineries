using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AdminRenewalAlerts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAlerts();
    }
    void LoadAlerts()
    {
        clsAlerts obj = new clsAlerts();
        obj.Op = 4;
        DataTable dt = obj.Alerts(obj).Tables[0];
        grdAlerts.DataSource = dt;
        grdAlerts.DataBind();
        if (grdAlerts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No records found";
        }
    }
}