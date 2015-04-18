<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="MoreProjectDetails.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server"> 
    <asp:MultiView ID="MultiView1" ActiveViewIndex="1" runat="server">

        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td>Username: 
                    </td>
                    <td>
                        <asp:Label ID="stdusername" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Project Title
                    </td>
                    <td>
                        <asp:Label ID="projecttitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Live Link: 
                    </td>
                    <td>
                        <asp:Label ID="LiveLink" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Abstract
                    </td>
                    <td>
                        <asp:Label ID="projectabstract" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Document
                    </td>
                    <td>
                        <asp:PlaceHolder ID="downloadfile" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>Your Approval Status:
                    </td>
                    <td>
                        <asp:Label ID="approvalstatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Your Comments:
                    </td>
                    <td>
                        <asp:Label ID="comments" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

            <asp:Button ID="addComments" runat="server" OnClick="addComments_Click" Text="Add Comments/Approve" />

        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td>Add Comments
                    </td>
                    <td>
                        <asp:TextBox ID="addingcomments" Columns="100" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="savecomments" runat="server" Text="Save" OnClick="savecomments_Click" />
                        <asp:Button ID="grantapproval1" runat="server" OnClick="grantapproval_Click" Text="Approve Account" />
                        <asp:Button ID="goback" runat="server" OnClick="goback_Click" Text="Go Back" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="savecommentsupdates" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="approvalstatusupdates" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>


        </asp:View>


    </asp:MultiView>
</asp:Content>