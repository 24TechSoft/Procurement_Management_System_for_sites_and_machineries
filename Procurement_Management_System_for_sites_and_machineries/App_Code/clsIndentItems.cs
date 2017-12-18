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
public class clsIndentItems
{
	public clsIndentItems()
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
    private int _IndentID = 0;

    public int IndentID
    {
        get { return _IndentID; }
        set { _IndentID = value; }
    }
    private string _LogNo = "";

    public string LogNo
    {
        get { return _LogNo; }
        set { _LogNo = value; }
    }
    private string _PartNo = "";

    public string PartNo
    {
        get { return _PartNo; }
        set { _PartNo = value; }
    }

    private string _Particular = "";

    public string Particular
    {
        get { return _Particular; }
        set { _Particular = value; }
    }
    private int _CurrentStock = 0;

    public int CurrentStock
    {
        get { return _CurrentStock; }
        set { _CurrentStock = value; }
    }
    private int _Quantity = 0;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    private string _UOM = "";

    public string UOM
    {
        get { return _UOM; }
        set { _UOM = value; }
    }
    private string _Remarks = "";

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    private string _Photo = "";

    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Read Data by Indent ID*/

    //ID, IndentID, Particular, CurrentStock, Quantity, Remarks
    public DataSet IndentItemMaster(clsIndentItems obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@IndentID", obj._IndentID);
            param[2] = new SqlParameter("@LogNo", obj._LogNo);
            param[3] = new SqlParameter("@PartNo", obj._PartNo);
            param[4] = new SqlParameter("@Particular", obj._Particular);
            param[5] = new SqlParameter("@CurrentStock", obj._CurrentStock);
            param[6] = new SqlParameter("@Quantity", obj._Quantity);
            param[7] = new SqlParameter("@UOM", obj._UOM);
            param[8] = new SqlParameter("@Remarks", obj._Remarks);
            param[9] = new SqlParameter("@Photo", obj._Photo);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procIndentItems", param);
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