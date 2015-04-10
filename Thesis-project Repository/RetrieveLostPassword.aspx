<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveLostPassword.aspx.cs" Inherits="Thesis_project_Repository.RetrieveLostPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:MultiView ID="ChangePasswordmultiview" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <table>
                    <tr>
                        <td>Enter new Password: 
                        </td>
                        <td>
                            <asp:TextBox ID="newpassword1" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Re-enter the password: 
                        </td>
                        <td>
                            <asp:TextBox ID="newpassword2" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="saveNewPassword" runat="server" Text="Change Password" OnClick="changepassword_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
            <%--  <asp:View ID="View2" runat="server">
                <asp:Label ID="PasswordChangeNotification" runat="server"></asp:Label>
            </asp:View>--%>
        </asp:MultiView>

        <div>
        </div>
    </form>
</body>
</html>
