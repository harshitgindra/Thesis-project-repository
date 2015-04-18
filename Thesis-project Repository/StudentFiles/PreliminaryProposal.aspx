﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="PreliminaryProposal.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">
    <h1>Project Preliminary Submissions</h1>
    <table>
        <tr>
            <td>Project Title: </td>
            <td>
                <asp:TextBox ID="projecttitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Course Number</td>
            <td>
                <asp:TextBox ID="courseNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Live Link: </td>
            <td>
                <asp:TextBox ID="livelink" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Keywords: </td>
            <td>
                <asp:TextBox ID="keywords" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Abstract: </td>
            <td>
                <asp:TextBox ID="projectabstract" TextMode="multiline" runat="server" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Preliminary Report: </td>
            <td>
                <asp:FileUpload ID="preliminaryreport" runat="server"/>
            </td>
            <td>
                <asp:PlaceHolder ID="preliminaryreportdownload" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Screenshots/Screencast: </td>
            <td>
                <asp:FileUpload ID="screencasts" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>Committee Chair: </td>
            <td>
                <asp:DropDownList ID="committeeChair" runat="server"></asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td>Committee Member: </td>
            <td>
                <asp:DropDownList ID="committeemember" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Graduate Advisor: </td>
            <td>
                <asp:DropDownList ID="graduateAdvisor" runat="server"></asp:DropDownList>
            </td>graduateAdvisor
        </tr>
        <tr>
            <td>Semester Completed: </td>
            <td>
                <asp:RadioButtonList ID="semester" runat="server">
                    <asp:ListItem Text="Spring 15" Value="sp15"/>
                    <asp:ListItem Text="Summer 15" Value="su15"/>
                    <asp:ListItem Text="Fall 15" Value="f15"/>
                    <asp:ListItem Text="Spring 16" Value="sp16"/>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="submit" Text="Submit" OnClick="submit_Click" runat="server"/>
            </td>
        </tr>
    </table>
</asp:Content>