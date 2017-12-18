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
public class clsCustomer
{
    public clsCustomer()
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
    private string _Phone = "";

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private string _Email = "";

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private string _Logo = "";

    public string Logo
    {
        get { return _Logo; }
        set { _Logo = value; }
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
     * Op=3 Read all data
     * Op=4 Read data by Customer ID
     * Op=5 Update Data*/

    //ID, Name, Address, Phone, Email, Logo
    public DataSet CustomerMaster(clsCustomer obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[7];
            param[0]=new SqlParameter("@ID",obj._ID);
            param[1] = new SqlParameter("@Name", obj._Name);
            param[2] = new SqlParameter("@Address", obj._Address);
            param[3] = new SqlParameter("@Phone", obj._Phone);
            param[4] = new SqlParameter("@Email", obj._Email);
            param[5] = new SqlParameter("@Logo", obj._Logo);
            param[6] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procCustomerMaster", param);
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