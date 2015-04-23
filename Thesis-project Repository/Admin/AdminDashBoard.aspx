<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashBoard.aspx.cs" Inherits="Thesis_project_Repository.Admin.AdminDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/TweenLite.min.js"></script>
    <script type="text/javascript" src="../js/TweenMax.min.js"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="../js/highcharts.js"></script>
    <script src="../js/highcharts-more.js"></script>
    <script src="../js/exporting.js"></script>

    <title>Download Files Dashboard</title>
    <style type="text/css">
        body {
            margin: 0;
            background-color: #FFF;
        }

        #content {
            overflow: auto;
            padding: 10px;
            font-size: 15px;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
            text-align: justify;
            color: #FFF;
            height: 500px;
            width: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMaster" runat="server">
    <div id="content">
        <!-- 2. initialize the combo (column, line & pie) chart on document ready -->
        <script type="text/javascript">

            var chart;
            $(document).ready(function () {
                chart = new Highcharts.Chart({
                    chart: {
                        renderTo: 'content'
                    },
                    title: {
                        text: 'Download Dashboard'
                    },
                    xAxis: {
                        categories: ['Downloads']
                    },
                    yAxis: {
                        title: {
                            text: 'Total Downloads'
                        }
                    },
                        tooltip: {
                            formatter: function () {
                                var s;
                                if (this.point.name) { // the pie chart
                                    s = '' +
                                        this.point.name + ': ' + this.y + ' Downloads';
                                } else {
                                    s = '' +
                                        this.x + ': ' + this.y + ' Downloads';
                                }
                                return s;
                            }
                        },
                        credits: {
                            enabled: false
                        },
                        labels: {
                            items: [{
                                html: 'Total File Downloaded',
                                style: {
                                    left: '0px',
                                    top: '8px',
                                    color: 'black'
                                }
                            }]
                        },
                        series: [<%=dataForBars%>,    
                    {
                        type: 'pie',
                        name: 'Download Dashboard',
                        data: [<%=fileNamefromDB%>],
		                center: [120, 150],
		                size: 200,
		                showInLegend: false,
		                dataLabels: {
		                    enabled: false
		                }
                    }]
                    });
            });
        </script>
    </div>
</asp:Content>
