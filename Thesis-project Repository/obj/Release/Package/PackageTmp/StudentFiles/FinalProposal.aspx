﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="FinalProposal.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">
    <div class="container">
    <h3>Final Proposal Submissions</h3>
    <div class="form-group">
        <label for="projecttitle">Project Title:</label>
        <asp:TextBox ID="projecttitle" class="form-control" Width="250px" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="livelink">Live Link:</label>
        <asp:TextBox ID="livelink" class="form-control" Width="250px" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="keywords">Keywords:</label>
        <asp:TextBox ID="keywords" class="form-control" Width="250px" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="projectabstract">Abstract:</label>
        <asp:TextBox ID="projectabstract" TextMode="multiline" Width="250px" class="form-control" runat="server" Rows="5"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="committeeChair">Committee Chair:</label>
        <asp:TextBox ID="committeeChair" class="form-control" Width="250px"  runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="committeemember">Committee Member:</label>
        <asp:TextBox ID="committeemember" class="form-control" Width="250px"  runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="deptchair">Graduate Advisor:</label>
        <asp:TextBox ID="graduateAdvisor" class="form-control" Width="250px"  runat="server"></asp:TextBox>
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
        <label for="finalreport">Preliminary Report:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="finalreport" runat="server" />
            <asp:PlaceHolder ID="finalReporttag" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <div class="form-group">
        <label for="screencasts">Screenshots/Screencast:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="screencasts" runat="server" />
        </div>
    </div>

    <div class="btn-group">
        <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="submit_Click" />
    </div>
   </div>
</asp:Content>
