using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_CurrentStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadAllData();
                LoadGrid();
                LoadMachines();
            }
        }
        catch
        {

        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachines.DataSource = dt;
        ddlMachines.DataValueField = "ID";
        ddlMachines.DataTextField = "Machine";
        ddlMachines.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in grd.Rows)
        {
            TextBox txtPartNo = dr.FindControl("txtPartNo") as TextBox;
            HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
            Label lblPartName = dr.FindControl("lblPartName") as Label;
            TextBox txtReference = dr.FindControl("txtReference") as TextBox;
            DropDownList ddlTransactionType = dr.FindControl("ddlTransactionType") as DropDownList;
            TextBox txtRate = dr.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
            Label lblTotal = dr.FindControl("lblTotal") as Label;
            TextBox txtRemarks = dr.FindControl("txtRemarks") as TextBox;
            clsSiteProductParts obj = new clsSiteProductParts();
            //ID, SiteID,SiteMachineID,PartID,EntryDate1,EntryDate2,BillRef,TransactionType,Quantity,Rate,Total,Remarks,Op
            if (hdPartID.Value != "" && Convert.ToInt32(txtQuantity.Text) != 0)
            {
                obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                obj.SiteMachineID = Convert.ToInt32(ddlMachines.SelectedValue);
                obj.PartID = Convert.ToInt32(hdPartID.Value);
                try { obj.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
                catch { }
                obj.BillRef=txtReference.Text;
                obj.TransactionType=Convert.ToInt32(ddlTransactionType.SelectedValue);
                obj.Quantity=Convert.ToInt32(txtQuantity.Text);
                obj.Rate=Convert.ToDouble(txtRate.Text);
                obj.Total=Convert.ToDouble(lblTotal.Text);
                obj.Remarks=txtRemarks.Text;
                obj.Op = 1;
                obj.SiteProductParts(obj);
            }
        }
    }
    void LoadAllData()
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 9;
        DataTable dt = obj.SiteProductParts(obj).Tables[0];
        grdAllStock.DataSource = dt;
        grdAllStock.DataBind();
    }
    protected void grdParts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.SiteProductParts(obj);
        LoadSelectedData(grdAllStock.SelectedIndex);
    }
    protected void grdParts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdParts.EditIndex = e.NewEditIndex;
        LoadSelectedData(grdAllStock.SelectedIndex);
    }
    protected void grdParts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtEBillRef = (TextBox)grdParts.Rows[e.RowIndex].FindControl("txtEBillRef");
        TextBox txtEQuantity = (TextBox)grdParts.Rows[e.RowIndex].FindControl("txtEQuantity");
        Label lblTotalPrice = (Label)grdParts.Rows[e.RowIndex].FindControl("lblTotalPrice");
        TextBox txtERate = (TextBox)grdParts.Rows[e.RowIndex].FindControl("txtERate");
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.Op = 2;
        obj.Quantity = Convert.ToInt32(txtEQuantity.Text);
        obj.BillRef = txtEBillRef.Text;
        try { obj.Rate = Convert.ToDouble(txtERate.Text); }
        catch { }
        try { obj.Total = (Convert.ToDouble(txtERate.Text) * Convert.ToInt32(txtEQuantity.Text)); }
        catch { }
        obj.SiteProductParts(obj);
        LoadSelectedData(grdAllStock.SelectedIndex);
    }
    protected void grdParts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdParts.EditIndex = -1;
        LoadSelectedData(grdAllStock.SelectedIndex);
    }
    void LoadGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SL");
        for (int i = 0; i < 20; i++)
        {
            dt.Rows.Add();
            dt.Rows[i]["SL"] = i + 1;
        }
        grd.DataSource = dt;
        grd.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPartNo = sender as TextBox;
        txtPartNo.Text = txtPartNo.Text.Trim();
        GridViewRow dr = txtPartNo.NamingContainer as GridViewRow;
        HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
        Label lblPartName = dr.FindControl("lblPartName") as Label;
        TextBox txtReference = dr.FindControl("txtReference") as TextBox;
        DropDownList ddlTransactionType = dr.FindControl("ddlTransactionType") as DropDownList;
        TextBox txtRate = dr.FindControl("txtRate") as TextBox;
        TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
        Label lblTotal = dr.FindControl("lblTotal") as Label;
        TextBox txtRemarks = dr.FindControl("txtRemarks") as TextBox;
        clsPart obj = new clsPart();
        obj.Op = 8;
        obj.PartName = txtPartNo.Text;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            hdPartID.Value = dt.Rows[0]["ID"].ToString();
            lblPartName.Text = dt.Rows[0]["PartName"].ToString();
            txtRate.Text = dt.Rows[0]["Price"].ToString();
        }
        else
        {
            txtPartNo.Text = "";
            txtPartNo.Focus();
            lblPartName.Text = "";
            hdPartID.Value = "";
        }
    }
    protected void txtRate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtRate = sender as TextBox;
        txtRate.Text = txtRate.Text.Trim();
        GridViewRow dr = txtRate.NamingContainer as GridViewRow;
        TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
        Label lblTotal = dr.FindControl("lblTotal") as Label;
        try
        {
            lblTotal.Text = (Convert.ToDouble(txtRate.Text) * Convert.ToInt32(txtQuantity.Text)).ToString();
        }
        catch
        {
            lblTotal.Text = "0";
        }
    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        TextBox txtQuantity = sender as TextBox;
        txtQuantity.Text = txtQuantity.Text.Trim();
        GridViewRow dr = txtQuantity.NamingContainer as GridViewRow;
        TextBox txtRate = dr.FindControl("txtRate") as TextBox;
        Label lblTotal = dr.FindControl("lblTotal") as Label;
        try
        {
            lblTotal.Text = (Convert.ToDouble(txtRate.Text) * Convert.ToInt32(txtQuantity.Text)).ToString();
        }
        catch
        {
            lblTotal.Text = "0";
        }
    }
    protected void grdAllStock_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        grdAllStock.SelectedIndex = e.NewSelectedIndex;
        LoadSelectedData(grdAllStock.SelectedIndex);
    }
    void LoadSelectedData(int Index)
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.Op = 10;
        HiddenField hdSiteMachineID = grdAllStock.Rows[Index].FindControl("hdSiteMachineID") as HiddenField;
        HiddenField hdPartID = grdAllStock.Rows[Index].FindControl("hdPartID") as HiddenField;
        obj.SiteMachineID = Convert.ToInt32(hdSiteMachineID.Value);
        obj.PartID = Convert.ToInt32(hdPartID.Value);
        DataTable dt = obj.SiteProductParts(obj).Tables[0];
        grdParts.DataSource = dt;
        grdParts.DataBind();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = true;
        pnlExisting.Visible = false;
    }
    protected void btnExisting_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlNew.Visible = false;
    }
}