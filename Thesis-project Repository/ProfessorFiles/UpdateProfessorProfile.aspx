﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="UpdateProfessorProfile.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.UpdateProfessorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server">
    <div>
        <table class="table">
            <tr>
                <td>UserName: </td>
                <td>
                    <asp:TextBox ID="username" runat="server" ReadOnly ="true"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Password: </td>
                <td>
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Confirm Password: </td>
                <td>
                    <asp:TextBox ID="cnfrmPassword" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>First Name: </td>
                <td>
                    <asp:TextBox ID="fname" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Last Name: </td>
                <td>
                    <asp:TextBox ID="lname" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Phone Number: </td>
                <td>
                    <asp:TextBox ID="phnNumber" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Provider: </td>
                <td>
                    <asp:TextBox ID="provider" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Security Question: </td>
                <td>
                    <asp:TextBox ID="secQuestion" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Security Answer: </td>
                <td>
                    <asp:TextBox ID="secAnswer" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div class="btn-group">
            <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Update Profile" OnClick="UpdateUserProfile" />
        </div>
                </td>
            </tr>
             </table>
       <asp:Label ID="updateResult" ForeColor="Green" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
