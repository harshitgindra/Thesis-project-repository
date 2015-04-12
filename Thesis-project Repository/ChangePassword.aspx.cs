using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class ChangePassword : Page
    {
        private const string ConnectionString =
            "Data Source=itksqlexp8;Initial Catalog=it485project;" + "Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                            var _usernameDb = reader.GetString(0);
                            Session["username"] = _usernameDb;
                        }
                        else
                        {
                            TestMessage.Text = "invalid Link";
                        }
                        connection.Close();
                        connection.Open();

                        try
                        {
                            const string query1 = "UPDATE LOGININFO SET RDM_STR = '' WHERE rdm_str = @rdmString;";
                            var command2 = new SqlCommand(query1, connection);
                            command2.Parameters.AddWithValue("@rdmString", randomString);
                            TestMessage.Text = command2.ExecuteNonQuery() == 1
                                ? "Congratulations!! Your email has been verified successfully."
                                : "Something went wrong. Please contact admin";
                            MultiView1.ActiveViewIndex = 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
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

        protected void UpdatePassword(object sender, EventArgs e)
        {
            var newPassword = NewPassword.Text;
            var name = Session["username"].ToString();
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    const string query = "UPDATE LOGININFO SET password = @password WHERE username = @username;";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.Parameters.AddWithValue("@username", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    result.Text =
                        "Your password has been changed successfully. Please click on the login button to login to your account.";
                    MultiView1.ActiveViewIndex = 2;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        protected void loginPage(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}