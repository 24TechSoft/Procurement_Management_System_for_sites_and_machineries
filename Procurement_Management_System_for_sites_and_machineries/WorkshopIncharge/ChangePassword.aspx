<%@ Page Title="Tax Master" Language="C#" MasterPageFile="Worker.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Worker_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
    <div class="container">
<h1>Change Password</h1>

<div class="form-group">
<label>Old Password</label>
<asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>
<div class="form-group">
<label>New Password</label>
<asp:TextBox ID="txtNewPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>
<div class="form-group">
<label>Confirm Password</label>
<asp:TextBox ID="txtConfirmPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>
<asp:Button ID="btnChange" runat="server" Text="Change Password" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" 
        onclick="btnChange_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
    </div>
</section>
</asp:Content>

