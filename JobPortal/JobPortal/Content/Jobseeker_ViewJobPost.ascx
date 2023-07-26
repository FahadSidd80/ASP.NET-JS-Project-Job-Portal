<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Jobseeker_ViewJobPost.ascx.cs" Inherits="JobPortal.Content.Jobseeker_ViewJobPost" %>
<script language="javascript" type="text/javascript" >
    function Validation() {
        var cont = "";
        cont = checkJobTitle();
        cont += checkCompanyName();
        cont += checkSalary();
       

        if (cont == "") {
            return true;
        }
        else {
            alert(cont);
            return false;
        } 
    }

    function checkJobTitle() {
        var dd = document.getElementById('<%=ddljobprofile.ClientID%>');
        if (dd.value == "0") {
            return 'Please select job title...\n';
        }
        else{
            return "";
        } 
    }
    function checkCompanyName() {
        var cn = document.getElementById('<%=ddlcompanyname.ClientID%>');
        if (cn.value == "0") {
            return 'please select company name...\n';
        }
        else {
            return "";
        }
    }
    function checkSalary() {
        var sl = document.getElementById('<%=txtusersalary.ClientID%>');
        var exp = /^[0-9]*$/
        if (sl.value == "") {
            return 'please enter your salary..\n';
        }
        else if (exp.test(sl.value) ) {
            return "";
        }
        else {
            return "Please enter value only between 0-9\n";
        }  

        
    }
   
</script>

<table>
    <tr>
        <td>Job Title:</td>
        <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>
            <Text>Company Name: </Text><asp:DropDownList ID="ddlcompanyname" runat="server"></asp:DropDownList>
            <Text>Enter salary: </Text><asp:TextBox ID="txtusersalary" runat="server"></asp:TextBox>   
            <asp:Button ID="btnsearch" runat="server" Text="Search" ForeColor="White" BackColor="Gray" OnClientClick="return Validation()" OnClick="btnsearch_Click"/>
            <asp:Button ID="btnrefresh" runat="server" Text="Refresh" ForeColor="White" BackColor="Gray" OnClick="btnrefresh_Click" />  
        </td>   
    </tr>   
    <tr>
        <td></td>
        <td><asp:Label ID="lblrecruitermsg" runat="server"></asp:Label></td>
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
                 <asp:TemplateField HeaderText="Date Posted">
                    <ItemTemplate>
                        <%#Eval("noofdays") %>
                        <Text> days ago</Text>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Easy Apply">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnapply" runat="server" Text="Apply" CommandName="Aply" CommandArgument='<%#Eval("jobid") %>' OnClientClick="return confirm('Email will sent to recuiter for this job !! are you sure you want to apply...')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnjobedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("jobid") %>' ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
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