<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ProductPartTransfer.aspx.cs" Inherits="Admin_ProductPartTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnlMain" runat="server">
<ContentTemplate>
    <div class="row">
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Date</label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" Width="200px"></asp:TextBox>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Source Site</label>
            <asp:DropDownList ID="ddlSourceSite" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Destination Site</label>
            <asp:DropDownList ID="ddlDestSite" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Driver Name</label>
            <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Driver Phone No</label>
            <asp:TextBox ID="txtDriverPh" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <label>Vehicle No</label>
            <asp:TextBox ID="txtVehicleNo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-3 col-md-6 col-sm-12">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
        onclick="btnSave_Click" />
        </div>
        <div class="col-lg-3 col-md-6 col-sm-12">
            <asp:Button ID="btnViewExisting" runat="server" Text="View Existing" 
        CssClass="btn btn-info" onclick="btnViewExisting_Click" />
        </div>
        <div class="clearfix"></div>
        <asp:GridView ID="grd" runat="server" Width="100%" AutoGenerateColumns="false">
<HeaderStyle CssClass="TableHeaderClass" />
<Columns>
    <asp:BoundField DataField="SL" HeaderText="SL"/>


    <asp:TemplateField HeaderText="Part No">
        <ItemTemplate>
    <asp:TextBox ID="txtPartNo" runat="server" AutoPostBack="true" OnTextChanged="txtPartNo_TextChanged"></asp:TextBox>
    <asp:HiddenField ID="hdPartID" runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Part Name">
        <ItemTemplate>
    <asp:TextBox ID="txtPartName" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Machine Name">
        <ItemTemplate>
    <asp:TextBox ID="txtMachineName" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
            <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="true" OnTextChanged="txtQuantity_TextChange"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Rate">
        <ItemTemplate>
    <asp:TextBox ID="txtRate" runat="server" Text="0" AutoPostBack="true" OnTextChanged="txtRate_TextChange"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="Total">
        <ItemTemplate>
    <asp:TextBox ID="txtTotal" runat="server" Text="0"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
        <div class="clearfix"></div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
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

