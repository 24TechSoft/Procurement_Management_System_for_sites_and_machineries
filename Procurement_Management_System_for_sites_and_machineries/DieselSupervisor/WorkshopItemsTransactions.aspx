<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="WorkshopItemsTransactions.aspx.cs" Inherits="Supervisor_WorkshopItemsTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="row">
<div class="col-lg-3">
<label>Item Name</label><br />
<asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" 
        AutoPostBack="true" ontextchanged="txtItemName_TextChanged"></asp:TextBox>
<asp:HiddenField ID="hdItemID" runat="server" />
<asp:GridView ID="grdItemList" runat="server" DataKeyNames="ID" ShowHeader="false" Visible="false" AutoGenerateColumns="false" OnRowDeleting="grdItemList_RowDeleting" Width="500px" GridLines="None">
<Columns>
<asp:BoundField DataField="ItemName" />
<asp:BoundField DataField="Description" />
<asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Select" />
</Columns>
</asp:GridView>
</div>
<div class="col-lg-3">
<label>Quantity</label><br />
<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Transaction Type</label><br />
<asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="form-control">
<asp:ListItem Value="1">In Stock</asp:ListItem>
<asp:ListItem Value="2">Out Stock</asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-lg-3">
<label><br /></label><br />
<asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn" 
        onclick="btnAdd_Click" />
</div>
</div>
<asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" ShowFooter="true"
        GridLines="Horizontal" Width="100%" OnRowDeleting="grdItems_RowDeleting" 
        onrowcancelingedit="grdItems_RowCancelingEdit" onrowediting="grdItems_RowEditing" 
        onrowupdating="grdItems_RowUpdating" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<FooterStyle BackColor="#009999" Font-Bold="True" ForeColor="White" />
<Columns>
<asp:TemplateField HeaderText="Item Name">
<ItemTemplate>
<asp:Label ID="lblItemName" runat="server" Text='<%#bind("ItemName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description">
<ItemTemplate>
<asp:Label ID="lblDescription" runat="server" Text='<%#bind("Description") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Entry Date">
<ItemTemplate>
<asp:Label ID="lblEntryDate" runat="server" Text='<%#bind("EntryDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Transaction Type">
<ItemTemplate>
<asp:Label ID="lblTansactionType" runat="server" Text='<%#bind("TansactionType") %>'></asp:Label>
</ItemTemplate>
<FooterTemplate>Total:</FooterTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Text='<%#bind("Quantity") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox runat="server" ID="txtEQuantity" Text='<%#bind("Quantity") %>'></asp:TextBox>
</EditItemTemplate>
<FooterTemplate>

</FooterTemplate>
</asp:TemplateField>
<asp:TemplateField>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Content>

