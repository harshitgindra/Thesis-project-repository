using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;" + "Integrated Security=true";
        private string _usernameDb = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        _usernameDb = reader.GetString(0);
                        const string query1 = "UPDATE LOGININFO SET RDM_STR = '' WHERE rdm_str = @rdmString;";
                        var command2 = new SqlCommand(query1, connection);
                        command.Parameters.AddWithValue("@randomString", randomString);
                        try
                        {
                            TestMessage.Text = command2.ExecuteNonQuery() == 1 ? "Congratulations!! Your email has been verified successfully." : "Something went wrong. Please contact admin";
                            MultiView2.ActiveViewIndex = 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        TestMessage.Text = "invalid Link";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        protected void UpdatePassword_Click(object sender, EventArgs e)
        {
            string newPassword = NewPassword.Text;
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    const string query = "UPDATE LOGININFO SET password = @password WHERE username = @username;";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.Parameters.AddWithValue("@username", _usernameDb);
                    connection.Open();
                    command.ExecuteNonQuery();
                    result.Text =
                        "Your password has been changed successfully. Please click on the login button to login to your account.";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        protected void loginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


    }
}