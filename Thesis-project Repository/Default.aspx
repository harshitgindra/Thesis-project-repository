<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis_project_Repository.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--   <link href="../css/layout.css" rel="stylesheet" />--%>
    <title></title>
</head>
<body>
    <%--  Login Page--%>
    <form id="loginForm" runat="server">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="loginPage" runat="server">

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
                </table>
            </asp:View>

            <%--  Login Page End--%>

            <%--  SignUp Page Start--%>
            <asp:View ID="signUpPage" runat="server">
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
                            <asp:DropDownList ID="ntwrkprovider" runat="server">
                                <asp:ListItem Selected="True">Select One</asp:ListItem>
                                <asp:ListItem>boost mobile</asp:ListItem>
                                <asp:ListItem>t-mobile</asp:ListItem>
                                <asp:ListItem>virgin mobile</asp:ListItem>
                                <asp:ListItem>cingular</asp:ListItem>
                                <asp:ListItem>sprint nextel</asp:ListItem>
                                <asp:ListItem>verizon</asp:ListItem>
                                <asp:ListItem>nextel</asp:ListItem>
                                <asp:ListItem>us cellular</asp:ListItem>
                                <asp:ListItem>suncom</asp:ListItem>
                                <asp:ListItem>powertel</asp:ListItem>
                                <asp:ListItem>att cingular</asp:ListItem>
                                <asp:ListItem>alltel</asp:ListItem>
                                <asp:ListItem>metro pcs</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
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
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LoginLink" Text="Log In" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="SignUpReply" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <%--  SignUp Page End--%>

            <%--  SignUp Page Start--%>
            <asp:View ID="forgotPasswordPage" runat="server">
                <table>
                    <tr>
                        <td>Please Enter your Email ID here: </td>
                        <td>
                            <asp:TextBox ID="forgotEmailId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Account Type:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="FpAccntType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Student" Value="S" />
                                <asp:ListItem Text="Professor" Value="P" />
                                <asp:ListItem Text="Viewer" Value="V" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>Retrievel Method:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="retrievelMethodRadioList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Email" Value="E" />
                                <asp:ListItem Text="Message" Value="M" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="forgotpassword" runat="server" Text="Retrieve Password" OnClick="RetrieveForgotPassword" />
                        </td>
                        <td>
                            <asp:Label ID="confirationMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>

            <asp:View ID="changePasswordMessage" runat="server">
                  <table>
                      <tr>
                    <td>
                        Verification Code:
                    </td>
                    <td>
                        <asp:TextBox ID="VerificationCode" runat="server" EnableViewState="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password:
                    </td>
                    <td>
                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password:
                    </td>
                    <td>
                        <asp:TextBox ID="CnfrmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="UpdatePass" runat="server" Text="Change Password" OnClick="UpdatePasswordFromSMS"/>
                    </td>
                </tr>
                       <tr>
                    <td>
                        <asp:Label ID="UpdatePasswordFromSMSConfirmation" runat="server" Text="Label"></asp:Label>
                    </td>
                   
                </tr>
            </table>
            </asp:View>

            <%--  SignUp Page End--%>
        </asp:MultiView>
    </form>

</body>
</html>
