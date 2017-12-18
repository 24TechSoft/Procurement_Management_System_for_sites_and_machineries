using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class API : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strData = "";
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            if (Request.QueryString["TransactionType"].ToString() != "")
            {
                int TranType = Convert.ToInt32(Request.QueryString["TransactionType"]);
                switch (TranType)
                {
                    //User Master
                    //ID, UserType, Name, Email, PhoneNo, SiteID, Designation, Signature,UserID,Password
                    case 1:
                        clsUser obUser = new clsUser();
                        try { obUser.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obUser.UserType = Convert.ToInt32(Request.QueryString["UserType"]); }
                        catch { }
                        try { obUser.Name = Request.QueryString["Name"].ToString(); }
                        catch { }
                        try { obUser.Email = Request.QueryString["Email"].ToString(); }
                        catch { }
                        try { obUser.PhoneNo = Request.QueryString["PhoneNo"].ToString(); }
                        catch { }
                        try { obUser.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obUser.Designation = Request.QueryString["Designation"].ToString(); }
                        catch { }
                        try { obUser.Signature = Request.QueryString["Signature"].ToString(); }
                        catch { }
                        try { obUser.UserID = Request.QueryString["UserID"].ToString(); }
                        catch { }
                        try { obUser.Password = Request.QueryString["Password"].ToString(); }
                        catch { }
                        obUser.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obUser.UserMaster(obUser);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 10)
                            {
                                dt.Rows[0][0] = "Password Changed";
                            }
                        }
                        Dictionary<string, object> row;
                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //For Alerts
                    //SiteID,Op
                    case 2:
                        clsAlerts obAlerts = new clsAlerts();
                        try { obAlerts.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        obAlerts.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obAlerts.Alerts(obAlerts);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For Company
                    //Name,Address,Tin,Cst,Logo,Op
                    case 3:
                        clsCompany obCompany = new clsCompany();
                        try { obCompany.Name = Request.QueryString["Name"].ToString(); }
                        catch { }
                        try { obCompany.Address = Request.QueryString["Address"].ToString(); }
                        catch { }
                        try { obCompany.Tin = Request.QueryString["Tin"].ToString(); }
                        catch { }
                        try { obCompany.Cst = Request.QueryString["Cst"].ToString(); }
                        catch { }
                        try { obCompany.Logo = Request.QueryString["Logo"].ToString(); }
                        catch { }
                        obCompany.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obCompany.CompanyMster(obCompany);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }





                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //For Customer
                    //ID,Name,Address,PhoneNo,Email,Logo,Op
                    case 4:
                        clsCustomer obCustomer = new clsCustomer();
                        try { obCustomer.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obCustomer.Name = Request.QueryString["Name"].ToString(); }
                        catch { }
                        try { obCustomer.Address = Request.QueryString["Address"].ToString(); }
                        catch { }
                        try { obCustomer.Phone = Request.QueryString["Phone"].ToString(); }
                        catch { }
                        try { obCustomer.Email = Request.QueryString["Email"].ToString(); }
                        catch { }
                        try { obCustomer.Logo = Request.QueryString["Logo"].ToString(); }
                        catch { }
                        obCustomer.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obCustomer.CustomerMaster(obCustomer);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 5)
                            {
                                dt.Rows[0][0] = "Updated";
                            }


                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }

                        break;
                    // For Daily Progress
                    //ID,SiteID,SiteMachineID,EntryDate1 ,EntryDate2,Shift ,StartReading,CloseReading ,FuelIssued ,TotalReading,BreakDown ,Remarks,Op 
                    case 5:
                        clsDailyProgressReport obDPR = new clsDailyProgressReport();
                        try { obDPR.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obDPR.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obDPR.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                        catch { }
                        try { obDPR.EntryDate1 = Request.QueryString["EntryDate1"].ToString(); }
                        catch { }

                        try { obDPR.EntryDate2 = Request.QueryString["EntryDate2"].ToString(); }
                        catch { }

                        try { obDPR.Shift = Convert.ToInt32(Request.QueryString["Shift"]); }
                        catch { }
                        try { obDPR.StartReading = Convert.ToDouble(Request.QueryString["StartReading"]); }
                        catch { }
                        try { obDPR.CloseReading = Convert.ToDouble(Request.QueryString["CloseReading"]); }
                        catch { }
                        try { obDPR.FuelIssued = Convert.ToDouble(Request.QueryString["FuelIssued"]); }
                        catch { }
                        try { obDPR.TotalReading = Convert.ToDouble(Request.QueryString["TotalReading"]); }
                        catch { }
                        try { obDPR.BreakDown = Convert.ToInt32(Request.QueryString["BreakDown"]); }
                        catch { }
                        try { obDPR.Remarks = Request.QueryString["Remarks"].ToString(); }
                        catch { }
                        obDPR.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = obDPR.DailyProgressReport(obDPR);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }

                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //for procIndentMaster
                    //ID,UserID ,OrderFrom ,OrderFromID ,RefNo , ProjectNo , JobNo , IndentDate, Indentor, ApprovedBy ,Status ,Op
                    case 6:
                        clsIndent obIndent = new clsIndent();
                        try { obIndent.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obIndent.UserID = Convert.ToInt32(Request.QueryString["UserID"]); }
                        catch { }

                        try { obIndent.OrderFrom = Convert.ToInt32(Request.QueryString["OrderFrom"]); }
                        catch { }
                        try { obIndent.OrderFromID = Convert.ToInt32(Request.QueryString["OrderFromID"]); }
                        catch { }
                        try { obIndent.RefNo = Request.QueryString["RefNo"].ToString(); }
                        catch { }
                        try { obIndent.ProjectNo = Request.QueryString["ProjectNo"].ToString(); }
                        catch { }
                        try { obIndent.JobNo = Request.QueryString["JobNo"].ToString(); }
                        catch { }
                        try { obIndent.IndentDate = Request.QueryString["IndentDate"].ToString(); }
                        catch { }
                        try { obIndent.Indentor = Convert.ToInt32(Request.QueryString["Indentor"]); }
                        catch { }
                        try { obIndent.ApprovedBy = Convert.ToInt32(Request.QueryString["ApprovedBy"]); }
                        catch { }
                        try { obIndent.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }
                        obIndent.Op = Convert.ToInt32(Request.QueryString["Op"]);


                        ds = obIndent.IndentMaster(obIndent);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 10)
                            {
                                dt.Rows[0][0] = "Updated";
                            }

                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For procIndentItems 
                    // For   ID ,IndentID ,PartNo ,Particular,CurrentStock ,Quantity ,Remarks,Op 		
                    case 7:
                        clsIndentItems obIndentItems = new clsIndentItems();
                        try { obIndentItems.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obIndentItems.IndentID = Convert.ToInt32(Request.QueryString["IndentID"]); }
                        catch { }
                        try { obIndentItems.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { obIndentItems.Particular = Request.QueryString["Particular"].ToString(); }
                        catch { }
                        try { obIndentItems.CurrentStock = Convert.ToInt32(Request.QueryString["CurrentStock"]); }
                        catch { }
                        try { obIndentItems.Quantity = Convert.ToInt32(Request.QueryString["Quantity"]); }
                        catch { }
                        try { obIndentItems.Remarks = Request.QueryString["Remarks"].ToString(); }
                        catch { }
                        obIndentItems.Op = Convert.ToInt32(Request.QueryString["Op"]);


                        ds = obIndentItems.IndentItemMaster(obIndentItems);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }

                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //For ProcJobs
                    //ID , ProjectID ,JobName ,Op 
                    case 8: clsProjectJob obJob = new clsProjectJob();
                        try { obJob.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obJob.ProjectID = Convert.ToInt32(Request.QueryString["ProjectID"]); }
                        catch { }
                        try { obJob.JobName = Request.QueryString["JobName"].ToString(); }
                        catch { }
                        obJob.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = obJob.Jobs(obJob);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Updated";
                            }

                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    //For ProcMachineMaster
                    //ID , SerialNo , ModelNo ,Manufacturer, MachineType,Description ,Photo ,Op 					
                    case 9: clsMachineMaster obMachineMaster = new clsMachineMaster();
                        try { obMachineMaster.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obMachineMaster.SerialNo = Request.QueryString["SerialNo"].ToString(); }
                        catch { }
                        try { obMachineMaster.ModelNo = Request.QueryString["ModelNo"].ToString(); }
                        catch { }
                        try { obMachineMaster.Manufacturer = Request.QueryString["Manufacturer"].ToString(); }
                        catch { }
                        try { obMachineMaster.MachineType = Convert.ToInt32(Request.QueryString["MachineType"]); }
                        catch { }
                        try { obMachineMaster.Description = Request.QueryString["Description"].ToString(); }
                        catch { }
                        try { obMachineMaster.Photo = Request.QueryString["Photo"].ToString(); }
                        catch { }
                        obMachineMaster.Op = Convert.ToInt32(Request.QueryString["Op"]);


                        ds = obMachineMaster.MachineMaster(obMachineMaster);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }

                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //For procMachineryUsage
                    //ID ,EntryDate,SiteID ,SiteMachineID,StartingReading,ClosingReading ,WorkingHours,Idle,DB,AvailableHours,HSDLub,EOLub,HOLub,GoLub,OtherLub,HSDOil, UOM , 
                    //CurrentLocation ,TotalProduction ,Remarks, Status,EnteredBy,Op
                    //case 10: clsMachineryUsage obj = new clsMachineryUsage();
                    //    try { obj.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                    //    catch { }
                    //    try { obj.EntryDate = Request.QueryString["EntryDate"].ToString(); }
                    //    catch { }
                    //    try { obj.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                    //    catch { }
                    //    try { obj.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                    //    catch { }
                    //    try { obj.StartingReading = Convert.ToDouble(Request.QueryString["StartingReading"]); }
                    //    catch { }
                    //    try { obj.ClosingReading = Convert.ToDouble(Request.QueryString["ClosingReading"]); }
                    //    catch { }
                    //    try { obj.WorkingHours = Request.QueryString["WorkingHours"].ToString(); }
                    //    catch { }
                    //    try { obj.Idle = Request.QueryString["Idle"].ToString(); }
                    //    catch { }
                    //    try { obj.DB = Request.QueryString["DB"].ToString(); }
                    //    catch { }
                    //    try { obj.AvailableHours = Request.QueryString["AvailableHours"].ToString(); }
                    //    catch { }
                    //    try { obj.HSDLub = Convert.ToDouble(Request.QueryString["HSDLub"]); }
                    //    catch { }
                    //    try { obj.EOLub = Convert.ToDouble(Request.QueryString["EOLub"]); }
                    //    catch { }
                    //    try { obj.HOLub = Convert.ToDouble(Request.QueryString["HOLub"]); }
                    //    catch { }
                    //    try { obj.GoLub = Convert.ToDouble(Request.QueryString["GoLub"]); }
                    //    catch { }
                    //    try { obj.OtherLub = Convert.ToDouble(Request.QueryString["OtherLub"]); }
                    //    catch { }
                    //    try { obj.HSDOil = Convert.ToDouble(Request.QueryString["HSDOil"]); }
                    //    catch { }
                    //    try { obj.UOM = Convert.ToDouble(Request.QueryString["UOM"]); }
                    //    catch { }
                    //    try { obj.CurrentLocation = Request.QueryString["CurrentLocation"].ToString(); }
                    //    catch { }
                    //    try { obj.TotalProduction = Convert.ToDouble(Request.QueryString["TotalProduction"]); }
                    //    catch { }
                    //    try { obj.Remarks = Request.QueryString["Remarks"].ToString(); }
                    //    catch { }
                    //    try { obj.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                    //    catch { }
                    //    try { obj.EnteredBy = Convert.ToInt32(Request.QueryString["EnteredBy"]); }
                    //    catch { }
                    //    obj.Op = Convert.ToInt32(Request.QueryString["Op"]);


                    //    ds = obj.MachineryUsage(obj);
                    //    if (ds.Tables.Count > 0)
                    //    {
                    //        dt = ds.Tables[0];
                    //    }
                    //    else
                    //    {
                    //        dt.Columns.Add("Message");
                    //        dt.Rows.Add(dt.NewRow());
                    //        if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                    //        {
                    //            dt.Rows[0][0] = "Saved";
                    //        }


                    //        else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                    //        {
                    //            dt.Rows[0][0] = "Deleted";
                    //        }
                    //        else if (Convert.ToInt32(Request.QueryString["Op"]) == 5)
                    //        {
                    //            dt.Rows[0][0] = "Updated";
                    //        }


                    //    }



                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        row = new Dictionary<string, object>();
                    //        foreach (DataColumn col in dt.Columns)
                    //        {
                    //            row.Add(col.ColumnName, dr[col]);
                    //        }
                    //        rows.Add(row);
                    //    }
                    //    break;
                    //For procMachineTransfer	
                    //ID ,SourceSiteID ,DestinationSiteID ,SiteMachineID ,StartDate ,UpdateDate,UpdatedBy ,Status ,Remarks ,Op 			
                    case 11: clsMachineTransfer obMachineTransfer = new clsMachineTransfer();
                        try { obMachineTransfer.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obMachineTransfer.SourceSiteID = Convert.ToInt32(Request.QueryString["SourceSiteID"]); }
                        catch { }
                        try { obMachineTransfer.DestinationSiteID = Convert.ToInt32(Request.QueryString["DestinationSiteID"]); }
                        catch { }
                        try { obMachineTransfer.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                        catch { }
                        try { obMachineTransfer.StartDate = Request.QueryString["StartDate"].ToString(); }
                        catch { }
                        try { obMachineTransfer.UpdateDate = Request.QueryString["UpdateDate"].ToString(); }
                        catch { }
                        try { obMachineTransfer.UpdatedBy = Convert.ToInt32(Request.QueryString["UpdatedBy"]); }
                        catch { }
                        try { obMachineTransfer.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }
                        try { //obMachineTransfer.Remarks = Request.QueryString["Remarks"].ToString(); 
                        }
                        catch { }
                        obMachineTransfer.Op = Convert.ToInt32(Request.QueryString["Op"]);


                        ds = obMachineTransfer.MachineTransfer(obMachineTransfer);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }


                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 7)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }


                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //For  procManufacturer
                    //ID ,Name ,Address,PhoneNo,Email,AddedOn,Op				
                    case 12: clsManufacturer obManufacturer = new clsManufacturer();
                        try { obManufacturer.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obManufacturer.Name = Request.QueryString["Name"].ToString(); }
                        catch { }
                        try { obManufacturer.Address = Request.QueryString["Address"].ToString(); }
                        catch { }
                        try { obManufacturer.PhoneNo = Request.QueryString["PhoneNo"].ToString(); }
                        catch { }
                        try { obManufacturer.Email = Request.QueryString["Email"].ToString(); }
                        catch { }
                        try { obManufacturer.AddedOn = Request.QueryString["AddedOn"].ToString(); }
                        catch { }
                        obManufacturer.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = obManufacturer.ManufacturerMaster(obManufacturer);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }


                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Updated";
                            }


                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    //for procPartMaster
                    //ID ,MachineID ,SerialNo ,PartName,PartDescription,Photo ,Op 
                    case 13: clsPart objPart = new clsPart();
                        try { objPart.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { objPart.MachineID = Convert.ToInt32(Request.QueryString["MachineID"]); }
                        catch { }
                        try { objPart.SerialNo = Request.QueryString["SerialNo"].ToString(); }
                        catch { }
                        try { objPart.PartName = Request.QueryString["PartName"].ToString(); }
                        catch { }
                        try { objPart.PartDescription = Request.QueryString["PartDescription"].ToString(); }
                        catch { }
                        try { objPart.Photo = Request.QueryString["Photo"].ToString(); }
                        catch { }
                        objPart.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = objPart.PartMaster(objPart);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }


                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }


                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;


                    //for procPOParticulars
                    //ID ,POID ,LogNo,PartNo,Item,CurrentStock ,Qty ,UGM ,Rate,Tax ,Amount,Remark ,Op 
                    case 14: clsPOParticulars obPOParticulars = new clsPOParticulars();
                        try { obPOParticulars.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obPOParticulars.POID = Convert.ToInt32(Request.QueryString["POID"]); }
                        catch { }
                        try { obPOParticulars.LogNo = Request.QueryString["LogNo"].ToString(); }
                        catch { }
                        try { obPOParticulars.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { obPOParticulars.Item = Request.QueryString["Item"].ToString(); }
                        catch { }
                        try { obPOParticulars.CurrentStock = Convert.ToInt32(Request.QueryString["CurrentStock"]); }
                        catch { }
                        try { obPOParticulars.Qty = Convert.ToInt32(Request.QueryString["Qty"]); }
                        catch { }

                        try { obPOParticulars.UGM = Request.QueryString["UGM"].ToString(); }
                        catch { }
                        try { obPOParticulars.Rate = Convert.ToDouble(Request.QueryString["Rate"]); }
                        catch { }
                        try { obPOParticulars.Tax = Convert.ToDouble(Request.QueryString["Tax"]); }
                        catch { }
                        try { obPOParticulars.Amount = Convert.ToDouble(Request.QueryString["Amount"]); }
                        catch { }
                        try { obPOParticulars.Remark = Request.QueryString["Remark"].ToString(); }
                        catch { }
                        obPOParticulars.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = obPOParticulars.POParticularsMaster(obPOParticulars);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }



                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;


                    //for procPOTerms
                    //ID ,POID ,Heading,Detail,Op 
                    case 15: clsPOTerms obPOTerms = new clsPOTerms();
                        try { obPOTerms.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obPOTerms.POID = Convert.ToInt32(Request.QueryString["POID"]); }
                        catch { }

                        try { obPOTerms.Heading = Request.QueryString["Heading"].ToString(); }
                        catch { }
                        try { obPOTerms.Detail = Request.QueryString["Detail"].ToString(); }
                        catch { }
                        obPOTerms.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obPOTerms.POTermsMaster(obPOTerms);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }

                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Updated";
                            }



                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //for procProjects
                    //ID ,SiteID,ProjectName,ProjectDate,Op 

                    case 16: clsProjectJob obProject = new clsProjectJob();
                        try { obProject.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obProject.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }

                        try { obProject.ProjectName = Request.QueryString["ProjectName"].ToString(); }
                        catch { }

                        try { obProject.ProjectDate = Request.QueryString["ProjectDate"].ToString(); }
                        catch { }
                        obProject.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obProject.Projects(obProject);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }

                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Updated";
                            }



                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    //for procPurchaseOrderMaster
                    //ID ,SiteID ,SiteMachineID ,PORefNo,PODate,IndentRefNo,QuotationNo,QuotationDate,Subject ,PreparedBy ,CheckedBy , CompanySign, 
                    //TotalAmount ,TaxName ,TaxPercentage,DiscountPercentage,NetPayable,Status ,POTo,Op 


                    case 17: clsPurchaseOrder obPurchaseOrder = new clsPurchaseOrder();

                        try { obPurchaseOrder.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obPurchaseOrder.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obPurchaseOrder.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                        catch { }

                        try { obPurchaseOrder.PORefNo = Request.QueryString["PORefNo"].ToString(); }
                        catch { }

                        try { obPurchaseOrder.PODate = Request.QueryString["PODate"].ToString(); }
                        catch { }

                        try { obPurchaseOrder.IndentRefNo = Request.QueryString["IndentRefNo"].ToString(); }
                        catch { }

                        try { obPurchaseOrder.QuotationNo = Request.QueryString["QuotationNo"].ToString(); }
                        catch { }

                        try { obPurchaseOrder.QuotationDate = Request.QueryString["QuotationDate"].ToString(); }
                        catch { }

                        try { obPurchaseOrder.Subject = Request.QueryString["Subject"].ToString(); }
                        catch { }
                        try { obPurchaseOrder.PreparedBy = Convert.ToInt32(Request.QueryString["PreparedBy"]); }
                        catch { }
                        try { obPurchaseOrder.CheckedBy = Convert.ToInt32(Request.QueryString["CheckedBy"]); }
                        catch { }

                        try { obPurchaseOrder.CompanySign = Request.QueryString["CompanySign"].ToString(); }
                        catch { }
                        try { obPurchaseOrder.TotalAmount = Convert.ToDouble(Request.QueryString["TotalAmount"]); }
                        catch { }
                        try { obPurchaseOrder.TaxName = Request.QueryString["TaxName"].ToString(); }
                        catch { }
                        try { obPurchaseOrder.TaxPercentage = Convert.ToDouble(Request.QueryString["TaxPercentage"]); }
                        catch { }
                        try { obPurchaseOrder.DiscountPercentage = Convert.ToDouble(Request.QueryString["DiscountPercentage"]); }
                        catch { }
                        try { obPurchaseOrder.NetPayable = Convert.ToDouble(Request.QueryString["NetPayable"]); }
                        catch { }

                        try { obPurchaseOrder.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }

                        try { obPurchaseOrder.POTo = Convert.ToInt32(Request.QueryString["POTo"]); }
                        catch { }
                        obPurchaseOrder.Op = Convert.ToInt32(Request.QueryString["Op"]);

                        ds = obPurchaseOrder.PurchaseOrderMaster(obPurchaseOrder);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }

                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Updated";
                            }




                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    //For procSiteDamageEntry
                    //ID ,SiteID ,AddedBy ,Particular, Photo , EntryDate , Quantity ,Status ,Op 

                    case 18: clsSiteDamageEntry obSiteDamageEntry = new clsSiteDamageEntry();


                        try { obSiteDamageEntry.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSiteDamageEntry.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obSiteDamageEntry.AddedBy = Request.QueryString["AddedBy"].ToString(); }
                        catch { }
                        try { obSiteDamageEntry.Particular = Request.QueryString["Particular"].ToString(); }
                        catch { }
                        try { obSiteDamageEntry.Photo = Request.QueryString["Photo"].ToString(); }
                        catch { }
                        try { obSiteDamageEntry.EntryDate = Request.QueryString["EntryDate"].ToString(); }
                        catch { }

                        try { obSiteDamageEntry.Quantity = Convert.ToInt32(Request.QueryString["Quantity"]); }
                        catch { }

                        try { obSiteDamageEntry.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }
                        obSiteDamageEntry.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSiteDamageEntry.SiteDamageEntry(obSiteDamageEntry);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    // For   procSiteMachineRecords
                    //ID ,SiteID ,SiteMachineID ,RecordName ,RecordValue,ValidFrom, ValidTo ,TotalCost ,RemindBeforeDays ,Op      					
                    case 19: clsSiteMachineRecords obSiteMachineRecords = new clsSiteMachineRecords();

                        try { obSiteMachineRecords.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSiteMachineRecords.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }

                        try { obSiteMachineRecords.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                        catch { }
                        try { obSiteMachineRecords.RecordName = Request.QueryString["RecordName"].ToString(); }
                        catch { }
                        try { obSiteMachineRecords.RecordValue = Request.QueryString["RecordValue"].ToString(); }
                        catch { }
                        try { obSiteMachineRecords.ValidFrom = Request.QueryString["ValidFrom"].ToString(); }
                        catch { }
                        try { obSiteMachineRecords.ValidTo = Request.QueryString["ValidTo"].ToString(); }
                        catch { }

                        try { obSiteMachineRecords.TotalCost = Convert.ToDouble(Request.QueryString["TotalCost"]); }
                        catch { }

                        try { obSiteMachineRecords.RemindBeforeDays = Convert.ToInt32(Request.QueryString["RemindBeforeDays"]); }
                        catch { }

                        obSiteMachineRecords.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSiteMachineRecords.SiteMachineRecords(obSiteMachineRecords);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For procSiteMachines	
                    //ID ,SiteID ,MachineID ,SerialNo ,AddedOn,Status ,UpdateDate,UsageUnit ,ThesisNo ,EngineNo ,RegistrationNo ,Op 
                    case 20: clsSiteMachines obSiteMachines = new clsSiteMachines();

                        try { obSiteMachines.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSiteMachines.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }

                        try { obSiteMachines.MachineID = Convert.ToInt32(Request.QueryString["MachineID"]); }
                        catch { }
                        try { obSiteMachines.SerialNo = Request.QueryString["SerialNo"].ToString(); }
                        catch { }
                        try { obSiteMachines.AddedOn = Request.QueryString["AddedOn"].ToString(); }
                        catch { }

                        try { obSiteMachines.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }
                        try { obSiteMachines.UpdateDate = Request.QueryString["UpdateDate"].ToString(); }
                        catch { }
                        try { obSiteMachines.UsageUnit = Request.QueryString["UsageUnit"].ToString(); }
                        catch { }
                        try { obSiteMachines.ThesisNo = Request.QueryString["ThesisNo"].ToString(); }
                        catch { }
                        try { obSiteMachines.EngineNo = Request.QueryString["EngineNo"].ToString(); }
                        catch { }
                        try { obSiteMachines.RegistrationNo = Request.QueryString["RegistrationNo"].ToString(); }
                        catch { }
                        obSiteMachines.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSiteMachines.SiteMachines(obSiteMachines);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Updated";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    //For procSiteMaster
                    //ID ,Name ,Location ,Address ,PhoneNo ,Email ,Op 
                    case 21: clsSite obSite = new clsSite();
                        try { obSite.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSite.Name = Request.QueryString["Name"].ToString(); }
                        catch { }
                        try { obSite.Location = Request.QueryString["Location"].ToString(); }
                        catch { }
                        try { obSite.Address = Request.QueryString["Address"].ToString(); }
                        catch { }
                        try { obSite.PhoneNo = Request.QueryString["PhoneNo"].ToString(); }
                        catch { }
                        try { obSite.Email = Request.QueryString["Email"].ToString(); }
                        catch { }
                        obSite.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSite.SiteMaster(obSite);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;


                    //For procSitePartIssue
                    //ID ,EntryDate ,SiteID , SiteMachineID , PartID , PartNo , LogNo, PartName, BillRef,Op 


                    case 22: clsSitePartIssue obSitePartIssue = new clsSitePartIssue();

                        try { obSitePartIssue.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSitePartIssue.EntryDate1 = Request.QueryString["EntryDate"].ToString(); }
                        catch { }
                        try { obSitePartIssue.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obSitePartIssue.SiteMachineID = Convert.ToInt32(Request.QueryString["SiteMachineID"]); }
                        catch { }
                        try { obSitePartIssue.PartID = Convert.ToInt32(Request.QueryString["PartID"]); }
                        catch { }
                        try { obSitePartIssue.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { //obSitePartIssue.LogNo = Request.QueryString["LogNo"].ToString(); 
                        }
                        catch { }
                        try { obSitePartIssue.PartName = Request.QueryString["PartName"].ToString(); }
                        catch { }
                        try { //obSitePartIssue.BillRef = Request.QueryString["BillRef"].ToString(); 
                        }
                        catch { }
                        obSitePartIssue.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSitePartIssue.SitePartIssue(obSitePartIssue);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }


                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;








                    //For  procSitePartRequest						
                    //ID ,SiteID ,UserID ,EntryDate,PartNo ,Description ,Photo ,Status,FromSite ,ItemType ,Op 

                    case 23: clsSitePartRequest obSitePartRequest = new clsSitePartRequest();

                        try { obSitePartRequest.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSitePartRequest.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obSitePartRequest.UserID = Convert.ToInt32(Request.QueryString["UserID"]); }
                        catch { }
                        try { obSitePartRequest.EntryDate = Request.QueryString["EntryDate"].ToString(); }
                        catch { }
                        try { obSitePartRequest.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { obSitePartRequest.Description = Request.QueryString["Description"].ToString(); }
                        catch { }
                        try { obSitePartRequest.Photo = Request.QueryString["Photo"].ToString(); }
                        catch { }

                        try { obSitePartRequest.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }

                        try { obSitePartRequest.FromSite = Convert.ToInt32(Request.QueryString["FromSite"]); }
                        catch { }

                        try { obSitePartRequest.ItemType = Convert.ToInt32(Request.QueryString["ItemType"]); }
                        catch { }

                        obSitePartRequest.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSitePartRequest.SitePartRequest(obSitePartRequest);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 6)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 7)
                            {
                                dt.Rows[0][0] = "Updated";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // for procSiteProductParts
                    //ID ,SiteID ,MachineID ,PartID , EntryDate, BillRef , TransactionType , Quantity ,Op 
                    case 24: clsSiteProductParts obSiteProductParts = new clsSiteProductParts();
                        try { obSiteProductParts.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obSiteProductParts.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obSiteProductParts.SiteMachineID = Convert.ToInt32(Request.QueryString["MachineID"]); }
                        catch { }
                        try { obSiteProductParts.PartID = Convert.ToInt32(Request.QueryString["PartID"]); }
                        catch { }
                        try { obSiteProductParts.EntryDate1 = Request.QueryString["EntryDate"].ToString(); }
                        catch { }
                        try { obSiteProductParts.BillRef = Request.QueryString["BillRef"].ToString(); }
                        catch { }
                        try { obSiteProductParts.TransactionType = Convert.ToInt32(Request.QueryString["TransactionType"]); }
                        catch { }
                        try { obSiteProductParts.Quantity = Convert.ToInt32(Request.QueryString["Quantity"]); }
                        catch { }

                        obSiteProductParts.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obSiteProductParts.SiteProductParts(obSiteProductParts);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For procTaxMaster
                    //ID ,TaxName,TaxPercent,Op 	
                    case 25:
                        clsTaxMaster obTaxMaster = new clsTaxMaster();
                        try { obTaxMaster.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obTaxMaster.TaxName = Request.QueryString["TaxName"].ToString(); }
                        catch { }
                        try { obTaxMaster.TaxPercent = Convert.ToDouble(Request.QueryString["TaxPercent"]); }
                        catch { }


                        obTaxMaster.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obTaxMaster.TaxMaster(obTaxMaster);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }





                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    // For procTempIndentItems  
                    //ID , UserID ,PartNo ,Particular ,CurrentStock ,Quantity ,Remarks ,Op 
                    case 26:
                        clsTempIndentItems obTempIndentItems = new clsTempIndentItems();
                        try { obTempIndentItems.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obTempIndentItems.UserID = Convert.ToInt32(Request.QueryString["UserID"]); }
                        catch { }
                        try { obTempIndentItems.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { obTempIndentItems.Particular = Request.QueryString["Particular"].ToString(); }
                        catch { }
                        try { obTempIndentItems.CurrentStock = Convert.ToInt32(Request.QueryString["CurrentStock"]); }
                        catch { }
                        try { obTempIndentItems.Quantity = Convert.ToInt32(Request.QueryString["Quantity"]); }
                        catch { }
                        try { obTempIndentItems.Remarks = Request.QueryString["Remarks"].ToString(); }
                        catch { }

                        obTempIndentItems.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obTempIndentItems.TempIndentItems(obTempIndentItems);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 5)
                            {
                                dt.Rows[0][0] = "Updated";
                            }




                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;

                    // For procTempPOParticulars
                    // ID ,UserID ,PartNo ,Item ,CurrentStock ,Qty ,UGM ,Rate ,Amount ,Op 

                    case 27:
                        clsTempPOParticulars obTempPOParticulars = new clsTempPOParticulars();
                        try { obTempPOParticulars.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obTempPOParticulars.UserID = Convert.ToInt32(Request.QueryString["UserID"]); }
                        catch { }
                        try { obTempPOParticulars.PartNo = Request.QueryString["PartNo"].ToString(); }
                        catch { }
                        try { obTempPOParticulars.Item = Request.QueryString["Item"].ToString(); }
                        catch { }
                        try { obTempPOParticulars.CurrentStock = Convert.ToInt32(Request.QueryString["CurrentStock"]); }
                        catch { }
                        try { obTempPOParticulars.Qty = Convert.ToInt32(Request.QueryString["Qty"]); }
                        catch { }
                        try { obTempPOParticulars.UGM = Request.QueryString["UGM"].ToString(); }
                        catch { }
                        try { obTempPOParticulars.Rate = Convert.ToDouble(Request.QueryString["Rate"]); }
                        catch { }
                        try { obTempPOParticulars.Amount = Convert.ToDouble(Request.QueryString["Amount"]); }
                        catch { }

                        obTempPOParticulars.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obTempPOParticulars.TempPOParticulars(obTempPOParticulars);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 4)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 5)
                            {
                                dt.Rows[0][0] = "Updated";
                            }




                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For procUserMaster     
                    // ID ,UserType,Name ,Email,PhoneNo ,SiteID ,Designation ,Signature ,UserID,Password ,Op

                    case 28:
                        clsWorkshopItemMaster obWorkshopItemMaster = new clsWorkshopItemMaster();

                        try { obWorkshopItemMaster.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obWorkshopItemMaster.SiteID = Convert.ToInt32(Request.QueryString["SiteID"]); }
                        catch { }
                        try { obWorkshopItemMaster.ItemName = Request.QueryString["ItemName"].ToString(); }
                        catch { }
                        try { obWorkshopItemMaster.Description = Request.QueryString["Description"].ToString(); }
                        catch { }
                        obWorkshopItemMaster.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obWorkshopItemMaster.WorkshopItemMaster(obWorkshopItemMaster);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Updated";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }




                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;
                    // For procWorkshopItemTransaction
                    // ID ,ItemID ,EntryDate, Quantity ,Status ,Op
                    case 29:
                        clsWorkshopItemTransaction obWorkshopItemTransaction = new clsWorkshopItemTransaction();

                        try { obWorkshopItemTransaction.ID = Convert.ToInt32(Request.QueryString["ID"]); }
                        catch { }
                        try { obWorkshopItemTransaction.ItemID = Convert.ToInt32(Request.QueryString["ItemID"]); }
                        catch { }
                        try { obWorkshopItemTransaction.EntryDate = Request.QueryString["EntryDate"].ToString(); }
                        catch { }
                        try { obWorkshopItemTransaction.Quantity = Convert.ToInt32(Request.QueryString["Quantity"]); }
                        catch { }
                        try { obWorkshopItemTransaction.Status = Convert.ToInt32(Request.QueryString["Status"]); }
                        catch { }
                        obWorkshopItemTransaction.Op = Convert.ToInt32(Request.QueryString["Op"]);
                        ds = obWorkshopItemTransaction.WorkshopItemTransaction(obWorkshopItemTransaction);
                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Columns.Add("Message");
                            dt.Rows.Add(dt.NewRow());
                            if (Convert.ToInt32(Request.QueryString["Op"]) == 1)
                            {
                                dt.Rows[0][0] = "Saved";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 2)
                            {
                                dt.Rows[0][0] = "Deleted";
                            }
                            else if (Convert.ToInt32(Request.QueryString["Op"]) == 3)
                            {
                                dt.Rows[0][0] = "Updated";
                            }




                        }



                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        break;






                    default:
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows[0][0] = "1";
                        break;

                }
            }
        }
        catch
        {
            dt = new DataTable();
            dt.Columns.Add("Error");
            dt.Columns.Add("Description");
            dt.Rows.Add(dt.NewRow());
            dt.Rows[0][0] = "1";
            dt.Rows[0][1] = "Valid Transaction type not passed";
        }
        strData = serializer.Serialize(rows);
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(strData);
        Response.End();
    }

}