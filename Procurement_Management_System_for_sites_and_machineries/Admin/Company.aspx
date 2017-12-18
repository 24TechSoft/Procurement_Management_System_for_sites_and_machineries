<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Admin_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <script type="text/javascript">
    function loadImage() {
        var file = document.getElementById('CPH1_Logo').files[0]; //sames as here
        var reader = new FileReader();
        reader.onloadend = function () {
            document.getElementById("CPH1_imgLogo").src = reader.result;
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
<h1>My Profile</h1>

<div class="form-group">
<label>Name</label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Address</label>
<asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" style="resize:none" Rows="3"></asp:TextBox>
</div>
<div class="form-group">
<label>Tin</label>
<asp:TextBox ID="txtTin" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Cst</label>
<asp:TextBox ID="txtCst" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Logo</label>
<asp:FileUpload ID="Logo" runat="server" onchange="loadImage();" />
<asp:Image ID="imgLogo" runat="server" Height="150px" Width="150px" />
</div>
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnSave_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
</div>
</section>
</asp:Content>

