using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Admin_CreatePO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!IsPostBack)
        {
            LoadTax();
            txtPreparedBy.Text = Request.Cookies["Name"].Value.ToString();
            hdPreparedBy.Value = Request.Cookies["User"].Value.ToString();
            clsPurchaseOrder obj = new clsPurchaseOrder();
            obj.Op = 9;
            DataTable dt = obj.PurchaseOrderMaster(obj).Tables[0];
            if (dt.Rows.Count == 0)
            {
                txtRefNo.Text = "TKECP/P&E/LOI-001";
            }
            else
            {
                int x = Convert.ToInt32(dt.Rows[0][0].ToString().Substring(14));
                txtRefNo.Text = "TKECP/P&E/LOI-" + (x + 1).ToString();
            }
            MapData();
            LoadSites();
            LoadSiteMachines();
            LoadPOTo();
        }
    }
    void MapData()
    {
        DataTable dtLoad = new DataTable();
        dtLoad.Columns.Add("SL");
        dtLoad.Columns.Add("CGST");
        dtLoad.Columns.Add("SGST");
        dtLoad.Columns.Add("IGST");
        for (int i = 0; i < 20; i++)
        {
            DataRow dr = dtLoad.NewRow();
            dr[0] = i + 1;
            string Tax = ddlTax.SelectedValue.ToString();
            dr[1] = Tax.Substring(0, Tax.IndexOf(":"));
            Tax = Tax.Substring(Tax.IndexOf(":") + 1);
            dr[2] = Tax.Substring(0, Tax.IndexOf(":"));
            Tax = Tax.Substring(Tax.IndexOf(":") + 1);
            dr[3] = Tax;
            if(chkIGST.Checked==true)
            {
                dr[1] = "0.00";
                dr[2] = "0.00";
            }
            else
            {
                dr[3] = "0.00";
            }
            dtLoad.Rows.Add(dr);
        }
        grd.DataSource = dtLoad;
        grd.DataBind();
    }
    void LoadSites()
    {
        clsSite obj = new clsSite();
        obj.Op = 4;
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        ddlSite.DataSource = dt;
        ddlSite.DataValueField = "ID";
        ddlSite.DataTextField = "Name";
        ddlSite.DataBind();
        LoadSiteMachines();
    }
    void LoadPOTo()
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Op = 4;
        DataTable dt = obj.ManufacturerMaster(obj).Tables[0];
        ddlPOTo.DataSource = dt;
        ddlPOTo.DataValueField = "ID";
        ddlPOTo.DataTextField = "Name";
        ddlPOTo.DataBind();
    }
    protected void txtRate1_TextChange(object sender, EventArgs e)
    {
        TextBox txtRate1 = (TextBox)sender;
        GridViewRow row = txtRate1.NamingContainer as GridViewRow;
        CalculateAmount();
    }
    protected void txtQuantity1_TextChange(object sender, EventArgs e)
    {
        TextBox txtQuantity1 = (TextBox)sender;
        GridViewRow row = txtQuantity1.NamingContainer as GridViewRow;
        CalculateAmount();
    }
    protected void txtPartNo1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPartNo = (TextBox)sender;
        GridViewRow row = txtPartNo.NamingContainer as GridViewRow;
        TextBox txtPartName = grd.Rows[row.RowIndex].FindControl("txtPartName1") as TextBox;
        Label lblCurrentStock = grd.Rows[row.RowIndex].FindControl("lblCurrentStock1") as Label;
        HiddenField hdPartID = grd.Rows[row.RowIndex].FindControl("hdPartID") as HiddenField;
        clsPart obj = new clsPart();
        obj.PartName = txtPartNo.Text.Trim();
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtPartName.Text = dt.Rows[0]["PartName"].ToString();
            hdPartID.Value = dt.Rows[0]["ID"].ToString();
        }
        else
        {
            hdPartID.Value = "";
        }
       clsSiteProductParts obParts = new clsSiteProductParts();
        obParts.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        try
        {
            obParts.PartID = Convert.ToInt32(dt.Rows[0]["ID"]);
        }
        catch
        {
            obParts.PartID = 0;
        }
        obParts.Op = 8;
        DataTable dtStock = obParts.SiteProductParts(obParts).Tables[0];
        if (dtStock.Rows.Count > 0)
        {
            try
            {
                lblCurrentStock.Text = dtStock.Rows[0]["Quantity"].ToString();
            }
            catch
            {
                lblCurrentStock.Text = "0";
            }
        }
        else
        {
            lblCurrentStock.Text = "0";
        }

    }
    void LoadTax()
    {
        clsTaxMaster obj = new clsTaxMaster();
        obj.Op = 3;
        DataTable dt = obj.TaxMaster(obj).Tables[0];
        dt.Columns.Add("TaxAmount");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["TaxAmount"] = (dt.Rows[i]["CGST"].ToString() + ":" + dt.Rows[i]["SGST"].ToString() + ":" + dt.Rows[i]["IGST"].ToString()).ToString();
        }
        ddlTax.DataSource = dt;
        ddlTax.DataTextField = "TaxAmount";
        ddlTax.DataValueField = "TaxAmount";
        ddlTax.DataBind();
        MapData();
    }
    protected void txtIndentRef_TextChanged(object sender, EventArgs e)
    {
        clsIndent obj = new clsIndent();
        obj.Op = 7;
        obj.RefNo = txtIndentRef.Text.Trim();
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        grdIndentRef.DataSource = dt;
        grdIndentRef.DataBind();
        grdIndentRef.Visible = true;
        if (dt.Rows.Count > 0)
        {
            hdSiteID.Value = dt.Rows[0]["OrderFromID"].ToString();
            ddlSite.Text = dt.Rows[0]["OrderFromID"].ToString();
        }
        else
        {

        }
        LoadSiteMachines();
    }
    protected void grdIndentRef_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtIndentRef.Text = grdIndentRef.Rows[e.RowIndex].Cells[0].Text;
        clsIndent objIndent = new clsIndent();
        objIndent.Op = 7;
        objIndent.RefNo = txtIndentRef.Text.Trim();
        DataTable dtIndent = objIndent.IndentMaster(objIndent).Tables[0];
        if (dtIndent.Rows.Count > 0)
        {
            hdSiteID.Value = dtIndent.Rows[0]["OrderFromID"].ToString();
            ddlSite.Text = dtIndent.Rows[0]["OrderFromID"].ToString();
        }
        else
        {

        }
        clsIndentItems obj = new clsIndentItems();
        obj.IndentID = Convert.ToInt32(grdIndentRef.DataKeys[e.RowIndex].Value);
        obj.Op = 2;
        DataTable dt = obj.IndentItemMaster(obj).Tables[0];
        grdIndentItems.DataSource = dt;
        grdIndentItems.DataBind();
        grdIndentRef.Visible = false;
        LoadSiteMachines();
    }
    protected void txtCheckedBy_TextChanged(object sender, EventArgs e)
    {
        clsUser obj = new clsUser();
        obj.Op = 6;
        obj.Name = txtCheckedBy.Text;
        DataTable dt = obj.UserMaster(obj).Tables[0];
        grdCheckedBy.DataSource = dt;
        grdCheckedBy.DataBind();
        grdCheckedBy.Visible = true;
    }
    protected void chkIGST_CheckedChanged(object sender,EventArgs e)
    {
        MapData();
    }
    protected void grdCheckedBy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtCheckedBy.Text = grdCheckedBy.Rows[e.RowIndex].Cells[1].Text;
        hdCheckedBy.Value = grdCheckedBy.DataKeys[e.RowIndex].Value.ToString();
        grdCheckedBy.Visible = false;
    }
    protected void ddlTax_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in grd.Rows)
        {
            string Tax = ddlTax.SelectedValue.ToString();

            TextBox txtCGST1 = (TextBox)dr.FindControl("txtCGST1");
            txtCGST1.Text = Tax.Substring(0, Tax.IndexOf(":"));
            Tax = Tax.Substring(Tax.IndexOf(":") + 1);
            TextBox txtSGST1 = (TextBox)dr.FindControl("txtSGST1");
            txtSGST1.Text = Tax.Substring(0, Tax.IndexOf(":"));
            Tax = Tax.Substring(Tax.IndexOf(":") + 1);
            TextBox txtIGST1 = (TextBox)dr.FindControl("txtIGST1");
            txtIGST1.Text = Tax;
            if (chkIGST.Checked == true)
            {
                txtCGST1.Text = "0";
                txtSGST1.Text = "0";
            }
            else
            {
                txtIGST1.Text = "0";
            }
        }
        CalculateAmount();
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        CalculateAmount();
    }
    void CalculateAmount()
    {
        double TotalAmount = 0;
        foreach (GridViewRow dr in grd.Rows)
        {
            TextBox txtRate1 = (TextBox)dr.FindControl("txtRate1");
            TextBox txtCGST1 = (TextBox)dr.FindControl("txtCGST1");
            TextBox txtSGST1 = (TextBox)dr.FindControl("txtSGST1");
            TextBox txtIGST1 = (TextBox)dr.FindControl("txtIGST1");
            TextBox txtTotal1 = (TextBox)dr.FindControl("txtTotal1");
            TextBox txtQuantity1 = (TextBox)dr.FindControl("txtQuantity1");
            double Rate1 = 0;
            double CGST1 = 0;
            double SGST1 = 0;
            double IGST1 = 0;
            double Quantity1 = 0;
            try
            {
                Rate1 = Convert.ToDouble(txtRate1.Text);
            }
            catch
            {
                Rate1 = 0;
            }
            try
            {
                CGST1 = Convert.ToDouble(txtCGST1.Text);
            }
            catch
            {
                CGST1 = 0;
            }
            try
            {
                SGST1 = Convert.ToDouble(txtSGST1.Text);
            }
            catch
            {
                SGST1 = 0;
            }
            try
            {
                IGST1 = Convert.ToDouble(txtIGST1.Text);
            }
            catch
            {
                IGST1 = 0;
            }
            try
            {
                Quantity1 = Convert.ToDouble(txtQuantity1.Text);
            }
            catch
            {
                Quantity1 = 0;
            }
            double Amount = Rate1 * Quantity1;
            double Tax = Amount * (CGST1+SGST1+IGST1) / 100;
            txtTotal1.Text = (Amount + Tax).ToString();
            TotalAmount = TotalAmount + Convert.ToDouble(txtTotal1.Text);
        }
        txtTotalAmount.Text = TotalAmount.ToString();
        txtPayable.Text = (TotalAmount - (TotalAmount * Convert.ToDouble(txtDiscount.Text) / 100)).ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsPurchaseOrder obj = new clsPurchaseOrder();
        //ID, PORefNo, PODate, IndentRefNo, QuotationNo, QuotationDate, Subject, PreparedBy, CheckedBy, CompanySign, TotalAmount, TaxName, 
        //TaxPercentage, DiscountPercentage, NetPayable,Status
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        obj.PORefNo = txtRefNo.Text;
        obj.PODate = txtPODate.Text;
        obj.IndentRefNo = txtIndentRef.Text;
        obj.QuotationNo = txtQuotationNo.Text;
        obj.QuotationDate = txtQuotationDate.Text;
        obj.Subject = txtSubject.Text;
        obj.PreparedBy = Convert.ToInt32(hdPreparedBy.Value);
        obj.CheckedBy = Convert.ToInt32(hdCheckedBy.Value);
        obj.CompanySign = "";
        try { obj.TotalAmount = Convert.ToDouble(txtTotalAmount.Text); }
        catch { }
        string Tax = ddlTax.SelectedValue.ToString();

        obj.CGST = Convert.ToDouble(Tax.Substring(0, Tax.IndexOf(":")));
        Tax = Tax.Substring(Tax.IndexOf(":") + 1);
        obj.SGST = Convert.ToDouble(Tax.Substring(0, Tax.IndexOf(":")));
        Tax = Tax.Substring(Tax.IndexOf(":") + 1);
        obj.IGST = Convert.ToDouble(Tax);
        if (chkIGST.Checked == true)
        {
            obj.CGST = 0;
            obj.SGST = 0;
        }
        else
        {
            obj.IGST = 0;
        }
        obj.DiscountPercentage = Convert.ToDouble(txtDiscount.Text);
        try { obj.NetPayable = Convert.ToDouble(txtPayable.Text); }
        catch { }
        obj.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        try { obj.POTo = Convert.ToInt32(ddlPOTo.SelectedValue); }
        catch { }
        try { obj.POFile = UploadPhoto(file); }
        catch { }
        obj.Op = 1;
        obj.PurchaseOrderMaster(obj);
        obj.Op = 8;
        DataTable dt = obj.PurchaseOrderMaster(obj).Tables[0];
        SavePOItems(Convert.ToInt32(dt.Rows[0][0]));
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Saved');", true);
        Response.Redirect("PurchaseOrder.aspx");
    }
    void SavePOItems(int POID)
    {
        foreach (GridViewRow dr in grd.Rows)
        {
            clsPOParticulars ob = new clsPOParticulars();
            //POID, PartNo, Item,CurrentStock, Qty, UGM, Rate,Tax, Amount,Remark
            TextBox txtQuantity1 = (TextBox)dr.FindControl("txtQuantity1");
            //TextBox txtLogNo1 = (TextBox)dr.FindControl("txtLogNo1");
            TextBox txtPartNo1 = (TextBox)dr.FindControl("txtPartNo1");
            TextBox txtPartName1 = (TextBox)dr.FindControl("txtPartName1");
            TextBox txtUOM1 = (TextBox)dr.FindControl("txtUOM1");
            Label lblCurrentStock1 = (Label)dr.FindControl("lblCurrentStock1");
            TextBox txtRate1 = (TextBox)dr.FindControl("txtRate1");
            TextBox txtCGST = (TextBox)dr.FindControl("txtCGST1");
            TextBox txtSGST = (TextBox)dr.FindControl("txtSGST1");
            TextBox txtIGST = (TextBox)dr.FindControl("txtIGST1");
            TextBox txtTotal1 = (TextBox)dr.FindControl("txtTotal1");
            TextBox txtRemark1 = (TextBox)dr.FindControl("txtRemark1");
            HiddenField hdPartID = (HiddenField)dr.FindControl("hdPartID");
            if (txtPartNo1.Text != "" && txtRate1.Text != "" && txtQuantity1.Text != "")
            {
                ob.POID = POID;
                ob.PartNo = txtPartNo1.Text;
                ob.Item = txtPartName1.Text;
                ob.CurrentStock = Convert.ToInt32(lblCurrentStock1.Text);
                ob.Qty = Convert.ToInt32(txtQuantity1.Text);
                ob.UGM = txtUOM1.Text;
                ob.Rate = Convert.ToDouble(txtRate1.Text);
                ob.CGST = Convert.ToDouble(txtCGST.Text);
                ob.SGST = Convert.ToDouble(txtSGST.Text);
                ob.IGST = Convert.ToDouble(txtIGST.Text);
                ob.Amount = Convert.ToDouble(txtTotal1.Text);
                ob.Remark = txtRemark1.Text;
                ob.Op = 1;
                ob.POParticularsMaster(ob);
                if (hdPartID.Value == "")
                {
                    clsPart obPart = new clsPart();
                    clsSiteMachines obSM = new clsSiteMachines();
                    obSM.ID = Convert.ToInt32(ddlSite.SelectedValue);
                    obSM.Op = 5;
                    DataTable dtMDetail = obSM.SiteMachines(obSM).Tables[0];
                    obPart.MachineID = Convert.ToInt32(dtMDetail.Rows[0]["MachineID"]);
                    obPart.PartName = txtPartName1.Text;
                    obPart.SerialNo = txtPartNo1.Text;
                    obPart.Op = 1;
                    obPart.PartMaster(obPart);
                }
            }
        }

    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSiteMachines();
    }
    void LoadSiteMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        ddlMachine.DataSource = dt;
        ddlMachine.DataValueField = "ID";
        ddlMachine.DataTextField = "Machine";
        ddlMachine.DataBind();
    }
    protected void btnAddCust_Click(object sender, EventArgs e)
    {
        clsManufacturer obj = new clsManufacturer();
        obj.Name = txtName.Text;
        obj.Address = txtAddress.Text;
        obj.PhoneNo = txtPhone.Text;
        obj.Email = txtEmail.Text;
        obj.Op = 1;
        obj.ManufacturerMaster(obj);
        LoadPOTo();
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