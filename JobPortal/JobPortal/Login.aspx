<%@ Page  Title="" Language="C#" MasterPageFile="~/MasterDefault.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JobPortal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>User Type : </td>
        <td><asp:DropDownList ID="ddlusertype" runat="server">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                <asp:ListItem Text="JobSeeker" Value="2"></asp:ListItem>
                <asp:ListItem Text="Recruiter" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Email Id :</td>
        <td><asp:TextBox ID="txtloginemail" runat="server"></asp:TextBox>
            
   <%--         <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td>Password :</td>
        <td><asp:TextBox ID="txtloginpassword" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnlogin" Text="Login" runat="server" OnClick="btnlogin_Click" />
            <a href="JobseekerForm.aspx">SignUp for User</a>
            <a href="JobrecruiterForm.aspx">SignUp for Recruiter</a>
        </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Label ID="lblmsg" runat="server"  Font-Bold="true"></asp:Label></td>
    </tr>

</table>
</asp:Content>
