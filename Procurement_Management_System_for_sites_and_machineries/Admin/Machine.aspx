<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Machine.aspx.cs" Inherits="Admin_Machine" %>

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
        <h4 class="modal-title">Add New Machine</h4>
      </div>
      <div class="modal-body">
            <label>Serial No</label>
            <asp:TextBox ID="txtSerial" runat="server" CssClass="form-control"></asp:TextBox>
        
            <label>Model No</label>
            <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" ></asp:TextBox>
            
          <label>Supplier</label>
            <asp:DropdownList ID="ddlManufacturer" runat="server" CssClass="form-control" Width="200px">
            </asp:DropdownList>
        
            <label>Machine Type</label>
            <asp:DropdownList ID="ddlMachineType" runat="server" CssClass="form-control" Width="200px">
                <asp:ListItem Value="1" Text="Moveable"></asp:ListItem>
                <asp:ListItem Value="2" Text="Fixed"></asp:ListItem>
            </asp:DropdownList>
            
          <label>Description</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" style="resize:none" TextMode="MultiLine"></asp:TextBox>
        
            <label>Photo</label>
        <asp:FileUpload ID="Photo" runat="server" />
        <asp:Image ID="imgPhoto" runat="server" Height="150px" Width="200px" />
        
        <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" 
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
<h1>Machines</h1>
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New</button><br /><br />


<asp:Panel ID="pnlExisting" runat="server">
<div class="form-group">
<asp:TextBox ID="txtMachineName" runat="server" AutoPostBack="true" 
        placeholder="Type here to search by Model Name, Manufacturer, Serial No or Description" 
        CssClass="form-control" ontextchanged="txtMachineName_TextChanged"></asp:TextBox>
</div>
<div class="row">
<asp:GridView ID="grdMachine" runat="server" AutoGenerateColumns="False" 
        AllowPaging="true" PageSize="50"
        GridLines="None" Width="100%" EnableModelValidation="True" 
        onrowdeleting="grdMachine_RowDeleting" onpageindexchanging="grdMachine_PageIndexChanging">
    <AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass"/>
    <PagerStyle CssClass="TablePagerClass" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Serial No">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblSerial" runat="server" Text='<%#bind("SerialNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Model No">
<ItemTemplate>
<asp:Label ID="lblModel" runat="server" Text='<%#bind("ModelNo")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Manufacturer">
<ItemTemplate>
<asp:Label ID="lblManufacturer" runat="server" Text='<%#bind("Manufacturer")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Machine Type">
<ItemTemplate>
<asp:Label ID="lblType" runat="server" Text='<%#bind("MachineType")%>'></asp:Label>
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
<label>Serial No</label>
<asp:TextBox ID="txtESerial" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Model No</label>
<asp:TextBox ID="txtEModel" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
</div>
<div class="form-group">
<label>Manufacturer</label>
<asp:DropdownList ID="ddlEManufacturer" runat="server" CssClass="form-control" Width="200px">
</asp:DropdownList>
</div>
<div class="form-group">
<label>Machine Type</label>
<asp:DropdownList ID="ddlEMachineType" runat="server" CssClass="form-control" Width="200px">
<asp:ListItem Value="1" Text="Moveable"></asp:ListItem>
<asp:ListItem Value="2" Text="Fixed"></asp:ListItem>
</asp:DropdownList>
</div>
<div class="form-group">
<label>Description</label>
<asp:TextBox ID="txtEDescription" runat="server" CssClass="form-control" style="resize:none" TextMode="MultiLine"></asp:TextBox>
</div>
<div class="form-group">
<label>Photo</label>
<asp:FileUpload ID="EPhoto" runat="server" />
<asp:Image ID="imgEPhoto" runat="server" Height="150px" Width="200px" />
</div>
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnUpdate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" 
        OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" 
        onclick="btnDelete_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel"  CssClass="btn btn-default" 
        onclick="btnCancel_Click" />
</div>
</asp:Panel>
        </div>
    </section>
</asp:Content>

