<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobRecruiter.Master" AutoEventWireup="true" CodeBehind="Recruiter_AddJobPost.aspx.cs" Inherits="JobPortal.Recruiter_AddJobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><h2>Add/Post Job...</h2></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>Job Title:</td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Min Exp (Year):</td>
            <td><asp:TextBox ID="txtminexperience" runat="server"></asp:TextBox> Year</td>
        </tr>
        <tr>
            <td>Max Exp (Year):</td>
            <td><asp:TextBox ID="txtmaxexperience" runat="server"></asp:TextBox> Year</td>
        </tr>
        <tr>
            <td>Min Salary (Rs.):</td>
            <td><asp:TextBox ID="txtminsalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Max Salary (Rs.):</td>
            <td><asp:TextBox ID="txtmaxsalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>No of vacancies:</td>
            <td><asp:TextBox ID="txtvacancies" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Comments:</td>
            <td><asp:TextBox ID="txtrecuitercomment" Width="165px" Height="40px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsave_recruiterpost" Text="Save" ForeColor="White" BackColor="Gray" runat="server" OnClick="btnsave_recruiterpost_Click" /></td>
        </tr>

    </table>
</asp:Content>
