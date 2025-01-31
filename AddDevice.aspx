<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true" CodeBehind="AddDevice.aspx.cs" Inherits="CampusNavigationWeb.AddDevice" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div class="box">
            	<%--<div class="welbox"><div class="weltitle">Add Customers</div></div>--%>

                <div class="welbox"><div class="weltitle">
                <asp:Label runat="server" ID="lblHeading" Text="Add New Device" />
                </div></div>

                 

<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    function validate(btn) {
        var msg = "";
        var name = document.getElementById("txtName").value;
        
        
        if (name == "")
            msg = "Name Required";


        if (msg != "") {
            alert(msg);
            return false;
        }
        __doPostBack('btnSave', 'btnSave');
        return true;
    }
</script>
    
<%--<table class="tblStyle" rules="rows" border="1" cellpadding="10" cellspacing="5" runat="server" ID="tblMain"--%>    
<table class="tblStyle" width=100% rules="rows" border="1" cellpadding="10" cellspacing="5" runat="server" ID="tblMain"
        style="border: 1px solid #D8D8D8;  ">
       <%-- <tr valign="top" style="text-align: center; font-size: large; background-color: #6483A9;
            color: White;">
            <td style="color:White;" colspan="2">
              <asp:Label runat="server" ID="lblHeading" Text="Add New Customer" />
            </td>
        </tr>--%>
       
     
       <tr valign="top">
            <td> <asp:Label ID="Label9" runat="server" Text="Name" /> </td>
            <td> <asp:TextBox runat="server" ID="txtName" ClientIDMode="Static" MaxLength="50"  Width="250" /> 
            </td>
       </tr>
       <tr valign="top">
            <td> <asp:Label ID="Label5" runat="server" Text="Description" /> </td>
            <td> <asp:TextBox runat="server" ID="txtDesc" ClientIDMode="Static" MaxLength="100"  Width="250" /> 
            </td>
       </tr>
        <tr valign="top">
            <td> <asp:Label ID="Label6" runat="server" Text="Latitude" /> </td>
            <td> <asp:TextBox runat="server" ID="txtLat" ClientIDMode="Static" onkeypress="return isNumberKey(event)" MaxLength="15"   Width="250" /> 
            </td>
       </tr>
    
    <tr valign="top">
            <td> <asp:Label ID="Label7" runat="server" Text="Lognitude" /> </td>
            <td> <asp:TextBox runat="server" ID="txtLong" ClientIDMode="Static" onkeypress="return isNumberKey(event)" MaxLength="15"  Width="250" /> 
            </td>
       </tr>

    <tr valign="top">
            <td> <asp:Label ID="Label8" runat="server" Text="Floor No" /> </td>
            <td> <asp:TextBox runat="server" ID="txtFloor" ClientIDMode="Static" onkeypress="return isNumberKey(event)" MaxLength="2"  Width="250" /> 
            </td>
       </tr>

    
       <tr>
            <td colspan="2">
        
            <asp:Button ID="btnSave" CssClass="subbutton1" runat="server" UseSubmitBehavior="false" CommandName="btnSave"
                Text="Save & New Device"  ClientIDMode="Static" onclick="btnSave_Click" OnClientClick="javascript:return validate(this);" />
                <br /></td>
        </tr>

            </table>
            <asp:HiddenField runat="server" ID="hdID" />
    
</asp:Content>

