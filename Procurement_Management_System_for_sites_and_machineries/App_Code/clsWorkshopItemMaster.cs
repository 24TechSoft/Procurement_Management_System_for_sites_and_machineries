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
public class clsWorkshopItemMaster
{
    public clsWorkshopItemMaster()
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
    private string _ItemName = "";

    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    private string _Description = "";

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Update Data
     * Op=3 Delete Data
     * Op=4 Get All Data
     * Op=5 Search Data
     */
    //@ID, @SiteID, @ItemName, @Description, @Op
    public DataSet WorkshopItemMaster(clsWorkshopItemMaster obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@ItemName", obj._ItemName);
            param[3] = new SqlParameter("@Description", obj._Description);
            param[4] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procWorkshopItemMaster", param);
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