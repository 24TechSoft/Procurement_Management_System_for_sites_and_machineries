<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Admin_UserProfile" %>

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
<div class="container">
    <div class="row">
<h1>My Profile</h1>
<div class="form-group">
<label>User Type</label>
<asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" Width="150px">
<asp:ListItem Text="Admin" Value="1"></asp:ListItem>
<asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
<asp:ListItem Text="Worker" Value="3"></asp:ListItem>
</asp:DropDownList>
</div>
<div class="form-group">
<label>Name</label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Email</label>
<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
</div>
<div class="form-group">
<label>Phone No</label>
<asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Site Name</label>
<asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
</div>
<div class="form-group">
<label>Designation</label>
<asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Signature</label>
<asp:FileUpload ID="Signature" runat="server" onChange="loadImage();" />
<asp:Image ID="imgSignature" runat="server" Height="50px" Width="150px" />
</div>
<div class="form-group">
<label>User ID</label>
<asp:Label ID="lblUserID" runat="server"></asp:Label>
</div>
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnUpdate_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>

