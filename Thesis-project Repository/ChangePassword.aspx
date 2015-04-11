<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Thesis_project_Repository.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Label ID="TestMessage" runat="server"></asp:Label>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                        <td>New Password:
                        </td>
                        <td>
                            <asp:TextBox ID="NewPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm Password:
                        </td>
                        <td>
                            <asp:TextBox ID="CnfrmPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="UpdatePassword" runat="server" Text="Button" OnClick="UpdatePassword_Click" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:LinkButton ID="loginPage" runat="server" OnClick="loginPage_Click">SignIn</asp:LinkButton>
                                 </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="result" runat="server" Text=""></asp:Label>
                                 </td>
                    </tr>
                </table>
            </asp:View>

        </asp:MultiView>

        <div>
        </div>
    </form>
</body>
</html>
