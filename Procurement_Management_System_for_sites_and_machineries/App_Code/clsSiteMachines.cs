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
public class clsSiteMachines
{
    public clsSiteMachines()
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
    private int _SiteID = 0;

    public int SiteID
    {
        get { return _SiteID; }
        set { _SiteID = value; }
    }
    private int _MachineID = 0;

    public int MachineID
    {
        get { return _MachineID; }
        set { _MachineID = value; }
    }
    private string _SerialNo = "";

    public string SerialNo
    {
        get { return _SerialNo; }
        set { _SerialNo = value; }
    }
    private string _AddedOn = DateTime.Today.ToShortDateString();

    public string AddedOn
    {
        get { return _AddedOn; }
        set { _AddedOn = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private string _UpdateDate = DateTime.Today.ToShortDateString();

    public string UpdateDate
    {
        get { return _UpdateDate; }
        set { _UpdateDate = value; }
    }
    private string _UsageUnit = "";

    public string UsageUnit
    {
        get { return _UsageUnit; }
        set { _UsageUnit = value; }
    }
    private string _ThesisNo = "";

    public string ThesisNo
    {
        get { return _ThesisNo; }
        set { _ThesisNo = value; }
    }
    private string _EngineNo = "";

    public string EngineNo
    {
        get { return _EngineNo; }
        set { _EngineNo = value; }
    }
    private string _RegistrationNo = "";

    public string RegistrationNo
    {
        get { return _RegistrationNo; }
        set { _RegistrationNo = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
/*
 * Op=1 Insert Data
 * Op=2 Update Data Status
 * Op=3 Get All Data By Site
 * Op=4 Update Site
 */
    //ID, SiteID, MachineID, SerialNo, AddedOn, Status, UpdateDate, UsageUnit

    public DataSet SiteMachines(clsSiteMachines obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@MachineID", obj._MachineID);
            param[3] = new SqlParameter("@SerialNo", obj._SerialNo);
            param[4] = new SqlParameter("@AddedOn", obj._AddedOn);
            param[5] = new SqlParameter("@Status", obj._Status);
            param[6] = new SqlParameter("@UpdateDate", obj._UpdateDate);
            param[7] = new SqlParameter("@UsageUnit", obj._UsageUnit);
            param[8] = new SqlParameter("@ThesisNo", obj._ThesisNo);
            param[9] = new SqlParameter("@EngineNo", obj._EngineNo);
            param[10] = new SqlParameter("@RegistrationNo", obj._RegistrationNo);
            param[11] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteMachines", param);
            return ds;
        }
        catch
        {
            return null;
        }
    }
}