using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_WorkshopItemsTransactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllData();
        }
    }
    void LoadAllData()
    {
        try
        {
            clsWorkshopItemTransaction obj = new clsWorkshopItemTransaction();
            obj.Op = 5;
            DataTable dt = obj.WorkshopItemTransaction(obj).Tables[0];
            grdItems.DataSource = dt;
            grdItems.DataBind();
            int Qty = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Qty = Qty + Convert.ToInt32(dr["Quantity"]);
            }
            grdItems.FooterRow.Cells[4].Text = Qty.ToString();
            if (grdItems.Rows.Count > 0)
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
    void LoadData()
    {
        try
        {
            clsWorkshopItemTransaction obj = new clsWorkshopItemTransaction();
            obj.Op = 4;
            obj.ItemID = Convert.ToInt32(hdItemID.Value);
            DataTable dt = obj.WorkshopItemTransaction(obj).Tables[0];
            grdItems.DataSource = dt;
            grdItems.DataBind();
            int Qty = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Qty = Qty + Convert.ToInt32(dr["Quantity"]);
            }
            grdItems.FooterRow.Cells[4].Text = Qty.ToString();
        }
        catch
        {
            LoadAllData();
        }
    }
    protected void txtItemName_TextChanged(object sender, EventArgs e)
    {
        clsWorkshopItemMaster obj = new clsWorkshopItemMaster();
        obj.ItemName = txtItemName.Text;
        obj.Op = 5;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.WorkshopItemMaster(obj).Tables[0];
        grdItemList.DataSource = dt;
        grdItemList.DataBind();
        grdItemList.Visible = true;
    }
    protected void grdItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtItemName.Text = grdItemList.Rows[e.RowIndex].Cells[0].Text;
        hdItemID.Value = grdItemList.DataKeys[e.RowIndex].Value.ToString();
        grdItemList.Visible = false;
        LoadData();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsWorkshopItemTransaction obj = new clsWorkshopItemTransaction();
        obj.ItemID = Convert.ToInt32(hdItemID.Value);
        obj.Op = 1;
        if (ddlTransactionType.SelectedValue == "1")
        {
            obj.Quantity = Convert.ToInt32(txtQuantity.Text);
        }
        else
        {
            obj.Quantity = -Convert.ToInt32(txtQuantity.Text);
        }
        obj.Status = Convert.ToInt32(ddlTransactionType.SelectedValue);
        obj.WorkshopItemTransaction(obj);
        LoadData();
    }
    protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdItems.EditIndex = -1;
        LoadData();
    }
    protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsWorkshopItemTransaction obj = new clsWorkshopItemTransaction();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdItems.DataKeys[e.RowIndex].Value);
        obj.WorkshopItemTransaction(obj);
        LoadData();
    }
    protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdItems.EditIndex = e.NewEditIndex;
        LoadData();
    }
    protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsWorkshopItemTransaction obj = new clsWorkshopItemTransaction();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(grdItems.DataKeys[e.RowIndex].Value);
        TextBox txtEQuantity = (TextBox)grdItems.Rows[e.RowIndex].FindControl("txtEQuantity");
        obj.Quantity = Convert.ToInt32(txtEQuantity.Text);
        obj.WorkshopItemTransaction(obj);
        grdItems.EditIndex = -1;
        LoadData();
    }
}