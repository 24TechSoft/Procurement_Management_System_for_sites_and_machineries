using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_Indent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadIndents();
        }
    }
    void LoadIndents()
    {
        clsIndent obj = new clsIndent();
        obj.Op = 11;
        obj.OrderFromID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        grdIndent.DataSource = dt;
        grdIndent.DataBind();
        if (grdIndent.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records Found";
        }
    }
    protected void grdIndent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Redirect("ViewIndent.aspx?ID=" + grdIndent.DataKeys[e.RowIndex].Value);
    }
    protected void lnkEditItems_Click(object sender, EventArgs e)
    {
        LinkButton lnkEditItems = sender as LinkButton;
        GridViewRow dr = lnkEditItems.NamingContainer as GridViewRow;
        HiddenField hdID = dr.FindControl("hdID") as HiddenField;
        clsIndent obj = new clsIndent();
        obj.ID = Convert.ToInt32(grdIndent.DataKeys[dr.RowIndex].Value);
        obj.Op = 4;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        Response.Redirect("EditIndentItems.aspx?IndentID=" + dt.Rows[0]["ID"] + "&SiteMachineID=" + dt.Rows[0]["SiteMachineID"] + "&Status=" + dt.Rows[0]["Status"] + "&SiteID=" + dt.Rows[0]["OrderFromID"]);
    }
}