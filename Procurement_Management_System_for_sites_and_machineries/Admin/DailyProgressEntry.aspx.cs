using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_DailyProgressEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToString();
            LoadSites();
            LoadGrid();
        }
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
    
    void LoadGrid()
    {
        clsDailyProgressReport obj = new clsDailyProgressReport();
        obj.Op = 5;
        if(txtDate.Text!="")
        {
            obj.EntryDate1 = txtDate.Text;
        }
        else
        {
            obj.EntryDate1 = DateTime.Today.ToShortDateString();
        }
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obj.Shift = Convert.ToInt32(ddlShift.SelectedValue);
        DataTable dt = obj.DailyProgressReport(obj).Tables[0];
        if (dt.Rows.Count == 0)
        {
            obj.Op = 6;
            dt = obj.DailyProgressReport(obj).Tables[0];
        }
        dt.Columns.Add("SL");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["SL"] = i + 1;
        }
        grd.DataSource = dt;
        grd.DataBind();
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsDailyProgressReport obj = new clsDailyProgressReport();
        foreach (GridViewRow dr in grd.Rows)
        {
            HiddenField hdID = (HiddenField)dr.FindControl("hdID");
            Label lblMachine = (Label)dr.FindControl("lblMachine");
            HiddenField hdSiteMachineID = (HiddenField)dr.FindControl("hdSiteMachineID");
            Label lblLogNo = (Label)dr.FindControl("lblLogNo");
            TextBox txtOpenReading = (TextBox)dr.FindControl("txtOpenReading");
            TextBox txtCloseReading = (TextBox)dr.FindControl("txtCloseReading");
            TextBox txtTotalReading = (TextBox)dr.FindControl("txtTotalReading");
            TextBox txtFuelIssued = (TextBox)dr.FindControl("txtFuelIssued");
            Label lblDamage = (Label)dr.FindControl("lblDamage");
            HiddenField hdBreakdown = (HiddenField)dr.FindControl("hdBreakdown");
            TextBox txtRemarks = (TextBox)dr.FindControl("txtRemarks");
            //ID, SiteID, SiteMachineID, EntryDate, Shift, StartReading, CloseReading, FuelIssued, TotalReading, BreakDown, Remarks
            obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
            obj.SiteMachineID = Convert.ToInt32(hdSiteMachineID.Value);
            obj.EntryDate1=Convert.ToDateTime(txtDate.Text).ToShortDateString();
            obj.Shift = Convert.ToInt32(ddlShift.SelectedValue);
            obj.StartReading = Convert.ToDouble(txtOpenReading.Text);
            obj.CloseReading = Convert.ToDouble(txtCloseReading.Text);
            obj.FuelIssued = Convert.ToDouble(txtFuelIssued.Text);
            obj.TotalReading = Convert.ToDouble(txtTotalReading.Text);
            obj.BreakDown = Convert.ToInt32(hdBreakdown.Value);
            obj.Remarks = txtRemarks.Text;
            if (Convert.ToInt32(hdID.Value) == 0)
            {
                obj.Op = 1;
            }
            else
            {
                obj.Op = 2;
                obj.ID = Convert.ToInt32(hdID.Value);
            }
            obj.DailyProgressReport(obj);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Data Saved')", true);
        }
        LoadGrid();
    }
    protected void txtOpenReading_TextChanged(object sender,EventArgs e)
    {
        TextBox txtOpenReading = (TextBox)sender;
        int row = (txtOpenReading.NamingContainer as GridViewRow).RowIndex;
        UpdateData(row);
    }
    protected void txtCloseReading_TextChanged(object sender,EventArgs e)
    {
        TextBox txtCloseReading = (TextBox)sender;
        int row = (txtCloseReading.NamingContainer as GridViewRow).RowIndex;
        UpdateData(row);
    }
    protected void txtFuelIssued_TextChanged(object sender, EventArgs e)
    {
        TextBox txtFuelIssued = (TextBox)sender;
        int row = (txtFuelIssued.NamingContainer as GridViewRow).RowIndex;
        UpdateData(row);
    }
    void UpdateData(int RowID)
    {
         TextBox txtOpenReading =(TextBox)grd.Rows[RowID].FindControl("txtOpenReading");
         TextBox txtCloseReading = (TextBox)grd.Rows[RowID].FindControl("txtCloseReading");
         TextBox txtFuelIssued = (TextBox)grd.Rows[RowID].FindControl("txtFuelIssued");
         TextBox txtTotalReading = (TextBox)grd.Rows[RowID].FindControl("txtTotalReading");
         if (txtOpenReading.Text == "")
         {
             txtOpenReading.Text = "0";
         }
         if (txtCloseReading.Text == "")
         {
             txtCloseReading.Text = "0";
         }
         if (txtFuelIssued.Text == "")
         {
             txtFuelIssued.Text = "0";
         }
         double OpenReading = Convert.ToDouble(txtOpenReading.Text);
         double CloseReading = Convert.ToDouble(txtCloseReading.Text);
         double FuelIssued = Convert.ToDouble(txtFuelIssued.Text);
         double TotalReading = OpenReading + FuelIssued - CloseReading;
         txtTotalReading.Text = TotalReading.ToString();
    }
}