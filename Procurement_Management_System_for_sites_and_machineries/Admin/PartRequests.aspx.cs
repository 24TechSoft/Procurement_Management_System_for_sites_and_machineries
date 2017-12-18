using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_PartRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            LoadSites();
        }
    }
    void LoadData()
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 3;
        DataTable dt = obj.SitePartRequest(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
        }
        grdPartRequest.DataSource = dt;
        grdPartRequest.DataBind();
        if (grdPartRequest.Rows.Count == 0)
        {
            lblError.Text = "No Records found";
        }
        else
        {
            lblError.Text = "";
        }
    }
    void LoadDataBySite()
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 4;
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        DataTable dt = obj.SitePartRequest(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
        }
        grdPartRequest.DataSource = dt;
        grdPartRequest.DataBind();
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
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDataBySite();
    }
    protected void grdPartRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdPartRequest.DataKeys[e.RowIndex].Value);
        obj.Status = 1;
        obj.SitePartRequest(obj);
        LoadDataBySite();
    }
}