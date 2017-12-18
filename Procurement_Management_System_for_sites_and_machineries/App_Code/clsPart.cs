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
public class clsPart
{
    public clsPart()
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
    private string _PartName = "";

    public string PartName
    {
        get { return _PartName; }
        set { _PartName = value; }
    }
    private string _PartDescription = "";

    public string PartDescription
    {
        get { return _PartDescription; }
        set { _PartDescription = value; }
    }
    private string _Photo = "";

    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private double _Price = 0;

    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
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
     * Op=4 Rad All Parts
     * Op=5 Read Data By Machine
     * Op=6 Read Data By ID
     * Op=7 Search Data By Part Name or Description*/
    //ID, MachineID, SerialNo, PartName, PartDescription, Photo
    public DataSet PartMaster(clsPart obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@MachineID", obj._MachineID);
            param[2] = new SqlParameter("@SerialNo", obj._SerialNo);
            param[3] = new SqlParameter("@PartName", obj._PartName);
            param[4] = new SqlParameter("@PartDescription", obj._PartDescription);
            param[5] = new SqlParameter("@Photo", obj._Photo);
            param[6] = new SqlParameter("@Price", obj._Price);
            param[7] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procPartMaster", param);
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