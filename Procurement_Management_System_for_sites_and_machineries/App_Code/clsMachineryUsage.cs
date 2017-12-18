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
public class clsMachineryUsage
{
    public clsMachineryUsage()
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
    //create procedure procMachineryUsage
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
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
    private double _OpenKMReading = 0;

    public double OpenKMReading
    {
        get { return _OpenKMReading; }
        set { _OpenKMReading = value; }
    }
    private double _CloseKMReading = 0;

    public double CloseKMReading
    {
        get { return _CloseKMReading; }
        set { _CloseKMReading = value; }
    }
    private double _TotalKMReading = 0;

    public double TotalKMReading
    {
        get { return _TotalKMReading; }
        set { _TotalKMReading = value; }
    }
    private string _OpenHRReading = "00:00";

    public string OpenHRReading
    {
        get { return _OpenHRReading; }
        set { _OpenHRReading = value; }
    }
    private string _CloseHRReading = "00:00";

    public string CloseHRReading
    {
        get { return _CloseHRReading; }
        set { _CloseHRReading = value; }
    }
    private string _TotalHRReading = "00:00";

    public string TotalHRReading
    {
        get { return _TotalHRReading; }
        set { _TotalHRReading = value; }
    }
    private double _OpenHSDReading = 0;

    public double OpenHSDReading
    {
        get { return _OpenHSDReading; }
        set { _OpenHSDReading = value; }
    }
    private double _CloseHSDReading = 0;

    public double CloseHSDReading
    {
        get { return _CloseHSDReading; }
        set { _CloseHSDReading = value; }
    }
    private double _HSDIssue = 0;

    public double HSDIssue
    {
        get { return _HSDIssue; }
        set { _HSDIssue = value; }
    }
    private double _TotalHSDReading = 0;

    public double TotalHSDReading
    {
        get { return _TotalHSDReading; }
        set { _TotalHSDReading = value; }
    }
    private int _Breakdown = 0;

    public int Breakdown
    {
        get { return _Breakdown; }
        set { _Breakdown = value; }
    }
    private int _Idle = 0;

    public int Idle
    {
        get { return _Idle; }
        set { _Idle = value; }
    }
    private string _DriverName = "";

    public string DriverName
    {
        get { return _DriverName; }
        set { _DriverName = value; }
    }
    private string _Remarks = "";

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _EnteredBy = 0;

    public int EnteredBy
    {
        get { return _EnteredBy; }
        set { _EnteredBy = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Entry
     * Op=2 Read Data By Date and Site
     * Op=3 Read Data By Site and FromDate to ToDate
     * Op=4 Delete Data
     * Op=5 Change Status
     * Op=6 Read Data By Machine and FromDate to ToDate*/
    //ID, EntryDate1,EntryDate2,Shift,SiteID,SiteMachineID,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,
//CloseHRReading,TotalHRReading,OpenHSDReading,CloseHSDReading,HSDIssue,TotalHSDReading,DriverName,Remarks,Status,EnteredBy
    public DataSet MachineryUsage(clsMachineryUsage obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[23];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@EntryDate", obj._EntryDate1);
            param[2] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[3] = new SqlParameter("@Shift", obj._Shift);
            param[4] = new SqlParameter("@SiteID", obj.SiteID);
            param[5] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[6] = new SqlParameter("@OpenKMReading", obj._OpenKMReading);
            param[7] = new SqlParameter("@CloseKMReading", obj._CloseKMReading);
            param[8] = new SqlParameter("@TotalKMReading", obj._TotalKMReading);
            param[9] = new SqlParameter("@OpenHRReading", obj._OpenHRReading);
            param[10] = new SqlParameter("@CloseHRReading", obj._CloseHRReading);
            param[11] = new SqlParameter("@TotalHRReading", obj._TotalHRReading);
            param[12] = new SqlParameter("@OpenHSDReading", obj._OpenHSDReading);
            param[13] = new SqlParameter("@CloseHSDReading", obj._CloseHSDReading);
            param[14] = new SqlParameter("@HSDIssue", obj._HSDIssue);
            param[15] = new SqlParameter("@TotalHSDReading", obj._TotalHSDReading);
            param[16] = new SqlParameter("@Breakdown", obj._Breakdown);
            param[17] = new SqlParameter("@Idle", obj._Idle);
            param[18] = new SqlParameter("@DriverName", obj._DriverName);
            param[19] = new SqlParameter("@Remarks", obj._Remarks);
            param[20] = new SqlParameter("@Status", obj._Status);
            param[21] = new SqlParameter("@EnteredBy", obj._EnteredBy);
            param[22] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procMachineryUsage", param);
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