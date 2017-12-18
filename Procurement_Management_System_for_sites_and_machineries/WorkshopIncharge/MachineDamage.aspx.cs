using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_MachineDamage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
            LoadDamage();
        }
    }
    void LoadMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 3;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        DataTable dtNew=new DataTable();
        dtNew.Columns.Add("SL");
        dtNew.Columns.Add("Machine");
        dtNew.Columns.Add("SiteMachineID");
        for(int i=0;i<dt.Rows.Count;i++)
        {
            dtNew.Rows.Add();
            dtNew.Rows[i][0] = i + 1;
            dtNew.Rows[i][1] = dt.Rows[i]["Machine"].ToString();
            dtNew.Rows[i][2] = dt.Rows[i]["ID"];
        }
        grd.DataSource = dtNew;
        grd.DataBind();
    }
    void LoadDamage()
    {
        clsMachineDamage obj = new clsMachineDamage();
        LiteralControl lc;
        obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
        obj.Op = 4;
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        DataTable dtMain = new DataTable();
        foreach (DataColumn dc in dt.Columns)
        {
            dtMain.Columns.Add(dc.ColumnName);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dtMain.Rows.Add();
            for(int j=0;j<dt.Columns.Count;j++)
            {
                if (dt.Columns[j].ColumnName != "EntryDate")
                {
                    dtMain.Rows[i][j] = dt.Rows[i][j].ToString();
                }
                else
                {
                    dtMain.Rows[i][j] = Convert.ToDateTime(dt.Rows[i][j]).ToShortDateString();
                }
            }
        }
        dt = dtMain;
        grdDamage.DataSource = dt;
        grdDamage.DataBind();
        foreach (GridViewRow dr in grdDamage.Rows)
        {
            lc = new LiteralControl();
            if (dt.Rows[dr.RowIndex]["IndentID"] != "" && Convert.ToInt32(dt.Rows[dr.RowIndex]["IndentID"]) != 0)
            {
                lc.Text = "<a href='ViewIndent.aspx?ID=" + dt.Rows[dr.RowIndex]["IndentID"].ToString() + "' target='_blank'>View Indent</a>";
                LinkButton LinkButton1 = dr.FindControl("LinkButton1") as LinkButton;
                LinkButton1.Text = "Change Indent";
            }
            else
            {
                lc.Text = "<a href='CreateIndent.aspx' target='_blank'>Create New Indent</a>";
            }
            dr.Cells[4].Controls.Add(lc);
        }
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
        LoadDamage();
    }
    protected void txtIndent_TextChange(object sender, EventArgs e)
    {
        TextBox txtIndent=sender as TextBox;
        clsIndent obj = new clsIndent();
        obj.Op = 7;
        obj.RefNo = txtIndent.Text.Trim();
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        GridViewRow dr = txtIndent.NamingContainer as GridViewRow;
        HiddenField hdIndentID = dr.FindControl("hdIndentID") as HiddenField;
        if (dt.Rows.Count > 0)
        {
            hdIndentID.Value = dt.Rows[0]["ID"].ToString();
            txtIndent.Text = txtIndent.Text.Trim();
        }
        else
        {
            hdIndentID.Value = "0";
        }
    }
    protected void txtEIndent_TextChanged(object sender, EventArgs e)
    {
        clsIndent obj = new clsIndent();
        obj.Op = 7;
        obj.RefNo = txtEIndent.Text.Trim();
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            hdEIndentID.Value = dt.Rows[0]["ID"].ToString();
            txtEIndent.Text = txtEIndent.Text.Trim();
        }
        else
        {
            hdEIndentID.Value = "0";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in grd.Rows)
        {
            HiddenField hdSiteMachineID = dr.FindControl("hdSiteMachineID") as HiddenField;
            HiddenField hdIndentID = dr.FindControl("hdIndentID") as HiddenField;
            TextBox txtRemark = dr.FindControl("txtRemark") as TextBox;
            CheckBox chkBreak = dr.FindControl("chkBreak") as CheckBox;
            if (chkBreak.Checked == true)
            {
                clsMachineDamage obj = new clsMachineDamage();
                obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                obj.SiteMachineID = Convert.ToInt32(hdSiteMachineID.Value);
                try { obj.EntryDate1 = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
                catch { obj.EntryDate1 = DateTime.Today.ToShortDateString(); }
                obj.Remarks = txtRemark.Text;
                try { obj.IndentID = Convert.ToInt32(hdIndentID.Value); }
                catch { obj.IndentID = 0; }
                obj.Op = 1;
                obj.MachineDamage(obj);
                clsSiteMachines obSM = new clsSiteMachines();
                obSM.Op = 2;
                try { obSM.UpdateDate = Convert.ToDateTime(txtDate.Text).ToShortDateString(); }
                catch { }
                obSM.Status = 3;
                obSM.ID = Convert.ToInt32(hdSiteMachineID.Value);
                obSM.SiteMachines(obSM);
            }
        }
        pnlExisting.Visible = true;
        pnlNewEntry.Visible = false;
        LoadDamage();
    }
    protected void grdDamage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.Op = 2;
        obj.ID = Convert.ToInt32(grdDamage.DataKeys[e.RowIndex].Value);
        obj.MachineDamage(obj);
        LoadDamage();
    }
    protected void grdDamage_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        grdDamage.SelectedIndex = e.NewSelectedIndex;
        pnlUpdate.Visible = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.IndentID = Convert.ToInt32(hdEIndentID.Value);
        obj.ID = Convert.ToInt32(grdDamage.DataKeys[grdDamage.SelectedIndex].Value);
        obj.Op = 3;
        obj.MachineDamage(obj);
        
        grdDamage.SelectedIndex = -1;
        pnlUpdate.Visible = false;
        LoadDamage();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grdDamage.SelectedIndex = -1;
        pnlUpdate.Visible = false;
        LoadDamage();
    }
    protected void btnExisting_Click(object sender, EventArgs e)
    {
        pnlNewEntry.Visible = false;
        pnlExisting.Visible = true;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNewEntry.Visible = true;
        pnlExisting.Visible = false;
    }
}