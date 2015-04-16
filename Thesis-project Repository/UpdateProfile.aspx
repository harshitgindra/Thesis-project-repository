<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Thesis_project_Repository.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr><td>UserName: </td>
            <td>
                <asp:Label ID="username" runat="server" Text="Label"></asp:Label> 
            </td></tr>
         <tr><td>Password: </td>
            <td>
                <asp:Label ID="password" runat="server" Text="Label"></asp:Label>    
            </td></tr>
        <tr><td>Confirm Password: </td>
            <td>
                <asp:Label ID="cnfrmPassword" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>First Name: </td>
            <td>
                <asp:Label ID="fname" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>Last Name: </td>
            <td>
                <asp:Label ID="lname" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>Phone Number: </td>
            <td>
                <asp:Label ID="phnNumber" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>Provider: </td>
            <td>
                <asp:Label ID="provider" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>Security Question: </td>
            <td>
                <asp:Label ID="secQuestion" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td>Security Answer: </td>
            <td>
                <asp:Label ID="secAnswer" runat="server" Text="Label"></asp:Label>
            </td></tr>
         <tr><td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="UpdateUserProfile" />
            </td></tr>
         <tr><td>
             <asp:Label ID="updateResult" runat="server" Text="Label"></asp:Label>
             </td>
            <td>
               
            </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
