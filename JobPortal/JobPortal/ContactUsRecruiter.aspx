<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobRecruiter.Master" AutoEventWireup="true" CodeBehind="ContactUsRecruiter.aspx.cs" Inherits="JobPortal.ContactUsRecruiter" %>
<%@ Register TagName="ContactUsCommon" TagPrefix="uc1" Src="~/Content/ContactUsCommon.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ContactUsCommon id="ContactUsCommon" runat="Server"></uc1:ContactUsCommon>
</asp:Content>
