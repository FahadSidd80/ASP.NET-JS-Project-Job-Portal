<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageJobProfile.aspx.cs" Inherits="JobPortal.ManageJobProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Job Profile:</td>
        <td><asp:TextBox ID="txtjobprofile" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="Btnsave_Jobprofile" runat="server" ForeColor="White" BackColor="Gray" Text="Save" OnClick="Btnsave_Jobprofile_Click" /></td>
    </tr>
   
</table>
</asp:Content>
