using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            lblAdminName.Text = Request.Cookies["Name"].Value.ToString();
            clsSite obj = new clsSite();
            obj.ID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 5;
            DataTable dt = obj.SiteMaster(obj).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblSiteName.Text = dt.Rows[0]["Name"].ToString();
            }
            if (Convert.ToInt32(Request.Cookies["UserType"].Value) != 3)
            {
                if (Convert.ToInt32(Request.Cookies["UserType"].Value) == 1)
                {
                    Response.Redirect("~/Admin/Admin.aspx");
                }
                else if (Convert.ToInt32(Request.Cookies["UserType"].Value) == 2)
                {
                    Response.Redirect("~/WorkshopIncharge/Default.aspx");
                }
            }
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Response.Cookies["Name"].Value = "";
        Response.Cookies["UserID"].Value = "";
        Response.Cookies["Designation"].Value = "";
        Response.Cookies["SiteID"].Value = "";
        Response.Cookies["SiteName"].Value = "";
        Response.Redirect("~/Default.aspx");
    }
}
