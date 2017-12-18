<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SitePartRequest.aspx.cs" Inherits="Admin_SitePartRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<script type="text/javascript">
    function DisplayImage(x) {
        var y = document.getElementById(x);
            document.getElementById("popupimg").src = y.src;
            document.getElementById("popup").style.display = "block";
        
    }
    function CloseDiv() {
        document.getElementById("popup").style.display="none";
    }
</script>
<div id="popup" style="width:100%; height:100%; background:rgba(255,255,255,.8); position:fixed; top:0px; left:0px; display:none; z-index:1; text-align:center; vertical-align:middle;" >
<a class="btn btn-danger" onclick="CloseDiv();" style="float:right;">Close</a><br />
<img id="popupimg" alt="No Image To display" width="500px" style="font-size:x-large" align="center"/>
</div>

<div class="row">
<div class="col-lg-3">
<label>Select Site</label><br />
<asp:DropDownList ID="ddlSites" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlSites_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
</div>
</div>
<div class="row">
<asp:GridView ID="grdParts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" 
        onrowcancelingedit="grdParts_RowCancelingEdit" 
        onrowediting="grdParts_RowEditing" onrowupdating="grdParts_RowUpdating"  BorderStyle="Inset" 
        BorderColor="#33CCCC" Font-Size="Small" 
        onrowdeleting="grdParts_RowDeleting">
    <AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#2b3c59" ForeColor="White" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Site">
<ItemTemplate><asp:Label ID="lblSite" runat="server" Text='<%#bind("Site") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="User Name">
<ItemTemplate><asp:Label ID="lblUser" runat="server" Text='<%#bind("UserName") %>'></asp:Label></ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date">
<ItemTemplate>
<asp:Label ID="lblDate" runat="server" Text='<%#bind("EntryDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
  <asp:TemplateField HeaderText="Part No">
 <ItemTemplate>
 <asp:Label ID="lblPartNo" runat="server" Text='<%#bind("PartNo") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:TextBox ID="txtEPartNo" runat="server" Text='<%#bind("PartNo") %>' Width="150"></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Description">
<ItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#bind("Description") %>' Width="200px"></asp:Label></ItemTemplate>
</asp:TemplateField>
  <asp:TemplateField HeaderText="Photo">
 <ItemTemplate>
<asp:Image ID="imgPhoto" runat="server" ImageUrl='<%#bind("Photo") %>' Width="100px" Height="100px" onclick="DisplayImage(this.id);" />
 </ItemTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Status">
 <ItemTemplate>
 <asp:Label ID="lblStatus" runat="server" Text='<%#bind("Status") %>'></asp:Label>
 </ItemTemplate>
  <EditItemTemplate>
 <asp:DropdownList ID="ddlEStatus" runat="server" Width="150px">
 <asp:ListItem Value="0" Text="Pending For Approval"></asp:ListItem>
 <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
 </asp:DropdownList>
 </EditItemTemplate>
 </asp:TemplateField>
    <asp:CommandField ShowEditButton="True" />
    <asp:CommandField ShowDeleteButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>

</asp:Content>

