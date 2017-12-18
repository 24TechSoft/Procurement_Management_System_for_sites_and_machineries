<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CreatePO.aspx.cs" Inherits="Admin_CreatePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $("input:text").focus(function () { $(this).select(); });
    });
</script>
<style type="text/css">
tr td
{
	padding:5px;
}
</style>
<div class="container">
    <div class="row">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="updatePanel" runat="server"  style="font-size:small">
<Triggers><asp:PostBackTrigger ControlID="btnSave" /></Triggers>
<ContentTemplate>
<div id="divAddCust" style="display:none; position:fixed; width:100%; height:100%; background:rgba(0,0,0,0.5); padding:10%; top:0px; left:0px;">

<table style="background:#fff; border:#f00 solid 2px; padding:50px;" align="center" cellpadding="10px" cellspacing="10px">
<tr><td></td><td>
<a href="#" onclick="document.getElementById('divAddCust').style.display='none';" class="btn btn-danger" style="float:right;">X</a>
</td></tr>
<tr><td>Name</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr></label>
<tr><td>Address</td><td><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" style="resize:none;"></asp:TextBox></td></tr>
<tr><td>Phone No</td><td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td></tr>
<tr><td>Email</td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnAddCust" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnAddCust_Click" /></td></tr>
</table>
</div>
<table width="100%" style="font-size:small">
<tr><td>
<h1>Purchase Order</h1>
</td></tr>

<tr style="border-top:solid 1px #f00; border-left:solid 1px #f00; border-right:solid 1px #f00; background-color:rgba(44,61,90,.1);"><td colspan="6">
<label>Select Indent</label><br />
            <asp:TextBox ID="txtIndentRef" runat="server" AutoPostBack="true" 
                ontextchanged="txtIndentRef_TextChanged" Width="200px"></asp:TextBox>
            <asp:GridView ID="grdIndentRef" runat="server" ShowHeader="False" 
                GridLines="None" Visible="False" AutoGenerateColumns="False" 
                onrowdeleting="grdIndentRef_RowDeleting" Width="100%"  
            DataKeyNames="ID" BackColor="White">
            <Columns>
            <asp:BoundField DataField="RefNo" />
            <asp:BoundField DataField="IndentDate" />
                <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
            </Columns>
            </asp:GridView>
</td>
<td colspan="3">
<label>Select Site</label><br />
<asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" Width="200px">
</asp:DropDownList>
<asp:HiddenField ID="hdSiteID" runat="server" />
</td>
<td colspan="3" align="right">
<label>Select Machine</label><br />
<asp:DropDownList ID="ddlMachine" runat="server" Width="200px">
</asp:DropDownList>
</td>
</tr>

<tr style=" background-color:rgba(44,61,90,.1); border-left:solid 1px #f00; border-right:solid 1px #f00;"><td colspan="12">
        <label>Indent Items</label><br />
        <asp:GridView ID="grdIndentItems" runat="server" AutoGenerateColumns="False" 
        GridLines="Horizontal" Width="100%">
           <AlternatingRowStyle CssClass="TableAlternateRowClass" />
<HeaderStyle CssClass="TableHeaderClass" />
<RowStyle CssClass="TableRowClass" />
        <Columns>
                <asp:TemplateField HeaderText="Particulars" ControlStyle-Width="200px">
                <ItemTemplate>
                <asp:Label ID="lblParticular" runat="server" Text='<%#bind("Particular") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="200px"></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Current Stock" ControlStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label ID="lblCurrentStock" runat="server" Text='<%#bind("CurrentStock")%>'></asp:Label>
                </ItemTemplate>

<ControlStyle Width="100px"></ControlStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Quantity" ControlStyle-Width="75px">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Text='<%#bind("Quantity")%>'></asp:Label>
</ItemTemplate>
<ControlStyle Width="75px"></ControlStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" ControlStyle-Width="200px">
<ItemTemplate>
<asp:Label ID="lblRemarks" runat="server" Text='<%#bind("Remarks")%>'></asp:Label>
</ItemTemplate>
<ControlStyle Width="200px"></ControlStyle>
</asp:TemplateField>
</Columns>
</asp:GridView>

</td></tr>
<tr style=" background-color:rgba(44,61,90,.1); border-left:solid 1px #f00; border-right:solid 1px #f00;"><td colspan="3">
<label>Refference No</label><br />
            <asp:TextBox ID="txtRefNo" runat="server" Width="200px"></asp:TextBox>
</td>
<td colspan="3">
<label>Date</label><br />
            <asp:TextBox ID="txtPODate" runat="server" CssClass="hajanDatePicker" type="date" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox>
</td>
<td colspan="3">
<label>Quotation No</label><br />
                <asp:TextBox ID="txtQuotationNo" runat="server" Width="200px"></asp:TextBox>
</td>
<td colspan="3" align="right">
<label>Quotation Date</label><br />
                <asp:TextBox ID="txtQuotationDate" runat="server" CssClass="hajanDatePicker" type="date" placeholder="mm/dd/yyyy" Width="200px"></asp:TextBox>
</td>
</tr>
<tr style=" background-color:rgba(44,61,90,.1); border-left:solid 1px #f00; border-right:solid 1px #f00;"><td colspan="12">
<label>Subject</label><br />
            <asp:TextBox ID="txtSubject" runat="server" TextMode="MultiLine" style="resize:none" width="99.5%"></asp:TextBox>
</td>
</tr>
<tr style=" background-color:rgba(44,61,90,.1); border-left:solid 1px #f00; border-right:solid 1px #f00;">
<td colspan="3">
<label>Prepared By</label><br />
        <asp:TextBox ID="txtPreparedBy" runat="server" Enabled="false" Width="200px"></asp:TextBox>
        <asp:HiddenField ID="hdPreparedBy" runat="server" />
