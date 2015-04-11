using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm2 : Page
    {
        private const string Username = "hgindra";

        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            const string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", Username);
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
                        committeemember.Text = reader.GetString(13);
                        graduateAdvisor.Text = reader.GetString(14);
                        semester.Text = reader.GetString(15);
                        var reportName = reader.GetString(8);
                        var hyp = new HyperLink
                        {
                            ID = "hyp1",
                            NavigateUrl = "../DownloadFile.aspx?username=" + Username + "&file=P",
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

        protected void submit_Click(object sender, EventArgs e)
        {
            var todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            var reportLength = preliminaryreport.PostedFile.ContentLength;
            var reportName = preliminaryreport.PostedFile.FileName;
            var screencastLength = screencasts.PostedFile.ContentLength;
            var screencastName = screencasts.PostedFile.FileName;

            const string query = "INSERT INTO PRELIMINARY_PROJECT_SUBMISSION "
                                 +
                                 "(USERNAME, PROJECT_TITLE, COURSE_NO, LIVE_LINK, KEYWORDS, ABSTRACT, DOCUMENT, DOCUMENT_LENGTH, DOCUMENT_NAME, SCREENCAST, SCREENCAST_LENGTH, SCREENCAST_NAME, COMMITTEE_CHAIR, COMMITTEE_MEMBERS, GRADUATE_ADVISOR, SEMESTER_COMPLETED, DATE_UPLOADED)"
                                 +
                                 "VALUES ( @username, @project_title, @course_no, @livelink, @keywords, @abstract, @preliminary_report, @report_length, @report_name, @screencast, @screencast_length, @screencast_name, @committee_chair, @committee_member, @graduate_advisor, @semester, @date);";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", Username);
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