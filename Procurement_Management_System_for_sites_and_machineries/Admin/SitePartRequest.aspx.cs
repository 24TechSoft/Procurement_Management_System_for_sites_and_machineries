using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_SitePartRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            LoadSites();
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSites.DataSource = dt;
        ddlSites.DataValueField = "ID";
        ddlSites.DataTextField = "Name";
        ddlSites.DataBind();
        ListItem li = new ListItem("Select Site");
        ddlSites.Items.Add(li);
        ddlSites.Items[ddlSites.Items.Count - 1].Selected = true;
    }
    void LoadData()
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        if (ddlSites.SelectedIndex == ddlSites.Items.Count - 1)
        {
            obj.Op = 3;
        }
        else
        {
            obj.SiteID = Convert.ToInt32(ddlSites.SelectedValue);
            obj.Op = 4;
        }
            DataTable dt = obj.SitePartRequest(obj).Tables[0];
         foreach (DataRow dr in dt.Rows)
        {
            if (dr["Photo"] != "")
            {
                dr["Photo"] = "~/" + dr["Photo"];
            }
            else
            {
                dr["Photo"] = "No Image";
            }
        }
        grdParts.DataSource = dt;
        grdParts.DataBind();
        if (grdParts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    protected void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    protected void grdParts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdParts.EditIndex = e.NewEditIndex;
        LoadData();
    }
    protected void grdParts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlEStatus = (DropDownList)grdParts.Rows[e.RowIndex].FindControl("ddlEStatus");
         TextBox   txtEPartNo=(TextBox)grdParts.Rows[e.RowIndex].FindControl("txtEPartNo");
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.PartNo=txtEPartNo.Text;
        obj.Status = Convert.ToInt32(ddlEStatus.SelectedValue);
        obj.SitePartRequest(obj);
        grdParts.EditIndex = -1;
        LoadData();
    }
    protected void grdParts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdParts.EditIndex = -1;
        LoadData();
    }
    protected void grdParts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.Op = 6;
        obj.SitePartRequest(obj);
        LoadData();
    }
}