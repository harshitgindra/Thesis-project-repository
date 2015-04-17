﻿using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm2 : Page
    {


        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Session["username"].ToString();
            if (!Page.IsPostBack)
            {
                const string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @username ;";
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
                            projecttitle.Text = reader.GetString(1);
                            courseNumber.Text = reader.GetString(2);
                            livelink.Text = reader.GetString(3);
                            keywords.Text = reader.GetString(4);
                            projectabstract.Text = reader.GetString(5);
                            committeeChair.Text = reader.GetString(12);
                            committeemember.Text = reader.GetString(15);
                            graduateAdvisor.Text = reader.GetString(18);
                            semester.Text = reader.GetString(21);
                            var reportNameFromDatabase = reader.GetString(8);
                            var reportName = reportNameFromDatabase.Substring(1);
                            var hyp = new HyperLink
                            {
                                ID = "hyp1",
                                NavigateUrl = "../DownloadFile.aspx?username=" + username + "&file=P",
                                Text = reportName
                            };
                            preliminaryreportdownload.Controls.Add(hyp);
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
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            var username = Session["username"].ToString();
            var todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            var reportLength = preliminaryreport.PostedFile.ContentLength;
            var reportNameFromUser = preliminaryreport.PostedFile.FileName;
            var reportName = "P"+reportNameFromUser;
            var screencastLength = screencasts.PostedFile.ContentLength;
            var screencastName = screencasts.PostedFile.FileName;

            const string query = "UPDATE PRELIMINARY_PROJECT_SUBMISSION "
                + " SET PROJECT_TITLE = @project_title , "
                + "COURSE_NO = @course_no , "
                + "LIVE_LINK = @livelink , "
                + "KEYWORDS = @keywords , "
                + "ABSTRACT = @abstract , "
                + "DOCUMENT = @preliminary_report , "
                + "DOCUMENT_LENGTH = @report_length , "
                + "DOCUMENT_NAME = @report_name , "
                + "SCREENCAST = @screencast , "
                 + "SCREENCAST_LENGTH = @screencast_length , "
                  + "SCREENCAST_NAME = @screencast_name , "
                   + "COMMITTEE_CHAIR = @committee_chair , "
                    + "COMMITTEE_MEMBERS = @committee_member , "
                     + "GRADUATE_ADVISOR = @graduate_advisor , "
                   + "SEMESTER_COMPLETED =  @semester , "
                   + "DATE_UPLOADED = @date "
                   + "WHERE USERNAME = @username ;";



            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@project_title", projecttitle.Text);
                command.Parameters.AddWithValue("@course_no", courseNumber.Text);
                command.Parameters.AddWithValue("@livelink", livelink.Text);
                command.Parameters.AddWithValue("@keywords", keywords.Text);
                command.Parameters.AddWithValue("@abstract", projectabstract.Text);
                #pragma warning disable 618
                command.Parameters.Add("@preliminary_report", ConvertUploadedFile(preliminaryreport));
                #pragma warning restore 618
                command.Parameters.AddWithValue("@report_length", reportLength);
                command.Parameters.AddWithValue("@report_name", reportName);
                #pragma warning disable 618
                command.Parameters.Add("@screencast", ConvertUploadedFile(screencasts));
                #pragma warning restore 618
                command.Parameters.AddWithValue("@screencast_length", screencastLength);
                command.Parameters.AddWithValue("@screencast_name", screencastName);
                command.Parameters.AddWithValue("@committee_chair", committeeChair.Text);
                command.Parameters.AddWithValue("@committee_member", committeemember.Text);
                command.Parameters.AddWithValue("@graduate_advisor", graduateAdvisor.Text);
                command.Parameters.AddWithValue("@semester", semester.Text);
                command.Parameters.AddWithValue("@date", todaydate);


                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 2)
                    {
                        Response.Write("Successfully updated the DB");
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
        }

        public byte[] ConvertUploadedFile(FileUpload file)
        {
            var lenght = file.PostedFile.ContentLength;
            var contenttype = file.PostedFile.ContentType;
            var name = file.PostedFile.FileName;
            var data = new byte[lenght];
            file.PostedFile.InputStream.Read(data, 0, lenght);
            return data;
        }
    }
}