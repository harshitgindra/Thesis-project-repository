<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationLink.aspx.cs" Inherits="Thesis_project_Repository.VerificationLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="verificationstatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="TakeToLogin" runat="server" OnClick="TakeToLoginPage">Login</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</form>
</body>
</html>