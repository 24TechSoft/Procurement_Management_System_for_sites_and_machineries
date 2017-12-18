<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="Parts.aspx.cs" Inherits="Worker_Parts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<script type="text/javascript">
    function loadImage() {
        var file = document.getElementById('CPH1_Signature').files[0]; //sames as here
        var reader = new FileReader();
        reader.onloadend = function () {
            document.getElementById("CPH1_imgSignature").src = reader.result;
        };
        if (file) {
            reader.readAsDataURL(file); //reads the data as a URL
        }
        else {
            alert("error");
        }
    };
</script>
<section>
    <div class="container">
<h1>Parts</h1>
Select Machine:<asp:DropDownList ID="ddlSiteMachine" runat="server" OnSelectedIndexChanged="ddlSiteMachine_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<asp:Panel ID="pnlExisting" runat="server">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>



<div class="row">
<asp:GridView ID="grdParts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" 
         Font-Size="Small" AllowPaging="True" PageSize="30" 
        onpageindexchanging="grdParts_PageIndexChanging">
    <AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
    <PagerStyle CssClass="TablePagerClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Machine Name">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblMachineName" runat="server" Text='<%#bind("ModelNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Serial No">
<ItemTemplate>
<asp:Label ID="lblSerial" runat="server" Text='<%#bind("SerialNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Part Name">
<ItemTemplate>
<asp:Label ID="lblPartName" runat="server" Text='<%#bind("PartName")%>'></asp:Label>
</ItemTemplate>

</asp:TemplateField>
<asp:TemplateField HeaderText="Description">
<ItemTemplate>
<asp:Label ID="lblDescription" runat="server" Text='<%#bind("PartDescription")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>

    </div>
</section>
</asp:Content>

