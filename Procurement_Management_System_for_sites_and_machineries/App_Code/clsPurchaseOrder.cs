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
public class clsPurchaseOrder
{
    public clsPurchaseOrder()
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
    private string _PORefNo = "";

    public string PORefNo
    {
        get { return _PORefNo; }
        set { _PORefNo = value; }
    }
    private string _PODate = DateTime.Today.ToShortDateString();

    public string PODate
    {
        get { return _PODate; }
        set { _PODate = value; }
    }
    private string _IndentRefNo = "";

    public string IndentRefNo
    {
        get { return _IndentRefNo; }
        set { _IndentRefNo = value; }
    }
    private string _QuotationNo = "";

    public string QuotationNo
    {
        get { return _QuotationNo; }
        set { _QuotationNo = value; }
    }
    private string _QuotationDate = DateTime.Today.ToShortDateString();

    public string QuotationDate
    {
        get { return _QuotationDate; }
        set { _QuotationDate = value; }
    }
    private string _Subject = "";

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
    private int _PreparedBy = 0;

    public int PreparedBy
    {
        get { return _PreparedBy; }
        set { _PreparedBy = value; }
    }
    private int _CheckedBy = 0;

    public int CheckedBy
    {
        get { return _CheckedBy; }
        set { _CheckedBy = value; }
    }
    private string _CompanySign = "";

    public string CompanySign
    {
        get { return _CompanySign; }
        set { _CompanySign = value; }
    }
    private double _TotalAmount = 0;

    public double TotalAmount
    {
        get { return _TotalAmount; }
        set { _TotalAmount = value; }
    }
    private double _SGST = 0;

    public double SGST
    {
        get { return _SGST; }
        set { _SGST= value; }
    }
    private double _IGST = 0;

    public double IGST
    {
        get { return _IGST; }
        set { _IGST = value; }
    }
    private double _CGST = 0;

    public double CGST
    {
        get { return _CGST; }
        set { _CGST = value; }
    }
    private double _DiscountPercentage = 0;

    public double DiscountPercentage
    {
        get { return _DiscountPercentage; }
        set { _DiscountPercentage = value; }
    }
    private double _NetPayable = 0;

    public double NetPayable
    {
        get { return _NetPayable; }
        set { _NetPayable = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _POTo = 0;

    public int POTo
    {
        get { return _POTo; }
        set { _POTo = value; }
    }
    private string _POFile = "";

    public string POFile
    {
        get { return _POFile; }
        set { _POFile = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Read All Data
     * Op=3 Read Data By ID
     * Op=4 Change Status
     * Op=5 Search By Quotation Date
     * Op=6 Search By Purchase Order Date
     * Op=7 Search By Status
     * Op=8 Read Max ID by Prepared by
     */
    //ID, PORefNo, PODate, IndentRefNo, QuotationNo, QuotationDate, Subject, PreparedBy, CheckedBy, CompanySign, TotalAmount, TaxName, 
    //TaxPercentage, DiscountPercentage, NetPayable,Status
    public DataSet PurchaseOrderMaster(clsPurchaseOrder obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[22];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[3] = new SqlParameter("@PORefNo", obj._PORefNo);
            param[4] = new SqlParameter("@PODate", obj._PODate);
            param[5] = new SqlParameter("@IndentRefNo", obj._IndentRefNo);
            param[6] = new SqlParameter("@QuotationNo", obj._QuotationNo);
            param[7] = new SqlParameter("@QuotationDate", obj._QuotationDate);
            param[8] = new SqlParameter("@Subject", obj._Subject);
            param[9] = new SqlParameter("@PreparedBy", obj._PreparedBy);
            param[10] = new SqlParameter("@CheckedBy", obj._CheckedBy);
            param[11] = new SqlParameter("@CompanySign", obj._CompanySign);
            param[12] = new SqlParameter("@TotalAmount", obj._TotalAmount);
            param[13] = new SqlParameter("@CGST", obj._CGST);
            param[14] = new SqlParameter("@SGST", obj._SGST);
            param[15] = new SqlParameter("@IGST", obj._IGST);
            param[16] = new SqlParameter("@DiscountPercentage", obj._DiscountPercentage);
            param[17] = new SqlParameter("@NetPayable", obj._NetPayable);
            param[18] = new SqlParameter("@Status", obj._Status);
            param[19] = new SqlParameter("@POTo", obj._POTo);
            param[20] = new SqlParameter("@POFile", obj._POFile);
            param[21] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procPurchaseOrderMaster", param);
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