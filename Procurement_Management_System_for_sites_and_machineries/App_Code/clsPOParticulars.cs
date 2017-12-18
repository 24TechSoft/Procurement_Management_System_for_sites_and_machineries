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
public class clsPOParticulars
{
    public clsPOParticulars()
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
    private string _PartNo = "";

    public string PartNo
    {
        get { return _PartNo; }
        set { _PartNo = value; }
    }
    private string _LogNo = "";

    public string LogNo
    {
        get { return _LogNo; }
        set { _LogNo = value; }
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
    private double _Amount = 0;

    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
    private string _Remark = "";

    public string Remark
    {
        get { return _Remark; }
        set { _Remark = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Read Data By Purchase Order*/

    //ID, POID, PartNo, Item, CurrentStock,Qty, UGM, Rate, Amount
    public DataSet POParticularsMaster(clsPOParticulars obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[15];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@POID", obj._POID);
            param[2] = new SqlParameter("@LogNo", obj._LogNo);
            param[3] = new SqlParameter("@PartNo", obj._PartNo);
            param[4] = new SqlParameter("@Item", obj._Item);
            param[5] = new SqlParameter("@CurrentStock", obj._CurrentStock);
            param[6] = new SqlParameter("@Qty", obj._Qty);
            param[7] = new SqlParameter("@UGM", obj._UGM);
            param[8] = new SqlParameter("@Rate", obj._Rate);
            param[9] = new SqlParameter("@CGST", obj._CGST);
            param[10] = new SqlParameter("@SGST", obj._SGST);
            param[11] = new SqlParameter("@IGST", obj._IGST);
            param[12] = new SqlParameter("@Amount", obj._Amount);
            param[13] = new SqlParameter("@Remark", obj._Remark);
            param[14] = new SqlParameter("@Op", obj._Op);
            DataSet ds=SqlHelper.ExecuteDataset(co,"procPOParticulars",param);
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