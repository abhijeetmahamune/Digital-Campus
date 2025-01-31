<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="CampusNavigationWeb.AddVisitor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div class="box">
            	<%--<div class="welbox"><div class="weltitle">Add Customers</div></div>--%>

                <div class="welbox"><div class="weltitle">
                <asp:Label runat="server" ID="lblHeading" Text="Add New Visitor" />
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
            <td> <asp:Label ID="Label5" runat="server" Text="Phone" /> </td>
            <td> <asp:TextBox runat="server" ID="txtPhone" ClientIDMode="Static" MaxLength="10"  Width="250" /> 
            </td>
       </tr>
        <tr valign="top">
            <td> <asp:Label ID="Label6" runat="server" Text="BLE ID" /> </td>
            <td> <asp:DropDownList runat="server" ID="ddBleID" ClientIDMode="Static"  Width="250" /> 
            </td>
       </tr>
    

    
       <tr>
            <td colspan="2">
        
            <asp:Button ID="btnSave" CssClass="subbutton1" runat="server" UseSubmitBehavior="false" CommandName="btnSave"
                Text="Update & New Visitor"  ClientIDMode="Static" onclick="btnSave_Click" OnClientClick="javascript:return validate(this);" />
                <br /></td>
        </tr>

            </table>
            <asp:HiddenField runat="server" ID="hdID" />
    
</asp:Content>

