<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobSeeker.Master" AutoEventWireup="true" CodeBehind="HelpJobseeker.aspx.cs" Inherits="JobPortal.HelpJobseeker" %>
<%@ Register TagName="HelpJobseeker" TagPrefix="uc1" Src="~/Content/Help.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HelpJobseeker id="helpjobseeek" runat="Server"></uc1:HelpJobseeker>
</asp:Content>
