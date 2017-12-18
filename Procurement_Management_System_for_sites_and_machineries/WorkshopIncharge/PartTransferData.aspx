<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="PartTransferData.aspx.cs" Inherits="Admin_PartTransferData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<table width="100%">
<tr>
<td>
<label>Date From</label>
<asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" Width="200px" TextMode="Date"></asp:TextBox>
</td>
<td>
<label>Date To</label>
<asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" Width="200px" TextMode="Date"></asp:TextBox>
</td>
<td align="right">
<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
        onclick="btnShow_Click" />
</td>
</tr>
<tr><td colspan="3">
<br />
</td></tr>
<tr><td colspan="3">
<asp:GridView ID="grdData" runat="server" Width="100%" DataKeyNames="Reference" 
        RowStyle-Font-Size="XX-Small" HeaderStyle-Font-Size="X-Small" 
        AutoGenerateColumns="False">
<HeaderStyle CssClass="TableHeaderClass"/>
<Columns>
<asp:BoundField HeaderText="Date" DataField="EntryDate" />
<asp:BoundField HeaderText="Reference No" DataField="Reference" />
<asp:BoundField HeaderText="Source Site" DataField="SourceSiteName" />
<asp:BoundField HeaderText="Destination Site" DataField="DestSiteName" />
<asp:BoundField HeaderText="Vehicle No" DataField="VehicleNo" />
<asp:BoundField HeaderText="Driver Name" DataField="DriverName" />
<asp:BoundField HeaderText="Driver Phone No" DataField="DriverPh" />
<asp:BoundField HeaderText="Current Status" DataField="CurrStatus" />
<asp:TemplateField><ItemTemplate></ItemTemplate></asp:TemplateField>
</Columns>

<RowStyle Font-Size="XX-Small"></RowStyle>
</asp:GridView>
</td></tr>
</table>
    </div>
</section>
</asp:Content>

