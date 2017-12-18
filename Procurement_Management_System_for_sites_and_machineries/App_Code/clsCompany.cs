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
public class clsCompany
{
	public clsCompany()
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
    private string _Name = "";

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Address = "";

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    private string _Tin = "";

    public string Tin
    {
        get { return _Tin; }
        set { _Tin = value; }
    }
    private string _Cst = "";

    public string Cst
    {
        get { return _Cst; }
        set { _Cst = value; }
    }
    private string _Logo = "";

    public string Logo
    {
        get { return _Logo; }
        set { _Logo = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    //Name, Address, Tin, Cst
    /*
     * Op=1 for Insert Data
     * Op=2 for Delete Data
     * Op=3 for Reading Data
     */
    public DataSet CompanyMster(clsCompany obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Name", obj._Name);
            param[1] = new SqlParameter("@Address", obj._Address);
            param[2] = new SqlParameter("@Tin", obj._Tin);
            param[3] = new SqlParameter("@Cst", obj._Cst);
            param[4] = new SqlParameter("@Logo", obj._Logo);
            param[5] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procCompanyMaster", param);
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