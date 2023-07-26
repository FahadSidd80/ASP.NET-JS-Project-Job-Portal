<%@ Page Title="" Language="C#" MasterPageFile="~/MasterJobRecruiter.Master" AutoEventWireup="true" CodeBehind="RecruiterHome.aspx.cs" Inherits="JobPortal.RecruiterHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<script language="javascript" type="text/javascript">
    function Validation() {
        var msg = "";
        msg = checkAlert();
        if (msg == "") {
            return true;
        }
        else {
            alert(msg);
            return false;
        }
    }
    function checkAlert() {
        
        var dd = document.getElementById('<%%>'); 
    }
    function checkDeleteAlert() {

    }

</script>--%>


<table>
    <tr>
        <td><h1>Welcome <asp:Label ID="lblrecruitermsg" runat="server"></asp:Label></h1></td>
    </tr>
</table>
<table>
    <tr>
        <td></td>
        <td><asp:GridView ID="grdrecruiter" runat="server" OnRowCommand="grdrecruiter_RowCommand" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%#Eval("SerialNumber") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="URL">
                    <ItemTemplate>
                        <%#Eval("url") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Address">
                    <ItemTemplate>
                        <%#Eval("address") %>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <%#Eval("countryname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <%#Eval("statename") %>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <%#Eval("cityname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Person">
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email ID">
                    <ItemTemplate>
                        <%#Eval("emailid") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Number">
                    <ItemTemplate>
                        <%#Eval("contactno") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="Del"  CommandArgument='<%#Eval("recruiterid") %>' OnClientClick="return confirm('are you sure you want to delete....??')" />  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("recruiterid") %>'  />
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
    <table>
        <tr>
            <td><asp:Label ID="lbldeletemsg" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
