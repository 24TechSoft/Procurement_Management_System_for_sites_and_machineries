using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_PendingMachineryUsage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    protected void grdMachineryUsage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Approve")
        {
            clsMachineryUsage obj = new clsMachineryUsage();
            obj.ID = Convert.ToInt32(grdMachineryUsage.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
            obj.Op = 5;
            obj.Status = 1;
            obj.MachineryUsage(obj);
            grdMachineryUsage.EditIndex = -1;
            LoadData();
        }
    }
    void LoadData()
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.Op = 7;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.EntryDate1 = DateTime.Today.ToShortDateString();
        obj.EntryDate2 = DateTime.Now.ToString();
        DataTable dt = obj.MachineryUsage(obj).Tables[0];
        grdMachineryUsage.DataSource = dt;
        grdMachineryUsage.DataBind();
        if (grdMachineryUsage.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void grdMachineryUsage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.ID = Convert.ToInt32(grdMachineryUsage.DataKeys[e.RowIndex].Value);
        obj.Op = 4;
        obj.MachineryUsage(obj);
        LoadData();
    }
}