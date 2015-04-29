using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class VerificationLink1 : System.Web.UI.Page
    {
        private const string ConnectionString =
             "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;" +
             "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the random string from the database.
            var randomString = Request.QueryString["verify"];
            const string query = "SELECT * FROM LOGININFO WHERE RDM_STR = @rdmString;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rdmString", randomString);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var rdnstring = reader.GetString(3);
                        const string query1 = "UPDATE LOGININFO SET RDM_STR = '' WHERE rdm_str = @randomString;";
                        var command2 = new SqlCommand(query1, connection);
                        command2.Parameters.AddWithValue("@randomString", randomString);

                        try
                        {
                            verificationstatus.Text = command2.ExecuteNonQuery() == 1
                                ? "Congratulations!! Your email has been verified successfully."
                                : "Something went wrong. Please contact admin";
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
            Response.Redirect("Default.aspx", false);
        }
    }
}