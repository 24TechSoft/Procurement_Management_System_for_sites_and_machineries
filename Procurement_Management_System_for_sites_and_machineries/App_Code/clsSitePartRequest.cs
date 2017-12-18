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
public class clsSitePartRequest
{
    public clsSitePartRequest()
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
    // procSitePartRequest
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
    private int _UserID = 0;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private string _EntryDate = DateTime.Today.ToShortDateString();

    public string EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }

    private string _PartNo = "";

    public string PartNo
    {
        get { return _PartNo; }
        set { _PartNo = value; }
    }
    private string _Description = "";

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    private string _Photo = "";

    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _FromSite = 0;

    public int FromSite
    {
        get { return _FromSite; }
        set { _FromSite = value; }
    }
    private int _ItemType = 0;

    public int ItemType
    {
        get { return _ItemType; }
        set { _ItemType = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Update Status
     * Op=3 Get All Requests
     * Op=4 Get All Data By Site
     * Op=5 Get All Data By UserID
     */
    //ID, SiteID, UserID, PartNo, Description, Photo, Status
    public DataSet SitePartRequest(clsSitePartRequest obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@UserID", obj._UserID);
            param[3] = new SqlParameter("@EntryDate", obj._EntryDate);
            param[4] = new SqlParameter("@PartNo", obj._PartNo);
            param[5] = new SqlParameter("@Description", obj._Description);
            param[6] = new SqlParameter("@Photo", obj._Photo);
            param[7] = new SqlParameter("@Status", obj._Status);
            param[8] = new SqlParameter("@FromSite", obj._FromSite);
            param[9] = new SqlParameter("@ItemType", obj._ItemType);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procSitePartRequest", param);
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