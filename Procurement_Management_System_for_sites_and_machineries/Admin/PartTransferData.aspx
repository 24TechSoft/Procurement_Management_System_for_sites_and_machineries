<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PartTransferData.aspx.cs" Inherits="Admin_PartTransferData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-6 col-sm-12">
                <label>Select Site</label>
                <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <label>Date From</label>
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" Width="200px" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <label>Date To</label>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" Width="200px" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" 
                onclick="btnShow_Click" />
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="row">
            <asp:GridView ID="grdData" runat="server" Width="100%" DataKeyNames="Reference" 
        AutoGenerateColumns="False" onrowdeleting="grdData_RowDeleting">
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
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Mark Delivered" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>

<RowStyle CssClass="TableRowClass"></RowStyle>
</asp:GridView>
        </div>
</div>

</asp:Content>

