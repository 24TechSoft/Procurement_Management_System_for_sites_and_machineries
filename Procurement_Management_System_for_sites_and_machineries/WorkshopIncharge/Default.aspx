<%@ Page Title="" Language="C#" MasterPageFile="Worker.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Worker_Default" %>
<asp:Content ContentPlaceHolderID="CHPHeader" runat="server">
<asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
<section class="margin-bottom50">
<div class="customtypewowslider fullwidth flexslider clearfix cayman-slider" style="max-height:500px;">
	<div class="fixed-box">
		<div class="row">
			<div class="col-md-12">
                <asp:UpdatePanel ID="pnl1" runat="server"><ContentTemplate>
                <!--div class="col-md-10 col-md-offset-1">
                    <asp:Label ID="lblTotalNewPart" runat="server" Text="0"></asp:Label>
                    <a href="SitePartRequest.aspx" class="btn btn-sm btn-primary"> &nbsp; New Part Requests</a>
                </div-->
                <div class="col-md-10 col-md-offset-1">
                     <div class="col-xs-2">
                         <asp:Label ID="lblTotalRenewal" runat="server" Text="0"></asp:Label>
                    </div>
                     <div class="col-xs-10">
                         <a class="btn btn-sm btn-primary btn-block" href="RenewalAlerts.aspx">&nbsp; New Renewal Alerts</a>
                    </div>
				</div>
				<div class="col-md-10 col-md-offset-1">
                    <div class="col-xs-2">
                        <asp:Label ID="Label1" runat="server" Text="0" CssClass="btn"></asp:Label>
                    </div>
                    <div class="col-xs-10">
                        <a href="CurrentStockReport.aspx" class="btn btn-sm btn-primary btn-block" >&nbsp; View Inventory</a>
                    </div>
				</div>
				<div class="col-md-10 col-md-offset-1">
					<div class="col-md-6">
                        <br />
                        <asp:TextBox ID="txtRef" runat="server" placeholder="Type Reference No" CssClass="form-control" Width="185px"></asp:TextBox>
					</div>
					<div class="col-md-6">
                        <asp:Button ID="btnShowPT" runat="server" Text="Track Package" 
                            CssClass="btn btn-info" OnClientClick="document.forms[0].target = '_blank';" 
                             onclick="btnShowPT_Click" />
					</div>
				</div>
            </ContentTemplate></asp:UpdatePanel>
			</div>
		</div>
	</div>
	<ul class="slides slider-content-style1">
		<li style="background-color:#000000;">
			<img src="../assets/img/s1.jpg" alt="" style="opacity:0.7;">
		</li>
		<li style="background-color:#000000;">
			<img src="../assets/img/s2.jpg" alt="" style="opacity:0.7;">
		</li>
		<li style="background-color:#000000;">
			<img src="../assets/img/s3.jpg" alt="" style="opacity:0.7;">
		</li>
	</ul>
</div>
</section>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" Runat="Server">
<section>
<div class="container">
	<div class="col-md-6">
		<div class="the-headline">
			<h1>About <span class="accentcolor">Us</span></h1>
		</div>
		<div class="textwidget">
			<p>
				T.K. Engineering Consortium Pvt. Ltd. is a well-organized company that deals in offering Road Construction Services and other services to our esteemed clients. Based in Arunachal Pradesh (Itanagar) from India, our company have till now accomplished a strong reputation within our marketplace for accomplishing complex projects and for rendering the best services to our esteemed customers from worldwide. Our approach to construction management and its reasonable cost have assisted the company to provide projects in limited time period, by sticking to strict quality control measures.
			</p>
			<p>
				Empowered as one of the pre-eminent Highway Construction Company from Arunachal Pradesh (India), we are self-possessed to extent new targets in near future. Owing to our rapid success and dedicated team of qualified engineers and technicians, we are able to change the quick flow of cognition and effective administrative creating across the organization.
			</p>
		</div>
	</div>
	<div class="col-md-6 wow fadeInRight">
		<img alt="" src="../assets/img/bg1.png" class="so-widget-image" style="max-width:100%; height:auto; display:block"/>
	</div>
</div>
</section>
</asp:Content>

