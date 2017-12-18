﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


public partial class Admin_CreateIndent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadIndentGrid();
            LoadSites();
            LoadProjects();
            LoadJobs();
            txtIndentDate.Text = DateTime.Today.ToShortDateString();
            txtApprovedBy.Text = Request.Cookies["Name"].Value;
            hdApprovedBy.Value = Request.Cookies["User"].Value;
            CreateReferenceNo();
            LoadMachines();
        }
    }
    void LoadIndentGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SL");
        for (int i = 1; i < 21; i++)
        {
            dt.Rows.Add();
            dt.Rows[i - 1][0] = i;
        }
        grd.DataSource = dt;
        grd.DataBind();
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(ddlSiteCustomer.SelectedValue);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlIMachine.DataSource = dt;
        ddlIMachine.DataValueField = "ID";
        ddlIMachine.DataTextField = "Machine";
        ddlIMachine.DataBind();
    }
    protected void txtLogNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPartNo = sender as TextBox;
        txtPartNo.Text = txtPartNo.Text.Trim();
        GridViewRow row = txtPartNo.NamingContainer as GridViewRow;
        TextBox txtItem = row.FindControl("txtItem") as TextBox;
        TextBox txtCurrentStock = row.FindControl("txtCurrentStock") as TextBox;
        TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
        HiddenField hdPartID = row.FindControl("hdPartID") as HiddenField;
        clsPart obj = new clsPart();
        obj.PartName = txtPartNo.Text.Trim();
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtItem.Text = dt.Rows[0]["PartName"].ToString();
            hdPartID.Value = dt.Rows[0]["ID"].ToString();
            clsSiteProductParts obParts = new clsSiteProductParts();
            obParts.SiteID = Convert.ToInt32(Convert.ToInt32(ddlSiteCustomer.SelectedValue));
            obParts.PartID = Convert.ToInt32(dt.Rows[0]["ID"]);
            obParts.Op = 8;
            DataTable dtStock = obParts.SiteProductParts(obParts).Tables[0];
            if (dtStock.Rows.Count > 0)
            {
                try
                {
                    txtCurrentStock.Text = dtStock.Rows[0]["Quantity"].ToString();
                }
                catch
                {
                    txtCurrentStock.Text = "0";
                }
            }
            else
            {
                txtCurrentStock.Text = "0";
            }
            txtQuantity.Focus();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('New Item Will Be Added')", true);
            hdPartID.Value = "0";
        }
    }
    protected void btnAddNewPart_Click(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.MachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        obj.SerialNo = txtSerial.Text;
        obj.PartName = txtNewPartName.Text;
        obj.PartDescription = txtDescription.Text;
        obj.Photo = UploadPhoto(Photo);
        obj.Op = 1;
        obj.PartMaster(obj);
    }
    
    void CreateReferenceNo()
    {
        try
        {
            string Project = "";
            string Job = "";
            string Site = "";
            if (txtIndentDate.Text == "")
            {
                txtIndentDate.Text = DateTime.Today.ToShortDateString();
            }
            if (ddlProject.Items.Count == 0)
            {
                Project = "";
            }
            else
            {
                Project = ddlProject.SelectedItem.Text;
            }
            if (ddlJob.Items.Count == 0)
            {
                Job = "";
            }
            else
            {
                Job = ddlJob.SelectedItem.Text;
            }
            if (ddlSiteCustomer.Items.Count == 0)
            {
                Site = "";
            }
            else
            {
                Site = ddlSiteCustomer.SelectedItem.Text;
            }
            try { Site = Site.Substring(0, Site.IndexOf(" ")); }
            catch { }
            try { Project = Project.Substring(0, Project.IndexOf(" ")); }
            catch { }
            try { Job = Job.Substring(0, Job.IndexOf(" ")); }
            catch { }
            string[] month = new string[12];
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";
            try
            {
                txtReferenceNo.Text = Site.Substring(0, Site.IndexOf("")) + "/" + Project.Substring(0, Project.IndexOf(" ")) + "/Store/" + Job + "/" + month[DateTime.Today.Month - 1].ToString() + "/" + DateTime.Today.Day.ToString();
            }
            catch
            {
                txtReferenceNo.Text = Site + "/" + Project + "/Store/" + Job + "/" + month[DateTime.Today.Month - 1].ToString() + "-" + DateTime.Today.Day.ToString();

            }
        }
        catch
        {

        }
    }

    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSiteCustomer.DataSource = dt;
        ddlSiteCustomer.DataValueField = "ID";
        ddlSiteCustomer.DataTextField = "Name";
        ddlSiteCustomer.DataBind();
    }

    protected void txtProjectNo_TextChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    protected void txtJobNo_TextChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    protected void txtIndentDate_TextChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    protected void grdIndentor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtIndentor.Text = grdIndentor.Rows[e.RowIndex].Cells[0].Text;
        hdIndentor.Value = grdIndentor.DataKeys[e.RowIndex].Value.ToString();
        grdIndentor.Visible = false;
    }
    protected void grdApprovedBy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtApprovedBy.Text = grdApprovedBy.Rows[e.RowIndex].Cells[0].Text;
        hdApprovedBy.Value = grdApprovedBy.DataKeys[e.RowIndex].Value.ToString();
        grdApprovedBy.Visible = false;
    }
    protected void txtIndentor_TextChanged(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.Name = txtIndentor.Text;
        obj.Op = 6;
        DataTable dt = obj.UserMaster(obj).Tables[0];
        grdIndentor.DataSource = dt;
        grdIndentor.DataBind();
        grdIndentor.Visible = true;

    }
    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.Name = txtApprovedBy.Text;
        obj.Op = 6;
        DataTable dt = obj.UserMaster(obj).Tables[0];
        grdApprovedBy.DataSource = dt;
        grdApprovedBy.DataBind();
        grdApprovedBy.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hdApprovedBy.Value != "" && hdIndentor.Value != "")
        {
            clsIndent obj = new clsIndent();
            obj.Op = 1;
            obj.OrderFrom = 1;
            obj.OrderFromID = Convert.ToInt32(ddlSiteCustomer.SelectedValue);
            obj.SiteMachineID = Convert.ToInt32(ddlIMachine.SelectedValue);
            obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
            obj.RefNo = txtReferenceNo.Text;
            try { obj.ProjectNo = ddlProject.SelectedItem.Text; }
            catch { }
            try { obj.JobNo = ddlJob.SelectedItem.Text; }
            catch { }
            obj.IndentDate = txtIndentDate.Text;
            obj.Indentor = Convert.ToInt32(hdIndentor.Value);
            obj.ApprovedBy = Convert.ToInt32(hdApprovedBy.Value);
            obj.Status = 1;
            obj.IndentMaster(obj);
            obj.Op = 6;
            DataTable dt = obj.IndentMaster(obj).Tables[0];
            int MaxID = Convert.ToInt16(dt.Rows[0][0]);
            AddTempItemsToIndent(MaxID);
            SaveIssueList(MaxID);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Saved');", true);
            Response.Redirect("Indent.aspx");
        }
    }
    void AddTempItemsToIndent(int IndentID)
    {
        foreach (GridViewRow dr in grd.Rows)
        {
            clsIndentItems obj = new clsIndentItems();
            //TextBox txtLogNo = dr.FindControl("txtLogNo") as TextBox;
            TextBox txtPartNo = dr.FindControl("txtPartNo") as TextBox;
            TextBox txtItem = dr.FindControl("txtItem") as TextBox;
            TextBox txtCurrentStock = dr.FindControl("txtCurrentStock") as TextBox;
            TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
            TextBox txtUOM = dr.FindControl("txtUOM") as TextBox;
            TextBox txtRemark = dr.FindControl("txtRemark") as TextBox;
            FileUpload file = dr.FindControl("file") as FileUpload;
            HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
            if (((txtPartNo.Text != "" && txtItem.Text != "")||file.HasFile) && Convert.ToInt32(txtQuantity.Text) != 0)
            {
                clsIndentItems objItems = new clsIndentItems();
                objItems.Op = 1;
                objItems.IndentID = IndentID;
                //objItems.LogNo = txtLogNo.Text;
                objItems.PartNo = txtPartNo.Text;
                objItems.Particular = txtItem.Text;
                objItems.CurrentStock = Convert.ToInt32(txtCurrentStock.Text);
                objItems.Quantity = Convert.ToInt32(txtQuantity.Text);
                objItems.UOM = txtUOM.Text;
                objItems.Remarks = txtRemark.Text;
                objItems.Photo = UploadPhoto(file);
                objItems.IndentItemMaster(objItems);
                if (hdPartID.Value == "0")
                {
                    clsSiteMachines obSM = new clsSiteMachines();
                    obSM.ID = Convert.ToInt32(ddlMachine.SelectedValue);
                    obSM.Op = 5;
                    DataTable dtSM = obSM.SiteMachines(obSM).Tables[0];
                    clsPart obPart = new clsPart();
                    obPart.SerialNo = txtPartNo.Text;
                    obPart.PartName = txtItem.Text;
                    obPart.MachineID = Convert.ToInt32(dtSM.Rows[0]["SiteMachineID"]);
                    obPart.Op = 1;
                    obPart.PartMaster(obPart);
                }
            }
            
            
        }
    }
    void SaveIssueList(int IndentID)
    {
        clsIndent obj = new clsIndent();
        obj.ID = IndentID;
        obj.Op = 4;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        clsIndentItems obII = new clsIndentItems();
        obII.IndentID = IndentID;
        obII.Op = 3;
        DataTable dtItems = obII.IndentItemMaster(obII).Tables[0];
        if (dtItems.Rows.Count > 0)
        {
            /*Add To Issue*/
            clsSitePartIssue obSPI = new clsSitePartIssue();
            obSPI.SiteID = Convert.ToInt32(dt.Rows[0]["SiteID"]);
            obSPI.SiteMachineID = Convert.ToInt32(dt.Rows[0]["SiteMachineID"]);
            obSPI.IndentRef = dt.Rows[0]["RefNo"].ToString();
            obSPI.Op = 1;
            /*Stock Management Entry*/
            clsSiteProductParts obSPP = new clsSiteProductParts();
            obSPP.SiteID = Convert.ToInt32(dt.Rows[0]["SiteID"]);
            obSPP.SiteMachineID = Convert.ToInt32(dt.Rows[0]["SiteMachineID"]);
            obSPP.BillRef = dt.Rows[0]["RefNo"].ToString();
            obSPP.Remarks = "Issued Against Indent";
            obSPP.Op = 1;
            obSPP.TransactionType = 2;
            foreach (DataRow dr in dtItems.Rows)
            {
                try
                {
                    obSPI.PartID = Convert.ToInt32(dr["PartID"]);
                    obSPI.PartNo = dr["PartNo"].ToString();
                    obSPI.PartName = dr["PartName"].ToString();
                    obSPI.Price = Convert.ToDouble(dr["Price"]);
                    if (Convert.ToInt32(dr["Quantity"]) > Convert.ToInt32(dr["CurrentStock"]))
                    {
                        obSPI.Quantity = Convert.ToInt32(dr["CurrentStock"]);
                        obSPP.Quantity = Convert.ToInt32(dr["CurrentStock"]);
                    }
                    else
                    {
                        obSPI.Quantity = Convert.ToInt32(dr["Quantity"]);
                        obSPP.Quantity = Convert.ToInt32(dr["Quantity"]);
                    }
                    obSPI.SitePartIssue(obSPI);
                    obSPP.PartID = Convert.ToInt32(dr["PartID"]);
                    try { obSPP.Rate = Convert.ToDouble(dr["Price"]); }
                    catch { }
                    obSPP.Total = obSPP.Rate * obSPP.Quantity;
                    obSPP.SiteProductParts(obSPP);
                }
                catch
                {

                }
            }
        }
    }
    protected void ddlSiteCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProjects();
        LoadJobs();
        CreateReferenceNo();
        LoadMachines();
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadJobs();
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    void LoadProjects()
    {
        try
        {
            clsProjectJob obj = new clsProjectJob();
            obj.Op = 3;
            obj.SiteID = Convert.ToInt32(ddlSiteCustomer.SelectedValue);
            DataTable dt = obj.Projects(obj).Tables[0];
            ddlProject.DataSource = dt;
            ddlProject.DataValueField = "ID";
            ddlProject.DataTextField = "ProjectName";
            ddlProject.DataBind();
        }
        catch
        {

        }
    }
    void LoadJobs()
    {
        try
        {
            clsProjectJob obj = new clsProjectJob();
            obj.Op = 3;
            obj.ProjectID = Convert.ToInt32(ddlProject.SelectedValue);
            DataTable dt = obj.Jobs(obj).Tables[0];
            ddlJob.DataSource = dt;
            ddlJob.DataValueField = "ID";
            ddlJob.DataTextField = "JobName";
            ddlJob.DataBind();
            CreateReferenceNo();
        }
        catch
        {

        }
    }

    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    string UploadPhoto(FileUpload file)
    {
        if (file.HasFile)
        {
            string fileName = Path.GetFileName(file.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(file.PostedFile.FileName);
            file.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand.ToString();
        }
        else
        {
            return "";
        }
    }
}