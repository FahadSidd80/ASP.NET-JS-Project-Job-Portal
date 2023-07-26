<%@ Page Title="Manage Qualification" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageQualification.aspx.cs" Inherits="JobPortal.ManageQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Qualification:</td>
        <td><asp:TextBox ID="txtqualification" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave_Qualificaton" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Qualificaton_Click" /></td>
    </tr>
</table>
</asp:Content>
