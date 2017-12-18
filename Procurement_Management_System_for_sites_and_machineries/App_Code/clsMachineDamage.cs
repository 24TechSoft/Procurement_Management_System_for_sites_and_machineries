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
public class clsMachineDamage
{
    public clsMachineDamage()
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
    //procMachineDamage
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
    private int _SiteMachineID = 0;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
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
    private string _Remarks = "";

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    private int _IndentID = 0;

    public int IndentID
    {
        get { return _IndentID; }
        set { _IndentID = value; }
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
     * Op=3 Add Indent
     * Op=4 View data by Site
     * Op=5 View Data by Machine
     */
    public DataSet MachineDamage(clsMachineDamage obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[3] = new SqlParameter("@EntryDate1", obj._EntryDate1);
            param[4] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[5] = new SqlParameter("@Remarks", obj._Remarks);
            param[6] = new SqlParameter("@IndentID", obj._IndentID);
            param[7] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procMachineDamage", param);
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