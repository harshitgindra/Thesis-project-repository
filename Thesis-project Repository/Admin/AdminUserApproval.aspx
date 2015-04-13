<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserApproval.aspx.cs" Inherits="Thesis_project_Repository.Admin.AdminUserApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMaster" runat="server">
     <asp:MultiView ID="MultiView1" ActiveViewIndex="1" runat="server">
                    <asp:View ID="View1" runat="server">
                        Please select from the above tabs.
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <h2>View 1</h2>
                        <asp:SqlDataSource ID="approvalList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT [username] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'"></asp:SqlDataSource>

                        <asp:GridView ID="approvalwaitinglist" runat="server" AutoGenerateColumns="False" DataSourceID="approvalList" DataKeyNames="username">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                               <%-- What is the meaning of {0} in the below link--%>
                                <asp:HyperLinkField DataNavigateUrlFields="username" DataNavigateUrlFormatString="AdminUserApproval.aspx?username={0}" Text="Approve Account" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="DetailedInfoList" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [logininfo] WHERE ([username] = @username)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="approvalwaitinglist" Name="username" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:DetailsView ID="DetailedInfoApprovalAccount" runat="server" AutoGenerateRows="False" DataSourceID="DetailedInfoList" Height="50px" Width="125px">
                            <Fields>
                                <asp:BoundField DataField="username" HeaderText="firstname" SortExpression="firstname" />
                                <asp:BoundField DataField="acctype" HeaderText="lastname" SortExpression="lastname" />
                               
                            </Fields>
                        </asp:DetailsView>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </asp:View>
                </asp:MultiView>
</asp:Content>
