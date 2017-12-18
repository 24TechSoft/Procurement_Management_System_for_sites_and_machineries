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
public class clsAlerts
{
    public clsAlerts()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string conn = ConfigurationManager.ConnectionStrings["TKENGG"].ToString();
    SqlConnection co = new SqlConnection();
    SqlCommand command;
    public void connect()
    {
        co.ConnectionString = conn;
        co.Open();
    }

    private int _SiteID = 0;

    public int SiteID
    {
        get { return _SiteID; }
        set { _SiteID = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 New Parts Alert for Admin
     * Op=2 New indent alerts for Admin
     * Op=3 Purchase Order alers for Site
     * Op=4 Renewal alers for admin
     * Op=5 Parts Alert for Site
     * Op=6 indent alerts for Site
     * Op=7 Renewal alers for Site*/
    public DataSet Alerts(clsAlerts obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@SiteID", obj._SiteID);
            param[1] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procAlerts", param);
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