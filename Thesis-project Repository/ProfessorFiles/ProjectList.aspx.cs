using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository.ProfessorFiles
{
    public partial class WebForm2 : Page
    {

        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                               + "Integrated Security=true";
        string username = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            fetchPreliminaryreports();
            fetchFinalProjects();
            fetchThesisOptions();
        }




        private void fetchPreliminaryreports()
        {
            string tableContent = "";
            const string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE COMMITTEE_CHAIR = @username OR COMMITTEE_MEMBERS = @username OR GRADUATE_ADVISOR = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        tableContent = "<h2>List for Preliminary Project</h2>";
                        tableContent += "<table  class='table table-striped'><tr><th>username</th><th>Project Title</th><th>Your role</th><th>Your Approval Status</th><th>More Details</th></tr>";
                    }

                    while (reader.Read())
                    {
                        tableContent += "<tr>";
                        tableContent += "<td>" + reader.GetString(0) + "</td>";
                        tableContent += "<td>" + reader.GetString(1) + "</td>";
                        if (username.Equals(reader.GetString(12)))
                        {
                            tableContent += "<td>Committee Chair</td>";
                            if (!reader.IsDBNull(13))
                            {
                                tableContent += "<td>" + reader.GetString(13) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        else if (username.Equals(reader.GetString(15)))
                        {
                            tableContent += "<td>Committee Member</td>";
                            if (!reader.IsDBNull(16))
                            {
                                tableContent += "<td>" + reader.GetString(16) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        else
                        {
                            tableContent += "<td>Graduate Advisor</td>";
                            if (!reader.IsDBNull(19))
                            {
                                tableContent += "<td>" + reader.GetString(19) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        tableContent += "<td><a href = 'MoreProjectDetails.aspx?studentid=" + reader.GetString(0) + "&reptype=P' >More Details</a><td>";
                        tableContent += "</tr>";
                    }
                    tableContent += "</table>";

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    preliminaryprojectlist.Text = tableContent;
                    connection.Close();
                }
            }
        }

        private void fetchFinalProjects()
        {
            string tableContent = "";
            const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE COMMITTEE_CHAIR = @username OR COMMITTEE_MEMBERS = @username OR GRADUATE_ADVISOR = @username ;";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        tableContent = "<h2>List of Final Projects</h2>";
                        tableContent += "<table class='table table-striped'><tr><th>username</th><th>Report Type</th><th>Your role</th><th>Your Approval Status</th><th>More Details</th></tr>";
                    }

                    while (reader.Read())
                    {
                        tableContent += "<tr>";
                        tableContent += "<td>" + reader.GetString(0) + "</td>";
                        tableContent += "<td>Final Report</td>";
                        if (username.Equals(reader.GetString(9)))
                        {
                            tableContent += "<td>Committee Chair</td>";
                            if (!reader.IsDBNull(10))
                            {
                                tableContent += "<td>" + reader.GetString(10) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        else if (username.Equals(reader.GetString(12)))
                        {
                            tableContent += "<td>Committee Member</td>";
                            if (!reader.IsDBNull(13))
                            {
                                tableContent += "<td>" + reader.GetString(13) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        else
                        {
                            tableContent += "<td>Graduate Advisor</td>";
                            if (!reader.IsDBNull(16))
                            {
                                tableContent += "<td>" + reader.GetString(16) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }


                        tableContent += "<td><a href = 'MoreProjectDetails.aspx?studentid=" + reader.GetString(0) + "&reptype=F' >More Details</a><td>";
                        tableContent += "</tr>";
                    }
                    tableContent += "</table>";

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    finalProjectlist.Text = tableContent;
                    connection.Close();
                }
            }
        }
        private void fetchThesisOptions()
        {
            string tableContent = "";
            const string query = "SELECT * FROM THESIS_SUBMISSION WHERE COMMITTEE_CHAIR = @username OR COMMITTEE_MEMBERS = @username OR DEPARTMENT_CHAIR = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        tableContent = "<h2>List for Thesis</h2>";
                        tableContent += "<table class='table table-striped'><tr><th>username</th><th>Project Title</th><th>Your role</th><th>Approval Status</th><th>More Details</th></tr>";
                    }

                    while (reader.Read())
                    {
                        tableContent += "<tr>";
                        tableContent += "<td>" + reader.GetString(0) + "</td>";
                        tableContent += "<td>" + reader.GetString(1) + "</td>";
                        if (username.Equals(reader.GetString(11)))
                        {
                            tableContent += "<td>Committee Chair</td>";
                            if (!reader.IsDBNull(12))
                            {
                                tableContent += "<td>" + reader.GetString(12) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }

                        }
                        else if (username.Equals(reader.GetString(14)))
                        {
                            tableContent += "<td>Committee Member</td>";
                            if (!reader.IsDBNull(15))
                            {
                                tableContent += "<td>" + reader.GetString(15) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        else
                        {
                            tableContent += "<td>Department Chair</td>";
                            if (!reader.IsDBNull(18))
                            {
                                tableContent += "<td>" + reader.GetString(18) + "</td>";
                            }
                            else
                            {
                                tableContent += "<td>N</td>";
                            }
                        }
                        tableContent += "<td><a href = 'MoreProjectDetails.aspx?studentid=" + reader.GetString(0) + "&reptype=T' >More Details</a><td>";
                        tableContent += "</tr>";
                    }
                    tableContent += "</table>";

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    thesisproject.Text = tableContent;
                    connection.Close();
                }
            }
        }

    }



}