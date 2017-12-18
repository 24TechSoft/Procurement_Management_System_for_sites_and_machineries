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
public class clsTempIndentItems
{
    public clsTempIndentItems()
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
    private int _UserID = 0;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
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
     * Op=1 Insert Data
     * Op=2 Delete Data
     * Op=3 Read All Data
     * Op=4 Clear Data
     * Op=5 Update Data
     */
    //ID, UserID, Particular, CurrentStock, Quantity, Remarks, Op
    public DataSet TempIndentItems(clsTempIndentItems obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@UserID", obj._UserID);
            param[2] = new SqlParameter("@PartNo", obj._PartNo);
            param[3] = new SqlParameter("@Particular", obj._Particular);
            param[4] = new SqlParameter("@CurrentStock", obj._CurrentStock);
            param[5] = new SqlParameter("@Quantity", obj._Quantity);
            param[6] = new SqlParameter("@Remarks", obj._Remarks);
            param[7] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procTempIndentItems", param);
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