using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class VerificationLink : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the random string 
            var randomString = Request.QueryString["verify"];

            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";
            var query = "SELECT * FROM LOGININFO WHERE RDM_STR = '" + randomString + "';";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var query2 = "UPDATE LOGININFO SET RDM_STR = '' WHERE RDM_STR = '" + randomString + "';";
                        var command2 = new SqlCommand(query2, connection);
                        reader.Close();
                        try
                        {
                            if (command2.ExecuteNonQuery() == 1)
                            {
                                verificationstatus.Text = "Congratulations";
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
    }
}