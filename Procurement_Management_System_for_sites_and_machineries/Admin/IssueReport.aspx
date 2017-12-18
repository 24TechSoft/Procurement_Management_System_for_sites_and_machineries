<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="IssueReport.aspx.cs" Inherits="Admin_IssueReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
    <table width="100%">
<tr><td>
<label>Select Site</label>
<asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged"></asp:DropDownList>
</td>
<td>
<label>Select Machine</label>
<asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
</td>
<td>
<label>From</label>
<asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" TextMode="Date" Width="200px"></asp:TextBox>
</td>
<td>
<label>To</label>
<asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" TextMode="Date" Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td colspan="4"><br /></td></tr>
<tr><td colspan="4">
<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
        onclick="btnShow_Click" />
</td></tr>
<tr><td colspan="4"><br /></td></tr>
<tr><td colspan="4">
<asp:Panel ID="pnlDetail" runat="server"></asp:Panel>
</td></tr>
<tr><td colspan="4"><br /></td></tr>
<tr><td colspan="4">
<asp:Button ID="btnExportToPdf" runat="server" Text="Export To PDF" 
        CssClass="btn btn-info" onclick="btnExportToPdf_Click" />
</td></tr>
</table>
    </div>
</div>
</asp:Content>

