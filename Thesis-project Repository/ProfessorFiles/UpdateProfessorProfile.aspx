<%@ Page Title="" Language="C#" MasterPageFile="~/ProfessorFiles/Professor.Master" AutoEventWireup="true" CodeBehind="UpdateProfessorProfile.aspx.cs" Inherits="Thesis_project_Repository.ProfessorFiles.UpdateProfessorProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../bootstrap/css/RemoveBorder.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfessorTemplate" runat="server">
    <div>
        <table class="table borderless">
            <tr>
                <td><span class="label label-info" style="font-size:large;">UserName</span>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="username" class="form-control" runat="server" aria-describedby="basic-addon1" ReadOnly="true"></asp:TextBox>
                    </div>

                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Password</span>
                </td>
                 <td>
                    <div class="input-group">
                        <asp:TextBox ID="password" TextMode="Password" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Confirm Password</span>
                </td>
               <td>
                    <div class="input-group">
                        <asp:TextBox ID="cnfrmPassword" TextMode="Password" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">First Name</span>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="fname" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Last Name</span>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="lname" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>

                 <td><span class="label label-info" style="font-size:large;">Phone Number</span>
                </td>
               <td>
                    <div class="input-group">
                        <asp:TextBox ID="phnNumber" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Provider</span>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="provider" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Security Question</span>
                </td><td>
                    <div class="input-group">
                        <asp:TextBox ID="secQuestion" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                 <td><span class="label label-info" style="font-size:large;">Security Answer</span>
                </td><td>
                    <div class="input-group">
                        <asp:TextBox ID="secAnswer" class="form-control" runat="server" aria-describedby="basic-addon1"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td> </td>
                <td>
                    <div class="btn-group">
                        <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Update Profile" OnClick="UpdateUserProfile" />
                    </div>
                </td> 
            </tr>
            <tr><td></td>
                <td>  <asp:Label ID="updateResult" ForeColor="Green" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>

</asp:Content>
