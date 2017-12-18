using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_CurrentStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txtEntryDate.Text = DateTime.Today.ToShortDateString();
            LoadAllData();
        }
        catch
        {

        }
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.Op = 8;
        obj.PartName = txtPartNo.Text.Trim();
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            hdMachineID.Value = dt.Rows[0]["MachineID"].ToString();
            hdPartID.Value = dt.Rows[0]["ID"].ToString();
            LoadDataByPart();
        }
        else
        {
            txtPartNo.Text = "";
            txtPartNo.Focus();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hdMachineID.Value != "" && hdPartID.Value != "")
        {
            clsSiteProductParts obj = new clsSiteProductParts();
            //ID,SiteID,MachineID, PartID, EntryDate, BillRef, TransactionType, Quantity
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.SiteMachineID = Convert.ToInt32(hdMachineID.Value);
            obj.PartID = Convert.ToInt32(hdPartID.Value);
            obj.EntryDate1 = txtEntryDate.Text;
            obj.BillRef = txtBillRef.Text;
            obj.TransactionType = Convert.ToInt32(ddlTransactionType.SelectedValue);
            obj.Quantity = Convert.ToInt32(txtQuantity.Text);
            obj.Op = 1;
            obj.SiteProductParts(obj);
            LoadAllData();
        }
    }
    void LoadDataByPart()
    {
        try
        {
            clsSiteProductParts obj = new clsSiteProductParts();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.PartID = Convert.ToInt32(hdPartID.Value);
            obj.Op = 6;
            DataTable dt = obj.SiteProductParts(obj).Tables[0];
            grdParts.DataSource = dt;
            grdParts.DataBind();
            int Quantity = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Quantity = Quantity + Convert.ToInt32(dt.Rows[i]["Quantity"]);
            }
            grdParts.FooterRow.Cells[5].Text = Quantity.ToString();
            grdParts.FooterRow.Cells[4].Text = "Total";
            if (grdParts.Rows.Count > 0)
            {
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "No Records found";
            }
        }
        catch
        {

        }
    }
    void LoadAllData()
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 4;
        DataTable dt = obj.SiteProductParts(obj).Tables[0];
        grdParts.DataSource = dt;
        grdParts.DataBind();
        int Quantity = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Quantity = Quantity + Convert.ToInt32(dt.Rows[i]["Quantity"]);
        }
        grdParts.FooterRow.Cells[5].Text = Quantity.ToString();
        grdParts.FooterRow.Cells[4].Text = "Total";
        if (grdParts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void grdParts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.SiteProductParts(obj);
        LoadAllData();
    }
    protected void grdParts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdParts.EditIndex = e.NewEditIndex;
        LoadAllData();
    }
    protected void grdParts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtEBillRef = (TextBox)grdParts.Rows[e.RowIndex].FindControl("txtEBillRef");
        TextBox txtEQuantity = (TextBox)grdParts.Rows[e.RowIndex].FindControl("txtEQuantity");
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.Op = 2;
        obj.Quantity = Convert.ToInt32(txtEQuantity.Text);
        obj.BillRef = txtEBillRef.Text;
        obj.SiteProductParts(obj);
        LoadAllData();
    }
    protected void grdParts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdParts.EditIndex = -1;
        LoadAllData();
    }
}