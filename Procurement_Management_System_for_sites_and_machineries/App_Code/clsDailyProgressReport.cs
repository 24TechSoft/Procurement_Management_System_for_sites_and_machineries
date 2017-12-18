using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
public class clsDailyProgressReport
{
    public clsDailyProgressReport()
    {
    }
    string conn = ConfigurationManager.ConnectionStrings["TKENGG"].ToString();
    SqlConnection co = new SqlConnection();
    SqlCommand command;
    public void connect()
    {
        co.ConnectionString = conn;
        co.Open();
    }
    //procDailyProgressReport
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _SiteID = 0;

    public int SiteID
    {
        get { return _SiteID; }
        set { _SiteID = value; }
    }
    private int _SiteMachineID = 0;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
    }
    private string _EntryDate1 = DateTime.Today.ToShortDateString();

    public string EntryDate1
    {
        get { return _EntryDate1; }
        set { _EntryDate1 = value; }
    }
    private string _EntryDate2 = DateTime.Today.ToShortDateString();

    public string EntryDate2
    {
        get { return _EntryDate2; }
        set { _EntryDate2 = value; }
    }
    private int _Shift = 0;

    public int Shift
    {
        get { return _Shift; }
        set { _Shift = value; }
    }
    private double _StartReading = 0;

    public double StartReading
    {
        get { return _StartReading; }
        set { _StartReading = value; }
    }
    private double _CloseReading = 0;

    public double CloseReading
    {
        get { return _CloseReading; }
        set { _CloseReading = value; }
    }
    private double _FuelIssued = 0;

    public double FuelIssued
    {
        get { return _FuelIssued; }
        set { _FuelIssued = value; }
    }
    private double _TotalReading = 0;

    public double TotalReading
    {
        get { return _TotalReading; }
        set { _TotalReading = value; }
    }
    private int _BreakDown = 0;

    public int BreakDown
    {
        get { return _BreakDown; }
        set { _BreakDown = value; }
    }
    private string _Remarks = "";

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert data
     * Op=2 Replace data
     * Op=3 Delete data
     * Op=4 Read data by date and Site
     * Op=5 Find Duplicate Entry
     * Op=6 Get Data For Grid*/
    //ID, SiteID, SiteMachineID, EntryDate, Shift, StartReading, CloseReading, FuelIssued, TotalReading, BreakDown, Remarks
    public DataSet DailyProgressReport(clsDailyProgressReport obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[3] = new SqlParameter("@EntryDate1", obj._EntryDate1);
            param[4] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[5] = new SqlParameter("@Shift", obj._Shift);
            param[6] = new SqlParameter("@StartReading", obj._StartReading);
            param[7] = new SqlParameter("@CloseReading", obj._CloseReading);
            param[8] = new SqlParameter("@FuelIssued", obj._FuelIssued);
            param[9] = new SqlParameter("@TotalReading", obj._TotalReading);
            param[10] = new SqlParameter("@BreakDown", obj._BreakDown);
            param[11] = new SqlParameter("@Remarks", obj._Remarks);
            param[12] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procDailyProgressReport", param);
            return ds;
        }
        catch
        {
            return null;
        }
        finally
        {
            co.Close();
        }
    }
}