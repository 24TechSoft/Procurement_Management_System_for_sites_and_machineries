<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="MachineDamageReport.aspx.cs" Inherits="Admin_MachineDamageReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnl" runat="server"><ContentTemplate>
<table width="100%">
<tr valign="top">
<td>
<label>Machine</label><br />
<asp:DropDownList ID="ddlMachine" runat="server" Width="200px"></asp:DropDownList>
</td>
<td align="right">
<label>From</label>
<asp:TextBox ID="txtDateFrom" runat="server" Type="Date"></asp:TextBox><br />
<label>To</label>
<asp:TextBox ID="txtDateTo" runat="server" Type="Date"></asp:TextBox>
</td>
</tr>
<tr valign="top"><td>
<asp:RadioButtonList ID="rdType" runat="server" RepeatColumns="2">
<asp:ListItem Value="1" Text="View By Site"></asp:ListItem>
<asp:ListItem Value="2" Text="View By Machine"></asp:ListItem>
</asp:RadioButtonList>
</td>
<td align="right"><asp:Button ID="btnView" runat="server" Text="View" 
        CssClass="btn btn-info" onclick="btnView_Click" />
</td></tr>
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2">
<asp:Panel ID="pnlDetail" runat="server" BorderColor="Red" 
        BorderStyle="Ridge" BorderWidth="2px" style="padding:50px;"></asp:Panel>
</td></tr>
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2"><asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" 
        onclick="btnExportToPDF_Click" CssClass="btn btn-info" /></td></tr>

</table>
</ContentTemplate></asp:UpdatePanel>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="position:absolute; left: 40%; top: 40%;"><img src="../loading.gif" alt="" width="100" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    </div>
</section>
</asp:Content>

