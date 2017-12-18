using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Supervisor_Indent : System.Web.UI.Page
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
        obj.UserID = Convert.ToInt32(Request.Cookies["User"].Value);
        obj.Op = 9;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        grdIndent.DataSource = dt;
        grdIndent.DataBind();
        if (grdIndent.Rows.Count > 0)
        {
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "No Records found";
        }
    }
    protected void grdIndent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Redirect("ViewIndent.aspx?ID=" + grdIndent.DataKeys[e.RowIndex].Value);
    }
}