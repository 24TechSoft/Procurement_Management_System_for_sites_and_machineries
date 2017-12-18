<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="CurrentStockReport.aspx.cs" Inherits="Admin_CurrentStockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<table width="100%">
<tr>
<td>
<label>Machine</label>
<asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" 
        Width="200px" AutoPostBack="True" 
        onselectedindexchanged="ddlMachine_SelectedIndexChanged"></asp:DropDownList>
</td>
<td>
<label>Part No</label>
<asp:TextBox ID="txtPartNo" runat="server" CssClass="form-control" Width="200px" 
        AutoPostBack="True" ontextchanged="txtPartNo_TextChanged"></asp:TextBox>
</td>
</tr>
<tr><td colspan="3"></td></tr>
<tr><td colspan="3">
<asp:Panel ID="pnlDetail" runat="server">
</asp:Panel>
</td></tr>
<tr><td colspan="3">
<asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" CssClass="btn btn-info" />
</td></tr>
</table>
    </div>
</section>
</asp:Content>

