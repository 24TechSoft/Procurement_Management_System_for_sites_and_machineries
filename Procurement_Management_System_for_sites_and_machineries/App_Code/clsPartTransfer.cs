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
public class clsPartTransfer
{
    public clsPartTransfer()
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
    //procPartTransfer
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private string _Reference = "";

    public string Reference
    {
        get { return _Reference; }
        set { _Reference = value; }
    }
    private int _SourceSite = 0;

    public int SourceSite
    {
        get { return _SourceSite; }
        set { _SourceSite = value; }
    }
    private int _DestinationSite = 0;

    public int DestinationSite
    {
        get { return _DestinationSite; }
        set { _DestinationSite = value; }
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
    private string _VehicleNo = "";

    public string VehicleNo
    {
        get { return _VehicleNo; }
        set { _VehicleNo = value; }
    }
    private string _DriverName = "";

    public string DriverName
    {
        get { return _DriverName; }
        set { _DriverName = value; }
    }
    private string _DriverPh = "";

    public string DriverPh
    {
        get { return _DriverPh; }
        set { _DriverPh = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /* Op=1 Insert data
     * Op =2 Update status
     * Op=3 Get all Data By Date
     * Op=4 Get All Data By Site And Date
     * Op=5 Get Detail by Reference
     * Op=6 get Max ID 
     */
    public DataSet PartTransfer(clsPartTransfer obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@Reference", obj._Reference);
            param[2] = new SqlParameter("@SourceSite", obj._SourceSite);
            param[3] = new SqlParameter("@DestinationSite", obj._DestinationSite);
            param[4] = new SqlParameter("@EntryDate1", obj._EntryDate1);
            param[5] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[6] = new SqlParameter("@VehicleNo", obj._VehicleNo);
            param[7] = new SqlParameter("@DriverName", obj._DriverName);
            param[8] = new SqlParameter("@DriverPh", obj._DriverPh);
            param[9] = new SqlParameter("@Status", obj._Status);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procPartTransfer", param);
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