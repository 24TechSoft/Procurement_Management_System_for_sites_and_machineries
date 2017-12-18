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
public class clsSiteProductParts
{
    public clsSiteProductParts()
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
    private int _SiteMachineID = 0;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
    }
    private int _PartID = 0;

    public int PartID
    {
        get { return _PartID; }
        set { _PartID = value; }
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
    private string _BillRef = "";

    public string BillRef
    {
        get { return _BillRef; }
        set { _BillRef = value; }
    }
    private int _TransactionType = 0;

    public int TransactionType
    {
        get { return _TransactionType; }
        set { _TransactionType = value; }
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
    private string _Remarks = "";

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert data
     * Op=2 Update Data
     * Op=3 Delete Data
     * Op=4 Get All Data by Site
     * Op=5 Get Data By Machine ID
     * Op=6 Get Data By Part ID
     * Op=7 Get Detail by Part No
     * Op=8 Get Current Stock by Part ID
     */
    public DataSet SiteProductParts(clsSiteProductParts obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[3] = new SqlParameter("@PartID", obj._PartID);
            param[4] = new SqlParameter("@EntryDate1", obj._EntryDate1);
            param[5] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[6] = new SqlParameter("@BillRef", obj._BillRef);
            param[7] = new SqlParameter("@TransactionType", obj._TransactionType);
            param[8] = new SqlParameter("@Quantity", obj._Quantity);
            param[9] = new SqlParameter("@Rate", obj._Rate);
            param[10] = new SqlParameter("@Total", obj._Total);
            param[11] = new SqlParameter("@Remarks", obj._Remarks);
            param[12] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteProductParts", param);
            return ds;
        }
        catch
        {
            return null;
        }
        finally
        { co.Close(); }
    }

}