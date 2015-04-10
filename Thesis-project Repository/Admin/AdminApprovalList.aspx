<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="~/Admin/AdminApprovalList.aspx.cs" Inherits="Thesis_project_Repository.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMaster" runat="server">
    <h1>Need Approval</h1>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">

        <asp:View ID="View1" runat="server">
            <h2>View 1</h2>
            <asp:SqlDataSource ID="approvalList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT [username], [password] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'"></asp:SqlDataSource>

            <asp:GridView ID="approvalwaitinglist" runat="server" AutoGenerateColumns="False" DataSourceID="approvalList" DataKeyNames="username">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"/>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username"/>
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password"/>
                    <asp:HyperLinkField DataNavigateUrlFields="username" DataNavigateUrlFormatString="AdminApproveAccount.aspx?username={0}" Text="Approve Account"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="DetailedInfoList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [userinfo] WHERE ([username] = @username)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="approvalwaitinglist" Name="username" PropertyName="SelectedValue" Type="String"/>
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DetailsView ID="DetailedInfoApprovalAccount" runat="server" AutoGenerateRows="False" DataSourceID="DetailedInfoList" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="firstname" HeaderText="firstname" SortExpression="firstname"/>
                    <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname"/>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username"/>
                </Fields>
            </asp:DetailsView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h2>View 2</h2>
            <asp:Label ID="approvalStatus" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>