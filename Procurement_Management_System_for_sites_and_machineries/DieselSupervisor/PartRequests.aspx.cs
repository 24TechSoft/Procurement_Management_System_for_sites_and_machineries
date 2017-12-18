using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_PartRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void LoadData()
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 8;
        obj.FromSite = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.SitePartRequest(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
        }
        grdPartRequest.DataSource = dt;
        grdPartRequest.DataBind();
        if (grdPartRequest.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void grdPartRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 7;
        obj.ID = Convert.ToInt32(grdPartRequest.DataKeys[e.RowIndex].Value);
        obj.FromSite = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.SitePartRequest(obj);
        LoadData();
    }
}