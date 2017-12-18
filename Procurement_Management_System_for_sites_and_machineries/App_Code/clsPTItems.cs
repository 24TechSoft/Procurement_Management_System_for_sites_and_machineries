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
public class clsPTItems
{
    public clsPTItems()
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
    //procPTItems
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private int _PTID = 0;

    public int PTID
    {
        get { return _PTID; }
        set { _PTID = value; }
    }
    private string _PartNo = "";

    public string PartNo
    {
        get { return _PartNo; }
        set { _PartNo = value; }
    }
    private string _PartName = "";

    public string PartName
    {
        get { return _PartName; }
        set { _PartName = value; }
    }
    private string _MachineName = "";

    public string MachineName
    {
        get { return _MachineName; }
        set { _MachineName = value; }
    }
    private int _Quantity = 0;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    private double _Rate = 0;

    public double Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }
    private double _Total = 0;

    public double Total
    {
        get { return _Total; }
        set { _Total = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*Op=1 Insert Data
     * Op=2 Read Data By PTID
     */
    public DataSet PTITems(clsPTItems obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@PTID", obj._PTID);
            param[2] = new SqlParameter("@PartNo", obj._PartNo);
            param[3] = new SqlParameter("@PartName", obj._PartName);
            param[4] = new SqlParameter("@MachineName", obj._MachineName);
            param[5] = new SqlParameter("@Quantity", obj._Quantity);
            param[6] = new SqlParameter("@Rate", obj._Rate);
            param[7] = new SqlParameter("@Total", obj._Total);
            param[8] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procPTItems", param);
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