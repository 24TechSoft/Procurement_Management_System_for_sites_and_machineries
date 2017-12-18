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
public class clsMachineTransfer
{
	public clsMachineTransfer()
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
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _SourceSiteID = 0;

    public int SourceSiteID
    {
        get { return _SourceSiteID; }
        set { _SourceSiteID = value; }
    }
    private int _DestinationSiteID = 0;

    public int DestinationSiteID
    {
        get { return _DestinationSiteID; }
        set { _DestinationSiteID = value; }
    }
    private int _SiteMachineID = 0;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
    }
    private string _StartDate = DateTime.Today.ToShortDateString();

    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
    private string _UpdateDate = DateTime.Today.ToShortDateString();

    public string UpdateDate
    {
        get { return _UpdateDate; }
        set { _UpdateDate = value; }
    }
    private int _UpdatedBy = 0;

    public int UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private string _DriverName = "";

    public string DriverName
    {
        get { return _DriverName; }
        set { _DriverName = value; }
    }
    private string _DriverPhone = "";

    public string DriverPhone
    {
        get { return _DriverPhone; }
        set { _DriverPhone = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
/*
 * Op=1 Insert Data
 * Op=2 Update Status
 * Op=3 Get Data By Site
 * Op=4 Get All Data
 * Op=5 Get All Data by Date
 */
//ID, SourceSiteID, DestinationSiteID, SiteMachineID, StartDate, UpdateDate, UpdatedBy, Status, Remarks

    public DataSet MachineTransfer(clsMachineTransfer obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SourceSiteID", obj._SourceSiteID);
            param[2] = new SqlParameter("@DestinationSiteID", obj._DestinationSiteID);
            param[3] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[4] = new SqlParameter("@StartDate", obj._StartDate);
            param[5] = new SqlParameter("@UpdateDate", obj._UpdateDate);
            param[6] = new SqlParameter("@UpdatedBy", obj._UpdatedBy);
            param[7] = new SqlParameter("@Status", obj._Status);
            param[8] = new SqlParameter("@DriverName", obj._DriverName);
            param[9] = new SqlParameter("@DriverPhone", obj._DriverPhone);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procMachineTransfer", param);
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