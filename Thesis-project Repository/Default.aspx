<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis_project_Repository.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <%--  <link href="../css/layout.css" rel="stylesheet" />--%>
    <title></title>
</head>
<body>
    <%--  Login Page--%>
    <form id="loginForm" runat="server">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <h1>Login Form</h1>
                <table>
                    <tr>
                        <td>User Name</td>
                        <td>
                            <asp:TextBox runat="server" ID="loginUserName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox runat="server" ID="loginPassword"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Remember Me:     
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Login" />
                        </td>
                        <tr>
                            <td>
                                <asp:LinkButton ID="Button2" runat="server" OnClick="ForgotPassword" Text="Forgot Password" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="Button3" runat="server" OnClick="SignUpLink" Text="SignUp" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="loginResult"></asp:Label>
                            </td>
                        </tr>
                    </tr>
                </table>
            </asp:View>

            <%--  Login Page End--%>

            <%--  SignUp Page Start--%>
            <asp:View ID="View2" runat="server">
                <h1>Sign Up Form</h1>
                <table>
                    <tr>
                        <td>First Name</td>
                        <td>
                            <asp:TextBox runat="server" ID="fname"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td>
                            <asp:TextBox runat="server" ID="lname"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>User name:
                        </td>
                        <td>
                            <asp:TextBox ID="signUpUsername" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="usernameerror" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:
                        </td>
                        <td>
                            <asp:TextBox ID="signUpPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm Password:
                        </td>
                        <td>
                            <asp:TextBox ID="signUpPassword2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email ID
                        </td>
                        <td>
                            <asp:TextBox ID="signUpEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Security Question</td>
                        <td>
                            <asp:TextBox runat="server" ID="secques"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Security Answer</td>
                        <td>
                            <asp:TextBox runat="server" ID="secans"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Phone Number</td>
                        <td>
                            <asp:TextBox runat="server" ID="phoneNumber"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Provider</td>
                        <td>
                            <asp:TextBox runat="server" ID="provider"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Type of Account:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="accType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Student" Value="S" />
                                <asp:ListItem Text="Professor" Value="P" />
                                <asp:ListItem Text="Viewer" Value="V" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button Text="Submit" ID="signUp" runat="server" OnClick="SignUp"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <%--  SignUp Page End--%>
        </asp:MultiView>
    </form>

</body>
</html>
