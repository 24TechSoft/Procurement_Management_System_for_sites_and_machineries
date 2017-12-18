using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_Site : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadSites();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsSite obj = new clsSite();
        obj.Name=txtName.Text;
        obj.Location=txtLocation.Text;
        obj.Address=txtAddress.Text;
        obj.PhoneNo=txtPhone.Text;
        obj.Email = txtEmail.Text;
        obj.Op = 1;
        obj.SiteMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        LoadSites();
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtLocation.Text = "";
        txtName.Text = "";
        txtPhone.Text = "";
        pnlExisting.Visible = true;
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        grdSite.DataSource = dt;
        grdSite.DataBind();
        if (grdSite.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    protected void grdSite_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdSite.EditIndex = e.NewEditIndex;
        LoadSites();
    }
    protected void grdSite_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdSite.EditIndex = -1;
        LoadSites();
    }
    protected void grdSite_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsSite obj = new clsSite();
        HiddenField hdEID=(HiddenField)grdSite.Rows[e.RowIndex].FindControl("hdEID");
        TextBox txtEName=(TextBox)grdSite.Rows[e.RowIndex].FindControl("txtEName");
        TextBox txtELocation=(TextBox)grdSite.Rows[e.RowIndex].FindControl("txtELocation");
        TextBox txtEAddress=(TextBox)grdSite.Rows[e.RowIndex].FindControl("txtEAddress");
        TextBox txtEPhoneNo=(TextBox)grdSite.Rows[e.RowIndex].FindControl("txtEPhoneNo");
        TextBox txtEEmail=(TextBox)grdSite.Rows[e.RowIndex].FindControl("txtEEmail");
        obj.ID=Convert.ToInt32(hdEID.Value);
        obj.Name=txtEName.Text;
        obj.Location=txtELocation.Text;
        obj.Address=txtEAddress.Text;
        obj.PhoneNo=txtEPhoneNo.Text;
        obj.Email = txtEEmail.Text;
        obj.Op = 2;
        obj.SiteMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
        grdSite.EditIndex = -1;
        LoadSites();
    }
    protected void grdSite_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdID = (HiddenField)grdSite.Rows[e.RowIndex].FindControl("hdID");
        clsSite obj = new clsSite();
        obj.Op = 3;
        obj.ID = Convert.ToInt32(hdID.Value);
        obj.SiteMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        LoadSites();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
    }
}