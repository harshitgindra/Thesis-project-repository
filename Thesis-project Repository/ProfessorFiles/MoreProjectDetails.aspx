<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="MoreProjectDetails.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server">
    <asp:MultiView ID="MultiView1" ActiveViewIndex="1" runat="server">

        <asp:View ID="View1" runat="server">
            <table class="table table-hover table-striped">
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

            <div class="btn-group">
                <asp:Button class="btn btn-default" ID="addComments" runat="server" OnClick="addComments_Click" Text="Add Comments/Approve" />
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="col-lg-6">
                <div class="input-group">
                    <asp:TextBox placeholder="Comments..." class="form-control" Height="200" Columns="100" ID="addingcomments" runat="server" aria-describedby="basic-addon1" TextMode="MultiLine" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <br />

            <div class="input-group-btn">
                <asp:Button class="btn btn-default" ID="savecomments" runat="server" Text="Post Comments" OnClick="savecomments_Click" />&nbsp;&nbsp;        
            <br />
                <br />
                <asp:Button class="btn btn-default" ID="grantapproval1" runat="server" OnClick="grantapproval_Click" Text="Approve Proposal" />&nbsp;&nbsp;                        
            <br />
                <br />
                <asp:Button class="btn btn-default" ID="goback" runat="server" OnClick="goback_Click" Text="Back" />
            </div>
            <br />
            <asp:Label ForeColor="Green" ID="savecommentsupdates" runat="server"></asp:Label>
            <asp:Label ForeColor="Green" ID="approvalstatusupdates" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>
