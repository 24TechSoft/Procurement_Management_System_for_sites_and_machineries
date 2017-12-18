using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_SiteFuelIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadDataForEntry();
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
    void LoadDataForEntry()
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.Op = 5;
        DataTable dt = obj.SiteFuelIssue(obj).Tables[0];
        grdEntry.DataSource = dt;
        grdEntry.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.Op = 4;
        try { obj.IssueDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
        catch { }
        try { obj.IssueDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
        catch { }
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        DataTable dt = obj.SiteFuelIssue(obj).Tables[0];
        grdData.DataSource = dt;
        grdData.DataBind();
    }
    protected void txtIssueAmount_TextChanged(object sender, EventArgs e)
    {
        TextBox txtIssueAmount=sender as TextBox;
        GridViewRow dr = txtIssueAmount.NamingContainer as GridViewRow;
        Label lblCurrentBalance = dr.FindControl("lblCurrentBalance") as Label;
        Label lblBalance = dr.FindControl("lblBalance") as Label;
        try
        {
            lblCurrentBalance.Text = (Convert.ToDouble(lblBalance.Text) + Convert.ToDouble(txtIssueAmount.Text)).ToString();
        }
        catch
        {
            txtIssueAmount.Text = "0";
            lblCurrentBalance.Text = lblBalance.Text;
        }
    }
    protected void btnShowExisting_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlNew.Visible = false;
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
        pnlNew.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        foreach (GridViewRow dr in grdEntry.Rows)
        {
            TextBox txtIssueAmount = dr.FindControl("txtIssueAmount") as TextBox;
            Label lblCurrentBalance = dr.FindControl("lblCurrentBalance") as Label;
            TextBox txtRemarks = dr.FindControl("txtRemarks") as TextBox;
            //TextBox txtRate = dr.FindControl("txtRate") as TextBox;
            obj.SiteID = Convert.ToInt32(grdEntry.DataKeys[dr.RowIndex].Value);
            try { obj.IssueDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
            catch { }
            if (Convert.ToDouble(txtIssueAmount.Text) != 0)
            {
                obj.InAmount = Convert.ToDouble(txtIssueAmount.Text);
                obj.OutAmount = 0;
                obj.Balance = Convert.ToDouble(lblCurrentBalance.Text);
                try { obj.Rate = Convert.ToDouble(txtPrice.Text); }
                catch { }
                obj.Total = obj.Rate * obj.InAmount;
                obj.Remarks = txtRemarks.Text;
                obj.Op = 1;
                obj.SiteFuelIssue(obj);
            }
        }
        pnlExisting.Visible = true;
        pnlNew.Visible = false;
    }
}