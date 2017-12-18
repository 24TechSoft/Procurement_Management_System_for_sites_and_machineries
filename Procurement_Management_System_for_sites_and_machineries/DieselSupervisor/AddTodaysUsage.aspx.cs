using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AddTodaysUsage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
            LoadFuel();
        }
    }
    void LoadFuel()
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.Op = 6;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.SiteFuelIssue(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtAvailableFuel.Text = dt.Rows[0]["Balance"].ToString();
        }
        else
        {
            txtAvailableFuel.Text = "0";
        }
        txtFuelIssued.Text = "0";
        txtFuelBalance.Text = txtAvailableFuel.Text;
    }
    void LoadMachines()
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.Shift = Convert.ToInt32(ddlShift.SelectedValue);
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        try { obj.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
        catch { }
        obj.Op = 11;
        DataTable dt = obj.MachineryUsage(obj).Tables[0];
        if (dt.Rows.Count == 0)
        {
            obj.Op = 9;
            dt = obj.MachineryUsage(obj).Tables[0];
            /*SiteID,SiteMachineID,Machine,OpenKMReading,OpenHRReading,OpenHSDReading,BreakDown,Idle,Driver,Remark*/
            /*CloseKMReading,TotalKMReading,OpenHReading,OpenMReading,CloseHReading,CloseMReading,TotalHRReading,OpenHSDReading,HSDIssue,
             * CloseHSDReading,TotalHSDReading,BreakDown,Idle,Driver,Remarks*/
            dt.Columns.Add("CloseKMReading");
            dt.Columns.Add("TotalKMReading");
            dt.Columns.Add("OpenHReading");
            dt.Columns.Add("OpenMReading");
            dt.Columns.Add("CloseHReading");
            dt.Columns.Add("CloseMReading");
            dt.Columns.Add("TotalHRReading");
            dt.Columns.Add("HSDIssue");
            dt.Columns.Add("CloseHSDReading");
            dt.Columns.Add("TotalHSDReading");
            dt.Columns.Add("SL");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string OpenHR = dt.Rows[i]["OpenHRReading"].ToString();
                dt.Rows[i]["CloseKMReading"] = 0;
                dt.Rows[i]["TotalKMReading"] = 0;
                try { dt.Rows[i]["OpenHReading"] = OpenHR.Substring(0, OpenHR.IndexOf(":")); }
                catch { }
                try { dt.Rows[i]["OpenMReading"] = OpenHR.Substring(OpenHR.IndexOf(":") + 1); }
                catch { }
                dt.Rows[i]["CloseHReading"] = "00";
                dt.Rows[i]["CloseMReading"] = "00";
                dt.Rows[i]["TotalHRReading"] = "00:00";
                dt.Rows[i]["HSDIssue"] = 0;
                dt.Rows[i]["CloseHSDReading"] = 0;
                dt.Rows[i]["TotalHSDReading"] = 0;
                dt.Rows[i]["SL"] = i + 1;
            }
        }
        else
        {
            dt.Columns.Add("OpenHReading");
            dt.Columns.Add("OpenMReading");
            dt.Columns.Add("CloseHReading");
            dt.Columns.Add("CloseMReading");
            dt.Columns.Add("SL");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string OpenHR = dt.Rows[i]["OpenHRReading"].ToString();
                string CloseHR = dt.Rows[i]["CloseHRReading"].ToString();
                dt.Rows[i]["OpenHReading"] = OpenHR.Substring(0, OpenHR.IndexOf(":"));
                dt.Rows[i]["OpenMReading"] = OpenHR.Substring(OpenHR.IndexOf(":") + 1);
                dt.Rows[i]["CloseHReading"] = CloseHR.Substring(0, OpenHR.IndexOf(":"));
                dt.Rows[i]["CloseMReading"] = CloseHR.Substring(OpenHR.IndexOf(":") + 1);
                dt.Rows[i]["SL"] = i + 1;
            }
        }
        grd.DataSource = dt;
        grd.DataBind();
        foreach (GridViewRow dr in grd.Rows)
        {
            CheckBox chkBreakdown = dr.FindControl("chkBreakdown") as CheckBox;
            CheckBox chkIdle = dr.FindControl("chkIdle") as CheckBox;
            if (Convert.ToInt32(dt.Rows[dr.RowIndex]["Breakdown"]) == 1)
            {
                chkBreakdown.Checked = true;
            }
            else
            {
                chkBreakdown.Checked = false;
            }
            if (Convert.ToInt32(dt.Rows[dr.RowIndex]["Idle"]) == 1)
            {
                chkIdle.Checked = true;
            }
            else
            {
                chkIdle.Checked = false;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Shift = Convert.ToInt32(ddlShift.SelectedValue);
        obj.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString();
        obj.Op = 12;
        obj.MachineryUsage(obj);
        double TotalFuelUsed = 0;
        foreach (GridViewRow dr in grd.Rows)
        {
            Label lblMachine = dr.FindControl("lblMachine") as Label;
            HiddenField hdSiteMachineID = dr.FindControl("hdSiteMachineID") as HiddenField;
            TextBox txtOpenKMReading = dr.FindControl("txtOpenKMReading") as TextBox;
            TextBox txtCloseKMReading = dr.FindControl("txtCloseKMReading") as TextBox;
            Label lblTotalKMReading = dr.FindControl("lblTotalKMReading") as Label;
            TextBox txtOpenHReading = dr.FindControl("txtOpenHReading") as TextBox;
            TextBox txtOpenMReading = dr.FindControl("txtOpenMReading") as TextBox;
            TextBox txtCloseHReading = dr.FindControl("txtCloseHReading") as TextBox;
            TextBox txtCloseMReading = dr.FindControl("txtCloseMReading") as TextBox;
            Label lblTotalHRReading = dr.FindControl("lblTotalHRReading") as Label;
            TextBox txtOpenHSDReading = dr.FindControl("txtOpenHSDReading") as TextBox;
            TextBox txtHSDIssue = dr.FindControl("txtHSDIssue") as TextBox;
            TextBox txtCloseHSDReading = dr.FindControl("txtCloseHSDReading") as TextBox;
            Label lblTotalHSDReading = dr.FindControl("lblTotalHSDReading") as Label;
            CheckBox chkBreakdown = dr.FindControl("chkBreakdown") as CheckBox;
            CheckBox chkIdle = dr.FindControl("chkIdle") as CheckBox;
            TextBox txtDriver = dr.FindControl("txtDriver") as TextBox;
            TextBox txtRemarks = dr.FindControl("txtRemarks") as TextBox;
            obj.SiteMachineID = Convert.ToInt32(hdSiteMachineID.Value);
            obj.OpenKMReading = Convert.ToDouble(txtOpenKMReading.Text);
            obj.CloseKMReading = Convert.ToDouble(txtCloseKMReading.Text);
            obj.TotalKMReading = Convert.ToDouble(lblTotalKMReading.Text);
            obj.OpenHRReading = txtOpenHReading.Text + ":" + txtOpenMReading.Text;
            obj.CloseHRReading = txtCloseHReading.Text + ":" + txtCloseMReading.Text;
            obj.TotalHRReading = lblTotalHRReading.Text;
            obj.OpenHSDReading = Convert.ToDouble(txtOpenHSDReading.Text);
            obj.CloseHSDReading = Convert.ToDouble(txtCloseHSDReading.Text);
            obj.HSDIssue = Convert.ToDouble(txtHSDIssue.Text);
            TotalFuelUsed = TotalFuelUsed + Convert.ToDouble(txtHSDIssue.Text);
            obj.TotalHSDReading = Convert.ToDouble(lblTotalHSDReading.Text);
            if (chkBreakdown.Checked == true)
            {
                obj.Breakdown = 1;
            }
            if (chkIdle.Checked == true)
            {
                obj.Idle = 1;
            }
            obj.DriverName = txtDriver.Text;
            obj.Remarks = txtRemarks.Text;
            obj.Status = 1;
            obj.EnteredBy = Convert.ToInt32(Request.Cookies["User"].Value);
            obj.Op = 1;
            obj.MachineryUsage(obj);
            if (chkBreakdown.Checked == true)
            {
                clsSiteMachines obSM = new clsSiteMachines();
                obSM.ID = Convert.ToInt32(hdSiteMachineID.Value);
                obSM.Op = 2;
                obSM.Status = 3;
                try { obSM.UpdateDate = txtDate.Text; }
                catch { }
                obSM.SiteMachines(obSM);
                clsMachineDamage obMD = new clsMachineDamage();
                obMD.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                obMD.SiteMachineID = Convert.ToInt32(hdSiteMachineID.Value);
                obMD.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString();
                obMD.Remarks = "Entry From Daily Progress Report";
                obMD.Op = 1;
                obMD.MachineDamage(obMD);
            }
            else
            {
                if (chkIdle.Checked == true)
                {
                    clsSiteMachines obSM = new clsSiteMachines();
                    obSM.ID = Convert.ToInt32(hdSiteMachineID.Value);
                    obSM.Op = 2;
                    obSM.Status = 2;
                    try { obSM.UpdateDate = txtDate.Text; }
                    catch { }
                    obSM.SiteMachines(obSM);
                }
                else
                {
                    clsSiteMachines obSM = new clsSiteMachines();
                    obSM.ID = Convert.ToInt32(hdSiteMachineID.Value);
                    obSM.Op = 2;
                    obSM.Status = 1;
                    try { obSM.UpdateDate = txtDate.Text; }
                    catch { }
                    obSM.SiteMachines(obSM);
                }
            }
        }
        clsSiteFuelIssue obSFI = new clsSiteFuelIssue();
        obSFI.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        try { obSFI.IssueDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
        catch { }
        obSFI.InAmount = Convert.ToDouble(txtFuelIssued.Text);
        obSFI.OutAmount = TotalFuelUsed;
        obSFI.Balance = Convert.ToDouble(txtFuelBalance.Text);
        obSFI.Rate = 0;
        obSFI.Total = 0;
        obSFI.Remarks = "Entry from Daily Progress Report";
        obSFI.Op = 1;
        obSFI.SiteFuelIssue(obSFI);
        LoadMachines();
        LoadFuel();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    protected void KMReading(object sender, EventArgs e)
    {
        double OpenReading = 0, CloseReading = 0;
        GridViewRow dr = (sender as TextBox).NamingContainer as GridViewRow;
        TextBox txtOpenKMReading = dr.FindControl("txtOpenKMReading") as TextBox;
        TextBox txtCloseKMReading = dr.FindControl("txtCloseKMReading") as TextBox;
        Label lblTotalKMReading = dr.FindControl("lblTotalKMReading") as Label;
        try
        {
            OpenReading = Convert.ToDouble(txtOpenKMReading.Text);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Value');", true);
            txtOpenKMReading.Focus();
            return;
        }
        try
        {
            CloseReading = Convert.ToDouble(txtCloseKMReading.Text);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Value');", true);
            txtCloseKMReading.Focus();
            return;
        }
        lblTotalKMReading.Text = (CloseReading - OpenReading).ToString();
    }
    protected void HRReading(object sender, EventArgs e)
    {
        GridViewRow dr = (sender as TextBox).NamingContainer as GridViewRow;
        TextBox txtOpenHReading = dr.FindControl("txtOpenHReading") as TextBox;
        TextBox txtOpenMReading = dr.FindControl("txtOpenMReading") as TextBox;
        TextBox txtCloseHReading = dr.FindControl("txtCloseHReading") as TextBox;
        TextBox txtCloseMReading = dr.FindControl("txtCloseMReading") as TextBox;
        Label lblTotalHRReading = dr.FindControl("lblTotalHRReading") as Label;
        try
        {
            if (txtOpenHReading.Text == "")
            {
                txtOpenHReading.Text = "00";
            }
            if (txtOpenMReading.Text == "")
            {
                txtOpenMReading.Text = "00";
            }
            if (txtCloseHReading.Text == "")
            {
                txtCloseHReading.Text = "00";
            }
            if (txtCloseMReading.Text == "")
            {
                txtCloseMReading.Text = "00";
            }
            lblTotalHRReading.Text = GetTimeDiff(txtCloseHReading.Text + ":" + txtCloseMReading.Text, txtOpenHReading.Text + ":" + txtOpenMReading.Text);
        }
        catch
        {
            lblTotalHRReading.Text = "";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid value')", true);
            return;
        }

    }
    protected void HSDReading(object sender, EventArgs e)
    {
        double OpenReading = 0, Issue = 0, CloseReading = 0;
        GridViewRow dr = (sender as TextBox).NamingContainer as GridViewRow;
        TextBox txtOpenHSDReading = dr.FindControl("txtOpenHSDReading") as TextBox;
        TextBox txtCloseHSDReading = dr.FindControl("txtCloseHSDReading") as TextBox;
        TextBox txtHSDIssue = dr.FindControl("txtHSDIssue") as TextBox;
        Label lblTotalHSDReading = dr.FindControl("lblTotalHSDReading") as Label;
        try
        {
            OpenReading = Convert.ToDouble(txtOpenHSDReading.Text);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Value');", true);
            txtOpenHSDReading.Focus();
            return;
        }
        try
        {
            CloseReading = Convert.ToDouble(txtCloseHSDReading.Text);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Value');", true);
            txtCloseHSDReading.Focus();
            return;
        }
        try
        {
            Issue = Convert.ToDouble(txtHSDIssue.Text);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Value');", true);
            txtHSDIssue.Focus();
            return;
        }
        lblTotalHSDReading.Text = (Convert.ToDouble(txtOpenHSDReading.Text) + Convert.ToDouble(txtHSDIssue.Text) - Convert.ToDouble(txtCloseHSDReading.Text)).ToString();

        if (txtHSDIssue.ID == (sender as TextBox).ID)
        {
            CalculateFuel();
        }
    }
    string GetTimeDiff(string T1,string T2)
    {
        string H1 = T1.Substring(0, T1.IndexOf(":"));
        string H2 = T2.Substring(0, T1.IndexOf(":"));
        string M1 = T1.Substring(T1.IndexOf(":") + 1);
        string M2 = T2.Substring(T2.IndexOf(":") + 1);
        int TT1 = Convert.ToInt32(H1) * 60 + Convert.ToInt32(M1);
        int TT2 = Convert.ToInt32(H2) * 60 + Convert.ToInt32(M2);
        int TT3 = TT1 - TT2;
        string H3 = (TT3 / 60).ToString();
        string M3 = (TT3 % 60).ToString();
        if (M3.Length == 1)
        {
            M3 = "0" + M3;
        }
        return H3 + ":" + M3;
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
        LoadFuel();
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    protected void SiteFuel(object sender, EventArgs e)
    {
        if (txtAvailableFuel.Text == "")
        {
            txtAvailableFuel.Text = "0";
        }
        if (txtFuelIssued.Text == "")
        {
            txtFuelIssued.Text = "0";
        }
        if (txtFuelBalance.Text == "")
        {
            txtFuelBalance.Text = "0";
        }
        CalculateFuel();
    }
    void CalculateFuel()
    {
        double FuelIssued = 0;
        foreach (GridViewRow dr in grd.Rows)
        {
            TextBox txtHSDIssue = dr.FindControl("txtHSDIssue") as TextBox;
            if (txtHSDIssue.Text == "")
            {
                txtHSDIssue.Text = "0";
            }
            FuelIssued = FuelIssued + Convert.ToDouble(txtHSDIssue.Text);
        }
        txtFuelBalance.Text = (Convert.ToDouble(txtAvailableFuel.Text) + Convert.ToDouble(txtFuelIssued.Text) - FuelIssued).ToString();
    }
}