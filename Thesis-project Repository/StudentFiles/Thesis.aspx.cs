using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.StudentFiles
{
    public partial class WebForm4 : System.Web.UI.Page
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
                                if (!reader.IsDBNull(2))
                                {
                                    courseNumber.Text = reader.GetString(2);
                                }
                                if (!reader.IsDBNull(3))
                                {
                                    keywords.Text = reader.GetString(3);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    thesisabstract.Text = reader.GetString(4);
                                }
                                if (!reader.IsDBNull(11))
                                {
                                    committeeChair.Text = reader.GetString(11);
                                }
                                if (!reader.IsDBNull(14))
                                {
                                    committeemember.Text = reader.GetString(14);
                                }
                                if (!reader.IsDBNull(17))
                                {
                                    deptchair.Text = reader.GetString(17);
                                }
                                if (!reader.IsDBNull(20))
                                {
                                    semester.Text = reader.GetString(20);
                                }
                                if (!reader.IsDBNull(1))
                                {
                                    thesistitle.Text = reader.GetString(1);
                                }
                                var reportName = "";
                                if (!reader.IsDBNull(7))
                                {
                                    var reportNameFromDatabase = reader.GetString(7);
                                    reportName = reportNameFromDatabase.Substring(1);
                                    var hyp = new HyperLink
                                    {
                                        ID = "hyp1",
                                        NavigateUrl = "../DownloadFile.aspx?username=" + username + "&file=T",
                                        Text = reportName
                                    };
                                    thesisdocdownload.Controls.Add(hyp);
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
            var reportLength = thesisupload.PostedFile.ContentLength;
            var reportNameFromUser = thesisupload.PostedFile.FileName;
            var reportName = "T" + reportNameFromUser;
            var screencastLength = screencasts.PostedFile.ContentLength;
            var screencastName = screencasts.PostedFile.FileName;

            const string query = "UPDATE THESIS_SUBMISSION "
                + " SET TITLE = @thesis_title , "
                + "COURSE_NO = @course_no , "
                + "KEYWORDS = @keywords , "
                + "ABSTRACT = @abstract , "
                + "DOCUMENT = @thesis_report , "
                + "DOCUMENT_LENGTH = @report_length , "
                + "DOCUMENT_NAME = @report_name , "
                + "SCREENCAST = @screencast , "
                 + "SCREENCAST_LENGTH = @screencast_length , "
                  + "SCREENCAST_NAME = @screencast_name , "
                   + "COMMITTEE_CHAIR = @committee_chair , "
                    + "COMMITTEE_MEMBERS = @committee_member , "
                     + "DEPARTMENT_CHAIR = @dept_chair , "
                   + "SEMESTER_COMPLETED =  @semester , "
                   + "DATE_UPLOADED = @date "
                   + "WHERE USERNAME = @username ;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@thesis_title", thesistitle.Text);
                command.Parameters.AddWithValue("@course_no", courseNumber.Text);
                command.Parameters.AddWithValue("@keywords", keywords.Text);
                command.Parameters.AddWithValue("@abstract", thesisabstract.Text);
#pragma warning disable 618
                command.Parameters.Add("@thesis_report", ConvertUploadedFile(thesisupload));
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
                command.Parameters.AddWithValue("@dept_chair", deptchair.Text);
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