using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Admin_Customer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadCustomer();
        }
    }
    void LoadCustomer()
    {
        clsCustomer obj = new clsCustomer();
        obj.Op = 3;
        DataTable dt = obj.CustomerMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Logo"].ToString() != "")
            {
                dt.Rows[i]["Logo"] = "~/" + dt.Rows[i]["Logo"].ToString();
            }
        }
        grdCustomer.DataSource = dt;
        grdCustomer.DataBind();
        if (grdCustomer.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
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
        if (Logo.HasFile)
        {
            string fileName = Path.GetFileName(Logo.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(Logo.PostedFile.FileName);
            Logo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand;
        }
        else
        {
            return "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsCustomer obj = new clsCustomer();
        obj.Name = txtName.Text;
        obj.Address = txtAddress.Text;
        obj.Phone = txtPhone.Text;
        obj.Email = txtEmail.Text;
        obj.Logo = UploadImage();
        obj.Op = 1;
        obj.CustomerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        LoadCustomer();
        txtName.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        pnlExisting.Visible = true;
    }

    protected void btnExisting_Click(object sender, EventArgs e)
    {

    }
    protected void grdCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdID = (HiddenField)grdCustomer.Rows[e.RowIndex].FindControl("hdID");
        Label lblName=(Label)grdCustomer.Rows[e.RowIndex].FindControl("lblName");
        Label lblAddress=(Label)grdCustomer.Rows[e.RowIndex].FindControl("lblAddress");
        Label lblPhone=(Label)grdCustomer.Rows[e.RowIndex].FindControl("lblPhone");
        Label lblEmail=(Label)grdCustomer.Rows[e.RowIndex].FindControl("lblEmail");
        HiddenField hdLogo = (HiddenField)grdCustomer.Rows[e.RowIndex].FindControl("hdLogo");
        clsCustomer obj = new clsCustomer();
        txtEName.Text = lblName.Text;
        txtEAddress.Text = lblAddress.Text;
        txtEPhone.Text = lblPhone.Text;
        txtEEmail.Text = lblEmail.Text;
        EImg.ImageUrl = hdLogo.Value;
        hdEID.Value = hdID.Value;
        pnlUpdate.Visible = true;
        pnlExisting.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }
    string UpdateImage()
    {
        if (ELogo.HasFile)
        {
            if (File.Exists(MapPath(EImg.ImageUrl)))
            {
                File.Delete(@MapPath(EImg.ImageUrl));
            }
            string fileName = Path.GetFileName(ELogo.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(ELogo.PostedFile.FileName);
                ELogo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
                return "uploads/" + Rand;
        }
        else
        {
            try
            {
                return EImg.ImageUrl.ToString().Substring(2);
            }
            catch
            {
                return "";
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsCustomer obj = new clsCustomer();
        obj.ID=Convert.ToInt32(hdEID.Value);
        obj.Name=txtEName.Text;
        obj.Address=txtEAddress.Text;
        obj.Phone=txtEPhone.Text;
        obj.Email=txtEEmail.Text;
        obj.Logo = UpdateImage();
        obj.Op = 5;
        obj.CustomerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
        pnlUpdate.Visible = false;
        pnlExisting.Visible = true;
        LoadCustomer();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsCustomer obj = new clsCustomer();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Op = 2;
        obj.CustomerMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        pnlUpdate.Visible = false;
        pnlExisting.Visible = true;
        LoadCustomer();
    }
}