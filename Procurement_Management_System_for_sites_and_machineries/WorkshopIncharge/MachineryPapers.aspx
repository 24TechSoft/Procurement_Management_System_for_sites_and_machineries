<%@ Page Title="" Language="C#" MasterPageFile="Worker.master" AutoEventWireup="true" CodeFile="MachineryPapers.aspx.cs" Inherits="Supervisor_MachineryPapers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<table width="100%">
<tr><td colspan="4">
<asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="btn" 
        onclick="btnAddNew_Click" />
<asp:Button ID="btnExisting" runat="server" Text="View Existing" CssClass="btn" 
        onclick="btnExisting_Click" />

</td></tr>
</table>
<asp:Panel ID="pnlNew" runat="server" Visible="false">
<table width="100%"><tr><td>
<label>Select Machine</label><br />
<asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
</td>
<td>
<label>Record Type</label><br />
<asp:DropDownList ID="ddlRecordName" runat="server" CssClass="form-control" Width="200px">
<asp:ListItem Value="Polution" Text="Polution"></asp:ListItem>
<asp:ListItem Value="Road Permit" Text="Road Permit"></asp:ListItem>
<asp:ListItem Value="Insurance" Text="Insurance"></asp:ListItem>
<asp:ListItem Value="RC" Text="RC"></asp:ListItem>
<asp:ListItem Value="Road Tax" Text="Road Tax"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<label>Record Number</label><br />
<asp:TextBox ID="txtRecordNo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td>
<label>Valid From</label><br />
<asp:TextBox ID="txtValidFrom" runat="server" CssClass="form-control" type="date" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<label>Valid To</label><br />
<asp:TextBox ID="txtValidTo" runat="server" CssClass="form-control" type="date" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox>
</td>
<td>
<label>Total Cost</label><br />
<asp:TextBox ID="txtTotalCost" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td>
<label>Remind before(days)</label><br />
<asp:TextBox ID="txtRemindBefore" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnSave" runat="server" CssClass="btn btn-default" Text="Save" 
        onclick="btnSave_Click" />
</td>
</tr>
</table>


</asp:Panel>
<asp:Panel ID="pnlExisitng" runat="server">
<asp:GridView ID="grdRecords" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" 
        onrowcancelingedit="grdRecords_RowCancelingEdit" 
        onrowdeleting="grdRecords_RowDeleting" onrowediting="grdRecords_RowEditing" 
        onrowupdating="grdRecords_RowUpdating">
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
  <asp:TemplateField HeaderText="Machine">
 <ItemTemplate>
 <asp:Label ID="lblMachine" runat="server" Text='<%#bind("Machine") %>'></asp:Label>
 </ItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Record Name">
 <ItemTemplate>
 <asp:Label ID="lblRecordName" runat="server" Text='<%#bind("RecordName") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtERecordName" runat="server" Text='<%#bind("RecordName") %>' Width="150"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Number">
 <ItemTemplate>
 <asp:Label ID="lblRecordValue" runat="server" Text='<%#bind("RecordValue") %>'></asp:Label>
 </ItemTemplate>
 <EditItemTemplate>
 <asp:TextBox ID="txtERecordValue" runat="server" Text='<%#bind("RecordValue") %>' Width="150px"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Valid From">
 <ItemTemplate>
 <asp:Label ID="lblValidFrom" runat="server" Text='<%#bind("ValidFrom") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtEValidFrom" runat="server" Text='<%#bind("ValidFrom") %>' Width="150px"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Valid To">
 <ItemTemplate>
 <asp:Label ID="lblValidTo" runat="server" Text='<%#bind("ValidTo") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtEValidTo" runat="server" Text='<%#bind("ValidTo") %>' Width="150px"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Total Cost">
 <ItemTemplate>
 <asp:Label ID="lblTotalCost" runat="server" Text='<%#bind("TotalCost") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtETotalCost" runat="server" Text='<%#bind("TotalCost") %>' Width="150px"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Remind Before Days">
 <ItemTemplate>
 <asp:Label ID="lblRemindBeforeDays" runat="server" Text='<%#bind("RemindBeforeDays") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtERemindBeforeDays" runat="server" Text='<%#bind("RemindBeforeDays") %>' Width="150px"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
    <asp:CommandField ShowEditButton="True" />
    <asp:CommandField ShowDeleteButton="True" />
</Columns>
</asp:GridView>
</asp:Panel>
    </div>
</section>
</asp:Content>

