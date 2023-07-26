<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobSeeker.Master" AutoEventWireup="true" CodeBehind="Jobseeker_ViewJobPost.aspx.cs" Inherits="JobPortal.Jobseeker_ViewJobPost" %>
<%@ Register TagPrefix="uc1" TagName="Jobseeker_ViewJobPost" Src="~/Content/Jobseeker_ViewJobPost.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Jobseeker_ViewJobPost id="JobseekerViewJobPost1" runat="server"></uc1:Jobseeker_ViewJobPost>
</asp:Content>
