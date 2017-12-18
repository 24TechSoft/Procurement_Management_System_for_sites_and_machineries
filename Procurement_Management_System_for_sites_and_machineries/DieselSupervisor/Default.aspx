<%@ Page Title="" Language="C#" MasterPageFile="Supervisor.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Supervisor_Default" %>
<asp:Content ContentPlaceHolderID="CHPHeader" runat="server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="pnl1" runat="server"><ContentTemplate>
<asp:Timer runat="server" ID="Timer1" OnTick="Timer1_Tick" Enabled="true" Interval="3600"></asp:Timer>
<div class="banner w3l">
<div class="banner-info">
		<div class="container">
        <div class="profile-left wow flipInY" data-wow-duration="1.5s" data-wow-delay="0s">
					<div class="login" style="height:130px">
<!--table width="100%" style="height:100%">
<tr><td colspan="2">
<asp:Label ID="lblTotalNewPart" runat="server" Text="0"></asp:Label>
</td>
<td colspan="10">
<a href="PartRequests.aspx" class="btn btn-info form-control"> &nbsp; New Part Requests</a>
</td></tr>
<tr><td colspan="2">
<asp:Label ID="lblTotalIndents" runat="server" Text="0"></asp:Label>
</td>
<td colspan="10">
<a href="Indent.aspx" class="btn btn-info form-control">&nbsp; New Indents</a>
</td></tr>
<tr><td colspan="2">
<asp:Label ID="lblTotalRenewal" runat="server" Text="0"></asp:Label>
</td>
<td colspan="10">
<a href="RenewalAlerts.aspx" class="btn btn-info form-control" >&nbsp; New Renewal Alerts</a>
</td></tr>
<tr><td colspan="2">
<asp:Label ID="lblTotalPurchaseOrders" runat="server"></asp:Label>
</td>
<td colspan="10"><a href="#" class="btn btn-info form-control">&nbsp; New Purchase Orders</a></td>
</tr>

</table-->
</div></div>
		</div>
	</div>
</div>
</ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
    <p style="padding-top:50px">T.K. Engineering Consortium Pvt. Ltd. is a well-organized company that deals in offering Road Construction Services and other services to our esteemed clients. Based in Arunachal Pradesh (Itanagar) from India, our company have till now accomplished a strong reputation within our marketplace for accomplishing complex projects and for rendering the best services to our esteemed customers from worldwide. Our approach to construction management and its reasonable cost have assisted the company to provide projects in limited time period, by sticking to strict quality control measures.</p>
<p style="padding-top:50px">Empowered as one of the pre-eminent Highway Construction Company from Arunachal Pradesh (India), we are self-possessed to extent new targets in near future. Owing to our rapid success and dedicated team of qualified engineers and technicians, we are able to change the quick flow of cognition and effective administrative creating across the organization.</p>
</asp:Content>

