<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="Thesis.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">

    <h3>Thesis Submissions</h3>
    <div class="form-group">
        <label for="thesistitle">Thesis Title:</label>
        <asp:TextBox ID="thesistitle" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="courseNumber">Course Number:</label>
        <asp:TextBox ID="courseNumber" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="keywords">Keywords:</label>
        <asp:TextBox ID="keywords" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="thesisabstract">Abstract:</label>
        <asp:TextBox ID="thesisabstract" TextMode="multiline" class="form-control" runat="server" Rows="5"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="committeeChair">Committee Chair:</label>
        <asp:DropDownList ID="TcommitteeChair" CssClass="form-control" runat="server"></asp:DropDownList>
       
    </div>

    <div class="form-group">
        <label for="committeemember">Committee Member:</label>
        <asp:DropDownList ID="Tcommitteemember" CssClass="form-control" runat="server"></asp:DropDownList>      
    </div>

    <div class="form-group">
        <label for="deptchair">Department Chair:</label>
        <asp:DropDownList ID="Tdeptchair" CssClass="form-control" runat="server"></asp:DropDownList>       
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
        <label for="thesisupload">Thesis Report:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="thesisupload" runat="server" />
        </div>
        <asp:PlaceHolder ID="thesisdocdownload" runat="server"></asp:PlaceHolder>
    </div>

    <div class="form-group">
        <label for="screencasts">Screenshots/Screencast:</label>
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <asp:FileUpload class="btn btn-default" ID="screencasts" runat="server" />
        </div>
    </div>
    <div class="btn-group">
        <asp:Button class="btn btn-default" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    </div>

</asp:Content>
