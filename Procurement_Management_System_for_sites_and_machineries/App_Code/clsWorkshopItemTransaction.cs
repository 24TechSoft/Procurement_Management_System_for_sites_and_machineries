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
public class clsWorkshopItemTransaction
{
    public clsWorkshopItemTransaction()
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
    private int _ItemID = 0;

    public int ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }
    private string _EntryDate = DateTime.Today.ToShortDateString();

    public string EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }
    private int _Quantity = 0;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
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
     * Op=3 Update Data
     * Op=4 Get Transactions by Item
     */
    //ID, ItemID, EntryDate, Quantity, Status
    public DataSet WorkshopItemTransaction(clsWorkshopItemTransaction obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@ItemID", obj._ItemID);
            param[2] = new SqlParameter("@EntryDate", obj._EntryDate);
            param[3] = new SqlParameter("@Quantity", obj._Quantity);
            param[4] = new SqlParameter("@Status", obj._Status);
            param[5] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procWorkshopItemTransaction", param);
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