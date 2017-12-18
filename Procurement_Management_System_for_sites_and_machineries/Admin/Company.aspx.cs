using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
public partial class Admin_Company : System.Web.UI.Page
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
        clsCompany obj = new clsCompany();
        obj.Op = 3;
        System.Data.DataTable dt = obj.CompanyMster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtTin.Text = dt.Rows[0]["Tin"].ToString();
            txtCst.Text = dt.Rows[0]["Cst"].ToString();
            imgLogo.ImageUrl = "~/"+dt.Rows[0]["Logo"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsCompany obj = new clsCompany();
        obj.Name = txtName.Text;
        obj.Address = txtAddress.Text;
        obj.Tin = txtTin.Text;
        obj.Cst = txtCst.Text;
        
        if (Logo.HasFile)
        {
            try
            {
                string filepath = MapPath(imgLogo.ImageUrl);
                File.Delete(@filepath);
            }
            catch
            {

            }
        }
        obj.Logo = UploadPhoto();
        obj.Op = 2;
        obj.CompanyMster(obj);
        obj.Op = 1;
        obj.CompanyMster(obj);
        LoadData();
    }
    string UploadPhoto()
    {
        if (Logo.HasFile)
        {
            string fileName = Path.GetFileName(Logo.PostedFile.FileName);
            Logo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + fileName);
            return "uploads/" + fileName.ToString();
        }
        else
        {
            return imgLogo.ImageUrl.ToString().Substring(2);
        }
    }
}