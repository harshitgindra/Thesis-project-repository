<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Thesis_project_Repository.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <asp:MultiView ID="retrievepassword" ActiveViewIndex="1" runat="server">
        <asp:View ID="forgotpwdview" runat="server">
            <div>
                <h1>Please Enter your Email ID here: </h1>
                <asp:TextBox ID="forgotEmailId" runat="server"></asp:TextBox>
                <asp:Button ID="forgotpwdemail" runat="server" Text="Retrieve Password" OnClick="forgotpwdemail_Click"/>
            </div>
        </asp:View>

        <asp:View ID="confirmationview" runat="server">
            <asp:Label ID="confimationmsg" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</form>
</body>
</html>