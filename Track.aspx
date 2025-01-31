<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true" CodeBehind="Track.aspx.cs" Inherits="CampusNavigationWeb.Track" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
		<%--<script src="http://maps.google.com/maps/api/js?sensor=false&amp;language=en"></script>--%>
    <script type="text/javascript">
        function go()
        {
            var dd = document.getElementById('ddDestination');
            var id = dd.value;
            window.open('/loc/' + id + ".jpg"); 
        }
    </script>
    <div class="box">
        <%--<div class="welbox"><div class="weltitle">Add Customers</div></div>--%>

        <div class="welbox">
            <div class="weltitle">
                <asp:Label runat="server" ID="lblHeading" Text="BLE Device Tracking" />
            </div>
        </div>


        <%--<table class="tblStyle" rules="rows" border="1" cellpadding="10" cellspacing="5" runat="server" ID="tblMain"--%>
        <table class="tblStyle" width="100%" rules="rows" border="1" cellpadding="10" cellspacing="5" runat="server" id="tblMain"
            style="border: 1px solid #D8D8D8;">



            <tr valign="top">
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Device Details" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblDetails" Text="Device ID : abcdeg=1236" />
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Location Details" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblLocation" Text="Near Library, second floor" />
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Where to go" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddDestination" ClientIDMode="Static" AutoPostBack="false" OnSelectedIndexChanged="ddDestination_SelectedIndexChanged" />
                    <input type="button" id="btnGo" onclick="go();" value="show"/>
                    <asp:HiddenField runat="server" ID="hfID" />
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2">

                    <%--<div class="mapouter"><div class="gmap_canvas"><iframe class="gmap_iframe" width="100%" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?width=600&amp;height=400&amp;hl=en&amp;q=MIT World Peace University (MIT-WPU)&amp;t=&amp;z=18&amp;ie=UTF8&amp;iwloc=B&amp;output=embed"></iframe><a href="https://pdflist.com/" alt="pdf">Pdf</a></div>
					--%>
                    <asp:Image runat="server" ID="imgMap" ImageAlign="Middle" style="width:100%;"/>
                        <style>
								.mapouter {
									position: relative;
									text-align: right;
									width: 100%;
									height: 400px;
								}

								.gmap_canvas {
									overflow: hidden;
									background: none !important;
									width: 100%;
									height: 400px;
								}

								.gmap_iframe {
									height: 400px !important;
								}
							</style>
                </td>
            </tr>


        </table>
</asp:Content>


