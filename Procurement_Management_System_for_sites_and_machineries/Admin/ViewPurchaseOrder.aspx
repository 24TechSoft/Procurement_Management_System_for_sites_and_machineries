<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ViewPurchaseOrder.aspx.cs" Inherits="Admin_ViewPurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="row">
    <div class="form-group">
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
    <asp:Button CssClass="btn" ID="btnMessage" runat="server" Text="Update Message" 
            onclick="btnMessage_Click" />
    </div>
</div>

<asp:Panel ID="pnlDetail" runat="server" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="1px" Font-Size="X-Small">

</asp:Panel>

<div class="row">
<br /><br />
<br /><br />
<asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" 
        onclick="btnExportToPDF_Click" CssClass="btn btn-info" />
</div>
</asp:Content>

