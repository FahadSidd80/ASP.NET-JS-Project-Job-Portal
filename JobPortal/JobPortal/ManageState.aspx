<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageState.aspx.cs" Inherits="JobPortal.ManageState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Country Name:</td>
        <td><asp:DropDownList ID="ddlcountry" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>State Name: </td>
        <td><asp:TextBox ID="txtstate" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave_State" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_State_Click" /></td>
    </tr>
</table>
</asp:Content>
