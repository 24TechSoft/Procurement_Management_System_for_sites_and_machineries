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
public class clsSiteParts
{
    public clsSiteParts()
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
    private int _PartID = 0;

    public int PartID
    {
        get { return _PartID; }
        set { _PartID = value; }
    }
    private string _PORef = "";

    public string PORef
    {
        get { return _PORef; }
        set { _PORef = value; }
    }
    private string _AddedOn = DateTime.Today.ToShortDateString();

    public string AddedOn
    {
        get { return _AddedOn; }
        set { _AddedOn = value; }
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
     
     */
    //ID, SiteID, PartID, PORef, AddedOn, Quantity
    public DataSet SiteParts(clsSiteParts obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@PartID", obj._PartID);
            param[3] = new SqlParameter("@PORef", obj._PORef);
            param[4] = new SqlParameter("@AddedOn", obj._AddedOn);
            param[5] = new SqlParameter("@Quantity", obj._Quantity);
            param[6] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSiteParts", param);
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