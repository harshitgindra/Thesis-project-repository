using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                fetchPreliminaryappstatus(username);
                fetchFinalappStatus(username);
                fetchThesisAppStatus(username);
            }
        }

        protected void fetchPreliminaryappstatus(string username)
        {
            string result = "";
            const string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    result += "<table class='table table-striped'>";
                    result += "<tr><th>Professor's Email ID</th><th>Professor's Role</th><th>Approval Status</th><th>Comments</th></tr>";
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //committee chair
                        result += "<tr>";
                        if (!reader.IsDBNull(12))
                            result += "<td>" + reader.GetString(12) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Chair</td>";
                        if (!reader.IsDBNull(13))
                            result += "<td>" + reader.GetString(13) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(14))
                            result += "<td>" + reader.GetString(14) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //committee member
                        result += "<tr>";
                        if (!reader.IsDBNull(15))
                            result += "<td>" + reader.GetString(15) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Member</td>";
                        if (!reader.IsDBNull(16))
                            result += "<td>" + reader.GetString(16) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(17))
                            result += "<td>" + reader.GetString(17) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //graduate advisor
                        result += "<tr>";
                        if (!reader.IsDBNull(18))
                            result += "<td>" + reader.GetString(18) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Graduate Advisor</td>";
                        if (!reader.IsDBNull(19))
                            result += "<td>" + reader.GetString(19) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(20))
                            result += "<td>" + reader.GetString(20) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";
                    }
                    reader.Close();
                    result += "</table>";
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                preliminary.Text = result;
            }
        }


        protected void fetchFinalappStatus(string username)
        {

            string result = "";
            const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    result += "<table class='table table-striped'>";
                    result += "<tr><th>Professor's Email ID</th><th>Professor's Role</th><th>Approval Status</th><th>Comments</th></tr>";
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //committee chair
                        result += "<tr>";
                        if (!reader.IsDBNull(9))
                            result += "<td>" + reader.GetString(9) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Chair</td>";
                        if (!reader.IsDBNull(10))
                            result += "<td>" + reader.GetString(10) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(11))
                            result += "<td>" + reader.GetString(11) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //committee member
                        result += "<tr>";
                        if (!reader.IsDBNull(12))
                            result += "<td>" + reader.GetString(12) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Member</td>";
                        if (!reader.IsDBNull(13))
                            result += "<td>" + reader.GetString(13) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(14))
                            result += "<td>" + reader.GetString(14) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //graduate advisor
                        result += "<tr>";
                        if (!reader.IsDBNull(15))
                            result += "<td>" + reader.GetString(15) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Graduate Advisor</td>";
                        if (!reader.IsDBNull(16))
                            result += "<td>" + reader.GetString(16) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(17))
                            result += "<td>" + reader.GetString(17) + "</td>";
                        else
                            result += "<td>-</td>";
                 //       result += "</tr>";
                    }
                    reader.Close();
                    result += "</tr></table>";
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                final.Text = result;
            }
        }

        protected void fetchThesisAppStatus(string username)
        {

            string result = "";
            const string query = "SELECT * FROM THESIS_SUBMISSION WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    result += "<table class='table table-striped'>";
                    result += "<tr><th>Professor's Email ID</th><th>Professor's Role</th><th>Approval Status</th><th>Comments</th></tr>";
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //committee chair
                        result += "<tr>";
                        if (!reader.IsDBNull(13))
                            result += "<td>" + reader.GetString(13) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Chair</td>";
                        if (!reader.IsDBNull(14))
                            result += "<td>" + reader.GetString(14) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(15))
                            result += "<td>" + reader.GetString(15) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //committee member
                        result += "<tr>";
                        if (!reader.IsDBNull(16))
                            result += "<td>" + reader.GetString(16) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Committee Member</td>";
                        if (!reader.IsDBNull(17))
                            result += "<td>" + reader.GetString(17) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(19))
                            result += "<td>" + reader.GetString(18) + "</td>";
                        else
                            result += "<td>-</td>";
                        result += "</tr>";

                        //Department Chair
                        result += "<tr>";
                        if (!reader.IsDBNull(19))
                            result += "<td>" + reader.GetString(19) + "</td>";
                        else
                            result += "<td>No Professor Selected</td>";
                        result += "<td>Department Chair</td>";
                        if (!reader.IsDBNull(20))
                            result += "<td>" + reader.GetString(20) + "</td>";
                        else
                            result += "<td>N</td>";
                        if (!reader.IsDBNull(21))
                            result += "<td>" + reader.GetString(21) + "</td>";
                        else
                            result += "<td>-</td>";
                      //  result += "</tr>";
                    }
                    reader.Close();
                    result += "</tr></table>";
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                thesis.Text = result;
            }
        }



    }
}