<%@ Page Title="Tax Master" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Tax.aspx.cs" Inherits="Admin_Tax" %>

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
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Add New Tax</h4>
      </div>
      <div class="modal-body">
        <label>CGST</label>
        <asp:TextBox ID="txtCGST" runat="server" CssClass="form-control"></asp:TextBox>

        <label>SGST</label>
        <asp:TextBox ID="txtSGST" runat="server" CssClass="form-control"></asp:TextBox>
        <label>IGST</label>
        <asp:TextBox ID="txtIGST" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnAdd_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
<section>
<div class="container">
<h1>Tax</h1>
<div class="form-group">
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New</button>
</div>

<asp:Panel ID="pnlExisting" runat="server">
<div class="row">
<asp:GridView ID="grdTax" runat="server" AutoGenerateColumns="False" 
        GridLines="None" Width="100%" onrowdeleting="grdTax_RowDeleting">
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="CGST">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblCGST" runat="server" Text='<%#bind("CGST")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="SGST">
<ItemTemplate>
<asp:Label ID="lblSGST" runat="server" Text='<%#bind("SGST")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="IGST">
<ItemTemplate>
<asp:Label ID="lblIGST" runat="server" Text='<%#bind("IGST")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
</div>
</section>
</asp:Content>

