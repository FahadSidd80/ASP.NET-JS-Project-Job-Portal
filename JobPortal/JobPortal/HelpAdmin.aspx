<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="HelpAdmin.aspx.cs" Inherits="JobPortal.HelpAdmin" %>
<%@ Register TagName="helpAdmin" TagPrefix="uc1" Src="~/Content/Help.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:helpAdmin id="helpadmin" runat="server" />
</asp:Content>
