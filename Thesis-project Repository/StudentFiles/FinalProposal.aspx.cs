using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                               + "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                if (!Page.IsPostBack)
                {
                    const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @username ;";
                    const string query2 = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @username ;";
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        var command = new SqlCommand(query, connection);
                        var command2 = new SqlCommand(query2, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command2.Parameters.AddWithValue("@username", username);
                        try
                        {
                            connection.Open();
                            var reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(7))
                                {
                                    semester.Text = reader.GetString(7);
                                }
                                var reportName = "";
                                if (!reader.IsDBNull(7))
                                {
                                    var reportNameFromDatabase = reader.GetString(3);
                                    reportName = reportNameFromDatabase.Substring(1);
                                    var hyp = new HyperLink
                                    {
                                        ID = "hyp1",
                                        NavigateUrl = "../DownloadFile.aspx?username=" + username + "&file=F",
                                        Text = reportName
                                    };
                                    finalReporttag.Controls.Add(hyp);
                                }
                            }
                            reader.Close();
                            var reader2 = command2.ExecuteReader();
                            if (reader2.Read())
                            {
                                projecttitle.Text = reader2.GetString(1);
                                livelink.Text = reader2.GetString(3);
                                keywords.Text = reader2.GetString(4);
                                projectabstract.Text = reader2.GetString(5);
                                committeeChair.Text = reader2.GetString(12);
                                committeemember.Text = reader2.GetString(15);
                                graduateAdvisor.Text = reader2.GetString(18);
                            }
                            reader2.Close();
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
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            var todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            var reportLength = finalreport.PostedFile.ContentLength;
            var reportNameFromUser = finalreport.PostedFile.FileName;
            var reportName = "F"+reportNameFromUser;
            var screencastLength = screencasts.PostedFile.ContentLength;
            var screencastName = screencasts.PostedFile.FileName;

            const string query = "UPDATE FINAL_PROJECT_PROPOSAL SET "
                + "DOCUMENT = @final_report , "
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


            const string query2 = "UPDATE PRELIMINARY_PROJECT_SUBMISSION SET "
                  + " PROJECT_TITLE = @project_title , "
                + "LIVE_LINK = @livelink , "
                + "KEYWORDS = @keywords , "
                + "ABSTRACT = @abstract , "
               + "COMMITTEE_CHAIR = @committee_chair , "
                   + "COMMITTEE_MEMBERS = @committee_member , "
                    + "GRADUATE_ADVISOR = @graduate_advisor "
                    + "WHERE USERNAME = @username ;";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                var command2 = new SqlCommand(query2, connection);
                command.Parameters.AddWithValue("@username", username);
                #pragma warning disable 618
                command.Parameters.Add("@final_report", ConvertUploadedFile(finalreport));
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

                command2.Parameters.AddWithValue("@project_title", projecttitle.Text);
                command2.Parameters.AddWithValue("@livelink", livelink.Text);
                command2.Parameters.AddWithValue("@keywords", keywords.Text);
                command2.Parameters.AddWithValue("@abstract", projectabstract.Text);
                command2.Parameters.AddWithValue("@committee_chair", committeeChair.Text);
                command2.Parameters.AddWithValue("@committee_member", committeemember.Text);
                command2.Parameters.AddWithValue("@graduate_advisor", graduateAdvisor.Text);
                command2.Parameters.AddWithValue("@username", username);
                try
                {
                    connection.Open();
                    if ((command.ExecuteNonQuery() + command2.ExecuteNonQuery()) == 2)
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
