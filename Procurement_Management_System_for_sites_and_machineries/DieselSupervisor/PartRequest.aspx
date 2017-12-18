<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="PartRequest.aspx.cs" Inherits="Supervisor_PartRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<a href="#" onclick="document.getElementById('divNew').style.display='block';" class="btn btn-info">Add New</a>
<div id="divNew" style="display:none; width:100%; height:100%; padding:10%; position:absolute; top:0px; left:0px; background:rgba(0,0,0,.9);">
<a href="#" class="btn btn-danger" onclick="document.getElementById('divNew').style.display='none';" style="float:right;">Close</a><br />
<asp:Panel ID="pnlNew" runat="server" style="background:#fff; border:5px solid #f00; padding:10px;">
<label>Item Type</label><br />
<asp:RadioButtonList ID="rdItemType" runat="server" RepeatColumns="2">
<asp:ListItem Value="1" Selected="True" Text="Machine"></asp:ListItem>
<asp:ListItem Value="2" Selected="True" Text="Part"></asp:ListItem>
</asp:RadioButtonList>
<label>Request to Site</label><br />
<asp:DropDownList ID="ddlSite" runat="server"></asp:DropDownList><br />
<label>Part No/Machine Name/Model</label><br />
<asp:TextBox ID="txtPartNo" runat="server" CssClass="form-control"></asp:TextBox>
<label>Description</label><br />
<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" style="resize:none"></asp:TextBox>
<label>Photo</label><br />
<asp:FileUpload ID="Photo" runat="server" /><br />
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" 
        onclick="btnSave_Click" />
</asp:Panel>
</div>
<asp:Panel ID="pnlExisting" runat="server">
<asp:GridView ID="grdPartRequest" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" SelectedRowStyle-Font-Bold="true"
        GridLines="Horizontal" Width="100%" EnableModelValidation="True" BorderStyle="Inset"
        BorderColor="#33CCCC" Font-Size="Small">
        <FooterStyle BackColor="Gray" ForeColor="White" Font-Bold="true" />
<AlternatingRowStyle BackColor="#CCCCFF" ForeColor="Black" />
<HeaderStyle BackColor="#66FF99" ForeColor="Black" Font-Bold="true" 
        HorizontalAlign="Left" Height="30px" />
<RowStyle BackColor="White" ForeColor="Black" />
<Columns>
<asp:BoundField HeaderText="Site" DataField="Site" />
<asp:BoundField HeaderText="User" DataField="UserName" />
<asp:BoundField HeaderText="Part No" DataField="PartNo" />
<asp:BoundField HeaderText="Description" DataField="Description" />
<asp:ImageField HeaderText="Image" DataImageUrlField="Photo" ControlStyle-Height="100px" ControlStyle-Width="100px">
    <ControlStyle Height="100px" Width="100px" />
    </asp:ImageField>
<asp:BoundField HeaderText="Status" DataField="Status" />
</Columns>
        <SelectedRowStyle BackColor="Red" />
</asp:GridView>
<h4><asp:Label ID="lblError" runat="server"></asp:Label></h4>
</asp:Panel>
</asp:Content>

