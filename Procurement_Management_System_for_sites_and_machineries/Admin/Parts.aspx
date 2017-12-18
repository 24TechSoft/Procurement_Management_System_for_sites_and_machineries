<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Parts.aspx.cs" Inherits="Admin_Parts" %>

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
        <h4 class="modal-title">Add New Part</h4>
      </div>
      <div class="modal-body">
        <label>Machine</label>
        <asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Width="200px">
        </asp:DropDownList>
        
        <label>Serial No</label>
        <asp:TextBox ID="txtSerial" runat="server" CssClass="form-control"></asp:TextBox>

        <label>Part Name</label>
        <asp:TextBox ID="txtPartName" runat="server" CssClass="form-control"></asp:TextBox>

        <label>Description</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>

        <label>Price</label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>

        <label>Photo</label>
        <asp:FileUpload onchange="Preview();" ID="Photo" runat="server" />
        <asp:Image Height="200px" Width="300px" runat="server" ID="imgPhoto" />

        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnSave_Click" />
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
<h1>Parts</h1>
<div class="form-group">
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New</button>
</div>
<asp:Panel ID="pnlExisting" runat="server">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

<div class="form-group">
<asp:TextBox ID="txtSearch" runat="server"
        placeholder="Type here to search by Serial No, Part Name, Machine Name or Description" 
        CssClass="form-control" OnTextChanged="txtSearch_Changed" AutoPostBack="true" ></asp:TextBox>
</div>

<div class="row">
<asp:GridView ID="grdParts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        GridLines="None" Width="100%" EnableModelValidation="True" 
        onrowdeleting="grdParts_RowDeleting" AllowPaging="True" PageSize="50" 
        onpageindexchanging="grdParts_PageIndexChanging">
    <AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
    <PagerStyle CssClass="TablePagerClass"/>
<RowStyle BackColor="White" ForeColor="Black" CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Machine Name">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblMachineName" runat="server" Text='<%#bind("ModelNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Part No">
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
    <asp:CommandField ShowDeleteButton="True" DeleteText="Edit" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>

<asp:Panel ID="pnlUpdate" runat="server" Visible="false">
<div class="row">
<asp:HiddenField ID="hdEID" runat="server" />
<div class="form-group">
<label>Machine</label>
<asp:DropDownList ID="ddlEMachine" runat="server" CssClass="form-control" Width="200px">
</asp:DropDownList>
</div>
<div class="form-group">
<label>Serial No</label>
<asp:TextBox ID="txtESerial" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Part Name</label>
<asp:TextBox ID="txtEPartName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Description</label>
<asp:TextBox ID="txtEDescription" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
</div>
<div class="form-group">
<label>Price</label>
<asp:TextBox ID="txtEPrice" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Photo</label>
<asp:FileUpload ID="EPhoto" runat="server" />
<asp:Image ID="imgEPhoto" Height="200px" Width="300px" runat="server" />
</div>

<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" 
        OnClientClick="return confirm('Are You Sure?');" 
        onclick="btnUpdate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" 
        onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" 
        onclick="btnCancel_Click" />
</div>
</asp:Panel>
</div>
</section>
</asp:Content>

