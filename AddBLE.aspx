<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true" CodeBehind="AddBLE.aspx.cs" Inherits="CampusNavigationWeb.AddBLE" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div class="box">
            	<%--<div class="welbox"><div class="weltitle">Add Customers</div></div>--%>

                <div class="welbox"><div class="weltitle">
                <asp:Label runat="server" ID="lblHeading" Text="Add New BLE Device" />
                </div></div>

                 

<script type="text/javascript">
    function validate(btn) {
        var msg = "";
        var name = document.getElementById("txtName").value;


        if (name == "")
            msg = "Device ID Required";


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
       
       
     
       <tr valign="top">
            <td> <asp:Label ID="Label9" runat="server" Text="Device ID" /> </td>
            <td> <asp:TextBox runat="server" ID="txtName" ClientIDMode="Static" MaxLength="50"  Width="250" /> 
            </td>
       </tr>
       <tr valign="top">
            <td> <asp:Label ID="Label1" runat="server" Text="Active" /> </td>
            <td> <asp:CheckBox runat="server" ID="chkActive" ClientIDMode="Static" Width="250" /> 
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


