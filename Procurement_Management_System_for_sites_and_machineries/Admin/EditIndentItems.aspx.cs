using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_EditIndentItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadItems();
        }
    }
    void LoadItems()
    {
        try
        {
            clsIndentItems obj = new clsIndentItems();
            obj.IndentID = Convert.ToInt32(Request.QueryString["IndentID"]);
            obj.Op = 2;
            DataTable dt = obj.IndentItemMaster(obj).Tables[0];
            while (dt.Rows.Count < 20)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["ID"] = 0;
                dt.Rows[dt.Rows.Count - 1]["PartID"] = -1;
                dt.Rows[dt.Rows.Count - 1]["CurrentStock"] = 0;
                dt.Rows[dt.Rows.Count - 1]["Quantity"] = 0;
            }
            dt.Columns.Add("SL");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["SL"] = i + 1;
                if (dt.Rows[i]["Photo"] != "")
                {
                    dt.Rows[i]["Photo"] = "~/" + dt.Rows[i]["Photo"];
                }
            }
            grd.DataSource = dt;
            grd.DataBind();
            foreach (GridViewRow dr in grd.Rows)
            {
                LinkButton lnkDelete = dr.FindControl("lnkDelete") as LinkButton;
                HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
                if (hdPartID.Value == "-1")
                {
                    lnkDelete.Enabled = false;
                }
                else
                {
                    TextBox txtLogNo = dr.FindControl("txtLogNo") as TextBox;
                    txtLogNo.Enabled = false;
                    TextBox txtPartNo = dr.FindControl("txtPartNo") as TextBox;
                    txtPartNo.Enabled = false;
                    TextBox txtItem = dr.FindControl("txtItem") as TextBox;
                    txtItem.Enabled = false;
                    TextBox txtCurrentStock = dr.FindControl("txtCurrentStock") as TextBox;
                    txtCurrentStock.Enabled = false;
                    TextBox txtUOM = dr.FindControl("txtUOM") as TextBox;
                    txtUOM.Enabled = false;
                    TextBox txtRemark = dr.FindControl("txtRemark") as TextBox;
                    txtRemark.Enabled = false;
                }
            }
        }
        catch{
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsIndentItems obj = new clsIndentItems();
        obj.IndentID = Convert.ToInt32(Request.QueryString["IndentID"]);
        foreach (GridViewRow dr in grd.Rows)
        {
            TextBox txtLogNo = dr.FindControl("txtLogNo") as TextBox;
            TextBox txtPartNo = dr.FindControl("txtPartNo") as TextBox;
            HiddenField hdPartID = dr.FindControl("hdPartID") as HiddenField;
            TextBox txtItem = dr.FindControl("txtItem") as TextBox;
            TextBox txtCurrentStock = dr.FindControl("txtCurrentStock") as TextBox;
            TextBox txtQuantity = dr.FindControl("txtQuantity") as TextBox;
            HiddenField hdPrevQuantity = dr.FindControl("hdPrevQuantity") as HiddenField;
            TextBox txtUOM = dr.FindControl("txtUOM") as TextBox;
            TextBox txtRemark = dr.FindControl("txtRemark") as TextBox;
            LinkButton lnkDelete = dr.FindControl("lnkDelete") as LinkButton;
            if (hdPartID.Value == "-1")
            {
                if (txtPartNo.Text != "" && txtItem.Text != "" && Convert.ToInt32(txtQuantity.Text) != 0)
                {
                    obj.Op = 1;
                    obj.LogNo = txtLogNo.Text;
                    obj.PartNo = txtPartNo.Text;
                    obj.Particular = txtItem.Text;
                    obj.CurrentStock = Convert.ToInt32(txtCurrentStock.Text);
                    obj.Quantity = Convert.ToInt32(txtQuantity.Text);
                    obj.UOM = txtUOM.Text;
                    obj.Remarks = txtRemark.Text;
                    obj.IndentItemMaster(obj);
                }
            }
            else
            {
                if (Convert.ToInt32(Request.QueryString["Status"]) == 1)
                {
                    if (txtQuantity.Text != hdPrevQuantity.Value)
                    {
                        obj.Op = 4;
                        obj.ID = Convert.ToInt32(grd.DataKeys[dr.RowIndex].Value);
                        obj.Quantity = Convert.ToInt32(txtQuantity.Text);
                        obj.IndentItemMaster(obj);
                        if (Convert.ToInt32(txtCurrentStock.Text) > Convert.ToInt32(txtQuantity.Text))
                        {
                            clsSiteProductParts obSPP = new clsSiteProductParts();
                            obSPP.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]);
                            obSPP.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]);
                            obSPP.PartID = Convert.ToInt32(hdPartID.Value);
                            obSPP.Quantity = Convert.ToInt32(txtCurrentStock.Text) - Convert.ToInt32(txtQuantity.Text);
                            obSPP.Op = 1;
                            obSPP.TransactionType = 1;
                            obSPP.Remarks = "Insert against Indent edit";
                            obSPP.SiteProductParts(obSPP);
                        }
                    }
                }
            }
        }
    }
    protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsIndentItems obj = new clsIndentItems();
        obj.ID = Convert.ToInt32(grd.DataKeys[e.RowIndex].Value);
        obj.Op = 5;
        obj.IndentItemMaster(obj);

        /*Add to items*/
        TextBox txtLogNo = grd.Rows[e.RowIndex].FindControl("txtLogNo") as TextBox;
        TextBox txtPartNo = grd.Rows[e.RowIndex].FindControl("txtPartNo") as TextBox;
        HiddenField hdPartID = grd.Rows[e.RowIndex].FindControl("hdPartID") as HiddenField;
        TextBox txtItem = grd.Rows[e.RowIndex].FindControl("txtItem") as TextBox;
        TextBox txtCurrentStock = grd.Rows[e.RowIndex].FindControl("txtCurrentStock") as TextBox;
        TextBox txtQuantity = grd.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox;
        HiddenField hdPrevQuantity = grd.Rows[e.RowIndex].FindControl("hdPrevQuantity") as HiddenField;
        TextBox txtUOM = grd.Rows[e.RowIndex].FindControl("txtUOM") as TextBox;
        TextBox txtRemark = grd.Rows[e.RowIndex].FindControl("txtRemark") as TextBox;
        LinkButton lnkDelete = grd.Rows[e.RowIndex].FindControl("lnkDelete") as LinkButton;
        clsSiteProductParts obSPP = new clsSiteProductParts();
        obSPP.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]);
        obSPP.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]);
        obSPP.PartID = Convert.ToInt32(hdPartID.Value);
        obSPP.Quantity = Convert.ToInt32(txtCurrentStock.Text) - Convert.ToInt32(txtQuantity.Text);
        obSPP.Op = 1;
        obSPP.TransactionType = 1;
        obSPP.Remarks = "Insert against Indent edit";
        obSPP.SiteProductParts(obSPP);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Indent.aspx");
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPartNo = sender as TextBox;
        txtPartNo.Text = txtPartNo.Text.Trim();
        GridViewRow row = txtPartNo.NamingContainer as GridViewRow;
        TextBox txtItem = row.FindControl("txtItem") as TextBox;
        TextBox txtCurrentStock = row.FindControl("txtCurrentStock") as TextBox;
        TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;

        clsPart obj = new clsPart();
        obj.PartName = txtPartNo.Text.Trim();
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtItem.Text = dt.Rows[0]["PartName"].ToString();

            clsSiteProductParts obParts = new clsSiteProductParts();
            obParts.SiteID = Convert.ToInt32(Convert.ToInt32(Request.QueryString["SiteID"]));
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
            txtPartNo.Focus();
        }
    }
}