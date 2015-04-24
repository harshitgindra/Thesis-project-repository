<%@ Page Title="" Language="C#" MasterPageFile="~/Viewer/Viewer.Master" AutoEventWireup="true" CodeBehind="SearchProjects.aspx.cs" Inherits="Thesis_project_Repository.Viewer.SearchProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ViewerTemplate" runat="server">
    <div class="container">
        <h2 style="text-align: center;">Omni Search</h2>
        <br />
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox placeholder="Search for..." class="form-control" ID="TextBox1" runat="server" aria-describedby="basic-addon1" />
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                <span class="input-group-btn">
                    <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search" />
                </span>
            </div>
        </div>
        <div class="btn-group">
            <asp:Button class="btn btn-default" ID="jsonoutput" runat="server" Text="Export to JSON" OnClick="jsonoutput_Click" />
        </div>
        <asp:Label ForeColor="Red" ID="Label6" runat="server" />
        <br />
        <br />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading" style="text-align: center;"><b>Search Results</b></div>
            <%-- <table class="table">
            <tr>
                <td>--%>
            <asp:GridView ID="OmniResults" CssClass="table table-hover table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="DocumentSqlDataSource1" DataKeyNames="username">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Author" SortExpression="Name" ReadOnly="True" />
                    <asp:HyperLinkField DataNavigateUrlFields="document_name, username" DataNavigateUrlFormatString="../DownloadFile.aspx?document_name={0}&amp;username={1}" DataTextField="document_name" HeaderText="Document Name" SortExpression="document_name" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="keywords" HeaderText="Keywords" SortExpression="keywords" />
                    <asp:BoundField DataField="date_uploaded" HeaderText="Date Uploaded" SortExpression="date_uploaded" />
                     </Columns>
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
        </div>
    </div>
</asp:Content>
