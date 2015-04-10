using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class ForgotPassword : Page
    {
        private readonly EmailClass email = new EmailClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            retrievepassword.ActiveViewIndex = 0;
        }

        protected void forgotpwdemail_Click(object sender, EventArgs e)
        {
            retrievepassword.ActiveViewIndex = 1;
            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";
            var query = "SELECT * FROM USERINFO WHERE EMAILID = '" + forgotEmailId.Text + "';";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var username = reader.GetString(2);
                        var randomString = Path.GetRandomFileName();
                        randomString = randomString.Replace(".", "");
                        updateLogininfowtrdmstr(username, randomString);
                        if (email.sendEmail(forgotEmailId.Text, "Retrieve Lost Password", emailBody(randomString)))
                        {
                            confimationmsg.Text = "Email Sent Successfully. Please check your inbox";
                        }
                        else
                        {
                            confimationmsg.Text = "Something went wront. Please retry.";
                        }
                    }
                    else
                    {
                        confimationmsg.Text = "Email Id not in DB";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //in case of duplicate user id
                    confimationmsg.Text = "something went wrong";
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void updateLogininfowtrdmstr(string username, string randomstring)
        {
            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";
            var query = "UPDATE LOGININFO SET RDM_STR = '" + randomstring + "' WHERE USERNAME = '" + username + "';";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    confimationmsg.Text = "something went wrong";
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected string emailBody(string rdmString)
        {
            var message = "<html> <img src=\"http://www.underconsideration.com/brandnew/archives/dropbox_logo_detail.png\" width=\"90\" height=\"90\" /> "
                          +
                          " <h2>Thank you for signing up. </h2> <br /><p>Please click on the link to verify the email id which will help you change your password.</p><br />"
                          + "<a href='http://localhost:60443/RetrievePassword.aspx?verify=" + rdmString +
                          "' >Click Here</a>"
                          + "<h3>Thank you</h3>";
            return message;
        }
    }
}