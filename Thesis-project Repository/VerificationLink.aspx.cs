using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class VerificationLink : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the random string from the database.

            var randomString = Request.QueryString["verify"];

            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";
            var query = "SELECT * FROM LOGININFO WHERE RDM_STR = @rdmString;";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rdmString", randomString);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        //  var randomStringFromDatabase = reader.GetString(3);
                        // if (randomStringFromDatabase.Equals(randomString))

                        const string query1 = "UPDATE LOGININFO SET RDM_STR = '' WHERE rdm_str = @rdmString;";

                        var command2 = new SqlCommand(query1, connection);
                        command.Parameters.AddWithValue("@randomString", randomString);
                        try
                        {
                            if (command2.ExecuteNonQuery() == 1)
                            {
                                verificationstatus.Text = "Congratulations!! Your email has been verified successfully.";
                            }
                            else
                            {
                                verificationstatus.Text = "Something went wrong. Please contact admin";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        verificationstatus.Text = "invalid Link";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        protected void TakeToLoginPage(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}