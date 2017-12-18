<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ViewIndent.aspx.cs" Inherits="Admin_ViewIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">

<table width="100%">
<tr><td>
<asp:Panel ID="pnlDetail" runat="server" Width="800px" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="1px" style="padding:10px; z-index:-1;">
</asp:Panel>
</td></tr>
<tr><td><br /></td></tr>
<tr><td>
<asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" 
        onclick="btnExportToPDF_Click" CssClass="btn btn-info" />
</td></tr>
<tr><td>
<asp:Panel ID="pnlApprove" runat="server" Visible="false">
            Approved By<br />
            <asp:TextBox ID="txtApprovedBy" runat="server" AutoPostBack="True" 
                ontextchanged="txtApprovedBy_TextChanged"></asp:TextBox>
                <asp:HiddenField ID="hdApprovedBy" runat="server" />
            <asp:GridView ID="grdApprovedBy" runat="server" ShowHeader="False" 
                GridLines="None" Visible="False" AutoGenerateColumns="False" 
                onrowdeleting="grdApprovedBy_RowDeleting" Width="100%" DataKeyNames="ID">
            <Columns>
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="UserType" />
            <asp:BoundField DataField="SiteName" />
                <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
            </Columns>
            </asp:GridView>
<br />
<asp:Button ID="btnApprove" runat="server" Text="Approve" onclick="btnApprove_Click" CssClass="btn btn-info" />
</asp:Panel>
</td></tr>
</table>
</asp:Content>

