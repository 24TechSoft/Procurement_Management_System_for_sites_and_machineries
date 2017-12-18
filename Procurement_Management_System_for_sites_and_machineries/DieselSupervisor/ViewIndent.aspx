<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="ViewIndent.aspx.cs" Inherits="Supervisor_ViewIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">

<div class="row">
<asp:Panel ID="pnlDetail" runat="server" Width="800px" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="1px" style="padding:10px;">

</asp:Panel>
</div>
<div class="row">

<asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" 
        onclick="btnExportToPDF_Click" />
</div>
<asp:Panel ID="pnlApprove" runat="server" Visible="false">

</asp:Panel>
</asp:Content>

