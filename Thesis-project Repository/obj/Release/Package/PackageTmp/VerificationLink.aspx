<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="VerificationLink.aspx.cs" Inherits="Thesis_project_Repository.VerificationLink1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainTemplate" runat="server">
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
</asp:Content>
