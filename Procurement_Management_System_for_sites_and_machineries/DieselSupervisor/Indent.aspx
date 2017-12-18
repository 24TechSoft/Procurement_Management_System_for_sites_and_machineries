<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="Indent.aspx.cs" Inherits="Supervisor_Indent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<h1>Indents</h1>

<div class="row">
<asp:GridView ID="grdIndent" runat="server" AutoGenerateColumns="False" 
 DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" onrowdeleting="grdIndent_RowDeleting" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Reference No">
<ItemTemplate>
<asp:Label ID="lblRefNo" runat="server" Text='<%#bind("RefNo")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
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
<asp:TextBox ID="txtEIndentDate" runat="server" Text='<%#bind("IndentDate") %>' type="date" placeholder="mm/dd/yyyy"></asp:TextBox>
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
    <asp:CommandField ShowDeleteButton="True" DeleteText="View" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Content>

