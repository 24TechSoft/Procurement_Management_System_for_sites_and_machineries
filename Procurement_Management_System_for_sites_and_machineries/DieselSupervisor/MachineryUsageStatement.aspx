<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="MachineryUsageStatement.aspx.cs" Inherits="Admin_MachineryUsageStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnlMain" runat="server">
<ContentTemplate>

<table width="100%">
<tr valign="bottom" align="center"><td>Date From<br />
<asp:TextBox ID="txtDateFrom" runat="server" type="date" CssClass="form-control" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox>
</td>
<td>Date To<br />
<asp:TextBox ID="txtDateTo" runat="server" type="date" CssClass="form-control" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox></td>

<td>Machine Name<br />
<asp:DropDownList ID="ddlMachine" CssClass="form-control" runat="server" Width="200px"></asp:DropDownList>
</td>
<td>
<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
        onclick="btnShow_Click" />
</td></tr>
<tr><td colspan="3"><br /></td></tr>
</table>
<asp:Panel ID="pnlData" runat="server" style="padding:10px; border: ridge 2px #0f0;"></asp:Panel>
<br />
<asp:Button ID="btnExport" runat="server" Text="Export To PDF" 
        CssClass="btn btn-info" onclick="btnExport_Click" />
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="position:absolute; left: 40%; top: 40%;"><img src="../loading.gif" alt="" width="100" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
</asp:Content>

