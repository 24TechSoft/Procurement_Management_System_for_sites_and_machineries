<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="MachineTransfer.aspx.cs" Inherits="Admin_MachineTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<asp:Panel ID="pnlRequests" runat="server">
<table width="100%">
<tr valign="top">
<td>
<label>Date</label>
<asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" Width="200px"></asp:TextBox>
</td>
<td>
<label>Source Site</label>
<asp:DropDownList ID="ddlSourceSite" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSourceSite_SelectedIndexChanged"></asp:DropDownList>
</td>
<td>
<label>Select Machine</label><br />
<asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
</td>
<td>
<label>Select Destination Site</label><br />
    <asp:DropDownList ID="ddlDestSite" runat="server" CssClass="form-control" Width="200px">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
<label>Driver Name</label><br />
    <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td>
<label>Driver Phone No</label><br />
    <asp:TextBox ID="txtDriverPhone" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td valign="middle" colspan="2">
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
            onclick="btnSave_Click" />
</td>
</tr>
</table>
<div class="row">
    <div class="col-lg-3">
    
    
    </div>
    <div class="col-lg-3">
    
    </div>
    <div class="col-lg-3">
    
    </div>
    <div class="col-lg-3">
   
    </div>
</div>
<div class="row">
<asp:GridView ID="grdMachines" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" SelectedRowStyle-BackColor="Control"
        onselectedindexchanging="grdMachines_SelectedIndexChanging">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:BoundField HeaderText="Source Site" DataField="SourceSiteName" />
<asp:BoundField HeaderText="Destination Site" DataField="DestSiteName" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:BoundField HeaderText="Place On" DataField="StartDate" />
<asp:BoundField HeaderText="Update Date" DataField="UpdateDate" />
<asp:BoundField HeaderText="Updated By" DataField="UpdatedBy" />
<asp:BoundField HeaderText="Status" DataField="Status" />
<asp:BoundField HeaderText="Driver Name" DataField="DriverName" />
<asp:BoundField HeaderText="Driver Phone" DataField="DriverPhone" />
    <asp:CommandField ShowSelectButton="True" />
</Columns>
    <SelectedRowStyle BackColor="Control" />
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
<asp:Panel ID="pnlUpdate" runat="server" CssClass="row" Visible="false">
<table width="100%">
<tr valign="top">
<td colspan="3">
<h4>Machine Name</h4>
<asp:Label ID="lblMachineName" runat="server"></asp:Label>
</td>
<td colspan="3">
<h4>Source Site</h4>
<asp:Label ID="lblSourceSite" runat="server"></asp:Label>
</td>
<td colspan="3">
<h4>Destination Site</h4>
<asp:Label ID="lblDestinationSite" runat="server"></asp:Label>
</td>
<td colspan="3">
<h4>Placed On</h4>
<asp:Label ID="lblPlacedOn" runat="server"></asp:Label>
</td></tr>
<tr><td colspan="12">
<h4>Current Status</h4>
<asp:Label ID="lblCurrentStatus" runat="server"></asp:Label>
</td></tr>
<tr valign="top">
<td colspan="4">
<label>Status</label><br />
<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
<asp:ListItem Value="2" Text="Dispatched"></asp:ListItem>
<asp:ListItem Value="3" Text="Delivered"></asp:ListItem>
<asp:ListItem Value="4" Text="Canceled"></asp:ListItem>
</asp:DropDownList>
</td>
<td colspan="4">

</td>
<td colspan="4">
<label><br /></label><br />
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
            onclick="btnUpdate_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" 
            onclick="btnCancel_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" 
        onclick="btnDelete_Click" />
<asp:Button ID="btnDownloadReport" runat="server" Text="Download Report" 
        CssClass="btn btn-info" onclick="btnDownloadReport_Click" />
</td></tr>
</table>
</asp:Panel>
    </div>
</section>
</asp:Content>

