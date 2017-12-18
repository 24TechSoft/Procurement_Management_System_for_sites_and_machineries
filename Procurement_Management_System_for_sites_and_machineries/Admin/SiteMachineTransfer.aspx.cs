using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_SiteMachineTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadData();
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            dr[1] = dr[1] + ", " + dr[2];
        }
        dt.Rows.InsertAt(dt.NewRow(), 0);
        dt.Rows[0][1] = "---Select Site--";
        ddlSites.DataSource = dt;
        ddlSites.DataValueField = "ID";
        ddlSites.DataTextField = "Name";
        ddlSites.DataBind();
    }
    void LoadData()
    {
        DataTable dt = new DataTable();
        if (ddlSites.SelectedIndex != 0)
        {
            clsMachineTransfer obj = new clsMachineTransfer();
            obj.Op = 3;
            obj.SourceSiteID = Convert.ToInt32(ddlSites.SelectedValue);
            obj.DestinationSiteID = Convert.ToInt32(ddlSites.SelectedValue);
            dt = obj.MachineTransfer(obj).Tables[0];
        }
        else
        {
            clsMachineTransfer obj = new clsMachineTransfer();
            obj.Op = 4;
            dt = obj.MachineTransfer(obj).Tables[0];
        }
        grdMachines.DataSource = dt;
        grdMachines.DataBind();
        pnlUpdate.Visible = false;
        if (grdMachines.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 2;
        obj.UpdateDate = DateTime.Today.ToShortDateString();
        obj.UpdatedBy = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        obj.ID = Convert.ToInt32(grdMachines.DataKeys[grdMachines.SelectedRow.RowIndex].Value);
        obj.MachineTransfer(obj);
        grdMachines.SelectedIndex = -1;
        LoadData();
        pnlUpdate.Visible = false;
        pnlRequests.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grdMachines.SelectedIndex = -1;
        LoadData();
        pnlRequests.Visible = true;
        pnlUpdate.Visible = false;
    }
    protected void grdMachines_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        pnlUpdate.Visible = true;
        lblMachineName.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[2].Text;
        lblSourceSite.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[0].Text;
        lblDestinationSite.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[1].Text;
        lblPlacedOn.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[3].Text;
        lblCurrentStatus.Text = grdMachines.Rows[e.NewSelectedIndex].Cells[6].Text;
        pnlRequests.Visible = false;
    }
    protected void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}