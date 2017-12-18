using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_MachineryPapers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
            LoadData();
        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataTextField = "Machine";
        ddlMachine.DataBind();
    }
    void LoadData()
    {
        clsSiteMachineRecords obj = new clsSiteMachineRecords();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 5;
        DataTable dt = obj.SiteMachineRecords(obj).Tables[0];
        grdRecords.DataSource = dt;
        grdRecords.DataBind();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = true;
        pnlExisitng.Visible = false;
    }
    protected void btnExisting_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = false;
        pnlExisitng.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsSiteMachineRecords obj = new clsSiteMachineRecords();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        obj.RecordName = ddlRecordName.Text;
        obj.RecordValue = txtRecordNo.Text;
        obj.ValidFrom = txtValidFrom.Text;
        obj.ValidTo = txtValidTo.Text;
        obj.TotalCost = Convert.ToDouble(txtTotalCost.Text);
        obj.RemindBeforeDays = Convert.ToInt32(txtRemindBefore.Text);
        obj.Op = 1;
        obj.SiteMachineRecords(obj);
        pnlExisitng.Visible = true;
        pnlNew.Visible = false;
        LoadData();
    }
    protected void grdRecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdRecords.EditIndex = -1;
        LoadData();
    }
    protected void grdRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSiteMachineRecords obj = new clsSiteMachineRecords();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(grdRecords.DataKeys[e.RowIndex].Value);
        obj.SiteMachineRecords(obj);
        LoadData();
    }
    protected void grdRecords_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdRecords.EditIndex = e.NewEditIndex;
        LoadData();
    }
    protected void grdRecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtERecordName = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtERecordName");
        TextBox txtERecordValue = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtERecordValue");
        TextBox txtEValidFrom = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtEValidFrom");
        TextBox txtEValidTo = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtEValidTo");
        TextBox txtETotalCost = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtETotalCost");
        TextBox txtERemindBeforeDays = (TextBox)grdRecords.Rows[e.RowIndex].FindControl("txtERemindBeforeDays");
        clsSiteMachineRecords obj = new clsSiteMachineRecords();
        obj.RecordName = txtERecordName.Text;
        obj.RecordValue = txtERecordValue.Text;
        obj.ValidFrom = txtEValidFrom.Text;
        obj.ValidTo = txtEValidTo.Text;
        obj.TotalCost = Convert.ToDouble(txtETotalCost.Text);
        obj.RemindBeforeDays = Convert.ToInt32(txtERemindBeforeDays.Text);
        obj.ID = Convert.ToInt32(grdRecords.DataKeys[e.RowIndex].Value);
        obj.Op = 2;
        obj.SiteMachineRecords(obj);
        grdRecords.EditIndex = -1;
        LoadData();
    }


}