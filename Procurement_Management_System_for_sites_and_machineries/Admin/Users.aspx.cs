using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadUsers();
            LoadSites();
        }
    }
    void LoadUsers()
    {
        clsUser obj = new clsUser();
        obj.Op = 4;
        DataTable dt = obj.UserMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Signature"].ToString() != "")
            {
                dt.Rows[i]["Signature"] = "~/" + dt.Rows[i]["Signature"].ToString();
            }
        }
        grdUser.DataSource = dt;
        grdUser.DataBind();
        if (grdUser.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No records found";
        }
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSite.DataSource = dt;
        ddlSite.DataValueField = "ID";
        ddlSite.DataTextField = "Name";
        ddlSite.DataBind();

        ddlESite.DataSource = dt;
        ddlESite.DataValueField = "ID";
        ddlESite.DataTextField = "Name";
        ddlESite.DataBind();
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
        if (Signature.HasFile)
        {
            string fileName = Path.GetFileName(Signature.PostedFile.FileName);
            string Rand = RandomString(8) + "." + Signature.PostedFile.ContentType.ToString();
            Signature.PostedFile.SaveAs(Server.MapPath("~/uploads/") + fileName);
            return "uploads/" + fileName.ToString();
        }
        else
        {
            return "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsUser obj=new clsUser();
        obj.UserType=Convert.ToInt32(ddlUserType.SelectedValue); 
        obj.Name=txtName.Text;
        obj.Email=txtEmail.Text;
        obj.PhoneNo=txtPhone.Text;
        obj.SiteID=Convert.ToInt32(ddlSite.SelectedValue);
        obj.Designation=txtDesignation.Text;
        obj.Signature=UploadImage();
        obj.UserID=txtUserID.Text;
        obj.Password = txtPassword.Text;
        obj.Op = 1;
        obj.UserMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        LoadUsers();
        txtName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtDesignation.Text = "";
        txtUserID.Text = "";
        txtPassword.Text = "";
        pnlUpdate.Visible = false;
        pnlExisting.Visible = true;
    }
    protected void grdUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hdID = (HiddenField)grdUser.Rows[e.RowIndex].FindControl("hdID");
        clsUser obj = new clsUser();
        obj.Op = 5;
        obj.ID = Convert.ToInt32(hdID.Value);
        DataTable dt = obj.UserMaster(obj).Tables[0];
        //ID, UserType, Name, Email, PhoneNo, SiteID, Designation, Signature,UserID,Password
        hdEID.Value = dt.Rows[0]["ID"].ToString();
        ddlESite.SelectedValue = dt.Rows[0]["SiteID"].ToString();
        ddlEUserType.SelectedValue = dt.Rows[0]["UserType"].ToString();
        txtEName.Text = dt.Rows[0]["Name"].ToString();
        txtEEmail.Text = dt.Rows[0]["Email"].ToString();
        txtEPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
        txtEDesignation.Text = dt.Rows[0]["Designation"].ToString();
        if (dt.Rows[0]["Signature"].ToString() != "")
        {
            imgESignature.ImageUrl = "~/" + dt.Rows[0]["Signature"].ToString();
        }
        else
        {
            imgESignature.ImageUrl = "";
        }
        pnlUpdate.Visible = true;
        pnlExisting.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.UserType=Convert.ToInt32(ddlEUserType.SelectedValue);
        obj.Name=txtEName.Text;
        obj.Email=txtEEmail.Text;
        obj.PhoneNo=txtEPhone.Text;
        obj.SiteID=Convert.ToInt32(ddlSite.SelectedValue);
        obj.Designation=txtEDesignation.Text;
        obj.Signature = UpdateImage();
        obj.Op = 2;
        obj.UserMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Saved');</script>";
        LoadUsers();
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }

    string UpdateImage()
    {
        if (ESignature.HasFile)
        {
            if (imgESignature.ImageUrl != "")
            {
                File.Delete(@MapPath(imgESignature.ImageUrl));
            }
            string fileName = Path.GetFileName(ESignature.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(ESignature.PostedFile.FileName);
            ESignature.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand.ToString();
        }
        else
        {
            try
            {
                return imgESignature.ToString().Substring(2);
            }
            catch
            {
                return "";
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Op = 3;
        obj.UserMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Deleted');</script>";
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
        LoadUsers();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlUpdate.Visible = false;
    }
}