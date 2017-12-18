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
public class clsSitePartIssue
{
    public clsSitePartIssue()
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
    //procSitePartIssue
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
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
    private string _IndentRef = "";

    public string IndentRef
    {
        get { return _IndentRef; }
        set { _IndentRef = value; }
    }
    private double _Price = 0;

    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }
    private int _Quantity = 0;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert data
     * Op=2 Delete Data
     * Op=3 Read Data By SiteMachineID
     * Op=4 Read Data By SiteID
     * Op=5 Read Data By PartNo
     * Op=6 Read Data By Bill Ref
     * Op=7 Read Data By SiteMachineID and Date
     */
    //ID,EntryDate,SiteID,SiteMachineID,PartID,PartNo,LogNo,PartName,BillRef
    public DataSet SitePartIssue(clsSitePartIssue obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@EntryDate1", obj._EntryDate1);
            param[2] = new SqlParameter("@EntryDate2", obj._EntryDate2);
            param[3] = new SqlParameter("@SiteID", obj._SiteID);
            param[4] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[5] = new SqlParameter("@PartID", obj._PartID);
            param[6] = new SqlParameter("@PartNo", obj._PartNo);
            param[7] = new SqlParameter("@PartName", obj._PartName);
            param[8] = new SqlParameter("@IndentRef", obj._IndentRef);
            param[9] = new SqlParameter("@Price", obj._Price);
            param[10] = new SqlParameter("@Quantity", obj._Quantity);
            param[11] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSitePartIssue", param);
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
