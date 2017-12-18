<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="CreateIndent.aspx.cs" Inherits="Supervisor_CreateIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">


<!-- Items -->
<div class="row">
<div class="col-lg-12">
Refference No: <asp:Label ID="lblRef" runat="server" Text=""></asp:Label>
</div>
<div class="col-lg-3">
<label>Date</label><br />
<asp:TextBox ID="txtDate" runat="server"  type="date" placeholder="mm/dd/yyyy"
        AutoPostBack="true" ontextchanged="txtDate_TextChanged"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Select Project</label><br />
<asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="col-lg-3">
<label>Select Job</label><br />
<asp:DropDownList ID="ddlJob" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlJob_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="col-lg-3">
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" 
        onclick="btnSave_Click" />
</div>
<asp:Panel ID="pnlIndentItems" runat="server">
    <div class="col-lg-12">
        <h4>Indent Items</h4>
    </div>
    <div class="col-lg-3">
        <div class="form-group">
            Part No<br />
            <asp:TextBox ID="txtPartNo" runat="server" AutoPostBack="true"
                ontextchanged="txtPartNo_TextChanged"></asp:TextBox><br />
            <asp:Label ID="lblPartNo" runat="server"></asp:Label><br />
            <asp:Label ID="lblPartName" runat="server"></asp:Label>
        </div>
    </div>
    
    
    <div class="col-lg-6">
        <div class="form-group">
            Particular Detail<br />
            <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Rows="2" Enabled="false"
                style="resize:none;" Width="100%"></asp:TextBox>
        </div>
        <div class="form-group">
            Remarks<br />
            <asp:TextBox ID="txtRemarks" runat="server" style="resize:none" 
                TextMode="Multiline" Rows="2" Width="100%"></asp:TextBox>
        </div>
    </div>

    <div class="col-lg-3">
        <div class="form-group">
            Current Stock<br />
            <asp:TextBox ID="txtCurrentStock" runat="server" Width="100%" Enabled="False"></asp:TextBox>
        </div>
        <div class="form-group">
            Quantity<br />
            <asp:TextBox ID="txtQuantity" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div class="form-group">
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn" 
                onclick="btnAdd_Click" Width="45%" OnClientClick="return confirm('Are you sure?');" />
        <asp:Button ID="btnClear" runat="server" Text="Clear All" CssClass="btn" 
                onclick="btnClear_Click" Width="45%" OnClientClick="return confirm('Are you sure?');" />
        </div>
    </div>

    </asp:Panel>
    <asp:Panel ID="pnl1" runat="server" Width="100%">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>'
    <asp:UpdatePanel ID="pnlUpdate" runat="server">
    <ContentTemplate>
    <table width="100%" border="1">
    <tr style="font-weight:bold"><td>Quantity</td><td>Log Number</td><td>Part Number</td><td>Part Name</td><td>Current Stock</td><td>Remarks</td></tr>
    <tr>
    <td>
    <asp:TextBox ID="txtQuantity1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtLogNo1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtPartNo1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:Label ID="lblPartName1" runat="server"></asp:Label>
    </td>
    <td>
    <asp:Label ID="lblCurrentStock1" runat="server"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtRemark1" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
    </td>
    </tr>
        <tr>
    <td>
    <asp:TextBox ID="txtQuantity2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtLogNo2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox ID="txtPartNo2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:Label ID="lblPartName2" runat="server"></asp:Label>
    </td>
    <td>
    <asp:Label ID="lblCurrentStock2" runat="server"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtRemark2" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
    </td>
    </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>
    <div class="col-lg-12">
    <asp:GridView ID="grdIndentItems" runat="server" AutoGenerateColumns="False" 
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" 
        onrowdeleting="grdIndentItems_RowDeleting" 
            onrowcancelingedit="grdIndentItems_RowCancelingEdit" 
            onrowediting="grdIndentItems_RowEditing" 
            onrowupdating="grdIndentItems_RowUpdating" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Part No">
<ItemTemplate>
<asp:Label ID="lblPartNo" runat="server" Text='<%#bind("PartNo") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Particulars" ControlStyle-Width="200px">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblParticular" runat="server" Text='<%#bind("Particular") %>'></asp:Label>
</ItemTemplate>
<ControlStyle Width="200px"></ControlStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Current Stock" ControlStyle-Width="100px">
<ItemTemplate>
<asp:Label ID="lblCurrentStock" runat="server" Text='<%#bind("CurrentStock")%>'></asp:Label>
</ItemTemplate>

<ControlStyle Width="100px"></ControlStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity" ControlStyle-Width="75px">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Text='<%#bind("Quantity")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:HiddenField ID="hdEID" runat="server" Value='<%#bind("ID") %>' />
<asp:TextBox ID="txtEEQuantity" runat="server" Text='<%#bind("Quantity")%>'></asp:TextBox>
</EditItemTemplate>
<ControlStyle Width="75px"></ControlStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" ControlStyle-Width="200px">
<ItemTemplate>
<asp:Label ID="lblRemarks" runat="server" Text='<%#bind("Remarks")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtERemarks" runat="server" Text='<%#bind("Remarks") %>' TextMode="MultiLine" style="resize:none"></asp:TextBox>
</EditItemTemplate>
<ControlStyle Width="200px"></ControlStyle>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
    </div>
    <div class="col-lg-12">
    <asp:Button ID="btnNew" runat="server" Text="New Indent" CssClass="btn btn-default" 
            onclick="btnNew_Click" OnClientClick="return confirm('Are you sure?');" />
    </div>
</div>
<!-- Items -->
</asp:Content>

