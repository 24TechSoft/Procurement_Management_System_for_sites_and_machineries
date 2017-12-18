<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DailyProgressEntry.aspx.cs" Inherits="Admin_DailyProgressEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $("input:text").focus(function () { $(this).select(); });
        $("input:text").onclick(function () { $(this).select(); });
    });
</script>
    <asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnl" runat="server">
<ContentTemplate>
<table width="100%" style="font-size:small">
<tr><td colspan="3"><h3>Daily Progress Report</h3></td></tr>
<tr><td>Select Site</td><td>Select Date</td><td>Select Shift</td></tr>
<tr>
<td>
<asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" CssClass="form-control" Width="200px"></asp:DropDownList>
</td>
<td>
<asp:TextBox ID="txtDate" runat="server" Type="Date" OnTextChanged="txtDate_TextChanged" AutoPostBack="true" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" CssClass="form-control" Width="200px">
<asp:ListItem Value="1" Text="Day"></asp:ListItem>
<asp:ListItem Value="2" Text="Night"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr><td colspan="3"><br /></td></tr>
<tr><td colspan="3">
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" Width="100%">
<Columns>
<asp:TemplateField HeaderText="SL">
<ItemTemplate>
<asp:Label ID="Serial" runat="server" Text='<%#bind("SL") %>'></asp:Label>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Machine">
<ItemTemplate>
<asp:Label ID="lblMachine" Text='<%#bind("Machine")%>' runat="server"></asp:Label>
<asp:HiddenField ID="hdSiteMachineID" runat="server" Value='<%#bind("SiteMachineID") %>' />
 </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Log No/Registration No">
<ItemTemplate> 
<asp:Label ID="lblLogNo" Text='<%#bind("LogNo")%>' runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Opening Reading">
<ItemTemplate>
<asp:TextBox ID="txtOpenReading" runat="server" Text='<%#bind("StartReading")%>' AutoPostBack="true" OnTextChanged="txtOpenReading_TextChanged" onfocus="this.select()"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fuel Issued">
<ItemTemplate>
<asp:TextBox ID="txtFuelIssued" runat="server" Text='<%#bind("FuelIssued")%>' AutoPostBack="true" OnTextChanged="txtFuelIssued_TextChanged" onfocus="this.select()"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Closing Reading">
<ItemTemplate>
<asp:TextBox ID="txtCloseReading" runat="server" Text='<%#bind("CloseReading")%>' AutoPostBack="true" OnTextChanged="txtCloseReading_TextChanged" onfocus="this.select()"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TotalReading">
<ItemTemplate>
<asp:TextBox ID="txtTotalReading" runat="server" Text='<%#bind("TotalReading")%>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Breakdown">
<ItemTemplate>
<asp:Label ID="lblDamage" runat="server" Text='<%#bind("Damage")%>'></asp:Label>
<asp:HiddenField ID="hdBreakdown" runat="server" Value='<%#bind("BreakDown")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:TextBox ID="txtRemarks" runat="server" Text='<%#bind("Remarks")%>' onfocus="this.select()"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
    <HeaderStyle BackColor="#2b3c59" ForeColor="White" />
</asp:GridView>
</td></tr>
<tr><td colspan="3"><asp:Button ID="btnSave" runat="server" Text="Save" 
        CssClass="btn btn-info" onclick="btnSave_Click" /></td></tr>
</table>


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

