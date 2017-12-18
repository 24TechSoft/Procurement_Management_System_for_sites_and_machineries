<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="AdminRenewalAlerts.aspx.cs" Inherits="Admin_AdminRenewalAlerts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
<h3>Renewal Alerts</h3><br />
<asp:GridView ID="grdAlerts" runat="server" AutoGenerateColumns="False" 
 DataKeyNames="ID" GridLines="Horizontal" Width="100%" >
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:BoundField HeaderText="Site" DataField="Site" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:BoundField HeaderText="Record Name" DataField="RecordName" />
<asp:BoundField HeaderText="Expiry Date" DataField="ValidTo" />
<asp:BoundField HeaderText="Remaining Days" DataField="Remaining" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
    </div>
</div>
</asp:Content>

