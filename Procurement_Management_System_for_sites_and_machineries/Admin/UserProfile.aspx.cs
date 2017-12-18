using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Admin_UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadData();
        }
    }
    void LoadData()
    {
        try
        {
            clsUser obj = new clsUser();
            obj.ID = Convert.ToInt32(Request.Cookies["User"].Value);
            obj.Op = 5;
            System.Data.DataTable dt = obj.UserMaster(obj).Tables[0];
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            ddlSite.SelectedValue = dt.Rows[0]["SiteID"].ToString();
            ddlUserType.SelectedValue = dt.Rows[0]["UserType"].ToString();
            if (dt.Rows[0]["Signature"].ToString() != "")
            {
                imgSignature.ImageUrl = "~/"+dt.Rows[0]["Signature"].ToString();
            }
        }
        catch
        {
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.ID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.UserType=Convert.ToInt32(ddlUserType.SelectedValue);
        obj.Name=txtName.Text; 
        obj.Email=txtEmail.Text;
        obj.PhoneNo=txtPhone.Text;
        obj.SiteID=Convert.ToInt32(ddlSite.SelectedValue);
        obj.Designation=txtDesignation.Text;
        obj.Signature = UpdateImage();
        obj.Op = 2;
        obj.UserMaster(obj);
        msg.Text = "<script type='text/javascript'>alert('Updated');</script>";
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        System.Data.DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSite.DataSource = dt;
        ddlSite.DataValueField = "ID";
        ddlSite.DataTextField = "Name";
        ddlSite.DataBind();
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    string UpdateImage()
    {
        if (Signature.HasFile)
        {
            if (imgSignature.ImageUrl != "")
            {
                File.Delete(@MapPath(imgSignature.ImageUrl));
            }
            string fileName = Path.GetFileName(Signature.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(Signature.PostedFile.FileName);
            Signature.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand.ToString();
        }
        else
        {
            return imgSignature.ToString().Substring(2);
        }
    }
}