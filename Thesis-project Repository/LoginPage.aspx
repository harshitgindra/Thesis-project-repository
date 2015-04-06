<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Thesis_project_Repository.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            userName:  
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            Password:
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
