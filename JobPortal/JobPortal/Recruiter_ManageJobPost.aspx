<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobRecruiter.Master" AutoEventWireup="true" CodeBehind="Recruiter_ManageJobPost.aspx.cs" Inherits="JobPortal.Recruiter_ManageJobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>Job Title:</td>
        <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>
            <asp:Button ID="btnsearch" runat="server" Text="Search" ForeColor="White" BackColor="Gray" OnClick="btnsearch_Click" />
            <asp:Button ID="btnrefresh" runat="server" Text="Refresh" ForeColor="White" BackColor="Gray" OnClick="btnrefresh_Click" />
        </td>
        
    </tr>
    <tr>
        <td></td>
        <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:GridView ID="grdjobpostget" runat="server" AutoGenerateColumns="False" OnRowCommand="grdjobpostget_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%#Eval("SerialNumber") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Job Title">
                    <ItemTemplate>
                        <%#Eval("jobprofilename") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Required Exp.">
                    <ItemTemplate>
                        <%#Eval("minexperience") %>
                        <Text>year</Text>
                        <Text>-</Text>
                        <%#Eval("maxexperience") %>
                        <Text>year</Text>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Offered Salary">
                    <ItemTemplate>
                        <Text>Rs.</Text>
                        <%#Eval("minsalary") %>
                        <Text>-</Text>
                        <Text>Rs.</Text>
                        <%#Eval("maxsalary") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="No Of Position">
                    <ItemTemplate>
                        <%#Eval("vacancies") %>
                        <Text> positions</Text>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Comments">
                    <ItemTemplate>
                        <%#Eval("comment") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnjobdelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%#Eval("jobid") %>' OnClientClick="return confirm('are you sure you want to delete...')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnjobedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("jobid") %>' ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView></td>
    </tr>
</table>
</asp:Content>
