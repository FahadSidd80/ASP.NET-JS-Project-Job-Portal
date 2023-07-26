<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageSkills.aspx.cs" Inherits="JobPortal.ManageSkills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Job Profile:</td>
        <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
    </tr>
     <tr>
        <td>Skills :</td>
        <td><asp:TextBox ID="txtskills" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td></td>
        <td><asp:Button ID="Btnsave_Skill" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="Btnsave_Skill_Click" /></td>
    </tr>
</table>
</asp:Content>
