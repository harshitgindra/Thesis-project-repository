﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        //need to check the session
        string username = "hgindra";
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportName = "";
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @username ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        projecttitle.Text = reader.GetString(1);
                        courseNumber.Text = reader.GetString(2);
                        livelink.Text = reader.GetString(3);
                        keywords.Text = reader.GetString(4);
                        projectabstract.Text = reader.GetString(5);
                        committeeChair.Text = reader.GetString(12);
                        committeemember.Text = reader.GetString(13);
                        graduateAdvisor.Text = reader.GetString(14);
                        semester.Text = reader.GetString(15);
                        reportName = reader.GetString(8);
                        HyperLink hyp = new HyperLink();
                        hyp.ID = "hyp1";
                        hyp.NavigateUrl = "../DownloadFile.aspx?username=" + username + "&file=P";
                        hyp.Text = reportName;
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

        protected void submit_Click(object sender, EventArgs e)
        {

            string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            int reportLength = preliminaryreport.PostedFile.ContentLength;
            string reportName = preliminaryreport.PostedFile.FileName;
            int screencastLength = screencasts.PostedFile.ContentLength;
            string screencastName = screencasts.PostedFile.FileName;

            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";


            string query = "INSERT INTO PRELIMINARY_PROJECT_SUBMISSION "
                + "(USERNAME, PROJECT_TITLE, COURSE_NO, LIVE_LINK, KEYWORDS, ABSTRACT, DOCUMENT, DOCUMENT_LENGTH, DOCUMENT_NAME, SCREENCAST, SCREENCAST_LENGTH, SCREENCAST_NAME, COMMITTEE_CHAIR, COMMITTEE_MEMBERS, GRADUATE_ADVISOR, SEMESTER_COMPLETED, DATE_UPLOADED)"
                + "VALUES ( @username, @project_title, @course_no, @livelink, @keywords, @abstract, @preliminary_report, @report_length, @report_name, @screencast, @screencast_length, @screencast_name, @committee_chair, @committee_member, @graduate_advisor, @semester, @date);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@project_title", projecttitle.Text);
                command.Parameters.AddWithValue("@course_no", courseNumber.Text);
                command.Parameters.AddWithValue("@livelink", livelink.Text);
                command.Parameters.AddWithValue("@keywords", keywords.Text);
                command.Parameters.AddWithValue("@abstract", projectabstract.Text);
                command.Parameters.Add("@preliminary_report", convertUploadedFile(preliminaryreport));
                command.Parameters.AddWithValue("@report_length", reportLength);
                command.Parameters.AddWithValue("@report_name", reportName);
                command.Parameters.Add("@screencast", convertUploadedFile(screencasts));
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
                    if (command.ExecuteNonQuery() == 1)
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


        public byte[] convertUploadedFile(FileUpload file)
        {
            int lenght = file.PostedFile.ContentLength;
            string contenttype = file.PostedFile.ContentType;
            string name = file.PostedFile.FileName;
            byte[] data = new byte[lenght];
            file.PostedFile.InputStream.Read(data, 0, lenght);
            return data;
        }



    }
}