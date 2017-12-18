<%@ Page Title="User Master" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

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
        <h4 class="modal-title">Add New User</h4>
      </div>
      <div class="modal-body">
            <label>Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

            <label>User Type</label>
            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" Width="150px">
            <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
            <asp:ListItem Text="Workshop Incharge" Value="2"></asp:ListItem>
            <asp:ListItem Text="Diesel Supervisor" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <label>Email</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
    
            <label>Phone No</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            
            <label>Site Name</label>
            <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control" Width="200px">
            
            </asp:DropDownList>
          
            <label>Designation</label>
            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
         
            <label>Signature</label>
            <asp:FileUpload ID="Signature" runat="server" onChange="loadImage();" />
            <asp:Image ID="imgSignature" runat="server" Height="50px" Width="150px" /><br />
            
            <label>User ID</label>
            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control"></asp:TextBox>
            
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
           
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
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
        <h1>Users</h1>

<div class="form-group">
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add New</button>
</div>

<asp:Panel ID="pnlExisting" runat="server">
<div class="row">
<asp:GridView ID="grdUser" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" GridLines="None" Width="100%"
        onrowdeleting="grdUser_RowDeleting">
    <AlternatingRowStyle CssClass="TableAlternateRowClass"/>
<HeaderStyle CssClass="TableHeaderClass"/>
<RowStyle CssClass="TableRowClass" />
<Columns>
<asp:TemplateField HeaderText="User Type" ControlStyle-Width="100px">
<ItemTemplate>
<asp:Label ID="lblUserType" runat="server" Text='<%#bind("UserType") %>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" ControlStyle-Width="100px">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblName" runat="server" Text='<%#bind("Name")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Email"  ControlStyle-Width="150px">
<ItemTemplate>
<asp:Label ID="lblEmail" runat="server" Text='<%#bind("Email")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Phone No" ControlStyle-Width="75px">
<ItemTemplate>
<asp:Label ID="lblPhone" runat="server" Text='<%#bind("PhoneNo")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Site" ControlStyle-Width="150px">
<ItemTemplate>
<asp:Label ID="lblSite" runat="server" Text='<%#bind("SiteName")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Designation" ControlStyle-Width="100px">
<ItemTemplate>
<asp:Label ID="lblDesignation" runat="server" Text='<%#bind("Designation")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Signature" ControlStyle-Width="150px">
<ItemTemplate>
<asp:Image ID="imgSign" runat="server" ImageUrl='<%#bind("Signature") %>' Height="50px" Width="150px" />
</ItemTemplate>

    <ControlStyle Width="150px" />

</asp:TemplateField>
<asp:TemplateField HeaderText="User ID" ControlStyle-Width="75px">
<ItemTemplate>
<asp:Label ID="lblUserID" runat="server" Text='<%#bind("UserID")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Password" ControlStyle-Width="75px">
<ItemTemplate>
<asp:Label ID="lblPassword" runat="server" Text='<%#bind("Password")%>'></asp:Label>
</ItemTemplate>
    <ControlStyle Width="75px" />
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
<label>Name</label>
<asp:TextBox ID="txtEName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>User Type</label>
<asp:DropDownList ID="ddlEUserType" runat="server" CssClass="form-control" Width="150px">
<asp:ListItem Text="Admin" Value="1"></asp:ListItem>
<asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
<asp:ListItem Text="Worker" Value="3"></asp:ListItem>
</asp:DropDownList>
</div>
<div class="form-group">
<label>Email</label>
<asp:TextBox ID="txtEEmail" CssClass="form-control" runat="server"></asp:TextBox>
</div>
<div class="form-group">
<label>Phone No</label>
<asp:TextBox ID="txtEPhone" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Site Name</label>
<asp:DropDownList ID="ddlESite" runat="server" CssClass="form-control" Width="200px">

</asp:DropDownList>
</div>
<div class="form-group">
<label>Designation</label>
<asp:TextBox ID="txtEDesignation" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Signature</label>
<asp:FileUpload ID="ESignature" runat="server" onChange="loadImage();" />
<asp:Image ID="imgESignature" runat="server" Height="50px" Width="150px" />
</div>
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" 
        onclick="btnUpdate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" 
        OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" 
        onclick="btnDelete_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-info" 
        onclick="btnCancel_Click" />
</div>
</asp:Panel>
</div>
</section>
</asp:Content>

