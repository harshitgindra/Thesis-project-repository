<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis_project_Repository.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="loginForm" runat="server">
        <div>
            <h1>Login Form</h1>
            <table>
                
                <tr>
                    <td>User Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="loginusername"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox runat="server" ID="loginPassword"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="forgotpassword" runat="server" OnClick="forgotpassword_Click" Text="Forgot Password"/>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="accstatus"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <hr />
    <%--</form>
    <form id="signUpForm" runat="server">--%>
        <h1>Sign Up Form</h1>
        <div>
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="fname"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="lname"></asp:TextBox></td>
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
                        <asp:TextBox runat="server" ID="secques"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Security Answer</td>
                    <td>
                        <asp:TextBox runat="server" ID="secans"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td>Type of Account:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="accType" runat="server">
                            <asp:ListItem Text="Student" Value="S" />
                            <asp:ListItem Text="Professor" Value="P" />
                            <asp:ListItem Text="Viewer" Value="V" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td><asp:button Text="Submit" id="signUpSubmit" runat="server" OnClick="SignUpSubmit"></asp:button>
                    </td>                   
                </tr>
            </table>
        </div>
    </form>

</body>
</html>
