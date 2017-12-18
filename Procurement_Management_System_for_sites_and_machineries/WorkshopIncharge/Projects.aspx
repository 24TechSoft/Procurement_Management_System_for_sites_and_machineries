<%@ Page Title="" Language="C#" MasterPageFile="Worker.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="Admin_Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
    <div class="row">
    
<!-- Projects -->
    <div class="col-lg-6">
    <asp:Panel ID="pnlProject" runat="server">
        <div class="form-group">
        <label>Project Name:</label>
        <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
        <label>Project Start Date</label>
        <asp:TextBox ID="txtProjectDate" runat="server" CssClass="form-control" placeholder="mm/dd/yyyy" type="date"></asp:TextBox>
        </div>
        <asp:Button ID="btnSaveProject" runat="server" Text="Save" 
            CssClass="btn btn-default" onclick="btnSaveProject_Click" />

        <asp:GridView ID="grdProject" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-Font-Bold="true"
        GridLines="Horizontal" Width="100%" OnRowDeleting="grdProject_RowDeleting" 
       onrowcancelingedit="grdProject_RowCancelingEdit"
            onrowediting="grdProject_RowEditing" onrowupdating="grdProject_RowUpdating" 
            onselectedindexchanging="grdProject_SelectedIndexChanging">
        <FooterStyle CssClass="TableFooterClass" />
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Project Name">
<ItemTemplate>
<asp:Label ID="lblProjectName" runat="server" Text='<%#bind("ProjectName") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEProjectName" runat="server" Text='<%#bind("ProjectName") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Project Date">
<ItemTemplate>
<asp:Label ID="lblProjectDate" runat="server" Text='<%#bind("ProjectDate") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEProjectDate" runat="server" Text='<%#bind("ProjectDate") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowSelectButton="True" SelectText="Add Job" />
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblErrorProject" runat="server"></asp:Label></h4>
</asp:Panel>
    </div>
<!-- Jobs -->
    <div class="col-lg-6">
    <asp:Panel ID="pnlJobs" runat="server" Visible="false">
    <asp:HiddenField ID="hdPID" runat="server" />
        <div class="form-group">
        <label>Job Name:</label>
        <asp:TextBox ID="txtJobName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnSaveJob" runat="server" Text="Save" 
            CssClass="btn btn-default" onclick="btnSaveJob_Click" />

        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" OnRowDeleting="grdJobs_RowDeleting" 
        onrowcancelingedit="grdJobs_RowCancelingEdit" 
            onrowediting="grdJobs_RowEditing" onrowupdating="grdJobs_RowUpdating">
        <FooterStyle CssClass="TableFooterClass" />
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass"/>
<Columns>
<asp:TemplateField HeaderText="Job Name">
<ItemTemplate>
<asp:Label ID="lblJobName" runat="server" Text='<%#bind("JobName") %>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEJobName" runat="server" Text='<%#bind("JobName") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
    <asp:CommandField ShowEditButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblErrorJob" runat="server"></asp:Label></h4>
</asp:Panel>
    </div>
</div>
    </div>
</section>
</asp:Content>

