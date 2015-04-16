<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteProfile.aspx.cs" Inherits="Thesis_project_Repository.DeleteProfile" %>

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
                        <asp:Label ID="Label1" runat="server" Text="Label">Are you sure you want to delete the account?
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="yes" runat="server" Text="Yes" OnClick="Yes" /> &nbsp;&nbsp;
                        <asp:Button ID="no" runat="server" Text="No" OnClick="No" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
