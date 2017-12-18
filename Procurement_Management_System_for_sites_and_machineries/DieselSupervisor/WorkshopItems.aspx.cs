using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_WorkshopItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void LoadData()
    {
        clsWorkshopItemMaster obj = new clsWorkshopItemMaster();
        obj.Op = 4;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.WorkshopItemMaster(obj).Tables[0];
        grdItems.DataSource = dt;
        grdItems.DataBind();
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add();
        }
        grdItems.DataSource = dt;
        grdItems.DataBind();
        if (dt.Rows[0][0].ToString() == "")
        {
            grdItems.Rows[0].Controls.Clear();
            TableCell cell=new TableCell();
            cell.Text = "No Data Found";
            grdItems.Rows[0].Cells.Add(cell);
        }
        if (grdItems.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            clsWorkshopItemMaster obj = new clsWorkshopItemMaster();
            obj.Op = 1;
            TextBox txtItemName = (TextBox)grdItems.FooterRow.FindControl("txtItemName");
            TextBox txtDescription = (TextBox)grdItems.FooterRow.FindControl("txtDescription");
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.ItemName = txtItemName.Text;
            obj.Description = txtDescription.Text;
            obj.WorkshopItemMaster(obj);
            LoadData();
        }
    }
    protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsWorkshopItemMaster obj = new clsWorkshopItemMaster();
        obj.ID = Convert.ToInt32(grdItems.DataKeys[e.RowIndex].Value);
        obj.Op = 3;
        obj.WorkshopItemMaster(obj);
        LoadData();
    }
    protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdItems.EditIndex = e.NewEditIndex;
        LoadData();
    }
    protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsWorkshopItemMaster obj = new clsWorkshopItemMaster();
        obj.ID = Convert.ToInt32(grdItems.DataKeys[e.RowIndex].Value);
        obj.Op = 2;
        TextBox txtEItemName = (TextBox)grdItems.Rows[e.RowIndex].FindControl("txtEItemName");
        TextBox txtEDescription = (TextBox)grdItems.Rows[e.RowIndex].FindControl("txtEDescription");
        obj.ItemName = txtEItemName.Text;
        obj.Description = txtEDescription.Text;
        obj.WorkshopItemMaster(obj);
        grdItems.EditIndex = -1;
        LoadData();
    }
    protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdItems.EditIndex = -1;
        LoadData();
    }
}