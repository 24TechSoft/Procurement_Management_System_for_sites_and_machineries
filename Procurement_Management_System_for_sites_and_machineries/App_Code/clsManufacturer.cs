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
public class clsManufacturer
{
	public clsManufacturer()
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
    private string _Name = "";

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Address = "";

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    private string _PhoneNo = "";

    public string PhoneNo
    {
        get { return _PhoneNo; }
        set { _PhoneNo = value; }
    }
    private string _Email = "";

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private string _AddedOn = DateTime.Today.ToShortDateString();

    public string AddedOn
    {
        get { return _AddedOn; }
        set { _AddedOn = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Delete Data
     * Op=3 Update Data
     * Op=4 Read All Data*/

    //ID, Name, Address, PhoneNo, Email, AddedOn
    public DataSet ManufacturerMaster(clsManufacturer obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@Name", obj._Name);
            param[2] = new SqlParameter("@Address", obj._Address);
            param[3] = new SqlParameter("@PhoneNo", obj._PhoneNo);
            param[4] = new SqlParameter("@Email", obj._Email);
            param[5] = new SqlParameter("@AddedOn", obj._AddedOn);
            param[6] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procManufacturer", param);
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