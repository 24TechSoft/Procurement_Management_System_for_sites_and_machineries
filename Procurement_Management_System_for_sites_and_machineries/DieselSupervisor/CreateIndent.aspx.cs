using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_CreateIndent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadTempItems();
                
                LoadProjects();
                LoadJobs(Convert.ToInt32(ddlProject.SelectedValue));
                CreateReferenceNo();
            }
            catch
            {

            }
        }
    }
    void CreateReferenceNo()
    {
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
            lblRef.Text = ddlProject.SelectedItem.Text.Substring(0, ddlProject.SelectedItem.Text.IndexOf(" ")) + "/Store/" + ddlJob.SelectedItem.Text + "/" + month[DateTime.Today.Month - 1].ToString() + "-" + DateTime.Today.Day.ToString();
        }
        catch
        {
            lblRef.Text = ddlProject.SelectedItem.Text + "/Store/" + ddlJob.SelectedItem.Text + "/" + month[DateTime.Today.Month - 1].ToString() + "-" + DateTime.Today.Day.ToString();

        }
    }
    void ClearTemp()
    {
        clsTempIndentItems obj = new clsTempIndentItems();
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Op = 4;
        obj.TempIndentItems(obj);
        pnlIndentItems.Visible = true;
    }
    void LoadTempItems()
    {
        clsTempIndentItems obj = new clsTempIndentItems();
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Op = 3;
        DataTable dt = obj.TempIndentItems(obj).Tables[0];
        grdIndentItems.DataSource = dt;
        grdIndentItems.DataBind();
        if (dt.Rows.Count > 0)
        {
            pnlIndentItems.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
        else
        {
            pnlIndentItems.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = false;
        }
    }
    void LoadProjects()
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 3;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.Projects(obj).Tables[0];
        ddlProject.DataSource = dt;
        ddlProject.DataTextField = "ProjectName";
        ddlProject.DataValueField = "ID";
        ddlProject.DataBind();
    }
    void LoadJobs(int ProjectID)
    {
        try
        {
            clsProjectJob obj = new clsProjectJob();
            obj.ProjectID = ProjectID;
            obj.Op = 3;
            DataTable dt = obj.Jobs(obj).Tables[0];
            ddlJob.DataSource = dt;
            ddlJob.DataValueField = "ID";
            ddlJob.DataTextField = "JobName";
            ddlJob.DataBind();
        }
        catch
        {

        }
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        clsPart obj = new clsPart();
        obj.PartName = txtPartNo.Text.Trim();
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblPartNo.Text = dt.Rows[0]["SerialNo"].ToString();
            lblPartName.Text = dt.Rows[0]["PartName"].ToString();
            //txtPartName.Text = dt.Rows[0]["PartName"].ToString();

            txtDetail.Text = "Machine Model/Name: " + dt.Rows[0]["ModelNo"].ToString() + "\n Manufacturer/Supplier: " + dt.Rows[0]["Manufacturer"].ToString() + "\n Part No:" + dt.Rows[0]["SerialNo"].ToString() + "\n Part Name:" + dt.Rows[0]["PartName"].ToString();
            clsSiteProductParts obParts = new clsSiteProductParts();
            obParts.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
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
        }
        else
        {
            txtPartNo.Focus();
        }
        
    }
    protected void grdIndentItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdIndentItems.EditIndex = -1;
        LoadTempItems();
    }
    protected void grdIndentItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsTempIndentItems obj = new clsTempIndentItems();
        obj.Op = 2;
        HiddenField hdID = (HiddenField)grdIndentItems.Rows[e.RowIndex].FindControl("hdID");
        obj.ID = Convert.ToInt32(hdID.Value);
        obj.TempIndentItems(obj);
        LoadTempItems();
    }
    protected void grdIndentItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdIndentItems.EditIndex = e.NewEditIndex;
        LoadTempItems();
    }
    protected void grdIndentItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HiddenField hdEID = (HiddenField)grdIndentItems.Rows[e.RowIndex].FindControl("hdEID");
        TextBox txtEEQuantity = (TextBox)grdIndentItems.Rows[e.RowIndex].FindControl("txtEEQuantity");
        TextBox txtERemarks = (TextBox)grdIndentItems.Rows[e.RowIndex].FindControl("txtERemarks");
        clsTempIndentItems obj = new clsTempIndentItems();
        obj.Op = 5;
        obj.ID = Convert.ToInt32(hdEID.Value);
        obj.Quantity = Convert.ToInt32(txtEEQuantity.Text);
        obj.Remarks = txtERemarks.Text;
        obj.TempIndentItems(obj);
        grdIndentItems.EditIndex = -1;
        LoadTempItems();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (lblPartNo.Text.Trim() != "" && txtCurrentStock.Text.Trim() != "" && txtQuantity.Text.Trim() != "")
        {
            clsTempIndentItems obj = new clsTempIndentItems();
            obj.Op = 1;
            obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
            //UserID, Particular, CurrentStock, Quantity, Remarks, Op
            obj.PartNo = txtPartNo.Text;
            obj.Particular = txtDetail.Text;
            obj.CurrentStock = Convert.ToInt32(txtCurrentStock.Text);
            obj.Quantity = Convert.ToInt32(txtQuantity.Text);
            obj.Remarks = txtRemarks.Text;
            obj.TempIndentItems(obj);
            LoadTempItems();
            txtPartNo.Text = "";
            txtDetail.Text = "";
            txtCurrentStock.Text = "";
            txtQuantity.Text = "";
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearTemp();
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadJobs(Convert.ToInt32(ddlProject.SelectedValue));
        CreateReferenceNo();
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsIndent obj = new clsIndent();
        obj.Op = 1;
        obj.OrderFrom = 1;
        obj.OrderFromID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.RefNo = lblRef.Text;
        obj.ProjectNo = ddlProject.SelectedItem.Text;
        obj.JobNo = ddlJob.SelectedItem.Text;
        obj.IndentDate = txtDate.Text;
        obj.Indentor = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.ApprovedBy = 0;
        obj.Status = 0;
        obj.IndentMaster(obj);
        obj.Op = 6;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        int MaxID = Convert.ToInt16(dt.Rows[0][0]);
        AddTempItemsToIndent(MaxID);
        ClearTemp();
        Response.Redirect("Indent.aspx");
    }
    void AddTempItemsToIndent(int IndentID)
    {
        clsTempIndentItems obj = new clsTempIndentItems();
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Op = 3;
        DataTable dt = obj.TempIndentItems(obj).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            clsIndentItems objItems = new clsIndentItems();
            objItems.Op = 1;
            objItems.IndentID = IndentID;
            objItems.PartNo = dr[2].ToString();
            objItems.Particular = dr[3].ToString();
            objItems.CurrentStock = Convert.ToInt32(dr[4]);
            objItems.Quantity = Convert.ToInt32(dr[5]);
            objItems.Remarks = dr[6].ToString();
            objItems.IndentItemMaster(objItems);
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        CreateReferenceNo();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearTemp();
        
        txtCurrentStock.Text = "";
        txtQuantity.Text = "";
        txtDate.Text = DateTime.Today.ToShortDateString();
        CreateReferenceNo();
        txtRemarks.Text = "";
        txtPartNo.Text = "";
        LoadTempItems();
    }
}