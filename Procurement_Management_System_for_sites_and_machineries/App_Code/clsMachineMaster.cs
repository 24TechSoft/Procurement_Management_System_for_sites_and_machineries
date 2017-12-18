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
public class clsMachineMaster
{
	public clsMachineMaster()
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
    private string _SerialNo = "";

    public string SerialNo
    {
        get { return _SerialNo; }
        set { _SerialNo = value; }
    }
    private string _ModelNo = "";

    public string ModelNo
    {
        get { return _ModelNo; }
        set { _ModelNo = value; }
    }
    private string _Manufacturer = "";

    public string Manufacturer
    {
        get { return _Manufacturer; }
        set { _Manufacturer = value; }
    }
    private int _MachineType = 0;

    public int MachineType
    {
        get { return _MachineType; }
        set { _MachineType = value; }
    }
    private string _Description = "";

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    private string _Photo = "";

    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Update Data
     * Op=3 Delete Data
     * Op=4 Read All Data
     * Op=5 Read Machine Detail By ID
     * Op=6 Search Machine By Model No*/

    //ID, SerialNo, ModelNo, Manufacturer, MachineType,Description,ThesisNumber,EngineNumber,Photo
    public DataSet MachineMaster(clsMachineMaster obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SerialNo", obj._SerialNo);
            param[2] = new SqlParameter("@ModelNo", obj._ModelNo);
            param[3] = new SqlParameter("@Manufacturer", obj._Manufacturer);
            param[4] = new SqlParameter("@MachineType", obj._MachineType);
            param[5] = new SqlParameter("@Description", obj._Description);
            param[6] = new SqlParameter("@Photo", obj._Photo);
            param[7] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procMachineMaster", param);
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