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
public class clsUser
{
    public clsUser()
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
    //----------------Variables & Get Set Methods----------------//
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _UserType = 0;

    public int UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }
    private string _Name = "";

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Email = "";

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private string _PhoneNo = "";

    public string PhoneNo
    {
        get { return _PhoneNo; }
        set { _PhoneNo = value; }
    }
    private int _SiteID = 0;

    public int SiteID
    {
        get { return _SiteID; }
        set { _SiteID = value; }
    }
    private string _Designation = "";

    public string Designation
    {
        get { return _Designation; }
        set { _Designation = value; }
    }
    private string _Signature = "";

    public string Signature
    {
        get { return _Signature; }
        set { _Signature = value; }
    }
    private string _UserID = "";

    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private string _Password = "";

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    //ID, UserType, Name, Email, PhoneNo, SiteID, Designation, Signature,UserID,Password
    /*Values of OP and Functions
     *1-Insert Data
     *2-Update Data
     *3-Delete Data
     *4-Get All Users
     *5-Get User Detail By ID
     *6-Search User By Name
     *7-Get User By Site ID
     *8-Search User By Site Location
     *9-Check Log In
     *10-Change Password
    */
    public DataSet UserMaster(clsUser obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@UserType", obj._UserType);
            param[2] = new SqlParameter("@Name", obj._Name);
            param[3] = new SqlParameter("@Email", obj._Email);
            param[4] = new SqlParameter("@PhoneNo", obj._PhoneNo);
            param[5] = new SqlParameter("@SiteID", obj._SiteID);
            param[6] = new SqlParameter("@Designation", obj._Designation);
            param[7] = new SqlParameter("@Signature", obj._Signature);
            param[8] = new SqlParameter("@UserID", obj._UserID);
            param[9] = new SqlParameter("@Password", obj._Password);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procUserMaster", param);
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