<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="RenewalAlerts.aspx.cs" Inherits="Supervisor_RenewalAlerts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<h3>Renewal Alerts</h3><br />
<asp:GridView ID="grdAlerts" runat="server" AutoGenerateColumns="False" 
 DataKeyNames="ID" GridLines="Horizontal" Width="100%" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:BoundField HeaderText="Site" DataField="Site" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:BoundField HeaderText="Record Name" DataField="RecordName" />
<asp:BoundField HeaderText="Expiry Date" DataField="ValidTo" />
<asp:BoundField HeaderText="Remaining Days" DataField="Remaining" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Content>

