﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Viewer/Viewer.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Thesis_project_Repository.Viewer.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ViewerTemplate" runat="server">
     <div data-role="content">
        <table class="table">
            <tr>
                <th></th>
                <th>Member Name</th>
                <th>Contact Details</th>
            </tr>
            <tr>
               <td><img src="../../Resources/images/amitesh.jpeg" width ="100" height="125" /></td>
                <td>Amitesh Jain</td>
                <td>
                    <ol>
                        <li>IT graduate Student at ISU</li>
                        <li>Graduate Assistant at College of Education</li>
                        <li>...</li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td><img src="../../Resources/images/kaveh.jpg" width ="100" height="125" /></td>
                <td>Kaveh</td>
                <td><ol>
                        <li>IT graduate Student at ISU</li>
                        <li>Graduate Assistant at School of IT</li>
                        <li>...</li>
                    </ol></td>
            </tr>
            <tr>
                <td><img src="../../Resources/images/harshit.jpg" width ="100" height="125" /></td>
                <td>Harshit Gindra</td>
                <td>
                    <ol>
                        <li>IT graduate Student at ISU</li>
                        <li>Working as a Night ops at UHS</li>
                        <li>Intern at Vishgroup as an ETL Developer</li>
                    </ol>
                </td>
            </tr>
            
        </table>
    
    </div>
</asp:Content>
