<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="SearchProjects.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">
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
        <br /><br />
      <div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Search Results</div>
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
                            <asp:CommandField HeaderText="" SelectText="View Details" ShowSelectButton="True" />
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
                    <br />

                    <asp:FormView ID="FormView1" CssClass="table table-hover table-striped" runat="server" DataKeyNames="document_name,USERNAME" DataSourceID="SqlDataSource1">
                        <EditItemTemplate>
                            USERNAME:
                                <asp:Label ID="USERNAMELabel1" runat="server" Text='<%# Eval("USERNAME") %>' />
                            <br />
                            FIRSTNAME:
                                <asp:TextBox ID="FIRSTNAMETextBox" runat="server" Text='<%# Bind("FIRSTNAME") %>' />
                            <br />
                            LASTNAME:
                                <asp:TextBox ID="LASTNAMETextBox" runat="server" Text='<%# Bind("LASTNAME") %>' />
                            <br />
                            PHONENUMBER:
                                <asp:TextBox ID="PHONENUMBERTextBox" runat="server" Text='<%# Bind("PHONENUMBER") %>' />
                            <br />
                            CARRIER:
                                <asp:TextBox ID="CARRIERTextBox" runat="server" Text='<%# Bind("CARRIER") %>' />
                            <br />
                            PROJECT_TITLE:
                                <asp:TextBox ID="PROJECT_TITLETextBox" runat="server" Text='<%# Bind("PROJECT_TITLE") %>' />
                            <br />
                            COURSE_NO:
                                <asp:TextBox ID="COURSE_NOTextBox" runat="server" Text='<%# Bind("COURSE_NO") %>' />
                            <br />
                            LIVE_LINK:
                                <asp:TextBox ID="LIVE_LINKTextBox" runat="server" Text='<%# Bind("LIVE_LINK") %>' />
                            <br />
                            KEYWORDS:
                                <asp:TextBox ID="KEYWORDSTextBox" runat="server" Text='<%# Bind("KEYWORDS") %>' />
                            <br />
                            ABSTRACT:
                                <asp:TextBox ID="ABSTRACTTextBox" runat="server" Text='<%# Bind("ABSTRACT") %>' />
                            <br />
                            DOCUMENT:
                                <asp:TextBox ID="DOCUMENTTextBox" runat="server" Text='<%# Bind("DOCUMENT") %>' />
                            <br />
                            DOCUMENT_LENGTH:
                                <asp:TextBox ID="DOCUMENT_LENGTHTextBox" runat="server" Text='<%# Bind("DOCUMENT_LENGTH") %>' />
                            <br />
                            DOCUMENT_NAME:
                                <asp:TextBox ID="DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("DOCUMENT_NAME") %>' />
                            <br />
                            SCREENCAST:
                                <asp:TextBox ID="SCREENCASTTextBox" runat="server" Text='<%# Bind("SCREENCAST") %>' />
                            <br />
                            SCREENCAST_LENGTH:
                                <asp:TextBox ID="SCREENCAST_LENGTHTextBox" runat="server" Text='<%# Bind("SCREENCAST_LENGTH") %>' />
                            <br />
                            SCREENCAST_NAME:
                                <asp:TextBox ID="SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("SCREENCAST_NAME") %>' />
                            <br />
                            COMMITTEE_CHAIR:
                                <asp:TextBox ID="COMMITTEE_CHAIRTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR") %>' />
                            <br />
                            COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            COMMITTEE_MEMBERS:
                                <asp:TextBox ID="COMMITTEE_MEMBERSTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBERS") %>' />
                            <br />
                            COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            GRADUATE_ADVISOR:
                                <asp:TextBox ID="GRADUATE_ADVISORTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR") %>' />
                            <br />
                            GRADUATE_ADVISOR_APPROVAL:
                                <asp:TextBox ID="GRADUATE_ADVISOR_APPROVALTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_APPROVAL") %>' />
                            <br />
                            GRADUATE_ADVISOR_COMMENTS:
                                <asp:TextBox ID="GRADUATE_ADVISOR_COMMENTSTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_COMMENTS") %>' />
                            <br />
                            SEMESTER_COMPLETED:
                                <asp:TextBox ID="SEMESTER_COMPLETEDTextBox" runat="server" Text='<%# Bind("SEMESTER_COMPLETED") %>' />
                            <br />
                            DATE_UPLOADED:
                                <asp:TextBox ID="DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("DATE_UPLOADED") %>' />
                            <br />
                            FPP_DOCUMENT:
                                <asp:TextBox ID="FPP_DOCUMENTTextBox" runat="server" Text='<%# Bind("FPP_DOCUMENT") %>' />
                            <br />
                            FPP_DOCUMENT_NAME:
                                <asp:TextBox ID="FPP_DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("FPP_DOCUMENT_NAME") %>' />
                            <br />
                            FPP_SCREENCAST:
                                <asp:TextBox ID="FPP_SCREENCASTTextBox" runat="server" Text='<%# Bind("FPP_SCREENCAST") %>' />
                            <br />
                            FPP_SCREENCAST_NAME:
                                <asp:TextBox ID="FPP_SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("FPP_SCREENCAST_NAME") %>' />
                            <br />
                            FPP_DATE_UPLOADED:
                                <asp:TextBox ID="FPP_DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("FPP_DATE_UPLOADED") %>' />
                            <br />
                            FPP_COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="FPP_COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            FPP_COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="FPP_COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            FPP_COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="FPP_COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            FPP_COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="FPP_COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            FPP_GRADUATE_ADVISOR_APPROVAL:
                                <asp:TextBox ID="FPP_GRADUATE_ADVISOR_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_APPROVAL") %>' />
                            <br />
                            FPP_GRADUATE_ADVISOR_COMMENTS:
                                <asp:TextBox ID="FPP_GRADUATE_ADVISOR_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_COMMENTS") %>' />
                            <br />
                            TS_DOCUMENT:
                                <asp:TextBox ID="TS_DOCUMENTTextBox" runat="server" Text='<%# Bind("TS_DOCUMENT") %>' />
                            <br />
                            TS_DOCUMENT_NAME:
                                <asp:TextBox ID="TS_DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("TS_DOCUMENT_NAME") %>' />
                            <br />
                            TS_SCREENCAST:
                                <asp:TextBox ID="TS_SCREENCASTTextBox" runat="server" Text='<%# Bind("TS_SCREENCAST") %>' />
                            <br />
                            TS_SCREENCAST_NAME:
                                <asp:TextBox ID="TS_SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("TS_SCREENCAST_NAME") %>' />
                            <br />
                            TS_COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="TS_COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            TS_COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="TS_COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            TS_COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="TS_COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            TS_COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="TS_COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIRTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR_APPROVAL:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_APPROVAL") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR_COMMENTS:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_COMMENTS") %>' />
                            <br />
                            TS_DATE_UPLOADED:
                                <asp:TextBox ID="TS_DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("TS_DATE_UPLOADED") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <%--<EditRowStyle BackColor="#999999" />--%>
                       <%-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                        <InsertItemTemplate>
                            USERNAME:
                                <asp:TextBox ID="USERNAMETextBox" runat="server" Text='<%# Bind("USERNAME") %>' />
                            <br />
                            FIRSTNAME:
                                <asp:TextBox ID="FIRSTNAMETextBox" runat="server" Text='<%# Bind("FIRSTNAME") %>' />
                            <br />
                            LASTNAME:
                                <asp:TextBox ID="LASTNAMETextBox" runat="server" Text='<%# Bind("LASTNAME") %>' />
                            <br />
                            PHONENUMBER:
                                <asp:TextBox ID="PHONENUMBERTextBox" runat="server" Text='<%# Bind("PHONENUMBER") %>' />
                            <br />
                            CARRIER:
                                <asp:TextBox ID="CARRIERTextBox" runat="server" Text='<%# Bind("CARRIER") %>' />
                            <br />
                            PROJECT_TITLE:
                                <asp:TextBox ID="PROJECT_TITLETextBox" runat="server" Text='<%# Bind("PROJECT_TITLE") %>' />
                            <br />
                            COURSE_NO:
                                <asp:TextBox ID="COURSE_NOTextBox" runat="server" Text='<%# Bind("COURSE_NO") %>' />
                            <br />
                            LIVE_LINK:
                                <asp:TextBox ID="LIVE_LINKTextBox" runat="server" Text='<%# Bind("LIVE_LINK") %>' />
                            <br />
                            KEYWORDS:
                                <asp:TextBox ID="KEYWORDSTextBox" runat="server" Text='<%# Bind("KEYWORDS") %>' />
                            <br />
                            ABSTRACT:
                                <asp:TextBox ID="ABSTRACTTextBox" runat="server" Text='<%# Bind("ABSTRACT") %>' />
                            <br />
                            DOCUMENT:
                                <asp:TextBox ID="DOCUMENTTextBox" runat="server" Text='<%# Bind("DOCUMENT") %>' />
                            <br />
                            DOCUMENT_LENGTH:
                                <asp:TextBox ID="DOCUMENT_LENGTHTextBox" runat="server" Text='<%# Bind("DOCUMENT_LENGTH") %>' />
                            <br />
                            DOCUMENT_NAME:
                                <asp:TextBox ID="DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("DOCUMENT_NAME") %>' />
                            <br />
                            SCREENCAST:
                                <asp:TextBox ID="SCREENCASTTextBox" runat="server" Text='<%# Bind("SCREENCAST") %>' />
                            <br />
                            SCREENCAST_LENGTH:
                                <asp:TextBox ID="SCREENCAST_LENGTHTextBox" runat="server" Text='<%# Bind("SCREENCAST_LENGTH") %>' />
                            <br />
                            SCREENCAST_NAME:
                                <asp:TextBox ID="SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("SCREENCAST_NAME") %>' />
                            <br />
                            COMMITTEE_CHAIR:
                                <asp:TextBox ID="COMMITTEE_CHAIRTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR") %>' />
                            <br />
                            COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            COMMITTEE_MEMBERS:
                                <asp:TextBox ID="COMMITTEE_MEMBERSTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBERS") %>' />
                            <br />
                            COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            GRADUATE_ADVISOR:
                                <asp:TextBox ID="GRADUATE_ADVISORTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR") %>' />
                            <br />
                            GRADUATE_ADVISOR_APPROVAL:
                                <asp:TextBox ID="GRADUATE_ADVISOR_APPROVALTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_APPROVAL") %>' />
                            <br />
                            GRADUATE_ADVISOR_COMMENTS:
                                <asp:TextBox ID="GRADUATE_ADVISOR_COMMENTSTextBox" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_COMMENTS") %>' />
                            <br />
                            SEMESTER_COMPLETED:
                                <asp:TextBox ID="SEMESTER_COMPLETEDTextBox" runat="server" Text='<%# Bind("SEMESTER_COMPLETED") %>' />
                            <br />
                            DATE_UPLOADED:
                                <asp:TextBox ID="DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("DATE_UPLOADED") %>' />
                            <br />
                            FPP_DOCUMENT:
                                <asp:TextBox ID="FPP_DOCUMENTTextBox" runat="server" Text='<%# Bind("FPP_DOCUMENT") %>' />
                            <br />
                            FPP_DOCUMENT_NAME:
                                <asp:TextBox ID="FPP_DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("FPP_DOCUMENT_NAME") %>' />
                            <br />
                            FPP_SCREENCAST:
                                <asp:TextBox ID="FPP_SCREENCASTTextBox" runat="server" Text='<%# Bind("FPP_SCREENCAST") %>' />
                            <br />
                            FPP_SCREENCAST_NAME:
                                <asp:TextBox ID="FPP_SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("FPP_SCREENCAST_NAME") %>' />
                            <br />
                            FPP_DATE_UPLOADED:
                                <asp:TextBox ID="FPP_DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("FPP_DATE_UPLOADED") %>' />
                            <br />
                            FPP_COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="FPP_COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            FPP_COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="FPP_COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            FPP_COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="FPP_COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            FPP_COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="FPP_COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            FPP_GRADUATE_ADVISOR_APPROVAL:
                                <asp:TextBox ID="FPP_GRADUATE_ADVISOR_APPROVALTextBox" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_APPROVAL") %>' />
                            <br />
                            FPP_GRADUATE_ADVISOR_COMMENTS:
                                <asp:TextBox ID="FPP_GRADUATE_ADVISOR_COMMENTSTextBox" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_COMMENTS") %>' />
                            <br />
                            TS_DOCUMENT:
                                <asp:TextBox ID="TS_DOCUMENTTextBox" runat="server" Text='<%# Bind("TS_DOCUMENT") %>' />
                            <br />
                            TS_DOCUMENT_NAME:
                                <asp:TextBox ID="TS_DOCUMENT_NAMETextBox" runat="server" Text='<%# Bind("TS_DOCUMENT_NAME") %>' />
                            <br />
                            TS_SCREENCAST:
                                <asp:TextBox ID="TS_SCREENCASTTextBox" runat="server" Text='<%# Bind("TS_SCREENCAST") %>' />
                            <br />
                            TS_SCREENCAST_NAME:
                                <asp:TextBox ID="TS_SCREENCAST_NAMETextBox" runat="server" Text='<%# Bind("TS_SCREENCAST_NAME") %>' />
                            <br />
                            TS_COMMITTEE_CHAIR_APPROVAL:
                                <asp:TextBox ID="TS_COMMITTEE_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_APPROVAL") %>' />
                            <br />
                            TS_COMMITTEE_CHAIR_COMMENTS:
                                <asp:TextBox ID="TS_COMMITTEE_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_COMMENTS") %>' />
                            <br />
                            TS_COMMITTEE_MEMBER_APPROVAL:
                                <asp:TextBox ID="TS_COMMITTEE_MEMBER_APPROVALTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_APPROVAL") %>' />
                            <br />
                            TS_COMMITTEE_MEMBER_COMMENTS:
                                <asp:TextBox ID="TS_COMMITTEE_MEMBER_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_COMMENTS") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIRTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR_APPROVAL:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIR_APPROVALTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_APPROVAL") %>' />
                            <br />
                            TS_DEPARTMENT_CHAIR_COMMENTS:
                                <asp:TextBox ID="TS_DEPARTMENT_CHAIR_COMMENTSTextBox" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_COMMENTS") %>' />
                            <br />
                            TS_DATE_UPLOADED:
                                <asp:TextBox ID="TS_DATE_UPLOADEDTextBox" runat="server" Text='<%# Bind("TS_DATE_UPLOADED") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <table class="table">
                                <tr>
                                    <td><b>First Name:</b></td>
                                    <td>
                                        <asp:Label ID="FIRSTNAMELabel" runat="server" Text='<%# Bind("FIRSTNAME") %>' />
                                    </td>
                                    <td><b>Final Project Proposal Document:</b></td>
                                    <td>
                                        <asp:HyperLink ID="FPP_DOCUMENT_NAMELINK" runat="server" Text='<%# Bind("FPP_DOCUMENT_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "FPP_DOCUMENT_NAME"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Last Name:</b></td>
                                    <td>
                                        <asp:Label ID="LASTNAMELabel" runat="server" Text='<%# Bind("LASTNAME") %>' />
                                    </td>
                                    <td><b>Screen Cast:</b></td>
                                    <td>
                                        <asp:HyperLink ID="FPP_SCREENCAST_NAMELink" runat="server" Text='<%# Bind("FPP_SCREENCAST_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "Document_name"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Email:</b></td>
                                    <td>
                                        <asp:Label ID="USERNAMELabel" runat="server" Text='<%# Eval("USERNAME") %>' />
                                    </td>
                                    <td><b>Date Uploaded:</b></td>
                                    <td>
                                        <asp:Label ID="FPP_DATE_UPLOADEDLabel" runat="server" Text='<%# Bind("FPP_DATE_UPLOADED") %>' />
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Phone Number:</b></td>
                                    <td>
                                        <asp:Label ID="PHONENUMBERLabel" runat="server" Text='<%# Bind("PHONENUMBER") %>' />
                                    </td>
                                    <td><b>Approved by Committee Chair:</b></td>
                                    <td>
                                        <asp:Label ID="FPP_COMMITTEE_CHAIR_APPROVALLabel" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_APPROVAL") %>' />
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Project Title:</b></td>
                                    <td>
                                        <asp:Label ID="PROJECT_TITLELabel" runat="server" Text='<%# Bind("PROJECT_TITLE") %>' />
                                    </td>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="FPP_COMMITTEE_CHAIR_COMMENTSLabel" runat="server" Text='<%# Bind("FPP_COMMITTEE_CHAIR_COMMENTS") %>' />
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Course No.:</b></td>
                                    <td>
                                        <asp:Label ID="COURSE_NOLabel" runat="server" Text='<%# Bind("COURSE_NO") %>' />
                                    </td>
                                    <td><b>Approved by Committee Member(s):</b></td>
                                    <td>
                                        <asp:Label ID="FPP_COMMITTEE_MEMBER_APPROVALLabel" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_APPROVAL") %>' />
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Preliminary Project Live Link:</b></td>
                                    <td>
                                        <asp:Label ID="LIVE_LINKLabel" runat="server" Text='<%# Bind("LIVE_LINK") %>' />
                                    </td>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="FPP_COMMITTEE_MEMBER_COMMENTSLabel" runat="server" Text='<%# Bind("FPP_COMMITTEE_MEMBER_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Keywords:</b></td>
                                    <td>
                                        <asp:Label ID="KEYWORDSLabel" runat="server" Text='<%# Bind("KEYWORDS") %>' />
                                    </td>
                                    <td><b>Approved by Graduate Advisor:</b></td>
                                    <td>
                                        <asp:Label ID="FPP_GRADUATE_ADVISOR_APPROVALLabel" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_APPROVAL") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Abstract:</b></td>
                                    <td>
                                        <asp:Label ID="ABSTRACTLabel" runat="server" Text='<%# Bind("ABSTRACT") %>' />
                                    </td>
                                    <td><b>Comments:</b><td></td>
                                        <asp:Label ID="FPP_GRADUATE_ADVISOR_COMMENTSLabel" runat="server" Text='<%# Bind("FPP_GRADUATE_ADVISOR_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Preliminary Project Document:</b></td>
                                    <td>
                                        <asp:HyperLink ID="DOCUMENT_NAMELINK" runat="server" Text='<%# Bind("DOCUMENT_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "Document_name"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>
                                    </td>
                                    <td><b>Thesis Document:</b></td>
                                    <td>
                                        <asp:HyperLink ID="TS_DOCUMENT_NAMELink" runat="server" Text='<%# Bind("TS_DOCUMENT_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "TS_DOCUMENT_NAME"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Screen Cast:</b></td>
                                    <td>
                                        <asp:HyperLink ID="SCREENCAST_NAMELink" runat="server" Text='<%# Bind("SCREENCAST_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "Document_name"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>

                                        <%--<asp:Label ID="SCREENCAST_LENGTHLabel" runat="server" Text='<%# Bind("SCREENCAST_LENGTH") %>' />--%>
                                    </td>
                                    <td><b>Screen Cast:</b></td>
                                    <td>
                                        <asp:HyperLink ID="TS_SCREENCAST_NAMELink" runat="server" Text='<%# Bind("TS_SCREENCAST_NAME") %>' NavigateUrl='<%# String.Format("DownloadFile.aspx?document_name={0}&username={1}", DataBinder.Eval(Container.DataItem, "Document_name"), DataBinder.Eval(Container.DataItem, "username"))%>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Committee Chair:</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_CHAIRLabel" runat="server" Text='<%# Bind("COMMITTEE_CHAIR") %>' />
                                    </td>
                                    <td><b>Approved by Committee Chair:</b></td>
                                    <td>
                                        <asp:Label ID="TS_COMMITTEE_CHAIR_APPROVALLabel" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_APPROVAL") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Approved by Committee Chair:</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_CHAIR_APPROVALLabel" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_APPROVAL") %>' />
                                    </td>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="TS_COMMITTEE_CHAIR_COMMENTSLabel" runat="server" Text='<%# Bind("TS_COMMITTEE_CHAIR_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_CHAIR_COMMENTSLabel" runat="server" Text='<%# Bind("COMMITTEE_CHAIR_COMMENTS") %>' />
                                    </td>
                                    <td><b>Approved by Committee Member(s):</b></td>
                                    <td>
                                        <asp:Label ID="TS_COMMITTEE_MEMBER_APPROVALLabel" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_APPROVAL") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Committee Member(s):</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_MEMBERSLabel" runat="server" Text='<%# Bind("COMMITTEE_MEMBERS") %>' />
                                    </td>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="TS_COMMITTEE_MEMBER_COMMENTSLabel" runat="server" Text='<%# Bind("TS_COMMITTEE_MEMBER_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Committee Member(s) Approval:</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_MEMBER_APPROVALLabel" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_APPROVAL") %>' />
                                    </td>
                                    <td><b>Department Chair:</b></td>
                                    <td>
                                        <asp:Label ID="TS_DEPARTMENT_CHAIRLabel" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="COMMITTEE_MEMBER_COMMENTSLabel" runat="server" Text='<%# Bind("COMMITTEE_MEMBER_COMMENTS") %>' />
                                    </td>
                                    <td><b>Approved by Department Chair:</b></td>
                                    <td>
                                        <asp:Label ID="TS_DEPARTMENT_CHAIR_APPROVALLabel" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_APPROVAL") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Graduate Advisor:</b></td>
                                    <td>
                                        <asp:Label ID="GRADUATE_ADVISORLabel" runat="server" Text='<%# Bind("GRADUATE_ADVISOR") %>' />
                                    </td>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="TS_DEPARTMENT_CHAIR_COMMENTSLabel" runat="server" Text='<%# Bind("TS_DEPARTMENT_CHAIR_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Graduate Advisor Approval:</b></td>
                                    <td>
                                        <asp:Label ID="GRADUATE_ADVISOR_APPROVALLabel" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_APPROVAL") %>' />
                                    </td>
                                    <td><b>Date Uploaded:</b></td>
                                    <td>
                                        <asp:Label ID="TS_DATE_UPLOADEDLabel" runat="server" Text='<%# Bind("TS_DATE_UPLOADED") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Comments:</b></td>
                                    <td>
                                        <asp:Label ID="GRADUATE_ADVISOR_COMMENTSLabel" runat="server" Text='<%# Bind("GRADUATE_ADVISOR_COMMENTS") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Date Uploaded</b></td>
                                    <td>
                                        <asp:Label ID="DATE_UPLOADEDLabel" runat="server" Text='<%# Bind("DATE_UPLOADED") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                       <%-- <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />--%>
                    </asp:FormView>
               <%-- </td>
                <td>--%>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:it485projectConnectionString %>" SelectCommand="SELECT * FROM SEARCHRESULTS WHERE USERNAME = @USERNAME">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="OmniResults" DefaultValue="" Name="username" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
               <%-- </td>
            </tr>
        </table>--%>
    </div>
</div>
</asp:Content>
