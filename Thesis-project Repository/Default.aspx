<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis_project_Repository.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--   <link href="../css/layout.css" rel="stylesheet" />--%>
    <meta charset="UTF-8" />
  <%--  
    
    
    <%--
     
     <script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
      <script src="Resources/js/index.js"></script>--%>
    <link href="Resources/css/index.css" rel="stylesheet" />
   
   <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css" />
  <%--    <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
    
    <script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    --%>
    
    <title></title>
</head>
<body>
    <%--  Login Page--%>
    <form id="loginForm" runat="server">
        <div data-role="page" id="mainpage">
            <div data-role="header">
                <div data-role="navbar" style="background-color:transparent">
                    
                    <div data-type="horizontal" style="text-align:center;">
                        <%--<a href="Default.aspx"><img src="Resources/images/logo.jpg" width="50" height="50" /></a>--%>
                        <asp:LinkButton ID="Button3" runat="server" OnClick="SignUpLink" Text="Sign Up"  />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LoginLink" Text="Log In" />

                    </div>
                </div>
            </div>
           
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" >
                 
                <asp:View ID="View1" runat="server">
                    <div id="firsthomepage">
                        <%--<img src="Resources/images/HomePageBackground.jpg" />--%>
                    </div>
                </asp:View>
                <asp:View ID="loginPage" runat="server">
                    <div id="logintable" class="mainview">
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
                                    <asp:TextBox runat="server" TextMode="Password" ID="loginPassword"></asp:TextBox>
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
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="loginResult"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
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
                                <asp:TextBox ID="signUpPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Confirm Password:
                            </td>
                            <td>
                                <asp:TextBox ID="signUpPassword2" TextMode="Password" runat="server"></asp:TextBox>
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
                                <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LoginLink" Text="Log In" />--%>
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
                            <td>Verification Code:
                            </td>
                            <td>
                                <asp:TextBox ID="VerificationCode" runat="server" EnableViewState="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>New Password:
                            </td>
                            <td>
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Confirm Password:
                            </td>
                            <td>
                                <asp:TextBox ID="CnfrmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="UpdatePass" runat="server" Text="Change Password" OnClick="UpdatePasswordUsingSms" />
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

             <div data-role="footer" data-position="fixed">
                 <div data-role="content" style="text-align:center;">
                      <a href="#">About us</a>
            <a href="#">Contact us</a>
                 </div>
                 <h6>&copyAmitesh, Kaveh, Harshit</h6>
           
        </div>
        </div>
       
    </form>
    <script src="Resources/js/index.js"></script>
</body>
</html>
