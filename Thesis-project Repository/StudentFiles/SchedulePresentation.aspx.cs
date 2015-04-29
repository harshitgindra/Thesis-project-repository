using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";

        string repType = "";
        string username = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["username"] != null)
            {
                username = Session["username"].ToString();

                if (fetchFinalappStatus(username))
                {
                    //allow to schedule Presentation for project
                    repType = "P";
                    getPresentationDateFromDB(username);

                }
                else if (fetchThesisAppStatus(username))
                {
                    //allow to schedule Presentation for thesis
                    repType = "T";
                    getPresentationDateFromDB(username);
                }
                else
                {
                    //no Presentation scheduling
                    MultiView1.ActiveViewIndex = 1;
                }
            }
        }

        private void getPresentationDateFromDB(string username)
        {

            const string query = "SELECT * FROM PRESENTATION_SCHEDULE WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                        {
                            DateTime d = reader.GetDateTime(2);
                            string a = d.ToString();

                            timeSelected.Text = "<h2>Time Selected : " + a + "</h2>";
                        }
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        protected Boolean fetchFinalappStatus(string username)
        {
            Boolean returnvalue = false;
            const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        if ((!reader.IsDBNull(10)) && (!reader.IsDBNull(13)) && (!reader.IsDBNull(16)))
                        {
                            if ((reader.GetString(10).Equals("Y")) && (reader.GetString(13).Equals("Y")) && (reader.GetString(16).Equals("Y")))
                            {
                                returnvalue = true;
                            }
                            else
                            {
                                returnvalue = false;
                            }
                        }
                        else
                        {
                            returnvalue = false;
                        }

                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return returnvalue;
        }


        protected Boolean fetchThesisAppStatus(string username)
        {
            Boolean returnvalue = false;
            const string query = "SELECT * FROM THESIS_SUBMISSION WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        if ((!reader.IsDBNull(14)) && (!reader.IsDBNull(17)) && (!reader.IsDBNull(20)))
                        {
                            if ((reader.GetString(14).Equals("Y")) && (reader.GetString(17).Equals("Y")) && (reader.GetString(20).Equals("Y")))
                            {
                                returnvalue = true;
                            }
                            else
                            {
                                returnvalue = false;
                            }
                        }
                        else
                        {
                            returnvalue = false;
                        }
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return returnvalue;
        }


        protected void BookSlot_Click(object sender, EventArgs e)
        {
            //DB smalldatetime format : YYYY-MM-DD hh:mm:ss

            if (!presentationTable(username))
            {
                if (repType.Equals("P"))
                {
                    //insert record for project
                    insertRecordForProject(fetchDetailsForProject(username), username);
                }
                else
                {
                    //insert record for thesis
                    insertRecordForThesis(fetchDetailsForProject(username), username);
                }
            }
            else
            {
                UpdateTimeForPresentation(username);
            }
        }

        private Boolean UpdateTimeForPresentation(string username)
        {
            string dateInput = dateTimeinput.Value;
            dateInput = dateInput.Replace('T', ' ');
            Boolean result = false;
            const string query = "UPDATE  PRESENTATION_SCHEDULE " +
                " SET PRESENTATION_DATE = @presentation_date, ROOM_SCHEDULER =  @room_scheduler WHERE USERNAME = @username";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@room_scheduler", roomScheduler.Text);
                command.Parameters.AddWithValue("@presentation_date", dateInput);
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }



        private Boolean insertRecordForProject(string data, string username)
        {

            string[] dataArray = data.Split('/');
            string dateInput = dateTimeinput.Value;
            dateInput = dateInput.Replace('T', ' ');
            Boolean result = false;
            const string query = "INSERT INTO PRESENTATION_SCHEDULE " +
               " (USERNAME, TYPE, PRESENTATION_DATE, COMMITTEE_CHAIR, COMMITTEE_CHAIR_APPROVAL, COMMITTEE_MEMBER, COMMITTEE_MEMBER_APPROVAL, GRADUATE_ADVISOR, GRADUATE_ADVISOR_APPROVAL, ROOM_SCHEDULER, ROOM_SCHEDULER_APPROVAL) " +
         "VALUES (@username, @type, @presentation_date, @committee_chair,@committee_chair_approval, @committee_member,@committee_member_approval, @graduate_advisor,@graduate_advisor_approval, @room_scheduler, @room_scheduler_approval);";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@type", repType);
                command.Parameters.AddWithValue("@committee_chair", dataArray[0]);
                command.Parameters.AddWithValue("@committee_member", dataArray[1]);
                command.Parameters.AddWithValue("@graduate_advisor", dataArray[2]);
                command.Parameters.AddWithValue("@room_scheduler", roomScheduler.Text);
                command.Parameters.AddWithValue("@presentation_date", dateInput);
                command.Parameters.AddWithValue("@committee_chair_approval", "N");
                command.Parameters.AddWithValue("@committee_member_approval", "N");
                command.Parameters.AddWithValue("@graduate_advisor_approval", "N");
                command.Parameters.AddWithValue("@room_scheduler_approval", "N");
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }


        private Boolean insertRecordForThesis(string data, string username)
        {

            string[] dataArray = data.Split('/');
            string dateInput = dateTimeinput.Value;
            dateInput = dateInput.Replace('T', ' ');
            Boolean result = false;
            const string query = "INSERT INTO PRESENTATION_SCHEDULE " +
               " (USERNAME, TYPE, PRESENTATION_DATE, COMMITTEE_CHAIR, COMMITTEE_CHAIR_APPROVAL, COMMITTEE_MEMBER, COMMITTEE_MEMBER_APPROVAL, DEPARTMENT_CHAIR, GRADUATE_ADVISOR_APPROVAL, ROOM_SCHEDULER, ROOM_SCHEDULER_APPROVAL) " +
         "VALUES (@username, @type, @presentation_date, @committee_chair,@committee_chair_approval, @committee_member,@committee_member_approval, @graduate_advisor,@graduate_advisor_approval, @room_scheduler, @room_scheduler_approval);";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@type", repType);
                command.Parameters.AddWithValue("@committee_chair", dataArray[0]);
                command.Parameters.AddWithValue("@committee_member", dataArray[1]);
                command.Parameters.AddWithValue("@graduate_advisor", dataArray[2]);
                command.Parameters.AddWithValue("@room_scheduler", roomScheduler.Text);
                command.Parameters.AddWithValue("@presentation_date", dateInput);
                command.Parameters.AddWithValue("@committee_chair_approval", "N");
                command.Parameters.AddWithValue("@committee_member_approval", "N");
                command.Parameters.AddWithValue("@graduate_advisor_approval", "N");
                command.Parameters.AddWithValue("@room_scheduler_approval", "N");
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        private Boolean presentationTable(String username)
        {
            Boolean data = false;
            const string query = "SELECT * FROM PRESENTATION_SCHEDULE WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        data = true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }

        private string fetchDetailsForProject(string username)
        {
            String data = "";
            const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        data = reader.GetString(9) + "/" + reader.GetString(12) + "/" + reader.GetString(15);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }

        private string fetchDetailsForThesis(string username)
        {
            String data = "";
            const string query = "SELECT * FROM THESIS_SUBMISSION WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        data = reader.GetString(11) + "/" + reader.GetString(14) + "/" + reader.GetString(17);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }
    }
}