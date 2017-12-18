<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="WorkOrder.aspx.cs" Inherits="Admin_WorkOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
<table width="100%">
<tr><td><asp:Button ID="btnViewExisting" runat="server" Text="View Existing" 
        CssClass="btn btn-info" onclick="btnViewExisting_Click" />
<asp:Button ID="btnAddNew" runat="server" Text="Add New"  CssClass="btn btn-info" 
        onclick="btnAddNew_Click" />
</td></tr>
<tr><td colspan="2"><br /></td></tr>
<asp:Panel ID="pnlExisting" runat="server">
<tr><td>
<label>Search by Name</label><br />
<asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
<asp:Button ID="btnSearchByName" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearchByName_Click" />
</td><td>
<label>Search By Date</label><br />
<asp:TextBox ID="txtDateFrom" runat="server" Type="Date"  Width="160px"></asp:TextBox>
To
<asp:TextBox ID="txtDateTo" runat="server" Type="Date"  Width="160px"></asp:TextBox>
<asp:Button ID="btnSearchByDate" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearchByDate_Click" />
</td></tr>
<tr><td colspan="2">
<asp:GridView ID="grdExisting" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" AllowPaging="True" PageSize="30" 
        onpageindexchanging="grdExisting_PageIndexChanging">
    <AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass"/>
    <PagerStyle CssClass="TablePagerClass" />
<RowStyle CssClass="TableRowClass"/>
<Columns>
<asp:BoundField HeaderText="Date" DataField="IssueDate" />
<asp:BoundField HeaderText="Name" DataField="CName" />
<asp:BoundField HeaderText="Address" DataField="CAddress" />
<asp:BoundField HeaderText="Phone" DataField="CPhone" />
<asp:BoundField HeaderText="Email" DataField="CEmail" />
<asp:BoundField HeaderText="Subject" DataField="Subject" />
<asp:BoundField HeaderText="Detail" DataField="Detail" />
<asp:HyperLinkField HeaderText="File" DataNavigateUrlFields="UploadedFile" Text="Download" Target="_blank" />
    <asp:CommandField ShowDeleteButton="True" DeleteText="Edit" />
</Columns>
</asp:GridView>
</td></tr>
</asp:Panel>
<asp:Panel ID="pnlNew" runat="server" Visible="false">
<tr><td colspan="2">
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" Width="100%" Font-Size="X-Small">
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:BoundField HeaderText="SL" DataField="SL" />
<asp:TemplateField HeaderText="Issue Date">
<ItemTemplate>
<asp:TextBox ID="txtIssueDate" runat="server" Type="Date"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name">
<ItemTemplate>
<asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:TextBox ID="txtCAddress" runat="server" TextMode="MultiLine" Style="resize:none;"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Phone">
<ItemTemplate>
<asp:TextBox ID="txtCPhone" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
<ItemTemplate>
<asp:TextBox ID="txtCEmail" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subject">
<ItemTemplate>
<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Detail">
<ItemTemplate>
<asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Style="resize:none;"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="File">
<ItemTemplate>
<asp:FileUpload ID="file" runat="server" />
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</td></tr>
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2"><asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" /></td></tr>
</asp:Panel>
</table>
    </div>
</div>
</asp:Content>

