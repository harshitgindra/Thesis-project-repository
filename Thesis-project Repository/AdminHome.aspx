<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="Thesis_project_Repository.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Home</h1>
            <asp:Button ID="CheckListforApproval" runat="server" Text="Check waiting list" OnClick="CheckListforApproval_Click" />
        </div>
        <asp:SqlDataSource ID="approvalList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>"></asp:SqlDataSource>
        <asp:GridView ID="approvalwaitinglist" runat="server" AutoGenerateColumns="False" DataSourceID="approvalList" DataKeyNames="username">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:HyperLinkField DataNavigateUrlFields="username" DataNavigateUrlFormatString="AdminApproveAccount.aspx?username={0}" Text="Approve Account" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DetailedInfoList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [userinfo] WHERE ([username] = @username)">
            <SelectParameters>
                <asp:ControlParameter ControlID="approvalwaitinglist" Name="username" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DetailsView ID="DetailedInfoApprovalAccount" runat="server" AutoGenerateRows="False" DataSourceID="DetailedInfoList" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="firstname" HeaderText="firstname" SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            </Fields>
        </asp:DetailsView>
    </form>
</body>
</html>
