<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordCommon.ascx.cs" Inherits="JobPortal.Content.ChangePasswordCommon" %>
<%--<script language="javascript" type="text/javascript">
    function Validation() {
        var alt = "";
        alt = checkUpdatepassword();
        if (alt == "") {
            alert('your password updated successfully, please click Ok to logout !!');
            return true;
            Response.redirect("Logout.aspx");
        }
        else {
            alert(alt);
            return false;
        }
    }
    function checkUpdatepassword() {
        var ps = document.getElementById('<%=lblmsg.ClientID%>');
        if (ps.value == "") {
            return "";
            
        } else {
            return "Old password didn't match, Enter correct password!!";
        }
    }
</script>--%>
<table>
     <tr>
                    <td>Old Password :</td>
                    <td><asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                      <td>New Password :</td>
                      <td><asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                      <td>Confirm New Password :</td>
                      <td><asp:TextBox ID="txtconfirmnewpassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnupdatepassword" runat="server" Text="Update Password"  /></td>
                    <%--<td><asp:Button ID="btnresetpassword" runat="server" Text="Password Reset"  /></td>--%>
                </tr>
                <tr>
                      <td></td>
                      <td><asp:Label ID="lblmsg" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>

</table>