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
public class clsTempPOParticulars
{
    public clsTempPOParticulars()
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
    private int _UserID = 0;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private string _PartNo = "";

    public string PartNo
    {
        get { return _PartNo; }
        set { _PartNo = value; }
    }
    private string _Item = "";

    public string Item
    {
        get { return _Item; }
        set { _Item = value; }
    }
    private int _CurrentStock = 0;

    public int CurrentStock
    {
        get { return _CurrentStock; }
        set { _CurrentStock = value; }
    }
    private int _Qty = 0;

    public int Qty
    {
        get { return _Qty; }
        set { _Qty = value; }
    }
    private string _UGM = "";

    public string UGM
    {
        get { return _UGM; }
        set { _UGM = value; }
    }
    private double _Rate = 0;

    public double Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }
    private double _Amount = 0;

    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
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
     * Op=3 Read All Data
     * Op=4 Clear Data
     * Op=5 Update Data
     */
    //ID, UserID, PartNo, Item, CurrentStock, Qty, UGM, Rate, Amount
    public DataSet TempPOParticulars(clsTempPOParticulars obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@UserID", UserID);
            param[2] = new SqlParameter("@PartNo", obj._PartNo);
            param[3] = new SqlParameter("@Item", obj._Item);
            param[4] = new SqlParameter("@CurrentStock", obj._CurrentStock);
            param[5] = new SqlParameter("@Qty", obj._Qty);
            param[6] = new SqlParameter("@UGM", obj._UGM);
            param[7] = new SqlParameter("@Rate", obj._Rate);
            param[8] = new SqlParameter("@Amount", obj._Amount);
            param[9] = new SqlParameter("@Op", Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procTempPOParticulars", param);
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