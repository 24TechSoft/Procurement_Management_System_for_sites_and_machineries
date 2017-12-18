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
public class clsWorkOrder
{
    public clsWorkOrder()
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
    //procWorkOrder
    private int _ID = 0;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    private string _IssueDate1 = DateTime.Today.ToShortDateString();

    public string IssueDate1
    {
        get { return _IssueDate1; }
        set { _IssueDate1 = value; }
    }
    private string _IssueDate2 = DateTime.Today.ToShortDateString();

    public string IssueDate2
    {
        get { return _IssueDate2; }
        set { _IssueDate2 = value; }
    }
    private string _CName = "";

    public string CName
    {
        get { return _CName; }
        set { _CName = value; }
    }
    private string _CAddress = "";

    public string CAddress
    {
        get { return _CAddress; }
        set { _CAddress = value; }
    }
    private string _CPhone = "";

    public string CPhone
    {
        get { return _CPhone; }
        set { _CPhone = value; }
    }
    private string _CEmail = "";

    public string CEmail
    {
        get { return _CEmail; }
        set { _CEmail = value; }
    }
    private string _Subject = "";

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
    private string _Detail = "";

    public string Detail
    {
        get { return _Detail; }
        set { _Detail = value; }
    }
    private string _UploadedFile = "";

    public string UploadedFile
    {
        get { return _UploadedFile; }
        set { _UploadedFile = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 insert data
     * Delete Data
     * Get Data By Date
     * Search by CName
     * Get All Data
     * Get All Data by ID
     */
    public DataSet WorkOrder(clsWorkOrder obj)
    {
        try
        {
            connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@IssueDate1", obj._IssueDate1);
            param[2] = new SqlParameter("@IssueDate2", obj._IssueDate2);
            param[3] = new SqlParameter("@CName", obj._CName);
            param[4] = new SqlParameter("@CAddress", obj._CAddress);
            param[5] = new SqlParameter("@CPhone", obj._CPhone);
            param[6] = new SqlParameter("@CEmail", obj._CEmail);
            param[7] = new SqlParameter("@Subject", obj._Subject);
            param[8] = new SqlParameter("@Detail", obj._Detail);
            param[9] = new SqlParameter("@UploadedFile", obj._UploadedFile);
            param[10] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procWorkOrder", param);
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