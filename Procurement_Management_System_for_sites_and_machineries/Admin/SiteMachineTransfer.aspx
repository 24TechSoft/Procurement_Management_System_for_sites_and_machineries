<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="SiteMachineTransfer.aspx.cs" Inherits="Admin_SiteMachineTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<asp:Panel ID="pnlRequests" runat="server">
    <div class="row">
    <h3>Machinary Transfer</h3>
    Select Site:
    <asp:DropDownList ID="ddlSites" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSites_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="row">
<asp:GridView ID="grdMachines" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="None" Width="100%" SelectedRowStyle-BackColor="Control"
        onselectedindexchanging="grdMachines_SelectedIndexChanging">
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass"/>
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
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
<div class="clearfix"></div>
<asp:Panel ID="pnlUpdate" runat="server" Visible="false" CssClass="row">
    <div class="col-lg-3 col-md-6 col-sm-12">
        <h4>Machine Name</h4>
        <asp:Label ID="lblMachineName" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <h4>Source Site</h4>
        <asp:Label ID="lblSourceSite" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <h4>Destination Site</h4>
        <asp:Label ID="lblDestinationSite" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <h4>Placed On</h4>
        <asp:Label ID="lblPlacedOn" runat="server"></asp:Label>
    </div>
    <div class="clearfix"></div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <h4>Current Status</h4>
        <asp:Label ID="lblCurrentStatus" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <label>Status</label><br />
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Width="200px">
        <asp:ListItem Value="1" Text="Despatched"></asp:ListItem>
        <asp:ListItem Value="3" Text="Delivered"></asp:ListItem>
        <asp:ListItem Value="4" Text="Canceled"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" 
            onclick="btnUpdate_Click" />
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" 
            onclick="btnCancel_Click" />
    </div>
</asp:Panel>
</div>
</section>
</asp:Content>

