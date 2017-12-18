<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="POTerms.aspx.cs" Inherits="Admin_POTerms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<!-- ID, PORefNo, PODate, IndentRefNo, QuotationNo, QuotationDate, Subject, PreparedBy, 
CheckedBy, CompanySign, TotalAmount, TaxName, TaxPercentage, DiscountPercentage, NetPayable, 
Status-->
<div class="row"><h3>Purchase Order Terms</h3></div>
<div class="row" style="background:#bbb">
    <div class="col-lg-3">
        <label>Reference No:</label><br /><asp:Label ID="lblRefNo" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3">
        <label>Purchase Order Date:</label><br /><asp:Label ID="lblPODate" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3">
        <label>Indent Ref No:</label><br /><asp:Label ID="lblIndentRefNo" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3">
        <label>Net Payable:</label><br /><asp:Label ID="lblNetPayable" runat="server"></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-lg-6">
        <label>Header</label><br />
        <asp:TextBox ID="txtHeader" runat="server"></asp:TextBox>
    </div>
    <div class="col-lg-6">
        <label>Detail</label>
        <asp:TextBox ID="txtDetail" Width="100%" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
    </div>
    <div class="col-lg-12">
        <asp:Button ID="btnSave" runat="server" Text="Add" CssClass="btn btn-default" 
            onclick="btnSave_Click" />
        <asp:Button ID="btnView" runat="server" Text="View Purchase Order" 
            CssClass="btn" onclick="btnView_Click" />
    </div>
</div>
<div class="row">
    <asp:GridView ID="grdTerms" runat="server" AutoGenerateColumns="False" Font-Size="Small"
        GridLines="Horizontal" Width="100%" onrowdeleting="grdTerms_RowDeleting" 
        onrowcancelingedit="grdTerms_RowCancelingEdit" 
        onrowediting="grdTerms_RowEditing" onrowupdating="grdTerms_RowUpdating" DataKeyNames="ID" BorderStyle="Inset" 
        BorderColor="#33CCCC">
    <AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#2b3c59" ForeColor="White" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Heading">
<ItemTemplate>
    <asp:Label ID="lblHeading" runat="server" Text='<%#bind("Heading") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
    <asp:TextBox ID="txtEHeading" runat="server" Text='<%#bind("Heading") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Heading">
<ItemTemplate>
    <asp:Label ID="lblDetail" runat="server" Text='<%#bind("Detail") %>' Width="200px"></asp:Label>
</ItemTemplate>
<EditItemTemplate>
    <asp:TextBox ID="txtEDetail" runat="server" Text='<%#bind("Detail") %>' Width="200px" TextMode="MultiLine" style="resize:none"></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
</div>
</asp:Content>

