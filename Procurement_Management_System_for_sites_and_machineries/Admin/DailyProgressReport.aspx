<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DailyProgressReport.aspx.cs" Inherits="Admin_DailyProgressReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
    <asp:Panel ID="pnl" runat="server" style="font-size:x-small">
<asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnlUpdate" runat="server"><ContentTemplate>
    <table width="100%">
<tr><td colspan="5"><h3>Progress Report</h3></td></tr>
<tr><td colspan="5"><br /></td></tr>
<tr>
<td><asp:DropDownList ID="ddlSite" runat="server" Width="200px" AutoPostBack="True" 
        onselectedindexchanged="ddlSite_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList></td>
<td><asp:DropDownList ID="ddlMachine" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList></td>
<td><asp:TextBox ID="txtDateFrom" runat="server" Type="Date" Width="200px" CssClass="form-control"></asp:TextBox></td>
<td><asp:TextBox ID="txtDateTo" runat="server" Type="Date" Width="200px" CssClass="form-control"></asp:TextBox></td>
<td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
        onclick="btnShow_Click" /></td>
</tr>
<tr><td colspan="5"><br /></td></tr>
<tr><td colspan="5" align="center">
<asp:RadioButtonList ID="rdType" runat="server" AutoPostBack="true" 
        RepeatColumns="2" onselectedindexchanged="rdType_SelectedIndexChanged">
<asp:ListItem Value="1" Selected="True">Site Wise</asp:ListItem>
<asp:ListItem Value="2">Machine Wise</asp:ListItem>
</asp:RadioButtonList>
</td></tr>
<tr><td colspan="5"><br /></td></tr>
<tr><td colspan="5">
<asp:Panel ID="pnlDetailMachine" runat="server" Visible="false">

</asp:Panel>
<asp:Panel ID="pnlDetailSite" runat="server">

</asp:Panel>
</td></tr>
</table>
</ContentTemplate></asp:UpdatePanel>
</asp:Panel>
</asp:Content>

