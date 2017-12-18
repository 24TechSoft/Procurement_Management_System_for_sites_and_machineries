using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Admin_CurrentStockReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMachines();
        }
    }
    void LoadMachines()
    {

        try
        {
            clsSiteMachines obj = new clsSiteMachines();
            obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
            obj.Op = 3;
            DataTable dt = obj.SiteMachines(obj).Tables[0];
            ddlMachine.DataSource = dt;
            ddlMachine.DataValueField = "ID";
            ddlMachine.DataTextField = "Machine";
            ddlMachine.DataBind();
            ddlMachine.Items.Insert(0, new ListItem("Select"));
        }
        catch
        {
        }
    }
    private int Type = 0;
    void LoadData(int Type)
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        if (Type == 2)
        {
            obj.Op = 11;
            if (ddlMachine.SelectedIndex != 0)
            {
                obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
                DataTable dt = obj.SiteProductParts(obj).Tables[0];
                LoadDataMachineWise(dt);
            }
        }
        else if (Type == 3)
        {
                obj.Op = 12;
                obj.SiteID = Convert.ToInt32(Request.Cookies["SiteID"].Value);
                obj.BillRef = txtPartNo.Text.Trim();
                DataTable dt = obj.SiteProductParts(obj).Tables[0];
                LoadDataPartWise(dt);
            
        }
        else
        {
            pnlDetail.Controls.Clear();
        }

    }
    void LoadDataSiteWitse(DataTable dt)
    {
        StringBuilder str = new StringBuilder();
        str.Append("<h4>Site: "+Request.Cookies["SiteName"].Value+"</h4>");
        str.Append("<table width='100%' border='1'>");
        str.Append("<tr><td><b>Serial No</b></td><td><b>Machine</b></td><td><b>Part</b></td><td><b>Quantity</b></td></tr>");
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i++;
            str.Append("<tr>");
            str.Append("<td>" + i + "</td>");
            str.Append("<td>" + dr["Machine"] + "</td>");
            str.Append("<td>" + dr["Part"] + "</td>");
            str.Append("<td>" + dr["Quantity"] + "</td>");
            str.Append("</tr>");
        }
        //SiteMachineID,Machine,a.PartID,Part,Quantity
        str.Append("</table>");
        Label lbl = new Label();
        lbl.Text = str.ToString();
        pnlDetail.Controls.Add(lbl);
    }
    void LoadDataMachineWise(DataTable dt)
    {
        //a.SiteMachineID,Machine,a.PartID,Part,Quantity
        StringBuilder str = new StringBuilder();
        str.Append("<h4>Site: " + Request.Cookies["SiteName"].Value + "</h4><br>");
        str.Append("<h5>Machine: " + ddlMachine.SelectedItem.Text + "</h5><br>");
        str.Append("<table width='100%' border='1'>");
        str.Append("<tr><td><b>Serial No</b></td><td><b>Part</b></td><td><b>Quantity</b></td></tr>");
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i++;
            str.Append("<tr>");
            str.Append("<td>" + i + "</td>");
            str.Append("<td>" + dr["Part"] + "</td>");
            str.Append("<td>" + dr["Quantity"] + "</td>");
            str.Append("</tr>");
        }
        str.Append("</table>");
        Label lbl = new Label();
        lbl.Text = str.ToString();
        pnlDetail.Controls.Add(lbl);
    }
    void LoadDataPartWise(DataTable dt)
    {
        //a.ID, a.SiteMachineID,a.PartID,b.SerialNo,b.PartName,EntryDate, a.BillRef, a.TransactionType,TransactionText,a.Quantity, a.Rate,
        //a.Total, a.Remarks
        StringBuilder str = new StringBuilder();
        str.Append("<h4>Site: " + Request.Cookies["SiteName"].Value + "</h4><br>");
        /*str.Append("<h5>Machine: " + ddlMachine.SelectedItem.Text + "</h5><br>");*/
        str.Append("<h5>Part No: " + txtPartNo.Text + "</h5>");
        if (dt.Rows.Count > 0)
        {

            str.Append("<h5>Part Name: " + dt.Rows[0]["PartName"].ToString() + "</h5>");
        }
        str.Append("<table width='100%' border='1'>");
        str.Append("<tr><td><b>Serial No</b></td><td><b>Date</b></td><td><b>Quantity</b></td><td><b>TransactionType</b></td><td><b>Rate</b></td><td><b>Total</b></td><td><b>Remarks</b></td></tr>");
        int i = 0;
        double Total = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i++;
            str.Append("<tr>");
            str.Append("<td><b>" + i + "</b></td>");
            str.Append("<td><b>" + dr["EntryDate"] + "</b></td>");
            str.Append("<td><b>" + dr["Quantity"] + "</b></td>");
            Total = Total + Convert.ToDouble(dr["Quantity"]);
            str.Append("<td><b>" + dr["TransactionText"] + "</b></td>");
            str.Append("<td><b>" + dr["Rate"] + "</b></td>");
            str.Append("<td><b>" + dr["Total"] + "</b></td>");
            str.Append("<td><b>" + dr["Remarks"] + "</b></td></tr>");
        }
        str.Append("</table>");
        Label lbl = new Label();
        lbl.Text = str.ToString();
        pnlDetail.Controls.Add(lbl);
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type = 1;
        LoadData(Type);
        LoadMachines();
    }
    protected void ddlMachine_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type = 2;
        LoadData(Type);
    }
    protected void txtPartNo_TextChanged(object sender, EventArgs e)
    {
        Type = 3;
        LoadData(Type);
    }
}