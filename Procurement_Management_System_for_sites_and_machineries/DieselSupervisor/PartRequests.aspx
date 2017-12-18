<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="PartRequests.aspx.cs" Inherits="Supervisor_PartRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="row">
<h2>Part/Machine Requests</h2>
<asp:Panel ID="pnlExisting" runat="server" CssClass="row">
<asp:GridView ID="grdPartRequest" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID"  SelectedRowStyle-BackColor="Red"
        GridLines="Horizontal" Font-Size="Small" Width="100%" EnableModelValidation="True" 
        onrowdeleting="grdPartRequest_RowDeleting" BorderStyle="Inset" 
        BorderColor="#33CCCC">
        <AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:BoundField HeaderText="Date" DataField="EntryDate" />
<asp:BoundField HeaderText="Site" DataField="Site" />
<asp:BoundField HeaderText="Item Type" DataField="ItemType" />
<asp:BoundField HeaderText="Request To" DataField="FromSite" />
<asp:BoundField HeaderText="User" DataField="UserName" />
<asp:BoundField HeaderText="Part No" DataField="PartNo" />
<asp:BoundField HeaderText="Description" DataField="Description" />
<asp:ImageField HeaderText="Image" DataImageUrlField="Photo" ControlStyle-Height="100px" ControlStyle-Width="100px">
    <ControlStyle Height="100px" Width="100px" />
    </asp:ImageField>
<asp:BoundField HeaderText="Status" DataField="Status" />
    <asp:CommandField DeleteText="Accept" ShowDeleteButton="True" />
</Columns>
        <SelectedRowStyle BackColor="Red" />
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Panel>
</asp:Content>

