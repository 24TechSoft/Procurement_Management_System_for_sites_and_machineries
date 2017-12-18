using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Supervisor_PartRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadData();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        //ID, SiteID, UserID, PartNo, Description, Photo, Status
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.EntryDate = DateTime.Today.ToShortDateString();
        obj.PartNo = txtPartNo.Text;
        obj.Description = txtDescription.Text;
        obj.Status = 0;
        obj.Photo = UploadPhoto();
        obj.FromSite = Convert.ToInt32(ddlSite.SelectedValue);
        obj.ItemType = Convert.ToInt32(rdItemType.SelectedValue);
        obj.Op = 1;
        obj.SitePartRequest(obj);
        LoadData();
        pnlExisting.Visible = true;
        txtPartNo.Text = "";
        txtDescription.Text = "";
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                if (Convert.ToInt32(dt.Rows[i]["ID"]) == Convert.ToInt32(Request.Cookies["SiteID"].Value))
                {
                    dt.Rows[i].Delete();
                    i--;
                }
                else
                {
                    dt.Rows[i]["Name"] = dt.Rows[i]["Name"] + ", " + dt.Rows[i]["Location"];
                }
            }
            catch
            {
                break;
            }
        }
        ddlSite.DataSource = dt;
        ddlSite.DataTextField = "Name";
        ddlSite.DataValueField = "ID";
        ddlSite.DataBind();
        ddlSite.Items.Add(new ListItem("Any Site", "0"));
    }
    void LoadData()
    {
        clsSitePartRequest obj = new clsSitePartRequest();
        obj.Op = 4;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.SitePartRequest(obj).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
        }
        grdPartRequest.DataSource = dt;
        grdPartRequest.DataBind();
        if (grdPartRequest.Rows.Count > 0)
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
    string UploadPhoto()
    {
        if (Photo.HasFile)
        {
            string fileName = Path.GetFileName(Photo.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(Photo.PostedFile.FileName);
            Photo.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand.ToString();
        }
        else
        {
            return "";
        }
    }

}