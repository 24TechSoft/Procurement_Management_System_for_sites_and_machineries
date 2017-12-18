<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CurrentStock.aspx.cs" Inherits="Admin_CurrentStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-12">
                <asp:Button ID="btnNew" runat="server" Text="Add New" CssClass="btn btn-info" 
        onclick="btnNew_Click" />
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12">
                <asp:Button ID="btnExisting" runat="server" Text="View Existing" 
        CssClass="btn btn-info" onclick="btnExisting_Click" />
            </div>
        </div>
<asp:Panel ID="pnlNew" runat="server" CssClass="row">
    <div class="col-md-3">
        <label>Date</label>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" Width="200px"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <label>Machines</label>
        <asp:DropDownList ID="ddlMachines" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
    </div>
    <div class="col-md-3">
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info" 
        onclick="btnClear_Click" />
    </div>
    <div class="col-md-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
        onclick="btnSave_Click" />
    </div>
    <div class="clearfix"></div>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" Font-Size="Small">
<HeaderStyle CssClass="TableHeaderClass" />
<Columns>
<asp:BoundField HeaderText="SL" DataField="SL" />
<asp:TemplateField HeaderText="Part No">
<ItemTemplate>
<asp:TextBox ID="txtPartNo" runat="server" AutoPostBack="true" OnTextChanged="txtPartNo_TextChanged"></asp:TextBox>
<asp:HiddenField ID="hdPartID" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Part Name">
<ItemTemplate>
<asp:Label ID="lblPartName" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reference">
<ItemTemplate>
<asp:TextBox ID="txtReference" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Transaction Type">
<ItemTemplate>
<asp:DropDownList ID="ddlTransactionType" runat="server">
<asp:ListItem Value="1">In Stock</asp:ListItem>
<asp:ListItem Value="2">Out Stock</asp:ListItem>
<asp:ListItem Value="3">Damaged</asp:ListItem>
</asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Rate">
<ItemTemplate>
<asp:TextBox ID="txtRate" OnTextChanged="txtRate_TextChanged" runat="server" AutoPostBack="true" onfocus="this.select();"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:TextBox ID="txtQuantity" OnTextChanged="txtQuantity_TextChanged" runat="server" AutoPostBack="true" onfocus="this.select();"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total">
<ItemTemplate>
<asp:Label ID="lblTotal" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</asp:Panel>
<asp:Panel ID="pnlExisting" runat="server" Visible="false" CssClass="row">
<table width="100%">
<tr>
<td>
<asp:GridView ID="grdAllStock" runat="server" Font-Size="Small" 
        AutoGenerateColumns="False" 
        onselectedindexchanging="grdAllStock_SelectedIndexChanging" Width="100%">
<HeaderStyle CssClass="TableHeaderClass"/>
<SelectedRowStyle BackColor="Gold" />
<Columns>
<asp:TemplateField HeaderText="Machine">
<ItemTemplate>
<asp:HiddenField ID="hdSiteMachineID" Value='<%#bind("SiteMachineID") %>' runat="server" />
<asp:Label ID="lblMachine" runat="server" Text='<%#bind("Machine") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField> 
<asp:TemplateField HeaderText="Part">
<ItemTemplate>
<asp:HiddenField ID="hdPartID" Value='<%#bind("PartID") %>' runat="server" />
<asp:Label ID="lblPartName" runat="server" Text='<%#bind("Part") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HeaderText="Quantity" DataField="Quantity" />
    <asp:CommandField SelectText="Detail" ShowSelectButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError1" runat="server"></asp:Label></h4>
</td>

<td>
<asp:GridView ID="grdParts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Both" OnRowDeleting="grdParts_RowDeleting" 
        onrowcancelingedit="grdParts_RowCancelingEdit" 
        onrowediting="grdParts_RowEditing" onrowupdating="grdParts_RowUpdating">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
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
<asp:TemplateField HeaderText="Rate">
<ItemTemplate>
<asp:Label ID="lblRate" runat="server" Text='<%#bind("Rate") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtERate" runat="server" Text='<%#bind("Rate") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total">
<ItemTemplate>
<asp:Label ID="lblTotalPrice" runat="server" Text='<%#bind("Total") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:Label ID="lblRemarks" runat="server" Text='<%#bind("Remarks") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit"></asp:LinkButton>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
        </EditItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</td>
</tr>
</table>

</asp:Panel>
        </div>
    </section>
</asp:Content>

