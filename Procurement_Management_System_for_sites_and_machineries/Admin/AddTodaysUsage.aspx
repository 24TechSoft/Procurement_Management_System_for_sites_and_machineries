<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AddTodaysUsage.aspx.cs" Inherits="Admin_AddTodaysUsage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
<div class="container" style="width:99%;">
<asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnlMain" runat="server">
<ContentTemplate>
<h2>Machinery Usage</h2>
    <div class="row">
        <div class="col-md-4">
            <label>Entry Date</label><br />
            <asp:TextBox ID="txtDate" runat="server" Type="Date" AutoPostBack="True" 
        ontextchanged="txtDate_TextChanged" Width="200px" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Select Site</label><br />
            <asp:DropDownList ID="ddlSite" runat="server" Width="200px" AutoPostBack="True" 
                    onselectedindexchanged="ddlSite_SelectedIndexChanged" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label>Shift</label><br />
            <asp:DropDownList ID="ddlShift" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" CssClass="form-control">
            <asp:ListItem Value="1">Day</asp:ListItem>
            <asp:ListItem Value="2">Night</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
         <div class="col-md-4">
            <label>Available Fuel</label><br />
            <asp:TextBox ID="txtAvailableFuel" runat="server" Width="200px" CssClass="form-control" OnTextChanged="SiteFuel" AutoPostBack="true"></asp:TextBox>
         </div>
        <div class="col-md-4">
            <label>Fuel Issued</label><br />
            <asp:TextBox ID="txtFuelIssued" runat="server" Width="200px" CssClass="form-control" OnTextChanged="SiteFuel" AutoPostBack="true"></asp:TextBox>
         </div>
        <div class="col-md-4">
            <label>Fuel Balance</label><br />
            <asp:TextBox ID="txtFuelBalance" runat="server" Width="200px" CssClass="form-control" OnTextChanged="SiteFuel" AutoPostBack="true"></asp:TextBox>
         </div>
    </div>
    <div class="row">
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save" 
        OnClick="btnSave_Click" Width="200px" />
    </div>
    <div class="row">

    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" GridLines="Both" Font-Size="XX-Small">
    <HeaderStyle CssClass="TableHeaderClass"/>
    <RowStyle CssClass="TableRowClass" />
    <AlternatingRowStyle CssClass="TableAlternateRowClass" />
    <Columns>
    <asp:BoundField HeaderText="SL" DataField="SL" />
    <asp:TemplateField HeaderText="Machine">
    <ItemTemplate>
    <asp:Label ID="lblMachine" runat="server" Text='<%#bind("Machine") %>'></asp:Label>
    <asp:HiddenField ID="hdSiteMachineID" runat="server" Value='<%#bind("SiteMachineID") %>'/>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Opening KM Reading" ControlStyle-Width="70px">
    <ItemTemplate>
    <asp:TextBox ID="txtOpenKMReading" runat="server" Text='<%#bind("OpenKMReading") %>' OnTextChanged="KMReading" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Closing KM Reading" ControlStyle-Width="70px">
    <ItemTemplate>
    <asp:TextBox ID="txtCloseKMReading" runat="server" Text='<%#bind("CloseKMReading") %>' OnTextChanged="KMReading" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total KM Reading">
    <ItemTemplate>
    <asp:Label ID="lblTotalKMReading" Text='<%#bind("TotalKMReading") %>' runat="server"></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Opening HR Reading">
    <ItemTemplate>
    <div style="width:70px">
    <asp:TextBox ID="txtOpenHReading" runat="server" OnTextChanged="HRReading" Width="30px" Text='<%#bind("OpenHReading") %>' placeholder="HH" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    <!--label>:</!--label-->
    <asp:TextBox ID="txtOpenMReading" runat="server" OnTextChanged="HRReading" Width="30px" Text='<%#bind("OpenMReading") %>' placeholder="MM" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Closing HR Reading">
    <ItemTemplate>
    <div style="width:70px">
    <asp:TextBox ID="txtCloseHReading" runat="server" OnTextChanged="HRReading" Width="30px" Text='<%#bind("CloseHReading") %>' placeholder="HH" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    <!--label>:</label-->
    <asp:TextBox ID="txtCloseMReading" runat="server" OnTextChanged="HRReading" Width="30px" Text='<%#bind("CloseMReading") %>' placeholder="MM" onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total HR Reading">
    <ItemTemplate>
    <asp:Label ID="lblTotalHRReading" runat="server" Text='<%#bind("TotalHRReading") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Opening HSD Reading" ControlStyle-Width="70px">
    <ItemTemplate>
    <asp:TextBox ID="txtOpenHSDReading" runat="server" OnTextChanged="HSDReading" Text='<%#bind("OpenHSDReading") %>' onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="HSD Issue" ControlStyle-Width="70px">
    <ItemTemplate>
    <asp:TextBox ID="txtHSDIssue" runat="server" OnTextChanged="HSDReading" Text='<%#bind("HSDIssue") %>' onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Closing HSD Reading" ControlStyle-Width="70px">
    <ItemTemplate>
    <asp:TextBox ID="txtCloseHSDReading" runat="server" OnTextChanged="HSDReading" Text='<%#bind("CloseHSDReading") %>' onfocus="this.select();" AutoPostBack="true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total HSD Reading">
    <ItemTemplate>
    <asp:Label ID="lblTotalHSDReading" runat="server" Text='<%#bind("TotalHSDReading") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Breakdown">
    <ItemTemplate>
    <div style="width:70px">
    <asp:CheckBox ID="chkBreakdown" runat="server" Text="Breakdown" />
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Idle">
    <ItemTemplate>
    <div style="width:40px">
    <asp:CheckBox ID="chkIdle" runat="server" Text="Idle" />
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Driver Name" ControlStyle-Width="60px">
    <ItemTemplate>
    <asp:TextBox ID="txtDriver" runat="server" Text='<%#bind("Driver") %>' onfocus="this.select();"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks" ControlStyle-Width="120px">
    <ItemTemplate>
    <asp:TextBox ID="txtRemarks" runat="server" Text='<%#bind("Remarks") %>' onfocus="this.select();"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
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

