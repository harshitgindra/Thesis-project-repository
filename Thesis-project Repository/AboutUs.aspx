<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Thesis_project_Repository.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainTemplate" runat="server">
    <div data-role="content">
        <table class="ui-responsive">
            <tr>
                <th></th>
                <th>Member Name</th>
                <th>Contact Details</th>
            </tr>
            <tr>
               <td><img src="Resources/images/amitesh.jpeg" width ="100" height="125" /></td>
                <td>Amitesh Jain</td>
                <td>
                    <ul>
                        <li>IT graduate Student at ISU</li>
                        <li>Graduate Assistant at College of Education</li>
                        <li>...</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td><img src="Resources/images/kaveh.jpg" width ="100" height="125" /></td>
                <td>Kaveh Arvand</td>
                <td><ul>
                        <li>IT graduate Student at ISU</li>
                        <li>Graduate Assistant at School of IT</li>
                        <li>...</li>
                    </ul></td>
            </tr>
            <tr>
                <td><img src="Resources/images/harshit.jpg" width ="100" height="125" /></td>
                <td>Harshit Gindra</td>
                <td>
                    <ul>
                        <li>IT graduate Student at ISU</li>
                        <li>Working as a Night ops at UHS</li>
                        <li>Intern at Vishgroup as an ETL Developer</li>
                    </ul>
                </td>
            </tr>
            
        </table>
    
    </div>
</asp:Content>
