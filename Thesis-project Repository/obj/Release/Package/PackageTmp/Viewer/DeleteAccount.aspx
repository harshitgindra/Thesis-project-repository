<%@ Page Title="" Language="C#" MasterPageFile="~/Viewer/Viewer.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="Thesis_project_Repository.Viewer.DeleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ViewerTemplate" runat="server">
    <div>
        <div class="alert alert-danger" role="alert">
            <h3>
                <asp:Label ID="Label1" runat="server" Text="Label">Are you sure you want to delete the account?
                </asp:Label></h3>
        </div>
         <div style="text-align: center">
            <div class="btn-group">
                <asp:Button class="btn btn-danger btn-lg" ID="yes" runat="server" Text="Yes" OnClick="Yes" />
            </div>

            <div class="btn-group">
                <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="No" OnClick="No" />
            </div>
        </div>
        <div>
            <asp:Label ForeColor="Red" ID="status" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
