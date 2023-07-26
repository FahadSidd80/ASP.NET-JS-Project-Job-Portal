<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true"  CodeBehind="ManageCountry.aspx.cs" Inherits="JobPortal.ManageCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table> 
    <tr>
        <td>Country Name:</td>
        <td><asp:TextBox ID="txtcountry" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave_Country" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Country_Click" /></td>
    </tr>
</table>
</asp:Content>
