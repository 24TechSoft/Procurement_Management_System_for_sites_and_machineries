using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_DailyProgressReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSites();
            LoadMachines();
        }
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
    }
    void LoadMachines()
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
    void LoadDataMachinewise()
    {
        clsDailyProgressReport obj = new clsDailyProgressReport();
        obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
        obj.SiteMachineID = Convert.ToInt32(ddlMachine.SelectedValue);
        obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString();
        obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString();
        obj.Op = 7;
        DataTable dt = obj.DailyProgressReport(obj).Tables[0];
        double Total = 0;
        double TotalFuel = 0;
        LiteralControl lc = new LiteralControl();
        lc.Text = lc.Text + "<table width='100%' border='1'>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='12' align='center'><h3>T.K. Engineering Consortium Pvt. Ltd.</h3></td></tr>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='12' align='center'><h4>Site: " + dt.Rows[0]["Site"].ToString() + "</h4></td></tr>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='3'>From Date: " + txtDateFrom.Text + "</td><td colspan='6'></td><td colspan='3'>To Date: " + txtDateTo.Text + "</td></tr>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='4'>Machine: " + dt.Rows[0]["Machine"] + "</td><td colspan='4'>Log No: " + dt.Rows[0]["LogNo"] + "</td><td colspan='4'>Registration No: " + dt.Rows[0]["RegistrationNo"] + "</td></tr>";
        lc.Text = lc.Text + "<tr style='background:#ccc;'><td>Serial</td><td>Date</td><td colspan='2'>Shift</td><td colspan='2'>Starting Reading</td><td colspan='2'>Closing Reading</td><td colspan='2'>Fuel Issued</td><td colspan='2'>Total Reading</td></tr>";
        int i=0;
        foreach(DataRow dr in dt.Rows)
        {
            i++;
            lc.Text = lc.Text + "<tr><td>" + i.ToString() + "</td><td>" + Convert.ToDateTime(dr["EntryDate"]).ToShortDateString() + "</td>";
            lc.Text = lc.Text + "<td colspan='2'>" + dr["Shift"] + "</td><td colspan='2'>" + dr["StartReading"] + "</td><td colspan='2'>" + dr["CloseReading"] + "</td>";
            lc.Text = lc.Text + "<td colspan='2'>" + dr["FuelIssued"] + "</td><td colspan='2'>" + dr["TotalReading"] + "</td></tr>";
            Total = Total + Convert.ToDouble(dr["TotalReading"]);
            TotalFuel = TotalFuel + Convert.ToDouble(dr["FuelIssued"]);
        }
        lc.Text = lc.Text + "<tr style='background:#ccc'><td colspan='8'>Total</td><td colspan='2'>" + TotalFuel.ToString() + "</td><td colspan='2'>" + Total.ToString() + "</td></tr>";
        lc.Text = lc.Text + "<tr style='background:#ddd'><td colspan='8'>Average</td><td colspan='2'>" + (TotalFuel / dt.Rows.Count).ToString() + "</td><td colspan='2'>" + (Total / dt.Rows.Count).ToString() + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        pnlDetailMachine.Controls.Add(lc);
    }
    void LoadDataSitewise()
    {
        clsDailyProgressReport obj = new clsDailyProgressReport();
        
        double Total = 0;
        double TotalFuel = 0;
        LiteralControl lc = new LiteralControl();
        lc.Text = lc.Text + "<table width='100%' border='1'>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='12' align='center'><h3>T.K. Engineering Consortium Pvt. Ltd.</h3></td></tr>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='12' align='center'><h4>Site: " + ddlSite.SelectedItem.Text + "</h4></td></tr>";
        lc.Text = lc.Text + "<tr style='border:none 0 #fff;'><td colspan='3'>From Date: " + txtDateFrom.Text + "</td><td colspan='6'></td><td colspan='3'>To Date: " + txtDateTo.Text + "</td></tr>";
        lc.Text = lc.Text + "<tr style='background:#ccc;'><td>Serial</td><td colspan='3'>Machine</td><td colspan='2'>Log No</td><td colspan='2'>Registration No</td><td colspan='2'>Fuel Issued</td><td colspan='2'>Total Reading</td></tr>";
        int i = 0;
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("Serial");
        dtDetail.Columns.Add("Machine");
        dtDetail.Columns.Add("LogNo");
        dtDetail.Columns.Add("RegNo");
        dtDetail.Columns.Add("Fuel");
        dtDetail.Columns.Add("Reading");
        foreach (ListItem li in ddlMachine.Items)
        {
            i++;
            obj.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
            obj.SiteMachineID = Convert.ToInt32(li.Value);
            obj.EntryDate1 = Convert.ToDateTime(txtDateFrom.Text).ToShortDateString();
            obj.EntryDate2 = Convert.ToDateTime(txtDateTo.Text).ToShortDateString();
            obj.Op = 7;
            DataTable dt = obj.DailyProgressReport(obj).Tables[0];
            double Reading = 0;
            double Fuel = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Reading = Reading + Convert.ToDouble(dr["TotalReading"]);
                    Fuel = Fuel + Convert.ToDouble(dr["FuelIssued"]);
                }
                dtDetail.Rows.Add(dtDetail.NewRow());
                dtDetail.Rows[dtDetail.Rows.Count - 1][0] = i.ToString();
                dtDetail.Rows[dtDetail.Rows.Count - 1][1] = dt.Rows[0]["Machine"];
                dtDetail.Rows[dtDetail.Rows.Count - 1][2] = dt.Rows[0]["LogNo"];
                dtDetail.Rows[dtDetail.Rows.Count - 1][3] = dt.Rows[0]["RegistrationNo"];
                dtDetail.Rows[dtDetail.Rows.Count - 1][4] = Fuel.ToString();
                dtDetail.Rows[dtDetail.Rows.Count - 1][5] = Reading.ToString();
                Total = Total + Reading;
                TotalFuel = TotalFuel + Fuel;
            }
        }
        foreach (DataRow dr in dtDetail.Rows)
        {
            lc.Text = lc.Text + "<tr><td>" + dr["Serial"] + "</td><td colspan='3'>" + dr["Machine"] + "</td><td colspan='2'>" + dr["LogNo"] + "</td>";
            lc.Text = lc.Text + "<td colspan='2'>" + dr["RegNo"] + "</td><td colspan='2'>" + dr["Fuel"] + "</td><td colspan='2'>" + dr["Reading"] + "</td></tr>";
        }
        
        lc.Text = lc.Text + "<tr style='background:#ccc'><td colspan='8'>Total</td><td colspan='2'>" + TotalFuel.ToString() + "</td><td colspan='2'>" + Total.ToString() + "</td></tr>";
        lc.Text = lc.Text + "</table>";
        pnlDetailSite.Controls.Add(lc);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        LoadDataMachinewise();
        LoadDataSitewise();
    }
    protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMachines();
    }
    protected void rdType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(rdType.SelectedValue) == 1)
        {
            LoadDataSitewise();
            pnlDetailSite.Visible = true;
            pnlDetailMachine.Visible = false;
        }
        else
        {
            LoadDataMachinewise();
            pnlDetailSite.Visible = false;
            pnlDetailMachine.Visible = true;
        }
    }
}