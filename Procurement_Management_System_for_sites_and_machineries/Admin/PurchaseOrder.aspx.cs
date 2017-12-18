using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_PurchaseOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsPurchaseOrder obj = new clsPurchaseOrder();
            obj.Op = 2;
            DataTable dt = obj.PurchaseOrderMaster(obj).Tables[0];
            grdPO.DataSource = dt;
            grdPO.DataBind();
            if (grdPO.Rows.Count > 0)
            {
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "No Records Found";
            }
        }
    }
    protected void grdPO_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsPurchaseOrder obj = new clsPurchaseOrder();
        obj.ID = Convert.ToInt32(grdPO.DataKeys[e.RowIndex].Value);
        obj.Op = 3;
        DataTable dt = obj.PurchaseOrderMaster(obj).Tables[0];
        if (dt.Rows[0]["POFile"].ToString() != "")
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + dt.Rows[0]["POFile"].ToString());
            Response.TransmitFile(MapPath("~/"+dt.Rows[0]["POFile"].ToString()));
            Response.End();

        }
        else
        {
            Response.Redirect("POTerms.aspx?ID=" + grdPO.DataKeys[e.RowIndex].Value.ToString());
        }
    }
}