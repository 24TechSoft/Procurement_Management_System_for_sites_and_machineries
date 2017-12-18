using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_SiteIndent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadData();
        }
    }
    void LoadData()
    {
        clsIndent obj = new clsIndent();
        if (ddlSites.SelectedIndex == 0)
        {
            obj.Op = 3;
        }
        else
        {
            obj.Op = 11;
            obj.OrderFrom = 1;
            obj.OrderFromID = Convert.ToInt32(ddlSites.SelectedValue);
        }
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            dt.Rows[0][4] = "No rows found";
        }
        grdIndent.DataSource = dt;
        grdIndent.DataBind();
        if (grdIndent.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSites.DataSource = dt;
        ddlSites.DataValueField = "ID";
        ddlSites.DataTextField = "Location";
        ddlSites.DataBind();
        ddlSites.Items.Insert(0, new ListItem("--Select Site--", String.Empty));
    }
    protected void grdIndent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Redirect("ViewIndent.aspx?ID=" + grdIndent.DataKeys[e.RowIndex].Value.ToString());
    }
    protected void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}