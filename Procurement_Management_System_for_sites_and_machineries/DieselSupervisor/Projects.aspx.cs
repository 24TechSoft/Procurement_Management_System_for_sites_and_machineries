using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_Projects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProjects();
        }
    }
    protected void btnSaveProject_Click(object sender, EventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 1;
        obj.ProjectDate = txtProjectDate.Text;
        obj.ProjectName = txtProjectName.Text;
        obj.Projects(obj);
        LoadProjects();
        txtProjectDate.Text = "";
        txtProjectName.Text = "";
    }
    void LoadProjects()
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 3;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.Projects(obj).Tables[0];
        grdProject.DataSource = dt;
        grdProject.DataBind();
        if (grdProject.Rows.Count > 0)
        {
            lblErrorProject.Text = "";
        }
        else
        {
            lblErrorProject.Text = "No Records found";
        }
    }
    void LoadJobs(int ProjectID)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.ProjectID = ProjectID;
        obj.Op = 3;
        DataTable dt = obj.Jobs(obj).Tables[0];
        grdJobs.DataSource = dt;
        grdJobs.DataBind();
        if (grdJobs.Rows.Count > 0)
        {
            lblErrorJob.Text = "";
        }
        else
        {
            lblErrorJob.Text = "No Records found";
        }
    }
    protected void btnSaveJob_Click(object sender, EventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 1;
        obj.ProjectID = Convert.ToInt32(hdPID.Value);
        obj.JobName = txtJobName.Text;
        obj.Jobs(obj);
        LoadJobs(Convert.ToInt32(hdPID.Value));
        txtJobName.Text = "";
    }
    protected void grdProject_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ProjectID = Convert.ToInt32(grdProject.DataKeys[e.NewSelectedIndex].Value);
        LoadJobs(ProjectID);
        hdPID.Value = ProjectID.ToString();
        pnlJobs.Visible = true;
    }
    protected void grdProject_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdProject.EditIndex = e.NewEditIndex;
        LoadProjects();
    }
    protected void grdProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 4;
        obj.ID = Convert.ToInt32(grdProject.DataKeys[e.RowIndex].Value);
        TextBox txtEProjectName=(TextBox)grdProject.Rows[e.RowIndex].FindControl("txtEProjectName");
        TextBox txtEProjectDate = (TextBox)grdProject.Rows[e.RowIndex].FindControl("txtEProjectDate");
        obj.ProjectName = txtEProjectName.Text;
        obj.ProjectDate = txtEProjectDate.Text;
        obj.Projects(obj);
        grdProject.EditIndex = -1;
        LoadProjects();
    }
    protected void grdProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdProject.DataKeys[e.RowIndex].Value);
        obj.Projects(obj);
        LoadProjects();
        pnlJobs.Visible = false;
    }
    protected void grdJobs_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdJobs.EditIndex = e.NewEditIndex;
        LoadJobs(Convert.ToInt32(hdPID.Value));
    }
    protected void grdJobs_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 4;
        obj.ID = Convert.ToInt32(grdJobs.DataKeys[e.RowIndex].Value);
        TextBox txtEJobName = (TextBox)grdJobs.Rows[e.RowIndex].FindControl("txtEJobName");
        obj.JobName = txtEJobName.Text;
        obj.Jobs(obj);
        grdJobs.EditIndex = -1;
        LoadJobs(Convert.ToInt32(hdPID.Value));
    }
    protected void grdJobs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdJobs.EditIndex = -1;
        LoadJobs(Convert.ToInt32(hdPID.Value));
    }
    protected void grdProject_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdProject.EditIndex = -1;
        LoadProjects();
    }
    protected void grdJobs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdJobs.DataKeys[e.RowIndex].Value);
        obj.Jobs(obj);
        LoadJobs(Convert.ToInt32(hdPID.Value));
    }
}