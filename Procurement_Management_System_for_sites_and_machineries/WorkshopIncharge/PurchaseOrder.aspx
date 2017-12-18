<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="PurchaseOrder.aspx.cs" Inherits="Admin_PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<h1>Purchase Order</h1>

<div class="row">
<asp:GridView ID="grdPO" runat="server" AutoGenerateColumns="False" Font-Size="Small"
        GridLines="Horizontal" Width="100%" onrowdeleting="grdPO_RowDeleting" DataKeyNames="ID">
    <AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Reference No">
<ItemTemplate>
<asp:Label ID="lblRefNo" runat="server" Text='<%#bind("PORefNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Purchase Order Date">
<ItemTemplate>
<asp:Label ID="lblPODate" runat="server" Text='<%#bind("PODate")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indent Reference No">
<ItemTemplate>
<asp:Label ID="lblIndentRefNo" runat="server" Text='<%#bind("IndentRefNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Site">
<ItemTemplate>
<asp:Label ID="lblSite" runat="server" Text='<%#bind("Site") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indent Date">
<ItemTemplate>
<asp:Label ID="lblPreparedBy" runat="server" Text='<%#bind("PreparedBy")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Checked By">
<ItemTemplate>
<asp:Label ID="lblCheckedBy" runat="server" Text='<%#bind("CheckedBy")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Net Payable">
<ItemTemplate>
<asp:Label ID="lblNetPayable" runat="server" Text='<%#bind("NetPayable")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="View"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
    </div>
</section>
</asp:Content>

