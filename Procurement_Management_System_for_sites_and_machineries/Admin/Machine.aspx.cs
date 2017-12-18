using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Admin_Machine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadManufacturers();
            LoadMachines();
        }
    }
    void LoadManufacturers()
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Op = 4;
        DataTable dt = obj.ManufacturerMaster(obj).Tables[0];
        ddlManufacturer.DataSource = dt;
        ddlEManufacturer.DataSource = dt;
        ddlManufacturer.DataValueField = "ID";
        ddlManufacturer.DataTextField = "Name";
        ddlEManufacturer.DataValueField = "ID";
        ddlEManufacturer.DataTextField = "Name";
        ddlManufacturer.DataBind();
        ddlEManufacturer.DataBind();
    }
    void LoadMachines()
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.Op = 4;
        DataTable dt = obj.MachineMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Photo"] != "")
            {
                dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
            }
        }
        grdMachine.DataSource = dt;
        grdMachine.DataBind();
        if (grdMachine.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.SerialNo=txtSerial.Text;
        obj.ModelNo=txtModel.Text;
        obj.Manufacturer=ddlManufacturer.SelectedItem.Text;
        obj.MachineType = Convert.ToInt32(ddlMachineType.SelectedValue);
        obj.Description = txtDescription.Text;
        obj.Photo = UploadImage();
        obj.Op = 1;
        obj.MachineMaster(obj);
        txtSerial.Text = "";
        txtModel.Text = "";
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        LoadMachines();
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.ID=Convert.ToInt32(hdEID.Value); 
        obj.SerialNo=txtESerial.Text;
        obj.ModelNo=txtEModel.Text;
        obj.Manufacturer=ddlEManufacturer.SelectedItem.Text;
        obj.MachineType=Convert.ToInt32(ddlEMachineType.SelectedValue);
        obj.Description=txtEDescription.Text;
        obj.Photo = UpdateImage();
        obj.Op = 2;
        obj.MachineMaster(obj);
        pnlUpdate.Visible = false;
        pnlExisting.Visible = true;
        LoadMachines();
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
    }
    protected void grdMachine_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdID = (HiddenField)grdMachine.Rows[e.RowIndex].FindControl("hdID");
        clsMachineMaster obj = new clsMachineMaster();
        obj.ID = Convert.ToInt32(hdID.Value);
        obj.Op = 5;
        DataTable dt = obj.MachineMaster(obj).Tables[0];
        hdEID.Value = hdID.Value;
        txtESerial.Text = dt.Rows[0]["SerialNo"].ToString();
        txtEModel.Text = dt.Rows[0]["ModelNo"].ToString();
        txtEDescription.Text = dt.Rows[0]["Description"].ToString();
        ddlEMachineType.SelectedValue = dt.Rows[0]["MachineType"].ToString();
        ddlEManufacturer.SelectedItem.Text = dt.Rows[0]["Manufacturer"].ToString();
        if (dt.Rows[0]["Photo"].ToString() != "")
        {
            imgEPhoto.ImageUrl = "~/" + dt.Rows[0]["Photo"].ToString();
        }
        pnlUpdate.Visible = true;
        pnlExisting.Visible = false;
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
        pnlUpdate.Visible = false;
    }
    protected void btnExisting_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }

    string UpdateImage()
    {
        if (EPhoto.HasFile)
        {
            if (File.Exists(MapPath(imgEPhoto.ImageUrl)))
            {
                File.Delete(@MapPath(imgEPhoto.ImageUrl));
            }
            string fileName = Path.GetFileName(EPhoto.PostedFile.FileName);
            string Rand = RandomString(8) + "." + Path.GetExtension(Photo.PostedFile.FileName);
            Photo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand;
        }
        else
        {
            return imgEPhoto.ImageUrl.ToString().Substring(2);
        }
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    string UploadImage()
    {
        if (Photo.HasFile)
        {
            string fileName = Path.GetFileName(Photo.PostedFile.FileName);
            string Rand = RandomString(8) + "." + Path.GetExtension(Photo.PostedFile.FileName);
            Photo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand;
        }
        else
        {
            return "";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Op = 3;
        obj.MachineMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
    }
    protected void txtMachineName_TextChanged(object sender, EventArgs e)
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.ModelNo = txtMachineName.Text;
        obj.Op = 7;
        DataTable dt = obj.MachineMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Photo"] != "")
            {
                dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
            }
        }
        grdMachine.DataSource = dt;
        grdMachine.DataBind();
    }
    protected void grdMachine_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMachine.PageIndex = e.NewPageIndex;
        LoadMachines();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }
}