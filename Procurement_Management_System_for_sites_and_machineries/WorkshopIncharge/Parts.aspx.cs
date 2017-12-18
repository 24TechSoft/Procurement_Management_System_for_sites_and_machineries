using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Worker_Parts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
            LoadParts();
        }
    }
    protected void ddlSiteMachine_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadParts();
    }
    void LoadParts()
    {
        clsPart obj = new clsPart();
        obj.Op = 5;
        obj.MachineID = Convert.ToInt32(ddlSiteMachine.SelectedValue);
        DataTable dt = obj.PartMaster(obj).Tables[0];
        grdParts.DataSource = dt;
        grdParts.DataBind();
        if (grdParts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No data found for this machine";
        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlSiteMachine.DataSource = dt;
        ddlSiteMachine.DataValueField = "MachineID";
        ddlSiteMachine.DataTextField = "Machine";
        ddlSiteMachine.DataBind();
    }

    protected void grdParts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdParts.PageIndex = e.NewPageIndex;
        LoadParts();
    }
}