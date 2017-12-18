<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="MachineTransfer.aspx.cs" Inherits="Supervisor_MachineTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<asp:Panel ID="pnlRequests" runat="server">
<div class="row">
    <div class="col-lg-3">
    <label>Select Machine</label><br />
    <asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control">
    
    </asp:DropDownList>
    </div>
    <div class="col-lg-3">
    <label>Select Destination Site</label><br />
    <asp:DropDownList ID="ddlDestSite" runat="server" CssClass="form-control">
    
    </asp:DropDownList>
    </div>
    <div class="col-lg-3">
    <label>Remarks</label><br />
    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Style="resize:none"></asp:TextBox>
    </div>
    <div class="col-lg-3">
    <label><br /></label><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" 
            onclick="btnSave_Click" />
    </div>
</div>
<div class="row">
<asp:GridView ID="grdMachines" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" SelectedRowStyle-BackColor="Control"
        onselectedindexchanging="grdMachines_SelectedIndexChanging" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:BoundField HeaderText="Source Site" DataField="SourceSite" />
<asp:BoundField HeaderText="Destination Site" DataField="DestinationSite" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:BoundField HeaderText="Place On" DataField="StartDate" />
<asp:BoundField HeaderText="Update Date" DataField="UpdateDate" />
<asp:BoundField HeaderText="Updated By" DataField="UpdatedBy" />
<asp:BoundField HeaderText="Status" DataField="Status" />
<asp:BoundField HeaderText="Remarks" DataField="Remarks" />
    <asp:CommandField ShowSelectButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
<asp:Panel ID="pnlUpdate" runat="server" CssClass="row" Visible="false">
<div class="col-lg-3">
<h4>Machine Name</h4>
<asp:Label ID="lblMachineName" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
<h4>Source Site</h4>
<asp:Label ID="lblSourceSite" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
<h4>Destination Site</h4>
<asp:Label ID="lblDestinationSite" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
<h4>Placed On</h4>
<asp:Label ID="lblPlacedOn" runat="server"></asp:Label>
</div>
<div class="col-lg-12">
<h4>Current Status</h4>
<asp:Label ID="lblCurrentStatus" runat="server"></asp:Label>
</div>
<div class="col-lg-4">
<label>Status</label><br />
<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
<asp:ListItem Value="2" Text="Dispatched"></asp:ListItem>
<asp:ListItem Value="3" Text="Delivered"></asp:ListItem>
<asp:ListItem Value="4" Text="Canceled"></asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-lg-4">
<label>Remarks</label><br />
<asp:TextBox ID="txtERemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" style="resize:none"></asp:TextBox>
</div>
<div class="col-lg-4">
<label><br /></label><br />
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
            onclick="btnUpdate_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" 
            onclick="btnCancel_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" 
        onclick="btnDelete_Click" />
<asp:Button ID="btnDownloadReport" runat="server" Text="Download Report" 
        CssClass="btn btn-info" onclick="btnDownloadReport_Click" />
</div>
</asp:Panel>
</asp:Content>

