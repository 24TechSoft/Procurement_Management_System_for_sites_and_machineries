<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="PendingMachineryUsage.aspx.cs" Inherits="Supervisor_PendingMachineryUsage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CHPHeader" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<h3>Pending For Approval</h3>
<asp:GridView ID="grdMachineryUsage" runat="server" AutoGenerateColumns="False" 
 DataKeyNames="ID" onrowdeleting="grdMachineryUsage_RowDeleting" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="X-Small" 
        onrowcommand="grdMachineryUsage_RowCommand">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Entry Time">
<ItemTemplate>
<asp:Label ID="lblEntryTime" runat="server" Text='<%#bind("EntryTime")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Machine">
<ItemTemplate>
<asp:Label ID="lblMachine" runat="server" Text='<%#bind("Machine")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Starting Reading">
<ItemTemplate>
<asp:Label ID="lblStartReading" runat="server" Text='<%#bind("StartingReading")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Closing Reading">
<ItemTemplate>
<asp:Label ID="txtClosingReading" runat="server" Text='<%#bind("ClosingReading")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Working Hours">
<ItemTemplate>
<asp:Label ID="lblWorkingHours" runat="server" Text='<%#bind("WorkingHours")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Idle">
<ItemTemplate>
<asp:Label ID="lblIdle" runat="server" Text='<%#bind("Idle")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="B/D">
<ItemTemplate>
<asp:Label ID="lblDB" runat="server" Text='<%#bind("DB")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Available Hours">
<ItemTemplate>
<asp:Label ID="lblAvailableHours" runat="server" Text='<%#bind("AvailableHours")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="HSD Lub">
<ItemTemplate>
<asp:Label ID="lblHSDLub" runat="server" Text='<%#bind("HSDLub")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EO Lub">
<ItemTemplate>
<asp:Label ID="lblEOLub" runat="server" Text='<%#bind("EOLub")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="HO Lub">
<ItemTemplate>
<asp:Label ID="lblHOLub" runat="server" Text='<%#bind("HOLub")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="GO Lub">
<ItemTemplate>
<asp:Label ID="lblGOLub" runat="server" Text='<%#bind("GoLub")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Other Lub">
<ItemTemplate>
<asp:Label ID="lblOtherLub" runat="server" Text='<%#bind("OtherLub")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="HSDOil">
<ItemTemplate>
<asp:Label ID="lblHSDOil" runat="server" Text='<%#bind("HSDOil")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM">
<ItemTemplate>
<asp:Label ID="lblUOM" runat="server" Text='<%#bind("UOM")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Current Location">
<ItemTemplate>
<asp:Label ID="lblCurrentLocation" runat="server" Text='<%#bind("CurrentLocation")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Production">
<ItemTemplate>
<asp:Label ID="lblTotalProduction" runat="server" Text='<%#bind("TotalProduction")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
<ItemTemplate>
<asp:Label ID="lblRemarks" runat="server" Text='<%#bind("Remarks")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Entered By">
<ItemTemplate>
<asp:Label ID="lblEnteredBy" runat="server" Text='<%#bind("EnteredBy")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
    <asp:ButtonField CommandName="Approve" Text="Approve" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Content>

