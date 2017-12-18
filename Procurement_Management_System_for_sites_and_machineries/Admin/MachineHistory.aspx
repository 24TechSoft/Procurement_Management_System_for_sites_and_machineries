<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MachineHistory.aspx.cs" Inherits="Admin_MachineHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
<table width="100%" cellpadding="10px" cellspacing="10px">
<tr>
<td>
<label>Site</label><br />
<asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" Width="200px" 
        onselectedindexchanged="ddlSite_SelectedIndexChanged"></asp:DropDownList>
</td><td>
<label>Machine</label><br />
<asp:DropDownList ID="ddlMachine" runat="server" Width="200px"></asp:DropDownList><br />
</td>
<td>
<label>From</label><br />
<asp:TextBox ID="txtDateFrom" runat="server" placeholder="mm/dd/yyyy" Type="Date" Width="200px"></asp:TextBox>
</td><td>
<label>To</label><br />
<asp:TextBox ID="txtDateTo" runat="server" placeholder="mm/dd/yyyy" Type="Date" Width="200px"></asp:TextBox>
</td>
<td align="left" valign="bottom">
<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
        onclick="btnShow_Click" />
</td>
</tr>
<tr><td colspan="5"><br /></td></tr>
<tr><td colspan="5">
<asp:Panel ID="pnlDetail" runat="server" style="padding:20px;" BorderColor="Red" BorderWidth="2px" BorderStyle="Ridge"></asp:Panel>
</td></tr>
<tr><td colspan="5"><br /></td></tr>
<tr><td colspan="5"><asp:Button ID="btnExportToPDF" runat="server" 
        Text="export To PDF" CssClass="btn btn-info" onclick="btnExportToPDF_Click" /></td></tr>
</table>
    </div>
</div>
</asp:Content>

