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
public class clsSiteMachineRecords
{
    public clsSiteMachineRecords()
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
    //create procedure procSiteMachineRecords
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _SiteID;

    public int SiteID
    {
        get { return _SiteID; }
        set { _SiteID = value; }
    }
    private int _SiteMachineID;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
    }
    private string _RecordName = "";

    public string RecordName
    {
        get { return _RecordName; }
        set { _RecordName = value; }
    }
    private string _RecordValue = "";

    public string RecordValue
    {
        get { return _RecordValue; }
        set { _RecordValue = value; }
    }
    private string _ValidFrom = DateTime.Today.ToShortDateString();

    public string ValidFrom
    {
        get { return _ValidFrom; }
        set { _ValidFrom = value; }
    }
    private string _ValidTo = DateTime.Today.ToShortDateString();

    public string ValidTo
    {
        get { return _ValidTo; }
        set { _ValidTo = value; }
    }
    private double _TotalCost = 0;

    public double TotalCost
    {
        get { return _TotalCost; }
        set { _TotalCost = value; }
    }
    private int _RemindBeforeDays = 0;

    public int RemindBeforeDays
    {
        get { return _RemindBeforeDays; }
        set { _RemindBeforeDays = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /* Op=1 Insert Data
     * Op=2 Update Data
     * Op=3 Delete Data
     * Op=4 Get Current Records
     * Op=5 Get Current Records By Site
     * Op=6 Notification for admin
     * Op=7 Notification for Supervisor*/
    public DataSet SiteMachineRecords(clsSiteMachineRecords obj)
    {
        try
        {
            connect();
            //ID, SiteID, SiteMachineID, RecordName, RecordValue, ValidFrom, ValidTo, TotalCost, RemindBeforeDays
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[3] = new SqlParameter("@RecordName", obj._RecordName);
            param[4] = new SqlParameter("@RecordValue", obj._RecordValue);
            param[5] = new SqlParameter("@ValidFrom", obj._ValidFrom);
            param[6] = new SqlParameter("@ValidTo", obj._ValidTo);
            param[7] = new SqlParameter("@TotalCost", obj._TotalCost);
            param[8] = new SqlParameter("@RemindBeforeDays", obj._RemindBeforeDays);
            param[9] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteMachineRecords", param);
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