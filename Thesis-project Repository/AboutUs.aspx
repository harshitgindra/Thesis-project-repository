<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Thesis_project_Repository.AboutUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About Us</title>
       <link href="Resources/css/index.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>
    <script src="Resources/js/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
                <td>Kaveh</td>
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
    </form>
</body>
</html>
