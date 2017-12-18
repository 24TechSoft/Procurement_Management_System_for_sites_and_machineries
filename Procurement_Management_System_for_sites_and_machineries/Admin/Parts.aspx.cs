using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Admin_Parts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadMachines();
            LoadParts();
        }
    }
    void LoadParts()
    {
        if (txtSearch.Text == "")
        {
            clsPart obj = new clsPart();
            obj.Op = 4;
            DataTable dt = obj.PartMaster(obj).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
            }
            grdParts.DataSource = dt;
            grdParts.DataBind();
        }
        else
        {
            clsPart obj = new clsPart();
            obj.Op = 7;
            obj.PartName = txtSearch.Text;
            DataTable dt = obj.PartMaster(obj).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
            }
            grdParts.DataSource = dt;
            grdParts.DataBind();
        }
        if (grdParts.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    void LoadMachines()
    {
        clsMachineMaster obj = new clsMachineMaster();
        obj.Op = 4;
        DataTable dt = obj.MachineMaster(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataTextField = "ModelNo";
        ddlMachine.DataBind();
        ddlEMachine.DataSource = dt;
        ddlEMachine.DataValueField = "ID";
        ddlEMachine.DataTextField = "ModelNo";
        ddlEMachine.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.MachineID=Convert.ToInt32(ddlMachine.SelectedValue);
        obj.SerialNo = txtSerial.Text;
        obj.PartName = txtPartName.Text;
        obj.PartDescription = txtDescription.Text;
        obj.Photo = UploadImage();
        obj.Price = Convert.ToDouble(txtPrice.Text);
        obj.Op = 1;
        obj.PartMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
        LoadParts();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.Op = 2;
        obj.ID=Convert.ToInt32(hdEID.Value);
        obj.MachineID=Convert.ToInt32(ddlEMachine.SelectedValue);
        obj.SerialNo=txtESerial.Text;
        obj.PartName=txtEPartName.Text;
        obj.PartDescription=txtEDescription.Text;
        obj.Photo = UpdateImage();
        obj.Price = Convert.ToDouble(txtEPrice.Text);
        obj.PartMaster(obj);
        LoadParts();
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
        msg.Text = "";
    }
    protected void grdParts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsPart obj = new clsPart();
        HiddenField hdID = (HiddenField)grdParts.Rows[e.RowIndex].FindControl("hdID");
        obj.ID = Convert.ToInt32(grdParts.DataKeys[e.RowIndex].Value);
        obj.Op = 6;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        hdEID.Value = grdParts.DataKeys[e.RowIndex].Value.ToString();
        ddlEMachine.SelectedValue = dt.Rows[0]["MachineID"].ToString();
        txtESerial.Text = dt.Rows[0]["SerialNo"].ToString();
        txtEPartName.Text = dt.Rows[0]["PartName"].ToString();
        txtEDescription.Text = dt.Rows[0]["PartDescription"].ToString();
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
            string Rand = RandomString(8) + Path.GetExtension(EPhoto.PostedFile.FileName);
            EPhoto.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand.ToString();
        }
        else
        {
            try{
                return imgEPhoto.ImageUrl.ToString().Substring(2);
            }
            catch
            {
                return "";
            }
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
            string Rand = RandomString(8) + Path.GetExtension(Photo.PostedFile.FileName);
            Photo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand;
        }
        else
        {
            return "";
        }
    }
    protected void txtSearch_Changed(object sender, EventArgs e)
    {
        txtSearch.Text = txtSearch.Text.Trim();
        LoadParts();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Op = 3;
        obj.PartMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
        LoadParts();
    }
    protected void grdParts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdParts.PageIndex = e.NewPageIndex;
        LoadParts();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }
}