<%@ Page Title="" Language="C#" MasterPageFile="~/StudentFiles/StudentMain.Master" AutoEventWireup="true" CodeBehind="SchedulePresentation.aspx.cs" Inherits="Thesis_project_Repository.StudentFiles.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../includes/css/bootstrap-glyphicons.css" rel="stylesheet" />
    <link href="../bootstrap/css/sticky-footer-navbar.css" rel="stylesheet" />
    <script src="../Resources/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="student" runat="server">

    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="View1" runat="server">

            <h2>Schedule Presentation</h2>
            <asp:Label runat="server" ID="type"></asp:Label>
            Room Scheduler<asp:TextBox ID="roomScheduler" runat="server" Text="XYZ"></asp:TextBox>
            Select Date:
            <input type="datetime-local" name="bday" id="dateTimeinput" runat="server" />
            <asp:Button ID="BookSlot" OnClick="BookSlot_Click" Text="Book The Slot" runat="server" />
            <asp:Label ID="timeSelected" runat="server"></asp:Label>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h2>You need to get your project/thesis approved from your professors to book a slot.</h2>
        </asp:View>
    </asp:MultiView>




</asp:Content>
