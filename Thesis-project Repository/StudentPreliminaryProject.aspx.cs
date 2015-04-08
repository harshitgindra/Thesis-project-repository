using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string username = "hgindra";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "INSERT INTO PRELIMINARY_PROJECT_SUBMISSION "
                + "(USERNAME, COURSE_NO, LIVE_LINK, KEYWORDS, ABSTRACT, DOCUMENT, DOCUMENT_LENGTH, DOCUMENT_NAME, SCREENCAST, SCREENCAST_LENGTH, SCREENCAST_NAME, COMMITTEE_CHAIR, COMMITTEE_MEMBERS, GRADUATE_ADVISOR, SEMESTER_COMPLETED, DATE_UPLOADED)"
                + " VALUES ( '" + username + "','"
                + courseNumber.Text + "','"
                + livelink.Text + "','"
                + keywords.Text + "','"
                + projectabstract.Text + "','"
                //+ courseNumber.Text + "','"
                //+ courseNumber.Text + "','"
                //+ courseNumber.Text + "','"
                //+ courseNumber.Text + "','"
                //+ courseNumber.Text + "','"
                //+ courseNumber.Text + "','"
                + committeeChair.Text + "','"
                + committeemember.Text + "','"
                + graduateAdvisor.Text + "','"
                + semester.Text + "',"
                + date + ");";
                

        }


        public void convertUploadedFile(FileUpload file)
        {
            int lenght = file.PostedFile.ContentLength;
            string contenttype = file.PostedFile.ContentType;
            string name = file.PostedFile.FileName;
            byte[] data = new byte[lenght];
            FileUploadControl.PostedFile.InputStream.Read(data, 0, lenght);
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=hgindraLoginInfo;"
                                  + "Integrated Security=true";



            string query = "Insert into IMGUPLOAD VALUES(";
            query += " @username , @attachment);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username.Text);
                command.Parameters.Add("@attachment", data);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
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

    }
}