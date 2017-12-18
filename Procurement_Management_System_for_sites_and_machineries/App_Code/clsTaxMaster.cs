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
public class clsTaxMaster
{
	public clsTaxMaster()
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
    private double _CGST = 0;

    public double CGST
    {
        get { return _CGST; }
        set { _CGST = value; }
    }
    private double _SGST = 0;

    public double SGST
    {
        get { return _SGST; }
        set { _SGST = value; }
    }
    private double _IGST = 0;
    public double IGST
    {
        get { return _IGST; }
        set { _IGST = value; }
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
     * Op=3 Read All Data*/
    //ID, TaxName, TaxPercent
    public DataSet TaxMaster(clsTaxMaster obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@CGST", obj._CGST);
            param[2] = new SqlParameter("@SGST", obj._SGST);
            param[3] = new SqlParameter("@IGST", obj._IGST);
            param[4] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procTaxMaster", param);
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