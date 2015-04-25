<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Thesis_project_Repository.ChangePassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainTemplate" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:Label ID="TestMessage" runat="server"></asp:Label>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="container">
                <div class="defaultviews">
                    <div class="input-group" style="width: 240px;">
                        <asp:TextBox class="form-control" placeholder="New Password" TextMode="Password" aria-describedby="basic-addon1" runat="server" ID="NewPassword"></asp:TextBox>

                    </div>
                    <div class="input-group" style="width: 240px; padding-top: 0.5em;">
                        <asp:TextBox class="form-control" TextMode="Password" placeholder="Confirm Password" aria-describedby="basic-addon1" runat="server" ID="CnfrmPassword"></asp:TextBox>

                    </div>
                    <div class="btn-group" role="group" aria-label="..." style="padding-top: 0.5em;">
                        <asp:Button ID="UpdatePass" class="btn btn-default" runat="server" Text="Change Password" OnClick="UpdatePassword" />
                    </div>
                    <br />
                     <asp:Label ID="result" ForeColor="Green" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:View>
       
    </asp:MultiView>
</asp:Content>
