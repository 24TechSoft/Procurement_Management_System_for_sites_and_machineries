<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditIndentItems.aspx.cs" Inherits="Admin_EditIndentItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="container">
    <div class="row">
<script type="text/javascript">
    function show(x) {
        document.getElementById("divImage").style.display = "block";
        document.getElementById("imgPic").src = x;
    }
</script>
<div id="divImage" style="display:none; width:100%; height:100%; position:fixed; left:0px; top:0px; background-color:rgba(0,0,0,0.8);">
<a onclick="document.getElementById('divImage').style.display='none';" style="position:fixed; right:20px; top:20px;" class='btn btn-danger'>Close</a>
<img style="position:fixed; top:50px; left:50px; max-width:1000px; min-height:600px;" id="imgPic" alt="">
</div>
    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" Width="100%" 
        Font-Size="Small" DataKeyNames="ID" onrowdeleting="grd_RowDeleting">
<HeaderStyle CssClass="TableHeaderClass" />
        <Columns>
        <asp:BoundField HeaderText="SL" DataField="SL" />
        <asp:TemplateField HeaderText="Log No">
        <ItemTemplate>
        <asp:TextBox ID="txtLogNo" runat="server" Text='<%#bind("LogNo") %>' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Part No">
        <ItemTemplate>
        <asp:TextBox ID="txtPartNo" runat="server" Text='<%#bind("PartNo") %>' AutoPostBack="true" OnTextChanged="txtPartNo_TextChanged"></asp:TextBox>
        <asp:HiddenField ID="hdPartID" runat="server" Value='<%#bind("PartID") %>' />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item">
        <ItemTemplate>
        <asp:TextBox ID="txtItem" runat="server" Text='<%#bind("Particular") %>'></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Current Stock">
        <ItemTemplate>
        <asp:TextBox ID="txtCurrentStock" Text='<%#bind("CurrentStock") %>' runat="server" onfocus="this.select();"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
        <asp:TextBox ID="txtQuantity" Text='<%#bind("Quantity") %>' runat="server" onfocus="this.select();"></asp:TextBox>
        <asp:HiddenField ID="hdPrevQuantity" Value='<%#bind("Quantity") %>' runat="server"></asp:HiddenField>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM">
        <ItemTemplate>
        <asp:TextBox ID="txtUOM" runat="server" Text='<%#bind("UOM") %>'></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate>
        <asp:TextBox ID="txtRemark" runat="server" Text='<%#bind("Remarks") %>'></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Image">
        <ItemTemplate>
        <asp:Image ID="img" AlternateText="No Image" runat="server" ImageUrl='<%#bind("Photo") %>' style="max-width:100px; max-height:100px" onclick="show(this.src);" />
        </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are You Sure?')"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnSave" runat="server" Text="Update Indent" 
        CssClass="btn btn-info" onclick="btnSave_Click" />&nbsp;
<asp:Button ID="btnBack" runat="server" Text="Back To Indents" 
        CssClass="btn btn-info" onclick="btnBack_Click" />
    </div>
</div>
</asp:Content>

