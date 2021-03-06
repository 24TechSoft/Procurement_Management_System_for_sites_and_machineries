﻿<%@ Page Title="Manufacturer Master" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Manufacturer.aspx.cs" Inherits="Admin_Manufacturer" %>

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
        <h4 class="modal-title">Add New Supplier</h4>
      </div>
      <div class="modal-body">
            <label>Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

            <label>Address</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>

            <label>Phone No</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>

            <label>Email</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>

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
<h1>Supplier</h1>
<div class="form-group">
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New</button>
</div>
<asp:Panel ID="pnlExisting" runat="server">
<div class="row">
<asp:GridView ID="grdManufacturers" runat="server" AutoGenerateColumns="False" 
        GridLines="None" Width="100%" 
        onrowcancelingedit="grdManufacturers_RowCancelingEdit" 
        onrowediting="grdManufacturers_RowEditing" 
        onrowupdating="grdManufacturers_RowUpdating" 
        onrowdeleting="grdManufacturers_RowDeleting">
<AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="Name">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblName" runat="server" Text='<%#bind("Name")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:HiddenField ID="hdEID" runat="server" Value='<%#bind("ID") %>' />
<asp:TextBox ID="txtEName" runat="server" Text='<%#bind("Name") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:Label ID="lblAddress" runat="server" Text='<%#bind("Address")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEAddress" runat="server" Text='<%#bind("Address") %>' TextMode="MultiLine"></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Phone No">
<ItemTemplate>
<asp:Label ID="lblPhone" runat="server" Text='<%#bind("PhoneNo")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEPhone" runat="server" Text='<%#bind("PhoneNo") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
<ItemTemplate>
<asp:Label ID="lblEmail" runat="server" Text='<%#bind("Email")%>'></asp:Label>
</ItemTemplate>
<EditItemTemplate>
<asp:TextBox ID="txtEEmail" runat="server" Text='<%#bind("Email") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Del" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
        </ItemTemplate>
        <ControlStyle Font-Size="X-Small" />
    </asp:TemplateField>
    <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit"></asp:LinkButton>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
            &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
        </EditItemTemplate>
        <ControlStyle Font-Size="X-Small" />
    </asp:TemplateField>
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
    </div>
</section>
</asp:Content>

