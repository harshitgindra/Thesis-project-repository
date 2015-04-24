<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserApproval.aspx.cs" Inherits="Thesis_project_Repository.Admin.AdminUserApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMaster" runat="server">
    <asp:MultiView ID="MultiView1" ActiveViewIndex="1" runat="server">
        <asp:View ID="View1" runat="server">
            Please select from the above tabs.
        </asp:View>
        <asp:View ID="View2" runat="server">
            
            <asp:SqlDataSource ID="approvalList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT [username], [acctype], admin_approval FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'"></asp:SqlDataSource>
 <div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">User Approval List</div>
            <asp:GridView ID="approvalwaitinglist" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="approvalList" DataKeyNames="username" AllowSorting="True" AllowPaging="true">
                <Columns>
                    <%--<asp:CommandField ShowSelectButton="True" />--%>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" ReadOnly="True" />
                    <asp:BoundField DataField="acctype" HeaderText="acctype" SortExpression="acctype" />
                    <asp:BoundField DataField="admin_approval" HeaderText="admin_approval" SortExpression="admin_approval" />
                    <asp:HyperLinkField DataNavigateUrlFields="username, acctype" DataNavigateUrlFormatString="AdminUserApproval.aspx?username={0}&acctype={1}" Text="Approve Account" />
                </Columns>
            </asp:GridView>
           <%-- <asp:SqlDataSource ID="DetailedInfoList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [logininfo] WHERE ([username] = @username)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="approvalwaitinglist" Name="username" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DetailsView ID="DetailedInfoApprovalAccount" runat="server" AutoGenerateRows="False" DataSourceID="DetailedInfoList" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="username" HeaderText="firstname" SortExpression="firstname" />
                    <asp:BoundField DataField="acctype" HeaderText="lastname" SortExpression="lastname" />

                </Fields>
            </asp:DetailsView>--%>
            <asp:Label ID="Label1" runat="server"></asp:Label>
     </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
