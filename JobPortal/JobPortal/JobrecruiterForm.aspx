<%@ Page Title="" Language="C#" MasterPageFile="~/MasterDefault.Master" AutoEventWireup="true" CodeBehind="JobrecruiterForm.aspx.cs" Inherits="JobPortal.JobrecruiterForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td><h1>Recruiter Sign Up page...</h1></td>
    </tr>
</table>
<table>
    
    <tr>
        <td>Company Name:</td>
        <td><asp:TextBox ID="txtcompanyname" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Company URL:</td>
        <td><asp:TextBox ID="txtcompanyurl" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Country:</td>
        <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
     <tr>
        <td>State:</td>
        <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
     <tr>
        <td>City:</td>
        <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
    </tr>
     <tr>
        <td>Company Address:</td>
        <td><asp:TextBox ID="txtcompanyaddress" runat="server" TextMode="MultiLine" height="20px" Width="165px"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Company HR:</td>
        <td><asp:TextBox ID="txthrname" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Conatct Number:</td>
        <td><asp:TextBox ID="txtcompanymobile" runat="server"></asp:TextBox></td>
    </tr>
     <tr id="tremail" runat="server">
        <td>Company Email:</td>
        <td><asp:TextBox ID="txtcompanyemail" runat="server"></asp:TextBox> </td>
    </tr>
     <tr id="trpassword" runat="server">
        <td>Company Password:</td>
        <td><asp:TextBox ID="txtcompanypassword" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td></td>
        <td><asp:Button ID="btnsaverecruiter" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsaverecruiter_Click" />
            <a href="Login.aspx">Sign In</a>
        </td>
    </tr>
</table>
</asp:Content>
