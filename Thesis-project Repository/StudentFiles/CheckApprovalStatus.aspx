<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="CheckApprovalStatus.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">
    <h2>Preliminary report</h2>    
    <asp:Label ID="preliminaryappstatus" runat="server" Text=""></asp:Label>
    <br />
    <h2>Final report</h2>    
    <asp:Label ID="finalappstatus" runat="server" Text=""></asp:Label>
    <br />
    <h2>Thesis</h2>    
    <asp:Label ID="thesisappstatus" runat="server" Text=""></asp:Label>
</asp:Content>
