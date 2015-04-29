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

            <h2 class="page-header" style="text-align: center;"><span class="label label-primary">Schedule Presentation</span></h2>
            <asp:Label runat="server" ID="type"></asp:Label>
            <div class="form-group">
                <label for="roomScheduler">Room Scheduler</label>
                <asp:TextBox ID="roomScheduler" runat="server" Text="XYZ"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="dateTimeinput">Select Date and Time:</label>
                <input type="datetime-local" name="bday" id="dateTimeinput" runat="server" />
            </div>
            <asp:Button class="btn btn-primary" ID="BookSlot" OnClick="BookSlot_Click" Text="Book The Slot" runat="server" />
            <h1><asp:Label ID="timeSelected" runat="server"></asp:Label></h1>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h2>You need to get your project/thesis approved from your professors to book a slot.</h2>
        </asp:View>
    </asp:MultiView>




</asp:Content>
