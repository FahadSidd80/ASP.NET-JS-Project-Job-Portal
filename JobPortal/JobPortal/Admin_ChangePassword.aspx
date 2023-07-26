<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Admin_ChangePassword.aspx.cs" Inherits="JobPortal.Admin_ChangePassword" %>
<%@ Register TagName="changepassword" TagPrefix="uc1" Src="~/Content/ChangePasswordCommon.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc1:changepassword id="changeadminpassword" runat="server"></uc1:changepassword>
</asp:Content>
