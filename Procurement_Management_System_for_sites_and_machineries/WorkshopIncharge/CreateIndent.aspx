<%@ Page Title="" Language="C#" MasterPageFile="~/WorkshopIncharge/Worker.master" AutoEventWireup="true" CodeFile="CreateIndent.aspx.cs" Inherits="Admin_CreateIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CHPHeader" runat="Server">
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="CPH1" runat="server">
<section>
    <div class="container">
<script type="text/javascript">
    function Display(x) {
        document.getElementById(x).style.display = "block";
    }
</script>
<div id="divAddPart" style="display:none; position:absolute; width:100%; background:rgba(0,0,0,0.5); padding:10%; top:0px; left:0px;">
<a href="#" onclick="document.getElementById('divAddPart').style.display='none';" class="btn btn-danger" style="float:right; position:relative; top:5px">Close</a>
<div class="row" style="background-color:#fff; padding:20px; border:solid 3px #f00;">
<div class="row">
<div class="form-group">
<label>Machine</label>
<asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Width="200px">
</asp:DropDownList>
</div>
<div class="form-group">
<label>Part No</label>
<asp:TextBox ID="txtSerial" runat="server" CssClass="form-control"></asp:TextBox>
<asp:HiddenField ID="hdPartID" runat="server" />
</div>
<div class="form-group">
<label>Part Name</label>
<asp:TextBox ID="txtNewPartName" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
<label>Description</label>
<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
</div>
<div class="form-group">
<label>Photo</label>
<asp:FileUpload ID="Photo" runat="server" CssClass="form-control" />
</div>
<asp:Button ID="btnAddNewPart" runat="server" Text="Save" CssClass="btn btn-default" 
        OnClientClick="return confirm('Are You Sure?');" onclick="btnAddNewPart_Click" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
</div>
</div></div>
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<Asp:UpdatePanel ID="pnlUpdate" runat="server" >
<ContentTemplate>
<table width="100%">
<tr><td colspan="4"><h4>Create Indent</h4></td></tr>
<tr valign="top">
            <td>
            Project No <a href="Projects.aspx" target="_blank">Add New</a>
            <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control"
                    OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="true" 
                    Width="200px"></asp:DropDownList><br />
            </td>
            <td>
            Job No <a href="Projects.aspx" target="_blank">Add New</a>
            <asp:DropDownList ID="ddlJob" runat="server" CssClass="form-control"
                    OnSelectedIndexChanged="ddlJob_SelectedIndexChanged" AutoPostBack="true" 
                    Width="200px"></asp:DropDownList>
            </td>
            <td colspan="2">
            Reference No<br />
            <asp:TextBox ID="txtReferenceNo" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
        <br />
        </td></tr>
        <tr><td>
            Indent Date<br />
            <asp:TextBox ID="txtIndentDate" runat="server" AutoPostBack="True" 
                    CssClass="hajanDatePicker form-control" placeholder="mm/dd/yyyy" type="date"
                ontextchanged="txtIndentDate_TextChanged" Width="200px"></asp:TextBox>
            </td>
            <td>
            Indentor<br />
            <asp:TextBox ID="txtIndentor" runat="server" AutoPostBack="True" 
                ontextchanged="txtIndentor_TextChanged" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:HiddenField ID="hdIndentor" runat="server" />
            <asp:GridView ID="grdIndentor" runat="server" ShowHeader="False" 
                GridLines="None" Visible="False" AutoGenerateColumns="False" 
                onrowdeleting="grdIndentor_RowDeleting" Width="100%" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="#FFFFCC" />
            <Columns>
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="UserType" />
            <asp:BoundField DataField="SiteName" />
                <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
            </Columns>
                <RowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td>
            Approved By<br />
            <asp:TextBox ID="txtApprovedBy" runat="server" AutoPostBack="True" 
                ontextchanged="txtApprovedBy_TextChanged" CssClass="form-control" Width="200px"></asp:TextBox>
                <asp:HiddenField ID="hdApprovedBy" runat="server" />
            <asp:GridView ID="grdApprovedBy" runat="server" ShowHeader="False" 
                GridLines="None" Visible="False" AutoGenerateColumns="False" 
                onrowdeleting="grdApprovedBy_RowDeleting" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="#FFFFCC" />
            <Columns>
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="UserType" />
            <asp:BoundField DataField="SiteName" />
                <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
            </Columns>
                <RowStyle BackColor="White" />
            </asp:GridView>
            </td>
            
            <td>
            <label>Machine</label> <a onclick="document.getElementById('divAddPart').style.display='block';" href="#">Add New Part</a><br />
            <asp:DropDownList ID="ddlIMachine" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList>
            </td>
</tr>
<tr><td colspan="4"><br /></td></tr>
</table>
<!--
        <asp:TemplateField HeaderText="Log No">
        <ItemTemplate>
        <asp:TextBox ID="txtLogNo" runat="server" AutoPostBack="true" OnTextChanged="txtLogNo_TextChanged"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
-->
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" Font-Size="Small">
<HeaderStyle CssClass="TableHeaderClass"/>
        <Columns>
        <asp:BoundField HeaderText="SL" DataField="SL" />

        <asp:TemplateField HeaderText="Part No">
        <ItemTemplate>
        <asp:TextBox ID="txtPartNo" runat="server" AutoPostBack="true" OnTextChanged="txtPartNo_TextChanged"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item">
        <ItemTemplate>
        <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Image">
        <ItemTemplate>
        <asp:FileUpload ID="file" runat="server" EnableViewState="true" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Current Stock">
        <ItemTemplate>
        <asp:TextBox ID="txtCurrentStock" runat="server" Text="0" onfocus="this.select();"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
        <asp:TextBox ID="txtQuantity" runat="server" Text="1" onfocus="this.select();"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM">
        <ItemTemplate>
        <asp:TextBox ID="txtUOM" runat="server"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate>
        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
</asp:GridView>

</ContentTemplate></Asp:UpdatePanel>
<div class="row">

    <div class="col-lg-12"><br />
    <asp:Button ID="btnSave" runat="server" Text="Save Indent" 
            CssClass="btn btn-info" onclick="btnSave_Click" OnClientClick="return confirm('Are you sure?');" />
    </div>
</div>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="position:absolute; left: 40%; top: 40%;"><img src="../loading.gif" alt="" width="100" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    </div>
</section>
</asp:Content>

