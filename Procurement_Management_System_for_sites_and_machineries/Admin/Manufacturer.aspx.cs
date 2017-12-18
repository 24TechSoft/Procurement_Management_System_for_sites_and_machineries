using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manufacturer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            msg.Text = "";
        }
    }
    void LoadData()
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Op = 4;
        DataTable dt = obj.ManufacturerMaster(obj).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            dr["Address"] = dr["Address"].ToString().Replace("\n", "<br>");
        }
        grdManufacturers.DataSource = dt;
        grdManufacturers.DataBind();
        if (grdManufacturers.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    void LoadDataEdit()
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Op = 4;
        DataTable dt = obj.ManufacturerMaster(obj).Tables[0];
        grdManufacturers.DataSource = dt;
        grdManufacturers.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Name=txtName.Text;
        obj.Address=txtAddress.Text;
        obj.PhoneNo=txtPhone.Text;
        obj.Email=txtEmail.Text;
        obj.AddedOn = DateTime.Today.ToShortDateString();
        obj.Op = 1;
        obj.ManufacturerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        txtName.Text = "";
        txtAddress.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        pnlExisting.Visible = true;
        LoadData();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
    }
    protected void grdManufacturers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdManufacturers.EditIndex = e.NewEditIndex;
        LoadDataEdit();
    }
    protected void grdManufacturers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdManufacturers.EditIndex = -1;
        LoadData();
    }
    protected void grdManufacturers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HiddenField hdEID = (HiddenField)grdManufacturers.Rows[e.RowIndex].FindControl("hdEID");
        TextBox txtEName = (TextBox)grdManufacturers.Rows[e.RowIndex].FindControl("txtEName");
        TextBox txtEAddress = (TextBox)grdManufacturers.Rows[e.RowIndex].FindControl("txtEAddress");
        TextBox txtEPhone = (TextBox)grdManufacturers.Rows[e.RowIndex].FindControl("txtEPhone");
        TextBox txtEEmail = (TextBox)grdManufacturers.Rows[e.RowIndex].FindControl("txtEEmail");
        clsManufacturer obj = new clsManufacturer();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Name = txtEName.Text;
        obj.Address = txtEAddress.Text;
        obj.PhoneNo = txtEPhone.Text;
        obj.Email = txtEEmail.Text;
        obj.Op = 3;
        obj.ManufacturerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
        grdManufacturers.EditIndex = -1;
        LoadData();
    }
    protected void grdManufacturers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdID = (HiddenField)grdManufacturers.Rows[e.RowIndex].FindControl("hdID");
        clsManufacturer obj = new clsManufacturer();
        obj.ID = Convert.ToInt32(hdID.Value);
        obj.Op = 2;
        obj.ManufacturerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        LoadData();
    }
}