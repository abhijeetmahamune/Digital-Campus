<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CampusNavigationWeb.Log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Campus Navigation</title>
<meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0;">
<link href='https://fonts.googleapis.com/css?family=Roboto+Condensed' rel='stylesheet' type='text/css'>
<link href="css/default.css" rel="stylesheet" type="text/css">
<link href="css/main.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="css/styles.css">
<script src="js/jquery-latest.min.js" type="text/javascript"></script>
   <script src="js/script.js"></script>

   <script type="text/javascript">
       function Validate() {
           var msg = "";

           if (msg != "") {
               alert(msg);
               return false;
           }
           return true;
       }
    </script>

    <style type="text/css">

.btnStyle
{
    background-color: #5082A9;
    border: 2px solid #75C7AD;
    color: White;
    padding:7px;
    line-height:20px;
    cursor:pointer;
    
      border-radius: 10px; 
    -moz-border-radius: 10px; 
    -webkit-border-radius: 10px; 
    box-shadow: 0px 0px 8px #d9d9d9; 
    -moz-box-shadow: 0px 0px 8px #d9d9d9; 
    -webkit-box-shadow: 0px 0px 8px #d9d9d9; 
    
    /*min-width:150px;*/
    /*font-size: 8.25pt; */
}
    </style>

</head>

<body>
<form id="form1" runat="server">
		<div class="main">
        	<div class="top-section" style="margin-bottom:10px;">
            	<div class="wrapper">
                	<div class="logo"><a href="#"><img src="images/logo.png" alt="Company Logo"></a></div>
                    <div class="clr"></div>
                </div>
            	<div class="clr"></div>
            </div>
           
        
            
            <div class="box">
            	<div class="welbox">
            	  <div class="weltitle">Welcome to Campus Navigation</div>
            	</div>
                <div class="quote">Campus Navigation LogIn</div>
                <div class="quote-text">
                	<div class="login-box">
                	  

                       <asp:TextBox runat="server" class="uname" ID="txtLoginID" placeholder="Please Enter Phone" ClientIDMode="Static" MaxLength="10" /></br>
                       <asp:TextBox runat="server" class="uname" ID="txtPassword" ClientIDMode="Static" placeholder="Please Enter Password" MaxLength="10" TextMode="Password" />
                       
                                              
                      
                     </div>
                    <div class="clr">
                    
                        <asp:Label runat="server"  ID="lblStatusMsg" ForeColor="Red" 
                            style="text-align: center"  />

                    </div>
                </div>

                &nbsp;<div  class="subbutton">
               
               <asp:Button class="subbutton"  runat="server" ID="btnLogin" Text="Login"  
                        OnClientClick="javascript:return Validate();" onclick="btnLogin_Click"  />
                
               </div>



                <div class="divider"></div>
                
				              
            	<div class="clr"></div>
            </div>
            
            <div class="copyright">&copy;&nbsp;copyright CampusNavigation 2023</div>
        	<div class="clr"></div>
            
        </div>
           </form>
</body>


</html>
