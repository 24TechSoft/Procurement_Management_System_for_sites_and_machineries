using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Admin_WorkOrder : System.Web.UI.Page
{
    private int Option = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Option = 1;
            LoadData(Option);
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = true;
        pnlExisting.Visible = false;
        DataTable dt = new DataTable();
        dt.Columns.Add("SL");
        for (int i = 0; i < 20; i++)
        {
            dt.Rows.Add();
            dt.Rows[i][0] = i + 1;
        }
        grd.DataSource = dt;
        grd.DataBind();
    }
    protected void btnViewExisting_Click(object sender, EventArgs e)
    {
        pnlNew.Visible = false;
        pnlExisting.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsWorkOrder obj;
        foreach (GridViewRow dr in grd.Rows)
        {
            
            obj = new clsWorkOrder();
            TextBox txtIssueDate = dr.FindControl("txtIssueDate") as TextBox;
            TextBox txtCName = dr.FindControl("txtCName") as TextBox;
            TextBox txtCAddress = dr.FindControl("txtCAddress") as TextBox;
            TextBox txtCPhone = dr.FindControl("txtCPhone") as TextBox;
            TextBox txtCEmail = dr.FindControl("txtCEmail") as TextBox;
            TextBox txtSubject = dr.FindControl("txtSubject") as TextBox;
            TextBox txtDetail = dr.FindControl("txtDetail") as TextBox;
            FileUpload file = dr.FindControl("file") as FileUpload;
            if (txtIssueDate.Text != "" && txtCName.Text != "")
            {
                obj.IssueDate1 = Convert.ToDateTime(txtIssueDate.Text).ToShortDateString();
                obj.CName = txtCName.Text;
                obj.CAddress = txtCAddress.Text;
                obj.CPhone = txtCPhone.Text;
                obj.CEmail = txtCEmail.Text;
                obj.Subject = txtSubject.Text;
                obj.Detail = txtDetail.Text;
                obj.UploadedFile = UploadFile(file);
                obj.Op = 1;
                obj.WorkOrder(obj);
            }
        }
        Option = 1;
        LoadData(Option);
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    string UploadFile(FileUpload file)
    {
        if (file.HasFile)
        {
            string fileName = Path.GetFileName(file.PostedFile.FileName);
            string Rand = RandomString(8) + Path.GetExtension(file.PostedFile.FileName);
            file.PostedFile.SaveAs(Server.MapPath("~/uploads/") + Rand);
            return "uploads/" + Rand;
        }
        else
        {
            return "";
        }
    }
    protected void grdExisting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdExisting.PageIndex = e.NewPageIndex;
        LoadData(Option);
    }
    void LoadData(int Op)
    {
        clsWorkOrder obj = new clsWorkOrder();
        switch (Op)
        {
            case 1:
                obj.Op = 5;
                break;
            case 2:
                try { obj.IssueDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString(); }
                catch { }
                try { obj.IssueDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString(); }
                catch { }
                obj.Op = 3;
                break;
            case 3:
                obj.CName = txtName.Text;
                obj.Op = 4;
                break;
            default:
                obj.Op = 5;
                break;
        }
        DataTable dt = obj.WorkOrder(obj).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            if(dr["UploadedFile"].ToString().Trim()!="")
            {
                dr["UploadedFile"] = "~/" + dr["UploadedFile"].ToString().Trim();
            }
            dr["CAddree"] = dr["CAddress"].ToString().Replace("\n","<br>");
            dr["Detail"] = dr["Detail"].ToString().Replace("\n", "<br>");
        }
        grdExisting.DataSource = dt;
        grdExisting.DataBind();
        foreach (GridViewRow dr in grdExisting.Rows)
        {
            dr.Cells[0].Text = Convert.ToDateTime(dr.Cells[0].Text).ToShortDateString();
        }
    }
    protected void btnSearchByName_Click(object sender, EventArgs e)
    {
        Option = 3;
        LoadData(Option);
    }
    protected void btnSearchByDate_Click(object sender, EventArgs e)
    {
        Option = 2;
        LoadData(Option);
    }
}