<%@ Page Title="Log In" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript">
    function ValidateForm() {
        var txtUserID = document.getElementById("MainContent_txtUserID").value;
        var txtPassword = document.getElementById("MainContent_txtPassword").value;
        if (txtUserID == "" || txtPassword == "") {
            alert("User ID and Password cannot be empty");
            return false;
        }
        else {
            return true;
        }
    }
</script>
<!-- =========================== SLIDER BEGIN =========================== -->
<section>
<div class="customtypewowslider fullwidth flexslider clearfix cayman-slider" style="max-height:500px;">
	<div class="fixed-box login-box">
		<div class="row">
			<div class="col-md-12">
				<div class="the-headline">
							<h1 style="font-size:20px;">Log in form</h1>
				</div>
				<div class="textwidget" style="padding: 10px;">
					<div class="done">
						<div class="alert alert-success">
							<button type="button" class="close" data-dismiss="alert">×</button>
							Incorrect username or password!
						</div>
					</div>
                        <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="User ID"></asp:TextBox>
						<br/>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
						<br/>
						<asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control">
                            <asp:ListItem Value="1" Text="Admin"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Workshop Incharge"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Diesel Supervisor"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                        onclick="LoginButton_Click" OnClientClick="return ValidateForm();" CssClass="btn"/>
                        <asp:Label ID="msg" runat="server"></asp:Label>
				</div>
			</div>
		</div>
	</div>
	<ul class="slides slider-content-style1">
		<li style="background-color:#000000;">
			<img src="assets/img/s1.jpg" alt="" style="opacity:0.7;">
		</li>
		<li style="background-color:#000000;">
			<img src="assets/img/s2.jpg" alt="" style="opacity:0.7;">
		</li>
		<li style="background-color:#000000;">
			<img src="assets/img/s3.jpg" alt="" style="opacity:0.7;">
		</li>
	</ul>
</div>
</section>
<!-- =========================== SLIDER END =========================== -->


</asp:Content>