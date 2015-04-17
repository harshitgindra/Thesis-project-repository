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
            <asp:Button ID="Button1" runat="server" Text="Search" />
            <br />
            <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <table>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="OmniResults" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DocumentSqlDataSource1" ForeColor="#333333" GridLines="None" DataKeyNames="username">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ReadOnly="True" />
                                <asp:HyperLinkField DataNavigateUrlFields="document_name, username" DataNavigateUrlFormatString="DownloadFile.aspx?document_name={0}&username={1}" DataTextField="document_name" HeaderText="Document Name" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:BoundField DataField="keywords" HeaderText="Keywords" SortExpression="keywords" />
                                <asp:BoundField DataField="date_uploaded" HeaderText="Date Uploaded" SortExpression="date_uploaded" />
                                <asp:CommandField HeaderText="View Details" SelectText="View Details" ShowSelectButton="True" />
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
or (OMNISEARCHRESULTSVIEW.keywords LIKE '%' + @Keywords+ '%')
or  (OMNISEARCHRESULTSVIEW.Name LIKE '%' + @Name+ '%')
or  (OMNISEARCHRESULTSVIEW.Date_uploaded LIKE '%' + @Date_Uploaded+ '%')
or  (OMNISEARCHRESULTSVIEW.username LIKE '%' + @username+ '%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="Document_Name" PropertyName="Text" DefaultValue="" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Title" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Keywords" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Name" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Date_Uploaded" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TextBox1" Name="username" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" HeaderText="Detailed View">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" ReadOnly="True" SortExpression="USERNAME" />
                                <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" SortExpression="FIRSTNAME" />
                                <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME" />
                                <asp:BoundField DataField="PHONENUMBER" HeaderText="PHONENUMBER" SortExpression="PHONENUMBER" />
                                <asp:BoundField DataField="CARRIER" HeaderText="CARRIER" SortExpression="CARRIER" />
                                <asp:BoundField DataField="PROJECT_TITLE" HeaderText="PROJECT_TITLE" SortExpression="PROJECT_TITLE" />
                                <asp:BoundField DataField="COURSE_NO" HeaderText="COURSE_NO" SortExpression="COURSE_NO" />
                                <asp:BoundField DataField="LIVE_LINK" HeaderText="LIVE_LINK" SortExpression="LIVE_LINK" />
                                <asp:BoundField DataField="KEYWORDS" HeaderText="KEYWORDS" SortExpression="KEYWORDS" />
                                <asp:BoundField DataField="ABSTRACT" HeaderText="ABSTRACT" SortExpression="ABSTRACT" />
                                <asp:BoundField DataField="DOCUMENT_LENGTH" HeaderText="DOCUMENT_LENGTH" SortExpression="DOCUMENT_LENGTH" />
                                <asp:BoundField DataField="DOCUMENT_NAME" HeaderText="DOCUMENT_NAME" SortExpression="DOCUMENT_NAME" />
                                <asp:BoundField DataField="SCREENCAST_LENGTH" HeaderText="SCREENCAST_LENGTH" SortExpression="SCREENCAST_LENGTH" />
                                <asp:BoundField DataField="SCREENCAST_NAME" HeaderText="SCREENCAST_NAME" SortExpression="SCREENCAST_NAME" />
                                <asp:BoundField DataField="COMMITTEE_CHAIR" HeaderText="COMMITTEE_CHAIR" SortExpression="COMMITTEE_CHAIR" />
                                <asp:BoundField DataField="COMMITTEE_CHAIR_APPROVAL" HeaderText="COMMITTEE_CHAIR_APPROVAL" SortExpression="COMMITTEE_CHAIR_APPROVAL" />
                                <asp:BoundField DataField="COMMITTEE_CHAIR_COMMENTS" HeaderText="COMMITTEE_CHAIR_COMMENTS" SortExpression="COMMITTEE_CHAIR_COMMENTS" />
                                <asp:BoundField DataField="COMMITTEE_MEMBERS" HeaderText="COMMITTEE_MEMBERS" SortExpression="COMMITTEE_MEMBERS" />
                                <asp:BoundField DataField="COMMITTEE_MEMBER_APPROVAL" HeaderText="COMMITTEE_MEMBER_APPROVAL" SortExpression="COMMITTEE_MEMBER_APPROVAL" />
                                <asp:BoundField DataField="COMMITTEE_MEMBER_COMMENTS" HeaderText="COMMITTEE_MEMBER_COMMENTS" SortExpression="COMMITTEE_MEMBER_COMMENTS" />
                                <asp:BoundField DataField="GRADUATE_ADVISOR" HeaderText="GRADUATE_ADVISOR" SortExpression="GRADUATE_ADVISOR" />
                                <asp:BoundField DataField="GRADUATE_ADVISOR_APPROVAL" HeaderText="GRADUATE_ADVISOR_APPROVAL" SortExpression="GRADUATE_ADVISOR_APPROVAL" />
                                <asp:BoundField DataField="GRADUATE_ADVISOR_COMMENTS" HeaderText="GRADUATE_ADVISOR_COMMENTS" SortExpression="GRADUATE_ADVISOR_COMMENTS" />
                                <asp:BoundField DataField="SEMESTER_COMPLETED" HeaderText="SEMESTER_COMPLETED" SortExpression="SEMESTER_COMPLETED" />
                                <asp:BoundField DataField="DATE_UPLOADED" HeaderText="DATE_UPLOADED" SortExpression="DATE_UPLOADED" />
                                <asp:BoundField DataField="FPP_DOCUMENT_NAME" HeaderText="FPP_DOCUMENT_NAME" SortExpression="FPP_DOCUMENT_NAME" />
                                <asp:BoundField DataField="FPP_SCREENCAST_NAME" HeaderText="FPP_SCREENCAST_NAME" SortExpression="FPP_SCREENCAST_NAME" />
                                <asp:BoundField DataField="FPP_DATE_UPLOADED" HeaderText="FPP_DATE_UPLOADED" SortExpression="FPP_DATE_UPLOADED" />
                                <asp:BoundField DataField="FPP_COMMITTEE_CHAIR_APPROVAL" HeaderText="FPP_COMMITTEE_CHAIR_APPROVAL" SortExpression="FPP_COMMITTEE_CHAIR_APPROVAL" />
                                <asp:BoundField DataField="FPP_COMMITTEE_CHAIR_COMMENTS" HeaderText="FPP_COMMITTEE_CHAIR_COMMENTS" SortExpression="FPP_COMMITTEE_CHAIR_COMMENTS" />
                                <asp:BoundField DataField="FPP_COMMITTEE_MEMBER_APPROVAL" HeaderText="FPP_COMMITTEE_MEMBER_APPROVAL" SortExpression="FPP_COMMITTEE_MEMBER_APPROVAL" />
                                <asp:BoundField DataField="FPP_COMMITTEE_MEMBER_COMMENTS" HeaderText="FPP_COMMITTEE_MEMBER_COMMENTS" SortExpression="FPP_COMMITTEE_MEMBER_COMMENTS" />
                                <asp:BoundField DataField="FPP_GRADUATE_ADVISOR_APPROVAL" HeaderText="FPP_GRADUATE_ADVISOR_APPROVAL" SortExpression="FPP_GRADUATE_ADVISOR_APPROVAL" />
                                <asp:BoundField DataField="FPP_GRADUATE_ADVISOR_COMMENTS" HeaderText="FPP_GRADUATE_ADVISOR_COMMENTS" SortExpression="FPP_GRADUATE_ADVISOR_COMMENTS" />
                                <asp:BoundField DataField="TS_DOCUMENT_NAME" HeaderText="TS_DOCUMENT_NAME" SortExpression="TS_DOCUMENT_NAME" />
                                <asp:BoundField DataField="TS_SCREENCAST_NAME" HeaderText="TS_SCREENCAST_NAME" SortExpression="TS_SCREENCAST_NAME" />
                                <asp:BoundField DataField="TS_COMMITTEE_CHAIR_APPROVAL" HeaderText="TS_COMMITTEE_CHAIR_APPROVAL" SortExpression="TS_COMMITTEE_CHAIR_APPROVAL" />
                                <asp:BoundField DataField="TS_COMMITTEE_CHAIR_COMMENTS" HeaderText="TS_COMMITTEE_CHAIR_COMMENTS" SortExpression="TS_COMMITTEE_CHAIR_COMMENTS" />
                                <asp:BoundField DataField="TS_COMMITTEE_MEMBER_APPROVAL" HeaderText="TS_COMMITTEE_MEMBER_APPROVAL" SortExpression="TS_COMMITTEE_MEMBER_APPROVAL" />
                                <asp:BoundField DataField="TS_COMMITTEE_MEMBER_COMMENTS" HeaderText="TS_COMMITTEE_MEMBER_COMMENTS" SortExpression="TS_COMMITTEE_MEMBER_COMMENTS" />
                                <asp:BoundField DataField="TS_DEPARTMENT_CHAIR" HeaderText="TS_DEPARTMENT_CHAIR" SortExpression="TS_DEPARTMENT_CHAIR" />
                                <asp:BoundField DataField="TS_DEPARTMENT_CHAIR_APPROVAL" HeaderText="TS_DEPARTMENT_CHAIR_APPROVAL" SortExpression="TS_DEPARTMENT_CHAIR_APPROVAL" />
                                <asp:BoundField DataField="TS_DEPARTMENT_CHAIR_COMMENTS" HeaderText="TS_DEPARTMENT_CHAIR_COMMENTS" SortExpression="TS_DEPARTMENT_CHAIR_COMMENTS" />
                                <asp:BoundField DataField="TS_DATE_UPLOADED" HeaderText="TS_DATE_UPLOADED" SortExpression="TS_DATE_UPLOADED" />
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM SEARCHRESULTS
WHERE USERNAME = @USERNAME">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="OmniResults" DefaultValue="" Name="username" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
