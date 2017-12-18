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
public class clsPOTerms
{
	public clsPOTerms()
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
    private int _POID = 0;

    public int POID
    {
        get { return _POID; }
        set { _POID = value; }
    }
    private string _Heading = "";

    public string Heading
    {
        get { return _Heading; }
        set { _Heading = value; }
    }
    private string _Detail = "";

    public string Detail
    {
        get { return _Detail; }
        set { _Detail = value; }
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
     * Op=3 Read Data by Purchase Order*/
    //ID, POID, Heading, Detail
    public DataSet POTermsMaster(clsPOTerms obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@POID", obj._POID);
            param[2] = new SqlParameter("@Heading", obj._Heading);
            param[3] = new SqlParameter("@Detail", obj._Detail);
            param[4] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procPOTerms", param);
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