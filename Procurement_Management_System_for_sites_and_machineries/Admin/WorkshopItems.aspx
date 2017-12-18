<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="WorkshopItems.aspx.cs" Inherits="Admin_WorkshopItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" ShowFooter="True"
        GridLines="Horizontal" Width="100%" OnRowDeleting="grdItems_RowDeleting" 
    onrowcancelingedit="grdItems_RowCancelingEdit" 
    onrowcommand="grdItems_RowCommand" onrowediting="grdItems_RowEditing" 
    onrowupdating="grdItems_RowUpdating">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass"/>
<Columns>
<asp:TemplateField HeaderText="Item Name">
<ItemTemplate>
<asp:Label ID="lblItemName" runat="server" Text='<%#bind("ItemName") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox runat="server" ID="txtEItemName" Text='<%#bind("ItemName") %>'></asp:TextBox>
</EditItemTemplate>
<FooterTemplate>
<asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
</FooterTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description">
<ItemTemplate>
<asp:Label ID="lblDecription" runat="server" Text='<%#bind("Description") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox runat="server" ID="txtEDescription" Text='<%#bind("Description") %>'></asp:TextBox>
</EditItemTemplate>
<FooterTemplate>
<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
</FooterTemplate>
</asp:TemplateField>
<asp:TemplateField>
<FooterTemplate>
<asp:Button ID="btnInsert" runat="server" Text="Save" CommandName="Add" />
</FooterTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
    </div>
</div>
</asp:Content>

