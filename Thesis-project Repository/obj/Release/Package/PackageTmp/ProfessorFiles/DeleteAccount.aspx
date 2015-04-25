<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.DeleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server">
    <div>
        <div class="alert alert-danger" role="alert">
            <asp:Label ID="Label1" runat="server" Text="Label">Are you sure you want to delete the account?
            </asp:Label>
        </div>
        <div class="btn-group">
            <asp:Button class="btn btn-default" ID="yes" runat="server" Text="Yes" OnClick="Yes" />
        </div>

         <div class="btn-group">
            <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="No" OnClick="No" />
        </div>
<div>
        <asp:Label ForeColor="Red" ID="status" runat="server" Text=""></asp:Label>
</div>    
</div>
</asp:Content>
