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
public class clsSiteDamageEntry
{
	public clsSiteDamageEntry()
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
    private string _AddedBy = "";

    public string AddedBy
    {
        get { return _AddedBy; }
        set { _AddedBy = value; }
    }
    private string _Particular = "";

    public string Particular
    {
        get { return _Particular; }
        set { _Particular = value; }
    }
    private string _Photo = "";

    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private string _EntryDate = DateTime.Today.ToShortDateString();

    public string EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }
    private int _Quantity = 0;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
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
    //ID, SiteID, AddedBy, Particular, Photo, EntryDate, Quantity, Status
    public DataSet SiteDamageEntry(clsSiteDamageEntry obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[9];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[0] = new SqlParameter("@SiteID", obj._SiteID);
            param[0] = new SqlParameter("@AddedBy", obj._AddedBy);
            param[0] = new SqlParameter("@Particular", obj._Particular);
            param[0] = new SqlParameter("@Photo", obj._Photo);
            param[0] = new SqlParameter("@EntryDate", obj._EntryDate);
            param[0] = new SqlParameter("@Quantity", obj._Quantity);
            param[0] = new SqlParameter("@Status", obj._Status);
            param[0] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteDamageEntry", param);
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