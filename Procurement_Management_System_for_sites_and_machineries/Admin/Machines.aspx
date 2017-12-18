<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Machines.aspx.cs" Inherits="Admin_Machines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="pnlMachine" runat="server">
<ContentTemplate>
<div class="row">
<asp:Button ID="btnNew" runat="server" Text="Add New" CssClass="btn btn-default" 
        onclick="btnNew_Click" />
<asp:Button ID="btnExisting" runat="server" Text="View Existing" 
        CssClass="btn btn-default" onclick="btnExisting_Click" />
</div>

<div class="row">
<asp:Panel ID="pnlNew" runat="server" Visible="false">
<div class="col-lg-6">
<label>Machine</label><br />
<asp:TextBox ID="txtMachine" runat="server" CssClass="form-control" placeholder="Search machine here" AutoPostBack="true" OnTextChanged="txtMachine_TextChanged"></asp:TextBox>
<asp:HiddenField ID="hdMachine" runat="server" />
<asp:GridView ID="grdMachine" runat="server" DataKeyNames="ID" ShowHeader="false" Visible="false" AutoGenerateColumns="false" OnRowDeleting="grdMachine_RowDeleting" Width="500px" GridLines="Horizontal" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
<Columns>
<asp:BoundField DataField="SerialNo" />
<asp:BoundField DataField="ModelNo" />
<asp:BoundField DataField="Manufacturer" />
<asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Select" />
</Columns>
</asp:GridView>
</div>
<div class="col-lg-3">
<label>Log No</label><br />
<asp:TextBox ID="txtSerial" runat="server" CssClass="form-control" placeholder="Serial No"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Added On</label><br />
<asp:TextBox ID="txtAddedOn" runat="server" CssClass="form-control" placeholder="mm/dd/yyyy"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Unit of Interval</label><br />
<asp:TextBox ID="txtUnit" runat="server" CssClass="form-control" placeholder="Ex. KM, Hour, Day etc."></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Chessis No</label><br />
<asp:TextBox ID="txtThesisNo" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Engine No</label><br />
<asp:TextBox ID="txtEngineNo" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Registration No</label><br />
<asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-lg-12">
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" 
        onclick="btnSave_Click" OnClientClick="return confirm('Are you sure?');" />
</div>
</asp:Panel>
</div>
<div class="row">
<asp:Panel ID="pnlExisting" runat="server">
<asp:GridView ID="grdMachines" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="None" Width="100%" EnableModelValidation="True" OnRowDeleting="grdMachines_RowDeleting">
<AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:BoundField HeaderText="Site" DataField="Site" />
<asp:BoundField HeaderText="Machine" DataField="Machine" />
<asp:BoundField HeaderText="Serial No" DataField="SerialNo" />
<asp:BoundField HeaderText="Added On" DataField="AddedOn" />
<asp:BoundField HeaderText="Status" DataField="Status" />
<asp:BoundField HeaderText="Updated Date" DataField="UpdateDate" />
<asp:BoundField HeaderText="Usage Unit" DataField="UsageUnit" />
<asp:BoundField HeaderText="Chessis No" DataField="ThesisNo" />
<asp:BoundField HeaderText="Engine No" DataField="EngineNo" />
    <asp:CommandField DeleteText="Update" ShowDeleteButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Panel>
</div>
<div class="row">
<asp:Panel ID="pnlChange" runat="server" Visible="false">
<asp:HiddenField ID="hdEid" runat="server" />
<div class="col-lg-3">
Machine:
<asp:Label ID="lblMachine" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
Serial No:
<asp:Label ID="lblSerial" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
Added On:
<asp:Label ID="lblAddedOn" runat="server"></asp:Label>
</div>
<div class="col-lg-3">
Status:
<asp:DropDownList ID="ddlStatus" runat="server">
<asp:ListItem Value="1" Text="Working"></asp:ListItem>
<asp:ListItem Value="2" Text="Idle"></asp:ListItem>
<asp:ListItem Value="3" Text="Damaged"></asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-lg-3">
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
        onclick="btnUpdate_Click" />
</div>
</asp:Panel>
</div>
</ContentTemplate>
</asp:UpdatePanel>
    </div>
</div>
</asp:Content>

