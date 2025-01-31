<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="CampusNavigationWeb.Home" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

 <div class="box">
            	<div class="welbox"><div class="weltitle">Campus Navigation : Home page</div></div>

                              
            	
                <div class="quote">Welcome To Campus Navigation</div>
                <div class="quote-text">
                <asp:Label runat="server" ID="lblQuote" />
                    <br />
                
                </div>

                <div class="divider"></div>
                
				<div class="quote">Summary</div>
                <div class="quote-text adjmar"> 

                    <asp:Button runat="server" ID="btnOrders" Text="Tests" 
                            CssClass="nbt"  CommandName="bday" onclick="btnOrders_Click" />

                	<div class="clr"></div>
                </div>               
            	<div class="clr"></div>
            </div>



    
</asp:Content>
