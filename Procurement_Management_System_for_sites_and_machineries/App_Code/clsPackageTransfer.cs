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
public class clsPackageTransfer
{
	public clsPackageTransfer()
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

    //procPackageTransfer
private int _ID=0;
private string _EntryDate1=DateTime.Today.ToShortDateString();
private string _EntryDate2=DateTime.Today.ToShortDateString();
private int _FromSite =0;
private int _ToSite =0;
private string _ReferenceNo=""; 
private string _Remarks="";
private int _Status =0;
private int _Op =0;
/*
 * Op=1 Insert Data
 * Op=2 Delete Data
 * Op=3 Change Status
 * Op=4 Read data by Date
 * Op=5 Read Data By Status
 * Op=6 Read Data By Status and Source Site
 * Op=7 Read Data By Status and Destination Site
 * Op=8 Read Data By Date and Source Site
 * Op=9 Read Data By Date and Destination Site
 */
public DataSet PackageTransfer(clsPackageTransfer obj)
{
    try
    {
        connect();
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@ID", obj._ID);
        param[1] = new SqlParameter("@EntryDate1", obj._EntryDate1);
        param[2] = new SqlParameter("@EntryDate2", obj._EntryDate2);
        param[3] = new SqlParameter("@FromSite", obj._FromSite);
        param[4] = new SqlParameter("@ToSite", obj._ToSite);
        param[5] = new SqlParameter("@ReferenceNo", obj._ReferenceNo);
        param[6] = new SqlParameter("@Remarks", obj._Remarks);
        param[7] = new SqlParameter("@Status", obj._Status);
        param[8] = new SqlParameter("@Op", obj._Op);
        DataSet ds = SqlHelper.ExecuteDataset(co, "procPackageTransfer", param);
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