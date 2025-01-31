<%@ Page Title="" Language="C#" MasterPageFile="~/n2.Master" AutoEventWireup="true" CodeBehind="BLE.aspx.cs" Inherits="CampusNavigationWeb.BLE" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<div class="box1">
            	<div class="welbox"><div class="weltitle">BLE Devices</div></div>

<table class="tblStyle" width=100% rules="rows" border="1" cellpadding="10" cellspacing="5"
        style="border: 1px solid #D8D8D8;  background-color:#f1f1f1; ">
      
        <tr valign="top">
            <td>
                 <asp:Label ID="lblTotal" ForeColor="Teal" runat="server"  style="float:right;font-style:italic;"/><br />
                <br />

              
                 <asp:GridView runat="server" ID="gvBLEDevices" AutoGenerateColumns="false" Width="100%"
                    Style="max-height: 500px;border-color: lightblue;"   CellPadding="3" CellSpacing="3" 
                    DataKeyNames="ID" AlternatingRowStyle-BackColor="#ECF4FA"   GridLines="Both"
                    HeaderStyle-BackColor="#ffebe8" HeaderStyle-ForeColor="#985F5F"  
                     HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="Small" AllowPaging="true"
                    AutoGenerateEditButton="false" onrowdatabound="gvBLEDevices_RowDataBound"  >
                    
                    <AlternatingRowStyle BackColor="#ECF4FA"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField  ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/edit.png"
                            ShowEditButton="True" UpdateImageUrl="~/Images/update.png" />

                        <asp:TemplateField HeaderText="" >
	                        <ItemTemplate>
		                        <asp:Button ID="deleteButton" runat="server" CommandName="Delete"  CssClass="btnDelete" ToolTip="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete this BLE device?');" />
	                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="ID" HeaderText="BLE No" ControlStyle-Width="100"/>
                        <asp:BoundField  DataField="DeviceID" HeaderText="Device ID" ControlStyle-Width="100"/>

                        
                         <asp:TemplateField HeaderText="" >
	                        <ItemTemplate>
		                        <asp:ImageButton ID="trackButton" runat="server" CommandName="Track" ImageUrl="~/images/location.png" ToolTip="Track"
                                        OnClientClick="return true;" OnClick="trackButton_Click" style="height:16px;width:16px;" />
	                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    
                </asp:GridView>
            </td>
            </tr>
            <tr>
        <td>
        <br />
            <asp:Button ID="btnAdd" CssClass="subbutton1" runat="server" Text="Add BLE Device"  UseSubmitBehavior="false" CommandName="Add" ClientIDMode="Static"
                />
                <br /></td>
        </tr>
            </table>
    </div>
</asp:Content>

