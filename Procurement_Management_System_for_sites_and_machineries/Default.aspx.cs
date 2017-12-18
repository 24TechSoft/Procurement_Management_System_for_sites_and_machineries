using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.Op = 9;
        obj.UserID = txtUserID.Text;
        obj.Password = txtPassword.Text;
        obj.UserType = Convert.ToInt32(ddlUserType.SelectedValue);
        try
        {
            DataTable dt = obj.UserMaster(obj).Tables[0];
            if (dt.Rows.Count > 0)
            {
                msg.Text = "<script type='text/javascript'>alert('Successfull');</script>";
                Response.Cookies["User"].Value = dt.Rows[0]["ID"].ToString();
                Response.Cookies["User"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Name"].Value = dt.Rows[0]["Name"].ToString();
                Response.Cookies["Name"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["UserID"].Value = dt.Rows[0]["UserID"].ToString();
                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["UserType"].Value = dt.Rows[0]["UserType"].ToString();
                Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Designation"].Value = dt.Rows[0]["Designation"].ToString();
                Response.Cookies["Designation"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["SiteID"].Value = dt.Rows[0]["SiteID"].ToString();
                Response.Cookies["SiteID"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["SiteName"].Value = dt.Rows[0]["SiteName"].ToString();
                Response.Cookies["SiteName"].Expires = DateTime.Now.AddDays(1);
                if (Convert.ToInt32(dt.Rows[0]["UserType"]) == 1)
                {
                    Response.Redirect("Admin/");
                }
                else if (Convert.ToInt32(dt.Rows[0]["UserType"]) == 2)
                {
                    Response.Redirect("WorkshopIncharge/");
                }
                else
                {
                    Response.Redirect("DieselSupervisor/");
                }
            }
            else
            {
                msg.Text = "<script type='text/javascript'>alert('Wrong Authentication Detail');</script>";
            }
        }
        catch
        {
            msg.Text = "<script type='text/javascript'>alert('Error in Query');</script>";
        }
    }

}
