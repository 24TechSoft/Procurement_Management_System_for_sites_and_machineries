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
public class clsSiteFuelIssue
{
    public clsSiteFuelIssue()
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
    //procSiteFuelIssue
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
    private string _IssueDate1 = DateTime.Today.ToShortDateString();

    public string IssueDate1
    {
        get { return _IssueDate1; }
        set { _IssueDate1 = value; }
    }
    private string _IssueDate2 = DateTime.Today.ToShortDateString();

    public string IssueDate2
    {
        get { return _IssueDate2; }
        set { _IssueDate2 = value; }
    }
    private double _InAmount = 0;

    public double InAmount
    {
        get { return _InAmount; }
        set { _InAmount = value; }
    }
    private double _OutAmount = 0;

    public double OutAmount
    {
        get { return _OutAmount; }
        set { _OutAmount = value; }
    }
    private double _Balance = 0;

    public double Balance
    {
        get { return _Balance; }
        set { _Balance = value; }
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
 * Op=2 Delete data
 * Op=3 Get All data By Date
 * Op=4 Get data by Site & Date
 */
    public DataSet SiteFuelIssue(clsSiteFuelIssue obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@IssueDate1", obj._IssueDate1);
            param[3] = new SqlParameter("@IssueDate2", obj._IssueDate2);
            param[4] = new SqlParameter("@InAmount", obj._InAmount);
            param[5] = new SqlParameter("@OutAmount", obj._OutAmount);
            param[6] = new SqlParameter("@Balance", obj._Balance);
            param[7] = new SqlParameter("@Rate", obj._Rate);
            param[8] = new SqlParameter("@Total", obj._Total);
            param[9] = new SqlParameter("@Remarks", obj._Remarks);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteFuelIssue", param);
            return ds; ;
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