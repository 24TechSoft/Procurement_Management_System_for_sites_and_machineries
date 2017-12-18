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
public class clsProjectJob
{
	public clsProjectJob()
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
    private string _ProjectName = "";

    public string ProjectName
    {
        get { return _ProjectName; }
        set { _ProjectName = value; }
    }
    private string _ProjectDate = DateTime.Today.ToShortDateString();

    public string ProjectDate
    {
        get { return _ProjectDate; }
        set { _ProjectDate = value; }
    }
//ID, SiteID, ProjectName, ProjectDate
    //ID, ProjectID, JobName
    private int _ProjectID = 0;

    public int ProjectID
    {
        get { return _ProjectID; }
        set { _ProjectID = value; }
    }
    private string _JobName = "";

    public string JobName
    {
        get { return _JobName; }
        set { _JobName = value; }
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
     * Op=3 Get All Data
     */
    //ID, SiteID, ProjectName, ProjectDate
    public DataSet Projects(clsProjectJob obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[5];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@SiteID", obj._SiteID);
            param[2] = new SqlParameter("@ProjectName", obj._ProjectName);
            param[3] = new SqlParameter("@ProjectDate", obj._ProjectDate);
            param[4] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procProjects", param);
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
    /*
 * Op=1 Insert Data
 * Op=2 Delete Data
 * Op=3 Get All Data
 */
    //ID, ProjectID, JobName
    public DataSet Jobs(clsProjectJob obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@ProjectID", obj._ProjectID);
            param[2] = new SqlParameter("@JobName", obj._JobName);
            param[3] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procJobs", param);
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