<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SiteIndent.aspx.cs" Inherits="Admin_SiteIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
    Select Site: <asp:DropDownList ID="ddlSites" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSites_SelectedIndexChanged">

</asp:DropDownList><br />
    <asp:GridView ID="grdIndent" runat="server" AutoGenerateColumns="False" 
 DataKeyNames="ID" GridLines="None" Width="100%" onrowdeleting="grdIndent_RowDeleting">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Reference No">
<ItemTemplate>
<asp:Label ID="lblRefNo" runat="server" Text='<%#bind("RefNo")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtERefNo" runat="server" Text='<%#bind("RefNo") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Project No">
<ItemTemplate>
<asp:Label ID="lblProjectNo" runat="server" Text='<%#bind("ProjectNo")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEProjectNo" runat="server" Text='<%#bind("ProjectNo") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Job No">
<ItemTemplate>
<asp:Label ID="lblJobNo" runat="server" Text='<%#bind("JobNo")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEJobNo" runat="server" Text='<%#bind("JobNo") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indent Date">
<ItemTemplate>
<asp:Label ID="lblIndentDate" runat="server" Text='<%#bind("IndentDate")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEIndentDate" runat="server" Text='<%#bind("IndentDate") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indentor">
<ItemTemplate>
<asp:Label ID="lblIndentor" runat="server" Text='<%#bind("Indentor")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEIndentor" runat="server" Text='<%#bind("Indentor") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Approved By">
<ItemTemplate>
<asp:Label ID="lblApprovedBy" runat="server" Text='<%#bind("ApprovedBy")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEApprovedBy" runat="server" Text='<%#bind("ApprovedBy") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status">
<ItemTemplate>
<asp:Label ID="lblStatus" runat="server" Text='<%#bind("Status")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" DeleteText="View" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</div>
</asp:Content>

