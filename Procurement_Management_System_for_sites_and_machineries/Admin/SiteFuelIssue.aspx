<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SiteFuelIssue.aspx.cs" Inherits="Admin_SiteFuelIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
<div class="container">
   <div class="row">
       <div class="col-lg-3 col-md-6 col-sm-12">
           <asp:Button ID="btnShowExisting" runat="server" Text="Show Existing" 
        CssClass="btn btn-info" onclick="btnShowExisting_Click" />
       </div>
       <div class="col-lg-3 col-md-6 col-sm-12">
           <asp:Button ID="btnAddNew" runat="server" Text="Add New" 
        CssClass="btn btn-info" onclick="btnAddNew_Click" />
       </div>
   </div>
<asp:Panel ID="pnlExisting" runat="server" Width="100%" Visible="false">
<h4>Existing Data</h4>
    <div class="row">
        <div class="col-md-3">
            <label>Select Site</label>
            <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
        </div>
        <div class="col-md-3">
            <label>Date From</label>
            <asp:TextBox ID="txtDateFrom" runat="server" TextMode="Date" Width="200px" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Date To</label>
            <asp:TextBox ID="txtDateTo" runat="server" TextMode="Date" Width="200px" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnShow" runat="server" Text="Show Data" CssClass="btn btn-info" 
        onclick="btnShow_Click" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="false" Width="100%" GridLines="Both" 
            DataKeyNames="ID">
        <HeaderStyle CssClass="TableHeaderClass"/>
        <Columns>
        <asp:BoundField HeaderText="Date" DataField="IssueDate" />
        <asp:BoundField HeaderText="Issued Amount" DataField="InAmount" />
        <asp:BoundField HeaderText="Used Amount" DataField="OutAmount" />
        <asp:BoundField HeaderText="Balance" DataField="Balance" />
        <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
        </Columns>
        </asp:GridView>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlNew" Width="100%"><h4>New Data</h4>
<div class="row">
    <div class="col-lg-3 col-md-6 col-sm-12">
        <label>Date</label>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" Width="200px" 
        CssClass="form-control"></asp:TextBox>
    </div>
    <div class="col-lg-3 col-md-6 col-sm-12">
        <label>Price</label>
        <asp:TextBox ID="txtPrice" runat="server" Text="0" onfocus="this.select();" CssClass="form-control" Width="200px"></asp:TextBox>
    </div>
</div>
<asp:GridView ID="grdEntry" runat="server" AutoGenerateColumns="false" Width="100%" GridLines="Both" DataKeyNames="SiteID">
<HeaderStyle CssClass="TableHeaderClass" />
        <Columns>
        <asp:BoundField HeaderText="Site" DataField="Site" />
        <asp:BoundField HeaderText="Last Issue Date" DataField="LastEntry" />
       <asp:TemplateField HeaderText="Balance">
       <ItemTemplate>
       <asp:Label ID="lblBalance" runat="server" Text='<%#bind("Balance") %>'></asp:Label>
       </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Issue Amount">
       <ItemTemplate>
       <asp:TextBox ID="txtIssueAmount" runat="server" AutoPostBack="true" OnTextChanged="txtIssueAmount_TextChanged" Text="0" onfocus="this.select();"></asp:TextBox>
       </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Current Balance">
       <ItemTemplate>
       <asp:Label ID="lblCurrentBalance" runat="server"></asp:Label>
       </ItemTemplate>       
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Remarks">
       <ItemTemplate>
       <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
       </ItemTemplate>       
       </asp:TemplateField>
        </Columns>
</asp:GridView>
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
        onclick="btnSave_Click" />
</asp:Panel>
</div>
</section>
</asp:Content>

