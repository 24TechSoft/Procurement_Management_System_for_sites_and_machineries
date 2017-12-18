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
public class clsIndent
{
    public clsIndent()
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
    private int _OrderFrom = 0;

    public int OrderFrom
    {
        get { return _OrderFrom; }
        set { _OrderFrom = value; }
    }
    private int _OrderFromID = 0;

    public int OrderFromID
    {
        get { return _OrderFromID; }
        set { _OrderFromID = value; }
    }
    private int _UserID = 0;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private string _RefNo = "";

    public string RefNo
    {
        get { return _RefNo; }
        set { _RefNo = value; }
    }
    private string _ProjectNo = "";

    public string ProjectNo
    {
        get { return _ProjectNo; }
        set { _ProjectNo = value; }
    }
    private string _JobNo = "";

    public string JobNo
    {
        get { return _JobNo; }
        set { _JobNo = value; }
    }
    private string _IndentDate = DateTime.Today.ToShortDateString();

    public string IndentDate
    {
        get { return _IndentDate; }
        set { _IndentDate = value; }
    }
    private int _Indentor = 0;

    public int Indentor
    {
        get { return _Indentor; }
        set { _Indentor = value; }
    }
    private int _ApprovedBy = 0;

    public int ApprovedBy
    {
        get { return _ApprovedBy; }
        set { _ApprovedBy = value; }
    }
    private int _Status = 0;

    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    private int _SiteMachineID = 0;

    public int SiteMachineID
    {
        get { return _SiteMachineID; }
        set { _SiteMachineID = value; }
    }
    private int _Op = 0;

    public int Op
    {
        get { return _Op; }
        set { _Op = value; }
    }
    /*
     * Op=1 Insert Data
     * Op=2 Change Status
     * Op=3 Read All Indents
     * Op=4 Read Indent Detail By ID*
     * Op=5 Get Indent By Date
     * Op=6 Get Max Indent Date By User ID
     */

    //ID, OrderFrom, OrderFromID, UserID,RefNo, ProjectNo, JobNo, IndentDate, Indentor, ApprovedBy
    public DataSet IndentMaster(clsIndent obj)
    {
        try
        {
            connect();
            SqlParameter[] param=new SqlParameter[13];
            param[0] = new SqlParameter("@ID", obj._ID);
            param[1] = new SqlParameter("@UserID", obj._UserID);
            param[2] = new SqlParameter("@OrderFrom", obj._OrderFrom);
            param[3] = new SqlParameter("@OrderFromID", obj._OrderFromID);
            param[4] = new SqlParameter("@RefNo", obj._RefNo);
            param[5] = new SqlParameter("@ProjectNo", obj._ProjectNo);
            param[6] = new SqlParameter("@JobNo", obj._JobNo);
            param[7] = new SqlParameter("@IndentDate", obj._IndentDate);
            param[8] = new SqlParameter("@Indentor", obj._Indentor);
            param[9] = new SqlParameter("@ApprovedBy", obj._ApprovedBy);
            param[10] = new SqlParameter("@Status", obj._Status);
            param[11] = new SqlParameter("@SiteMachineID", obj._SiteMachineID);
            param[12] = new SqlParameter("@Op", obj._Op);
            DataSet ds = SqlHelper.ExecuteDataset(co, "procIndentMaster", param);
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