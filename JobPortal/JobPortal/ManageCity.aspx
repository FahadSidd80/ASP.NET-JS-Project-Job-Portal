<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageCity.aspx.cs" Inherits="JobPortal.ManageCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Country Name :</td>
        <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>State Name :</td>
        <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>City Name :</td>
        <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave_City" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_City_Click" /></td>
    </tr>
</table>
</asp:Content>
