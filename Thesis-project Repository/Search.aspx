<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Thesis_project_Repository.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Omni Search</h2>
            Enter a keyword:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="OmniSearchButton" Text="Search" />
            <br />
            <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <h2>Advanced Search:</h2>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="166px" AutoPostBack="true">
                <%--OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >--%>
                <asp:ListItem Text="Select Search Criterion" />
                <asp:ListItem>Title</asp:ListItem>
                <asp:ListItem>Semester</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>
                <asp:ListItem>Professor</asp:ListItem>
                <asp:ListItem>Uploaded Date </asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>Search All</asp:ListItem>
                            <asp:ListItem>Search by Keyword</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator></td>--%>
                </tr>
            </table>

            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <br />
            <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </div>

        <div>
            <asp:MultiView ID="SearchResults" runat="server" ActiveViewIndex="0">
                <asp:View ID="EmptyView" runat="server">
                </asp:View>
                <asp:View ID="OmniSearchResults" runat="server">
                    Search Results:<br />
                    <asp:GridView ID="OmniResults" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DocumentSqlDataSource1" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="username" DataNavigateUrlFormatString="Search.aspx?username={0}" DataTextField="document_name" HeaderText="Document Name" SortExpression="document_name" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Name" HeaderText="Author" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="keywords" HeaderText="Keywords" SortExpression="keywords" />
                            <asp:BoundField DataField="date_uploaded" HeaderText="Date Uploaded" SortExpression="date_uploaded" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="DocumentSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT *  FROM OMNISEARCHRESULTSVIEW 
WHERE (OMNISEARCHRESULTSVIEW.DOCUMENT_NAME LIKE '%' + @Document_Name + '%') 
OR (OMNISEARCHRESULTSVIEW.Title LIKE '%' + @Title+ '%') 
or (OMNISEARCHRESULTSVIEW.keywords LIKE '%' + @Keywords+ '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox1" Name="Document_Name" PropertyName="Text" DefaultValue="" />
                            <asp:ControlParameter ControlID="TextBox1" Name="Title" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TextBox1" Name="Keywords" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:View>
                <asp:View ID="AdvanceSearchResults" runat="server">
                    <asp:GridView ID="AdvanceResults" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <br />
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    <br />
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
