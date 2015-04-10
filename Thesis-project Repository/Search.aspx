<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Thesis_project_Repository.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>

        <h2>Omni Search</h2>

        Enter a keyword:<br/>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
        <br/>

    </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search"/>
    <br/>
    <br/>
    <h2>Advanced Search:</h2>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="166px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Text="Select Search Criterion"/>
        <asp:ListItem>username</asp:ListItem>
        <asp:ListItem>first name</asp:ListItem>
        <asp:ListItem>last name</asp:ListItem>
        <asp:ListItem>email</asp:ListItem>
        <asp:ListItem>phone number</asp:ListItem>
        <asp:ListItem>account type</asp:ListItem>
    </asp:DropDownList>
    <br/>
    <br/>
    <div id="div1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Search All</asp:ListItem>
                        <asp:ListItem>Search by Keyword</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" visible="False"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator></td>--%>
            </tr>
        </table>
    </div>
    <div id="div2" runat="server" visible="false">
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Search All</asp:ListItem>
                        <asp:ListItem>Search by Type</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" DataSourceID="TypeSqlDataSource" DataTextField="ACCTYPE" DataValueField="ACCTYPE" Visible="False">
                        <asp:ListItem Text="Select Type"/>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="TypeSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT DISTINCT [ACCTYPE] FROM [LOGININFO]"></asp:SqlDataSource>
                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="div3" runat="server" visible="false">
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Search by Keyword</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" visible="False"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator></td>--%>
            </tr>
        </table>
    </div>
    <br/>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search"/>
    <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
    <br/>
    <br/>
    <div id="div4" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="USERNAME" DataSourceID="UserInfoSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
            <Columns>
                <asp:CommandField ShowSelectButton="True"/>
                <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" SortExpression="FIRSTNAME"/>
                <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME"/>
                <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" ReadOnly="True" SortExpression="USERNAME"/>
                <asp:BoundField DataField="EMAILID" HeaderText="EMAILID" SortExpression="EMAILID"/>
                <asp:BoundField DataField="PHONENO" HeaderText="PHONENO" SortExpression="PHONENO"/>
            </Columns>
            <EditRowStyle BackColor="#999999"/>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
        <br/>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="USERNAME" DataSourceID="UserDetailsSqlDataSource" ForeColor="Black" GridLines="Horizontal" Height="50px" Width="125px">
            <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"/>
            <Fields>
                <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" SortExpression="FIRSTNAME"/>
                <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME"/>
                <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" ReadOnly="True" SortExpression="USERNAME"/>
                <asp:BoundField DataField="EMAILID" HeaderText="EMAILID" SortExpression="EMAILID"/>
                <asp:BoundField DataField="PHONENO" HeaderText="PHONENO" SortExpression="PHONENO"/>
            </Fields>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"/>
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right"/>
        </asp:DetailsView>
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" Height="35px" Width="169px">
            <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"/>
            <Fields>
                <asp:BoundField DataField="ACCTYPE" HeaderText="ACCTYPE" SortExpression="ACCTYPE"/>
            </Fields>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"/>
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right"/>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT [ACCTYPE] FROM [LOGININFO] WHERE ([USERNAME] = @USERNAME)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="USERNAME" PropertyName="SelectedValue" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="UserDetailsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [USERINFO] WHERE ([USERNAME] = @USERNAME)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="USERNAME" PropertyName="SelectedValue" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="UserInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM [USERINFO] WHERE (([LASTNAME] LIKE '%' + @LASTNAME + '%') OR ([USERNAME] LIKE '%' + @USERNAME + '%') OR ([FIRSTNAME] LIKE '%' + @FIRSTNAME + '%') OR ([EMAILID] LIKE '%' + @EMAILID + '%') OR ([PHONENO] LIKE '%' + @PHONENO + '%'))">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="LASTNAME" PropertyName="Text"/>
                <asp:ControlParameter ControlID="TextBox1" Name="USERNAME" PropertyName="Text"/>
                <asp:ControlParameter ControlID="TextBox1" Name="FIRSTNAME" PropertyName="Text"/>
                <asp:ControlParameter ControlID="TextBox1" Name="EMAILID" PropertyName="Text"/>
                <asp:ControlParameter ControlID="TextBox1" Name="PHONENO" PropertyName="Text"/>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

    <div id="div5" runat="server">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
            <EditRowStyle BackColor="#999999"/>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
        <br/>
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br/>


    </div>

</form>
</body>
</html>