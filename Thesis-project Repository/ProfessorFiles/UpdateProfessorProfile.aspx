<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="UpdateProfessorProfile.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.UpdateProfessorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server">
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
             <asp:Label ID="updateResult" runat="server"></asp:Label>
             </td>
            <td>
               
            </td></tr>
    </table>
    </div>
    </form>
</asp:Content>
