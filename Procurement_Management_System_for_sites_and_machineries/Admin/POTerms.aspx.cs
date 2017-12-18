using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_POTerms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTerms();
            LoadPurchaseOrder();
        }
    }
    void LoadPurchaseOrder()
    {
        clsPurchaseOrder obj = new clsPurchaseOrder();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(Request.QueryString["ID"]);
        DataTable dt = obj.PurchaseOrderMaster(obj).Tables[0];
        lblRefNo.Text = dt.Rows[0]["PORefNo"].ToString();
        lblPODate.Text = Convert.ToDateTime(dt.Rows[0]["PODate"]).ToShortDateString();
        lblIndentRefNo.Text = dt.Rows[0]["IndentRefNo"].ToString();
        lblNetPayable.Text = dt.Rows[0]["NetPayable"].ToString();
    }
    void LoadTerms()
    {
        clsPOTerms obj = new clsPOTerms();
        obj.Op = 3;
        obj.POID = Convert.ToInt32(Request.QueryString["ID"]);
        DataTable dt = obj.POTermsMaster(obj).Tables[0];
        grdTerms.DataSource = dt;
        grdTerms.DataBind();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsPOTerms obj = new clsPOTerms();
        obj.POID = Convert.ToInt32(Request.QueryString["ID"]);
        obj.Heading = txtHeader.Text;
        obj.Detail = txtDetail.Text;
        obj.Op = 1;
        obj.POTermsMaster(obj);
        LoadTerms();
    }
    protected void grdTerms_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsPOTerms obj = new clsPOTerms();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdTerms.DataKeys[e.RowIndex].Value);
        obj.POTermsMaster(obj);
        LoadTerms();
    }
    protected void grdTerms_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdTerms.EditIndex = e.NewEditIndex;
        LoadTerms();
    }
    protected void grdTerms_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsPOTerms obj = new clsPOTerms();
        obj.Op = 4;
        obj.Heading = ((TextBox)grdTerms.Rows[e.RowIndex].FindControl("txtEHeading")).Text;
        obj.Detail = ((TextBox)grdTerms.Rows[e.RowIndex].FindControl("txtEDetail")).Text;
        obj.ID = Convert.ToInt32(grdTerms.DataKeys[e.RowIndex].Value);
        obj.POTermsMaster(obj);
        grdTerms.EditIndex = -1;
        LoadTerms();
    }
    protected void grdTerms_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdTerms.EditIndex = -1;
        LoadTerms();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPurchaseOrder.aspx?ID=" + Request.QueryString["ID"] + " ");
    }
}