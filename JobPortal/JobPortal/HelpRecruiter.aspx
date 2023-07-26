<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobRecruiter.Master" AutoEventWireup="true" CodeBehind="HelpRecruiter.aspx.cs" Inherits="JobPortal.HelpRecruiter" %>
<%@ Register TagName="helpRecruiter" TagPrefix="uc1" Src="~/Content/Help.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:helpRecruiter ID="helprec" runat="server" />
</asp:Content>
