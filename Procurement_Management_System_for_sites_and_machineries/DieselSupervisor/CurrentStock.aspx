<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="CurrentStock.aspx.cs" Inherits="Supervisor_CurrentStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="row">
</div>
<asp:Panel ID="pnlNew" runat="server">
<div class="row">
<div class="col-lg-3">
<label>Part No</label><br />
<asp:TextBox ID="txtPartNo" runat="server" AutoPostBack="true" OnTextChanged="txtPartNo_TextChanged"></asp:TextBox>
<asp:HiddenField ID="hdMachineID" runat="server" />
<asp:HiddenField ID="hdPartID" runat="server" />
</div>
<div class="col-lg-3">
<label>Entry Date</label><br />
<asp:TextBox ID="txtEntryDate" runat="server" type="date" placeholder="mm/dd/yyyy"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Quantity</label><br />
<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Bill Ref</label><br />
<asp:TextBox ID="txtBillRef" runat="server"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Transaction Type</label><br />
<asp:DropDownList ID="ddlTransactionType" runat="server">
<asp:ListItem Value="1">In Stock</asp:ListItem>
<asp:ListItem Value="2">Out Stock</asp:ListItem>
<asp:ListItem Value="3">Damaged</asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-lg-3">
<label><br /></label><br />
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" 
        onclick="btnSave_Click" />
</div>
</div>
</asp:Panel>
<asp:Panel ID="pnlExisting" runat="server">
<div class="row">
<asp:GridView ID="grdParts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" OnRowDeleting="grdParts_RowDeleting" 
        onrowcancelingedit="grdParts_RowCancelingEdit" 
        onrowediting="grdParts_RowEditing" onrowupdating="grdParts_RowUpdating" 
        ShowFooter="True"  BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Machine">
<ItemTemplate>
<asp:Label ID="lblMachine" runat="server" Text='<%#bind("MachineID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Part">
<ItemTemplate>
<asp:Label ID="lblPart" runat="server" Text='<%#bind("PartID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date">
<ItemTemplate>
<asp:Label ID="lblEntryDate" runat="server" Text='<%#bind("EntryDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reference">
<ItemTemplate>
<asp:Label ID="lblBillRef" runat="server" Text='<%#bind("BillRef") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEBillRef" runat="server" Text='<%#bind("BillRef") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Transaction Type">
<ItemTemplate>
<asp:Label ID="lblTransaction" runat="server" Text='<%#bind("TransactionType") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Text='<%#bind("Quantity") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEQuantity" runat="server" Text='<%#bind("Quantity") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>

</asp:Content>

