using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Diagnostics;
public class WebService : System.Web.Services.WebService
{
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public void Login(string UserID,string Password, int UserType)
    {
        clsUser obj = new clsUser();
        obj.UserID = UserID;
        obj.Password = Password;
        obj.UserType = UserType;
        obj.Op = 9;
        DataTable dt = obj.UserMaster(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetPartDetailByPartNo(string PartNo)
    {
        clsPart obj = new clsPart();
        obj.PartName = PartNo;
        obj.Op = 8;
        DataTable dt = obj.PartMaster(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetNewIndents()
    {
        clsAlerts obj = new clsAlerts();
        obj.Op = 2;
        DataTable dt = obj.Alerts(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void Test(string CallBack)
    {
        if (CallBack == "")
        {
            Context.Response.Write(JsonConvert.SerializeObject("Hello"));
        }
        else
        {
            Context.Response.Write(CallBack + "(" + JsonConvert.SerializeObject("Hello") + ")");
        }
    }
    [WebMethod]
    public void GetNewPartsAlert()
    {
        clsAlerts obj = new clsAlerts();
        obj.Op = 1;
        DataTable dt = obj.Alerts(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void RenewalAlerts()
    {
        clsAlerts obj = new clsAlerts();
        obj.Op = 4;
        DataTable dt = obj.Alerts(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void PartTrasnferTrack(string RefNo)
    {
        clsPartTransfer obPT = new clsPartTransfer();
        clsPTItems obPTI = new clsPTItems();
        obPT.Reference = RefNo;
        obPT.Op = 5;
        DataTable dtPT = obPT.PartTransfer(obPT).Tables[0];
        if (dtPT.Rows.Count > 0)
        {
            obPTI.PTID = Convert.ToInt32(dtPT.Rows[0]["ID"]);
        }
        else
        {
            obPTI.PTID = 0;
        }
        obPTI.Op = 2;
        DataTable dtPTI = obPTI.PTITems(obPTI).Tables[0];
        DataTable[] arr = new DataTable[2];
        arr[0] = dtPT;
        arr[1] = dtPTI;
        Context.Response.Write(JsonConvert.SerializeObject(arr));
    }
    [WebMethod]
    public void GetSites(int SiteID)
    {
        clsSite obj = new clsSite();
        if (SiteID == 0)
        {
            obj.Op = 4;
        }
        else
        {
            obj.ID = SiteID;
            obj.Op = 5;
        }
        DataTable dt = obj.SiteMaster(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetLastFuelBalance(int SiteID)
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.SiteID = SiteID;
        obj.Op = 6;
        DataTable dt = obj.SiteFuelIssue(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveFuelIssue(int SiteID, string IssueDate, double InAmount, double OutAmount, double Balance, double Rate, double Total, string Remarks)
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.SiteID = SiteID;
        obj.IssueDate1 = IssueDate;
        obj.InAmount = InAmount;
        obj.OutAmount = OutAmount;
        obj.Balance = Balance;
        obj.Rate = Rate;
        obj.Total = Total;
        obj.Remarks = Remarks;
        obj.Op = 1;
        obj.SiteFuelIssue(obj);
        string Message = "Saved";
        Context.Response.Write(JsonConvert.SerializeObject(Message));
    }
    [WebMethod]
    public void GetFuelIssueReport(int SiteID, string IssueDate1, string IssueDate2)
    {
        clsSiteFuelIssue obj = new clsSiteFuelIssue();
        obj.SiteID = SiteID;
        obj.IssueDate1 = IssueDate1;
        obj.IssueDate2 = IssueDate2;
        obj.Op = 4;
        DataTable dt = obj.SiteFuelIssue(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void DPREntry(string EntryDate, int Shift, int SiteID, int SiteMachineID, double OpenKMReading, double CloseKMReading, double TotalKMReading, string OpenHRReading, string CloseHRReading, string TotalHRReading, double OpenHSDReading, double CloseHSDReading, double HSDIssue, double TotalHSDReading, int Breakdown, int Idle, string DriverName, string Remarks, int Status, int EnteredBy)
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.EntryDate1 = EntryDate;
        obj.Shift = Shift;
        obj.SiteID = SiteID;
        obj.SiteMachineID = SiteMachineID;
        obj.OpenKMReading = OpenKMReading;
        obj.CloseKMReading = CloseKMReading;
        obj.TotalKMReading = TotalKMReading;
        obj.OpenHRReading = OpenHRReading;
        obj.CloseHRReading = CloseHRReading;
        obj.TotalHRReading = TotalHRReading;
        obj.OpenHSDReading = OpenHSDReading;
        obj.CloseHSDReading = CloseHSDReading;
        obj.HSDIssue = HSDIssue;
        obj.TotalHSDReading = TotalHSDReading;
        obj.Breakdown = Breakdown;
        obj.Idle = Idle;
        obj.DriverName = DriverName;
        obj.Remarks = Remarks;
        obj.Status = Status;
        obj.EnteredBy = Status;
        obj.Op = 1;
        obj.MachineryUsage(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetDPRByDateMachineShift(int SiteMachineID, string EntryDate, int Shift, int SiteID)
    {
        clsMachineryUsage obj = new clsMachineryUsage();
        obj.EntryDate1 = EntryDate;
        obj.Shift = Shift;
        obj.SiteID = SiteID;
        obj.SiteMachineID = SiteMachineID;
        obj.Op = 15;
        DataTable dt = obj.MachineryUsage(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetDPRBySiteAndDate(int SiteID,int SiteMachineID,string EntryDate1,string EntryDate2)
    {
        clsDailyProgressReport obj = new clsDailyProgressReport();
        obj.EntryDate1 = EntryDate1;
        obj.EntryDate2 = EntryDate2;
        obj.SiteID = SiteID;
        obj.SiteMachineID = SiteMachineID;
        if (SiteMachineID == 0)
        {
            obj.Op = 4;
        }
        else
        {
            obj.Op = 7;
        }
        DataTable dt = obj.DailyProgressReport(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveProductStock(int SiteID,int SiteMachineID,int PartID,string EntryDate,string BillRef,int TransactionType,int Quantity,double Rate,double Total,string Remarks)
    {
        clsSiteProductParts obj=new clsSiteProductParts();
        obj.SiteID=SiteID; 
        obj.SiteMachineID=SiteMachineID; 
        obj.PartID=PartID;
        obj.EntryDate1=EntryDate;
        obj.BillRef=BillRef;
        obj.TransactionType=TransactionType; 
        obj.Quantity=Quantity;
        obj.Rate=Rate;
        obj.Total=Total;
        obj.Remarks = Remarks;
        obj.Op = 1;
        obj.SiteProductParts(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetCurrentStockByProductAndSite(int SiteID,string PartNo)
    {
        clsSiteProductParts obj = new clsSiteProductParts();
        obj.BillRef = PartNo;
        obj.SiteID = SiteID;
        obj.Op = 7;
        DataTable dt = obj.SiteProductParts(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetMachinesBySite(int SiteID)
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.Op = 3;
        obj.SiteID=SiteID;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveMachineTransfer(int SourceSiteID, int DestinationSiteID, int SiteMachineID, string StartDate, string UpdateDate, int Status, string DriverName, string DriverPhone)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.SourceSiteID = SourceSiteID;
        obj.DestinationSiteID = DestinationSiteID;
        obj.SiteMachineID = SiteMachineID;
        obj.StartDate = StartDate;
        obj.UpdateDate = UpdateDate;
        obj.Status = Status;
        obj.DriverName = DriverName;
        obj.DriverPhone = DriverPhone;
        obj.Op = 1;
        obj.MachineTransfer(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetMachineTransferByDate(string Date1,string Date2)
    {
        clsMachineTransfer obj = new clsMachineTransfer();
        obj.Op = 5;
        obj.StartDate = Date1;
        obj.UpdateDate = Date2;
        DataTable dt = obj.MachineTransfer(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveMachineDamage(int SiteID, int SiteMachineID, string EntryDate, string Remarks, int IndentID)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.SiteID=SiteID; 
        obj.SiteMachineID=SiteMachineID; 
        obj.EntryDate1=EntryDate;
        obj.Remarks=Remarks;
        obj.IndentID = IndentID;
        obj.MachineDamage(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetMachineDamageBySiteAndDate(string EntryDate1,string EntryDate2,int SiteID)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.EntryDate1 = EntryDate1;
        obj.EntryDate2 = EntryDate2;
        obj.SiteID = SiteID;
        obj.Op = 7;
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SavePartTransfer(string Reference, int SourceSite, int DestinationSite, string EntryDate, string VehicleNo, string DriverName, string DriverPh, int Status)
    {
        clsPartTransfer obj = new clsPartTransfer();
        obj.Reference=Reference;
        obj.SourceSite=SourceSite;
        obj.DestinationSite=DestinationSite;
        obj.EntryDate1=EntryDate;
        obj.VehicleNo=VehicleNo;
        obj.DriverName=DriverName;
        obj.DriverPh=DriverPh;
        obj.Status = Status;
        obj.Op = 1;
        obj.PartTransfer(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetPartTransferByDateAndSite(string EntryDate1,string EntryDate2,int SiteID)
    {
        clsPartTransfer obj = new clsPartTransfer();
        obj.EntryDate1 = EntryDate1;
        obj.EntryDate2 = EntryDate2;
        obj.SourceSite=SiteID;
        obj.DestinationSite = SiteID;
        obj.Op = 4;
        DataTable dt = obj.PartTransfer(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveIndent(int UserID, int OrderFrom, int OrderFromID, string RefNo, string ProjectNo, string JobNo, string IndentDate, int Indentor, int ApprovedBy, int Status, int SiteMachineID)
    {
        clsIndent obj = new clsIndent();
        obj.UserID = UserID;
        obj.OrderFrom = OrderFrom;
        obj.OrderFromID = OrderFromID;
        obj.RefNo = RefNo;
        obj.ProjectNo = ProjectNo;
        obj.JobNo = JobNo;
        obj.IndentDate = IndentDate;
        obj.Indentor = Indentor;
        obj.ApprovedBy = ApprovedBy;
        obj.Status = Status;
        obj.SiteMachineID = SiteMachineID;
        obj.Op = 1;
        obj.IndentMaster(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void getLastIndentID(int UserID)
    {
        clsIndent obj = new clsIndent();
        obj.Op = 6;
        obj.UserID = UserID;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void SaveIndentItems(int IndentID, string LogNo, string PartNo, string Particular, int CurrentStock, int Quantity, string UOM, string Remarks, string Photo)
    {
        clsIndentItems obj = new clsIndentItems();
        obj.IndentID = IndentID;
        obj.LogNo = LogNo;
        obj.PartNo = PartNo;
        obj.Particular = Particular;
        obj.CurrentStock = CurrentStock;
        obj.Quantity = Quantity;
        obj.UOM = UOM;
        obj.Remarks = Remarks;
        obj.Photo = Photo;
        obj.Op = 1;
        obj.IndentItemMaster(obj);
        Context.Response.Write(JsonConvert.SerializeObject("Saved"));
    }
    [WebMethod]
    public void GetIndentBySiteID(int SiteID)
    {
        clsIndent obj = new clsIndent();
        obj.OrderFromID = SiteID;
        obj.Op = 11;
        DataTable dt = obj.IndentMaster(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetIndentDetail(int IndentID)
    {
        clsIndent obj = new clsIndent();
        obj.ID = IndentID;
        obj.Op = 4;
        DataTable dtIndent = obj.IndentMaster(obj).Tables[0];
        clsIndentItems obj1 = new clsIndentItems();
        obj1.IndentID = IndentID;
        obj1.Op = 2;
        DataTable dtIndentItem = obj1.IndentItemMaster(obj1).Tables[0];
        DataTable[] dt = new DataTable[2];
        dt[0] = dtIndent;
        dt[1] = dtIndentItem;
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetMachineDamage(string EntryDate1,string EntryDate2,int SiteID,int MachineID)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.SiteID = SiteID;
        obj.SiteMachineID = MachineID;
        obj.EntryDate1 = EntryDate1;
        obj.EntryDate2 = EntryDate2;
        if(MachineID==0)
        {
            obj.Op = 7;
        }
        else
        {
            obj.Op = 6;
        }
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetMachineHistory(int SiteMachineID,string DateFrom,string DateTo,int SiteID)
    {
        DataTable[] dt = new DataTable[8];
        clsSiteMachines obSM = new clsSiteMachines();
        obSM.ID = SiteMachineID;
        obSM.Op = 5;
        DataTable dtSM = obSM.SiteMachines(obSM).Tables[0];
        dt[0] = dtSM;
        /*ID,Site,MachineID,Machine,SerialNo,AddedOn,Status,UpdateDate,a.UsageUnit,a.ThesisNo,a.EngineNo,a.RegistrationNo*/
        /*Machine Damage History*/
        clsMachineDamage obMD = new clsMachineDamage();
        obMD.SiteMachineID = SiteMachineID;
        obMD.EntryDate1 = DateFrom;
        obMD.EntryDate2 = DateTo;
        obMD.Op = 6;
        DataTable dtMD = obMD.MachineDamage(obMD).Tables[0];
        dt[1] = dtMD;
        /*ID, SiteID,Site,SiteMachineID,Machine,EntryDate,Remarks,IndentID,Indent*/
        /*Machine Progress History*/
        clsMachineryUsage obMU = new clsMachineryUsage();
        obMU.Op = 8;
        obMU.SiteID = SiteID;
        obMU.SiteMachineID = SiteMachineID;
        obMU.EntryDate1 = DateFrom;
        obMU.EntryDate2 = DateTo;
      
        DataTable dtMU = obMU.MachineryUsage(obMU).Tables[0];
        dt[2] = dtMU;
        obMU.Op = 14;
        DataTable dtFuel = obMU.MachineryUsage(obMU).Tables[0];
        dt[3] = dtFuel;
        obMU.Op = 13;
        DataTable dtBreakdown = obMU.MachineryUsage(obMU).Tables[0];
        dt[4] = dtBreakdown;
        /*ID,,EntryDate,Shift,ShiftText,SiteID,Site,SiteMachineID,Machine,OpenKMReading,CloseKMReading,TotalKMReading,OpenHRReading,CloseHRReading,TotalHRReading,OpenHSDReading,
         * CloseHSDReading,HSDIssue,TotalHSDReading,Breakdown,Idle,DriverName,Remarks,Status,EnteredBy*/
        /*Issue Slips*/
        clsSitePartIssue obSPI = new clsSitePartIssue();
        obSPI.Op = 7;
        obSPI.EntryDate1 = DateFrom;
        obSPI.EntryDate2 = DateTo;

        obSPI.SiteMachineID = SiteMachineID;
        DataTable dtSPI = obSPI.SitePartIssue(obSPI).Tables[0];
        dt[5] = dtSPI;
        /*ID,SiteID,Site,SiteMachineID,Machine,IssueDate,IssueType,Issue,Detail,Quantity,Rate,Total,Remarks*/
        /*Machine Transfer*/
        clsMachineTransfer obMT = new clsMachineTransfer();
        obMT.Op = 8;
        obMT.SiteMachineID = SiteMachineID;
        DataTable dtMT = obMT.MachineTransfer(obMT).Tables[0];
        dt[6] = dtMT;
        DataTable dtMTFinal = new DataTable();
        dtMTFinal.Columns.Add("Site");
        dtMTFinal.Columns.Add("FromDate");
        dtMTFinal.Columns.Add("ToDate");
        if (dtMT.Rows.Count > 0)
        {
            dtMTFinal.Rows.Add();
            dtMTFinal.Rows[0]["Site"] = dtMT.Rows[0]["SourceSite"];
            dtMTFinal.Rows[0]["FromDate"] = Convert.ToDateTime(dtMT.Rows[0]["AddedOn"]).ToShortDateString();
            dtMTFinal.Rows[0]["ToDate"] = Convert.ToDateTime(dtMT.Rows[0]["StartDate"]).ToShortDateString();
            for (int i = 1; i < dtMT.Rows.Count; i++)
            {
                dtMTFinal.Rows.Add();
                dtMTFinal.Rows[i]["Site"] = dtMT.Rows[i]["SourceSite"];
                dtMTFinal.Rows[i]["FromDate"] = Convert.ToDateTime(dtMTFinal.Rows[i - 1]["UpdatedDate"]).ToShortDateString();
                dtMTFinal.Rows[i]["ToDate"] = Convert.ToDateTime(dtMTFinal.Rows[i]["StartDate"]).ToShortDateString();
            }
        }
        dt[7] = dtMTFinal;
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetProjectsBySite(int SiteID)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.SiteID = SiteID;
        obj.Op = 3;
        DataTable dt = obj.Projects(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetJobsByProject(int ProjectID)
    {
        clsProjectJob obj = new clsProjectJob();
        obj.ProjectID = ProjectID;
        obj.Op = 3;
        DataTable dt = obj.Jobs(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetBreakdownBySite(int SiteID)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.SiteID = SiteID;
        obj.Op = 4;
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetBreakdownByMachine(int SiteMachineID)
    {
        clsMachineDamage obj = new clsMachineDamage();
        obj.SiteMachineID = SiteMachineID;
        obj.Op = 5;
        DataTable dt = obj.MachineDamage(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
    [WebMethod]
    public void GetAllSiteMachines()
    {
        clsSiteMachines obj = new clsSiteMachines();
        obj.Op = 7;
        DataTable dt = obj.SiteMachines(obj).Tables[0];
        Context.Response.Write(JsonConvert.SerializeObject(dt));
    }
}