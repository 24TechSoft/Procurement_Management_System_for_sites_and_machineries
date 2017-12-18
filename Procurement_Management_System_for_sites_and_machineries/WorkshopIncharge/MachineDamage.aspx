<%@ Page Title="" Language="C#" MasterPageFile="Worker.master" AutoEventWireup="true" CodeFile="MachineDamage.aspx.cs" Inherits="Admin_MachineDamage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnl" runat="server">
<ContentTemplate>
    <table width="100%">
<tr><td colspan="2"><h4>Machine Damage Entries</h4><br /></td></tr>
<tr><td colspan="2"><asp:Button ID="btnExisting" runat="server" Text="Show Existing" 
        CssClass="btn btn-info" onclick="btnExisting_Click" />
<asp:Button ID="btnNew" runat="server" Text="Add New" CssClass="btn btn-info" 
        onclick="btnNew_Click" /><br />
</td></tr>
<asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
<tr valign="bottom">
<td>
<label>Date</label><br />
<asp:TextBox ID="txtDate" runat="server" Width="200px" Type="Date" CssClass="form-control"></asp:TextBox>
</td>
<td><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
        onclick="btnSave_Click" /></td>
</tr>
<tr><td colspan="3">
<br />
</td></tr>
<tr><td colspan="3">
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
        GridLines="Horizontal" Width="100%" Font-Size="Small">
<HeaderStyle CssClass="TableHeaderClass" />
<Columns>
<asp:BoundField HeaderText="SL" DataField="SL" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:TemplateField HeaderText="Breakdown">
<ItemTemplate>
<asp:CheckBox ID="chkBreak" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
<asp:HiddenField ID="hdSiteMachineID" runat="server" Value='<%#bind("SiteMachineID") %>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indent Reference">
<Itemtemplate>
<asp:TextBox ID="txtIndent" runat="server" AutoPostBack="true" OnTextChanged="txtIndent_TextChange"></asp:TextBox>
<asp:HiddenField ID="hdIndentID" runat="server"/>
</Itemtemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</td></tr>
</asp:Panel>
<tr><td>
<asp:Panel ID="pnlExisting" runat="server">
<asp:GridView ID="grdDamage" runat="server" AutoGenerateColumns="False" 
        GridLines="Horizontal" Width="100%" Font-Size="Small" DataKeyNames="ID"
        onrowdeleting="grdDamage_RowDeleting" 
        onselectedindexchanging="grdDamage_SelectedIndexChanging">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass"/>
<Columns>
<asp:TemplateField HeaderText="Site">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#bind("Site") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Machine">
<ItemTemplate>
<asp:Label ID="lblAddress" runat="server" Text='<%#bind("Machine")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EntryDate">
<ItemTemplate>
<asp:Label ID="lblPhone" runat="server" Text='<%#bind("EntryDate")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:Label ID="lblEmail" runat="server" Text='<%#bind("Remarks")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Indent">
<ItemTemplate>

</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                CommandName="Select" Text="Add Existing Indent"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>

<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Panel>
</td></tr>
</table>

<asp:Panel ID="pnlUpdate" runat="server" Visible="false" style="position:absolute; width:100%; height:100%;left:0px;top:0px;background-color:rgba(0,0,0,0.8)">
<div style="top:30%; left:40%; position:absolute; padding:50px; background:#fff; border:1px solid #f00;">
<asp:TextBox ID="txtEIndent" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnTextChanged="txtEIndent_TextChanged"></asp:TextBox><br />
<asp:HiddenField ID="hdEIndentID" runat="server" />
<asp:Button ID="btnUpdate" CssClass="btn btn-info" Text="Update" runat="server" 
        onclick="btnUpdate_Click" />
<asp:Button ID="btnCancel" CssClass="btn btn-info" Text="Cancel" runat="server" 
        onclick="btnCancel_Click" />

</div>
</asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="position:absolute; left: 40%; top: 40%;"><img src="../loading.gif" alt="" width="100" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    </div>
</section>
</asp:Content>

