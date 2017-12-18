using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Tax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
        msg.Text = "";
    }
    void LoadData()
    {
        clsTaxMaster obj = new clsTaxMaster();
        obj.Op = 3;
        DataTable dt = obj.TaxMaster(obj).Tables[0];
        grdTax.DataSource = dt;
        grdTax.DataBind();
        if (grdTax.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            clsTaxMaster obj = new clsTaxMaster();
            obj.CGST = Convert.ToDouble(txtCGST.Text);
            obj.SGST = Convert.ToDouble(txtSGST.Text);
            obj.IGST = Convert.ToDouble(txtIGST.Text);
            obj.Op = 1;
            obj.TaxMaster(obj);
            msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
            LoadData();
            txtCGST.Text = "";
            txtSGST.Text = "";
            txtIGST.Text = "";
            pnlExisting.Visible = true;
        }
        catch
        {
            msg.Text = "<script type='text/javascript'>alert('Check the entered data. Not Saved.');</script>";
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
    }
    protected void grdTax_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsTaxMaster obj = new clsTaxMaster();
        HiddenField hdID = (HiddenField)grdTax.Rows[e.RowIndex].FindControl("hdID");
        obj.ID = Convert.ToInt32(hdID.Value);
        obj.Op = 2;
        obj.TaxMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        LoadData();
    }
}