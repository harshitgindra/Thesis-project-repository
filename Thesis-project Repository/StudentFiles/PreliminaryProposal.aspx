<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="PreliminaryProposal.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">
    <h3>Preliminary Submissions</h3>
    <div class="form-group">
        <label for="projecttitle">Project Title:</label>
        <asp:TextBox ID="projecttitle" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="courseNumber">Course Number:</label>
        <asp:TextBox ID="courseNumber" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="livelink">Live Link:</label>
        <asp:TextBox ID="livelink" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="keywords">Keywords:</label>
        <asp:TextBox ID="keywords" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="projectabstract">Abstract:</label>
        <asp:TextBox ID="projectabstract" TextMode="multiline" class="form-control" runat="server" Rows="5"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="committeeChair">Committee Chair:</label>
        <div class="dropdown">
            <asp:DropDownList ID="committeeChair" runat="server"></asp:DropDownList>

        </div>
    </div>

    <div class="form-group">
        <label for="committeemember">Committee Member:</label>
        <div class="dropdown">
            <asp:DropDownList ID="committeemember" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <label for="deptchair">Graduate Advisor:</label>
        <div class="dropdown">
            <asp:DropDownList  ID="graduateAdvisor" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <label for="semester">Semester Completed:</label>
        <asp:RadioButtonList ID="semester" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Spring 15" Value="sp15" />
            <asp:ListItem Text="Summer 15" Value="su15" />
            <asp:ListItem Text="Fall 15" Value="f15" />
            <asp:ListItem Text="Spring 16" Value="sp16" />
        </asp:RadioButtonList>
    </div>

    <div class="form-group">
        <label for="preliminaryreport">Preliminary Report:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="preliminaryreport" runat="server" />
        <asp:PlaceHolder ID="preliminaryreportdownload" runat="server"></asp:PlaceHolder>
    </div>
    </div>

    <div class="form-group">
        <label for="screencasts">Screenshots/Screencast:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="screencasts" runat="server" />
        </div>
    </div>

    <div class="btn-group">
        <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Submit" OnClick="submit_Click" />
    </div>
   
</asp:Content>
