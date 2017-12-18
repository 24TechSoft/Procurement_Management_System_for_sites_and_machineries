using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_Machines : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
            txtAddedOn.Text = DateTime.Today.ToShortDateString();
        }
    }
    //ID, SiteID, MachineID, SerialNo, AddedOn, Status, UpdateDate, UsageUnit
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.MachineID = Convert.ToInt32(hdMachine.Value);
        obj.SerialNo = txtSerial.Text;
        obj.AddedOn = txtAddedOn.Text;
        obj.Status = 1;
        obj.UpdateDate = txtAddedOn.Text;
        obj.UsageUnit = txtUnit.Text;
        obj.Op = 1;
        obj.SiteMachines(obj);
        LoadMachines();
        pnlNew.Visible = false;
        pnlExisting.Visible = true;
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        grdMachines.DataSource = dt;
        grdMachines.DataBind();
        if (grdMachines.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = true;
        pnlExisting.Visible = false;
        pnlChange.Visible = false;
    }
    protected void btnExisting_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlNew.Visible = false;
        pnlChange.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.ID = Convert.ToInt32(hdEid.Value);
        obj.Op = 2;
        obj.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        obj.UpdateDate = DateTime.Today.ToShortDateString();
        obj.SiteMachines(obj);
        pnlChange.Visible = false;
        pnlExisting.Visible = true;
        LoadMachines();
    }
    protected void txtMachine_TextChanged(object sender, EventArgs e)
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.ModelNo = txtMachine.Text;
        obj.Op = 7;
        DataTable dt = obj.MachineMaster(obj).Tables[0];
        grdMachine.DataSource = dt;
        grdMachine.DataBind();
        grdMachine.Visible = true;
    }
    protected void grdMachine_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        hdMachine.Value = grdMachine.DataKeys[e.RowIndex].Value.ToString();
        txtMachine.Text=grdMachine.Rows[e.RowIndex].Cells[1].Text;
        txtSerial.Text=grdMachine.Rows[e.RowIndex].Cells[0].Text;
        grdMachine.Visible = false;
    }
    protected void grdMachines_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        hdEid.Value = grdMachines.DataKeys[e.RowIndex].Value.ToString();
        lblSerial.Text = grdMachines.Rows[e.RowIndex].Cells[2].Text;
        lblMachine.Text = grdMachines.Rows[e.RowIndex].Cells[1].Text;
        lblAddedOn.Text = grdMachines.Rows[e.RowIndex].Cells[3].Text;
        pnlChange.Visible = true;
        pnlNew.Visible = false;
        pnlExisting.Visible = false;
    }
}