</td>
<td colspan="3">
<label>Checked By</label><br />
        <asp:TextBox ID="txtCheckedBy" runat="server" AutoPostBack="true" 
            ontextchanged="txtCheckedBy_TextChanged" Width="200px"></asp:TextBox>
        <asp:HiddenField ID="hdCheckedBy" runat="server" />
        <asp:GridView ID="grdCheckedBy" runat="server" ShowHeader="False" 
                GridLines="None" Visible="False" AutoGenerateColumns="False" 
                onrowdeleting="grdCheckedBy_RowDeleting" Width="100%"  
            DataKeyNames="ID" BackColor="White">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="UserType" />
            <asp:BoundField DataField="Name" />
            <asp:BoundField DataField="SiteName" />
            <asp:BoundField DataField="Designation" />
                <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
            </Columns>
            <RowStyle BackColor="#CCFFFF" />
            </asp:GridView>
</td>
<td colspan="3">
<label>Tax</label><br />
        <asp:DropDownList ID="ddlTax" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlTax_SelectedIndexChanged" Width="200px">
        
        </asp:DropDownList>
    <asp:CheckBox ID="chkIGST" runat="server" Text="IGST?" OnCheckedChanged="chkIGST_CheckedChanged" AutoPostBack="true" />
</td>
<td colspan="3" align="right">
<label>Discount Percentage</label><br />
        <asp:RegularExpressionValidator ID="rgDiscount" ErrorMessage="Enter Correctly" ValidationExpression="^[-+]?\d+(\.\d+)?$" ControlToValidate="txtDiscount" runat="server"></asp:RegularExpressionValidator>
        <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="True" 
            ontextchanged="txtDiscount_TextChanged" Width="200px">0</asp:TextBox>
</td>
</tr>
<tr style="border-bottom:solid 1px #f00; background-color:rgba(44,61,90,.1); border-left:solid 1px #f00; border-right:solid 1px #f00;">

<td colspan="3">
<label>Total Amount</label><br />
        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="False" Width="200px"></asp:TextBox>
</td>
<td colspan="3">
<label>Net Payable</label><br />
        <asp:TextBox ID="txtPayable" runat="server" Enabled="False" Width="200px">0</asp:TextBox>
</td>

<td colspan="3">
<label>Purchase Order To</label><br />
        <asp:DropDownList ID="ddlStatus" runat="server" Width="200px" Visible="false">
        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
        <asp:ListItem Text="Paid/Confirmed" Value="1" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Credit/Confirmed" Value="2"></asp:ListItem>
        <asp:ListItem Text="Canceled" Value="3"></asp:ListItem>
        </asp:DropDownList>
<asp:DropDownList ID="ddlPOTo" runat="server" Width="200px">

</asp:DropDownList>
<a href="#" onclick="document.getElementById('divAddCust').style.display='block';">Add New</a>
</td>
<td colspan="3" align="right">
<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" 
            onclick="btnSave_Click"  />
            <asp:Label ID="msg" runat="server"></asp:Label>
</td>
</tr>
<tr><td colspan="12"><label>Upload Soft Copy Here if old Purchase Order</label><br />
<asp:FileUpload ID="file" runat="server" EnableViewState="true" />
</td></tr>
<tr><td colspan="12"><br /></td></tr>
<tr><td colspan="12">
    <!--asp:TemplateField HeaderText="Log No">
        <ItemTemplate>
    <asp:TextBox ID="txtLogNo1" runat="server"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField-->
<asp:GridView ID="grd" runat="server" Width="100%" RowStyle-Font-Size="XX-Small" HeaderStyle-Font-Size="X-Small" AutoGenerateColumns="false">
<HeaderStyle CssClass="TableHeaderClass" />
<Columns>
    <asp:BoundField DataField="SL" />
    <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
            <asp:TextBox ID="txtQuantity1" runat="server" AutoPostBack="true" OnTextChanged="txtQuantity1_TextChange"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Part No">
        <ItemTemplate>
    <asp:TextBox ID="txtPartNo1" runat="server" AutoPostBack="true" OnTextChanged="txtPartNo1_TextChanged"></asp:TextBox>
    <asp:HiddenField ID="hdPartID" runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Part Name">
        <ItemTemplate>
    <asp:TextBox ID="txtPartName1" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="UOM">
        <ItemTemplate>
    <asp:TextBox ID="txtUOM1" runat="server"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Current Stock">
        <ItemTemplate>
    <asp:Label ID="lblCurrentStock1" runat="server" Text="0"></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Rate">
        <ItemTemplate>
    <asp:TextBox ID="txtRate1" runat="server" Text="0" AutoPostBack="true" OnTextChanged="txtRate1_TextChange"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="CGST">
        <ItemTemplate>
    <asp:TextBox ID="txtCGST1" runat="server" Text='<%#bind("CGST") %>'></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="SGST">
        <ItemTemplate>
    <asp:TextBox ID="txtSGST1" runat="server" Text='<%#bind("SGST") %>'></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="IGST">
        <ItemTemplate>
    <asp:TextBox ID="txtIGST1" runat="server" Text='<%#bind("IGST") %>'></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="Total">
        <ItemTemplate>
    <asp:TextBox ID="txtTotal1" runat="server" Text="0"></asp:TextBox>
   </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate>
    <asp:TextBox ID="txtRemark1" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
</Columns>
    <RowStyle Font-Size="X-Small" />
</asp:GridView>
</td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="position:absolute; left: 40%; top: 40%;"><img src="../loading.gif" alt="" width="100" /></span>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
    </div>
</div>
</asp:Content>

