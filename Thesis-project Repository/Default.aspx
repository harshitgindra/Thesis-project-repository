<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis_project_Repository.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--   <link href="../css/layout.css" rel="stylesheet" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />


    <%--<link href="Resources/css/bootstrap-glyphicons.css" rel="stylesheet" />
    <link href="Resources/css/index.css" rel="stylesheet" />
    <script src="Resources/js/bootstrap.js"></script>
    <link href="Resources/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Resources/js/modernizr-2.6.2.min.js"></script>
    <script src="Resources/js/jquery.min.js"></script>--%>


    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            left: 12px;
            top: 531px;
            width: 655px;
        }
    </style>
</head>
<body>
    <%--  Login Page--%>
    <form id="loginForm" runat="server">
        <div class="container" id="mainpage">
            <div class="navbar navbar-fixed-top">
                <div class="visible-sm pager">
                    <img src="Resources/images/logo.jpg" alt="Your Logo" /></div>
                <a class="navbar-brand" href="Default.aspx" id="websiteLogo">
                    <img class="hidden-sm" src="Resources/images/logo.jpg" alt="Your Logo" /></a>
                <div class="nav-collapse collapse navbar-responsive-collapse">

                    <ul class="nav navbar-nav  center">
                        <li>
                            <a href="Default.aspx">Home</a>
                        </li>
                        <li>
                            <asp:LinkButton  ID="Button3" runat="server" OnClick="SignUpLink" Text="Sign Up" /></li>
                        <li>
                            <asp:LinkButton  ID="LinkButton1" runat="server" OnClick="LoginLink" Text="Log In" /></li>
                    </ul>
                </div>
            </div>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                <asp:View ID="View1" runat="server">
                    <div class="container">
                        <%--<img id="mainimage" src="Resources/images/library.jpg" />--%>
                    </div>
                </asp:View>
                <asp:View ID="loginPage" runat="server">
                    <div class="container">
                        <div class="defaultviews">
                            <table>
                                <tr>
                                    <td>User Name</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="loginUserName" TextMode="Email" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="loginUserName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="UserId is Required"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="Password" ID="loginPassword"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="loginPassword" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is Required" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Remember Me:
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Login" OnClick="Login" />

                                        <asp:LinkButton ID="Button2" class="btn btn-default" runat="server" OnClick="ForgotPassword" Text="Forgot Password" />
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
                    </div>
                </asp:View>

                <%--  Login Page End--%>

                <%--  SignUp Page Start--%>
                <asp:View ID="signUpPage" runat="server">
                   
                    <div class="container">
                       
                        <div class="auto-style1" >
                         <h1>Sign Up Form</h1>
                        <table >
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
                                    <asp:RequiredFieldValidator ControlToValidate="lname" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Last Name is Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>User name:
                                </td>
                                <td>
                                    <asp:TextBox ID="signUpUsername" runat="server" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="signUpUsername" ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                                    <asp:CompareValidator ControlToValidate="signUpPassword2" ControlToCompare="signUpPassword" ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Security Question</td>
                                <td>
                                    <asp:TextBox runat="server" ID="secques"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="secques" ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Security Answer</td>
                                <td>
                                    <asp:TextBox runat="server" ID="secans"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="secans" ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Phone Number</td>
                                <td>
                                    <asp:TextBox runat="server" ID="phoneNumber" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="phoneNumber" ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ControlToValidate="ntwrkprovider" ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ControlToValidate="accType" ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button Text="Submit" class="btn btn-default" ID="signUp" runat="server" OnClick="SignUp"></asp:Button>
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
                            </div>
                    </div>
                </asp:View>
                <%--  SignUp Page End--%>

                <%--  SignUp Page Start--%>
                <asp:View ID="forgotPasswordPage" runat="server">
                    <div class="container">
                        <div class="defaultviews">
                            <table>
                                <tr>
                                    <td>Please Enter your Email ID here: </td>
                                    <td>
                                        <asp:TextBox ID="forgotEmailId" runat="server" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="forgotEmailId" ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ControlToValidate="FpAccntType" ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ControlToValidate="retrievelMethodRadioList" ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="forgotpassword" class="btn btn-default" runat="server" Text="Retrieve Password" OnClick="RetrieveForgotPassword" />
                                    </td>
                                    <td>
                                        <asp:Label ID="confirationMessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:View>

                <asp:View ID="changePasswordMessage" runat="server">
                    <div class="defaultviews container">
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
                                    <asp:RequiredFieldValidator ControlToValidate="NewPassword" ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Confirm Password:
                                </td>
                                <td>
                                    <asp:TextBox ID="CnfrmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="CnfrmPassword" ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ControlToValidate="CnfrmPassword" ControlToCompare="NewPassword" ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                                     </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="UpdatePass" class="btn btn-default" runat="server" Text="Change Password" OnClick="UpdatePasswordUsingSms" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="UpdatePasswordFromSMSConfirmation" runat="server" Text="Label"></asp:Label>
                                </td>

                            </tr>
                        </table>
                    </div>
                </asp:View>

                <%--  SignUp Page End--%>
            </asp:MultiView>
            <footer class="footer">
                <div class="container">
                    <div data-role="content" style="text-align: center;">
                        <div class="col-sm-2">
                            <h6>Copyright &COPY; 2013 Harshit Gindra</h6>
                        </div>
                        <a href="AboutUs.aspx">About us</a>
                        <a href="#">Contact us</a>
                    </div>
                    <h6>&copyAmitesh, Kaveh, Harshit</h6>
                </div>
            </footer>
        </div>

    </form>
    <script src="Resources/js/index.js"></script>
</body>
</html>
