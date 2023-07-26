<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeeker_ChangePassword.aspx.cs" Inherits="JobPortal.JobSeeker_ChangePassword" %>
<%@ Register TagName="Changepassword" TagPrefix="uc1" Src="~/Content/ChangePasswordCommon.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:Changepassword id="ChangeSeekerPassword" runat="server"></uc1:Changepassword>
</asp:Content>
