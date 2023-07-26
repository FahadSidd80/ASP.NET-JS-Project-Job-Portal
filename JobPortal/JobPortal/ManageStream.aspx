<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageStream.aspx.cs" Inherits="JobPortal.ManageStream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Qualification :</td>
        <td><asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Stream :</td>
        <td><asp:TextBox ID="txtstream" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave_stream" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_stream_Click" /></td>
    </tr>
</table>
</asp:Content>
