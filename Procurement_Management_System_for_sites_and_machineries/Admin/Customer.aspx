<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Admin_Customer" %>

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
<h1>Supplier</h1>
<a href="#" class="btn btn-info" onclick="document.getElementById('divNew').style.display='block';">Add New</a><br /><br />
<div id="divNew" style="display:none; position:absolute; width:100%; background:rgba(0,0,0,0.5); padding:10%; top:0px; left:0px;">
<a href="#" onclick="document.getElementById('divNew').style.display='none';" class="btn btn-danger" style="float:right; position:relative; top:5px">Close</a>
<div class="row" style="background-color:#fff; padding:20px; border:solid 5px #f00;">
<div class="form-group">
<label>Name</label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Address</label>
<asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
</div>
<div class="form-group">
<label>Phone No</label>
<asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Email</label>
<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
</div>

<div class="form-group">
<label>Logo</label>
<asp:FileUpload ID="Logo" runat="server" onChange="loadImage();" />
<asp:Image ID="imgLogo" runat="server" Height="200px" Width="200px" />
</div>

<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnSave_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
<asp:Button ID="btnExisting" runat="server" Text="Existing Records" CssClass="btn" 
        onclick="btnExisting_Click" />
</div></div>
<asp:Panel ID="pnlExisting" runat="server">
<div class="row">
<asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" 
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" Font-Size="Small"
        onrowdeleting="grdCustomer_RowDeleting" BorderStyle="Inset" 
        BorderColor="#33CCCC">
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#2b3c59" ForeColor="White" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:TemplateField HeaderText="Name">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#bind("Name") %>'></asp:Label>
<asp:HiddenField ID="hdLogo" runat="server" Value='<%#bind("Logo") %>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:HiddenField ID="hdID" runat="server" Value='<%#bind("ID") %>' />
<asp:Label ID="lblAddress" runat="server" Text='<%#bind("Address")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Phone No">
<ItemTemplate>
<asp:Label ID="lblPhone" runat="server" Text='<%#bind("Phone")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
<ItemTemplate>
<asp:Label ID="lblEmail" runat="server" Text='<%#bind("Email")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:CommandField ShowDeleteButton="True" DeleteText="Edit" />
</Columns>
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</div>
</asp:Panel>
<!-- Update -->
<asp:Panel ID="pnlUpdate" runat="server" Visible="false">
<asp:HiddenField ID="hdEID" runat="server" />
<div class="form-group">
<label>Name</label>
<asp:TextBox ID="txtEName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Address</label>
<asp:TextBox ID="txtEAddress" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
</div>
<div class="form-group">
<label>Phone No</label>
<asp:TextBox ID="txtEPhone" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Email</label>
<asp:TextBox ID="txtEEmail" CssClass="form-control" runat="server"></asp:TextBox>
</div>

<div class="form-group">
<label>Logo</label>
<asp:FileUpload ID="ELogo" runat="server" />
<asp:Image ID="EImg" runat="server" Height="200px" Width="200px" />
</div>

<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" 
        onclick="btnUpdate_Click" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" 
        onclick="btnDelete_Click" />
        
<asp:Button ID="btnCancel" runat="server" Text="Existing Records" CssClass="btn" 
        onclick="btnCancel_Click" />
</asp:Panel>
</asp:Content>

