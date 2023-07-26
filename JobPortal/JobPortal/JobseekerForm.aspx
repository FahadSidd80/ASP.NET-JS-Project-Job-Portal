<%@ Page Title="Job Seeker Form" Language="C#" MasterPageFile="~/MasterDefault.Master" AutoEventWireup="true" CodeBehind="JobseekerForm.aspx.cs" Inherits="JobPortal.JobseekerForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><h1>Job Seeker Registartion Form</h1></td>
        </tr>
    </table>
<table>
    <tr>
        <td>User Name :</td>
        <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Gender :</td>
        <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
            <asp:ListItem text="Male" Value="1"> </asp:ListItem>
            <asp:ListItem text="Female" Value="2"> </asp:ListItem>
            <asp:ListItem text="Other" Value="3"> </asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
      <tr>
        <td>Qualification :</td>
        <td><asp:DropDownList ID="ddlqualification" runat="server" OnSelectedIndexChanged="ddlqualification_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Stream :</td>
        <td><asp:DropDownList ID="ddlstream" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Job Profile :</td>
        <td><asp:DropDownList ID="ddljobprofile" runat="server" OnSelectedIndexChanged="ddljobprofile_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>    
    </tr>
    <tr id="tr_skills" runat="server">
        <td>Skills :</td>
        <td><asp:CheckBoxList ID="cblskills" runat="server" RepeatColumns="6"></asp:CheckBoxList></td>
    </tr>
     <tr>
        <td>Address :</td>
        <td><asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Country</td>
        <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>State :</td>
        <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>City :</td>
        <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
    </tr>
     <tr>
        <td>MobileNo :</td>
        <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Resume Upload :</td>
        <td><asp:FileUpload ID="furesume" runat="server" /></td>
    </tr>
     <tr>
        <td>Image Upload :</td>
        <td><asp:FileUpload ID="fuimg" runat="server" /></td>
    </tr>
     <tr>
        <td>Email Address :</td>
        <td><asp:TextBox id="txtemail" runat="server"></asp:TextBox></td>
    </tr>
     <%--<tr>
        <td>Confirm Email Address :</td>
        <td><asp:TextBox ID="txtconfirmemail" runat="server"></asp:TextBox></td>
    </tr>--%>
     <tr>
        <td>Password :</td>
        <td><asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
     <%--<tr>
        <td>Confirm Password :</td>
        <td><asp:TextBox ID="txtconfirmpassword" runat="server"></asp:TextBox></td>
    </tr>--%>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsave" runat="server" Text="Register" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" />
            <a href="Login.aspx">Sign In</a>
        </td>
    </tr>
</table>
</asp:Content>
