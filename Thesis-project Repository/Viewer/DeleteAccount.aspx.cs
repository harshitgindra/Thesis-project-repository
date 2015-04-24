using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.Viewer
{
    public partial class DeleteAccount : System.Web.UI.Page
    {
        private const string ConnectionString =
          "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;" +
          "Integrated Security=true";

        string _accountType = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected int Delete()
        {

            var user = Session["username"].ToString();
            var result = 0;
            const string query = " SELECT * FROM LOGININFO WHERE username = @username;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", user);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        _accountType = reader.GetString(2);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    const string loginInfoDeleteQuery = "Delete from logininfo where username = @username;";
                    var command1 = new SqlCommand(loginInfoDeleteQuery, connection);
                    command1.Parameters.AddWithValue("@username", user);
                    result = command1.ExecuteNonQuery();

                    var userProfileDeleteQuery = "";
                    if (_accountType.Equals("P"))
                    {
                        userProfileDeleteQuery = "Delete from facultyprofile where username = @username;";
                        var command2 = new SqlCommand(userProfileDeleteQuery, connection);
                        command2.Parameters.AddWithValue("@username", user);
                        result += command2.ExecuteNonQuery();
                    }
                    else if (_accountType.Equals("S"))
                    {
                        const string studentThesisDelete = "Delete from thesis_submission where username = @username;";
                        const string studentFinalProjectDelete = "Delete from final_project_proposal where username = @username;";
                        const string studentPreliminaryDelete = "Delete from preliminary_project_submission where username = @username;";
                        userProfileDeleteQuery = "Delete from studentprofile where username = @username;";
                        var command3 = new SqlCommand(studentThesisDelete, connection);
                        command3.Parameters.AddWithValue("@username", user);

                        var command4 = new SqlCommand(studentFinalProjectDelete, connection);
                        command4.Parameters.AddWithValue("@username", user);

                        var command5 = new SqlCommand(studentPreliminaryDelete, connection);
                        command5.Parameters.AddWithValue("@username", user);

                        var command2 = new SqlCommand(userProfileDeleteQuery, connection);
                        command2.Parameters.AddWithValue("@username", user);

                        result += command3.ExecuteNonQuery();
                        result += command4.ExecuteNonQuery();
                        result += command5.ExecuteNonQuery();
                        result += command2.ExecuteNonQuery();

                    }
                    else if (_accountType.Equals("V"))
                    {
                        userProfileDeleteQuery = "Delete from viewerprofile where username = @username;";
                        var command2 = new SqlCommand(userProfileDeleteQuery, connection);
                        command2.Parameters.AddWithValue("@username", user);
                        result += command2.ExecuteNonQuery();
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
            return result;
        }

        protected void Yes(object sender, EventArgs e)
        {
            var result = Delete();
            if (result == 2 || result == 5)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                status.Text = "Something went wrong!! Not able to delete your account. Please try again later.";

            }
        }
        protected void No(object sender, EventArgs e)
        {

            Response.Redirect("ViewerHome.aspx", false);

        }
    }
}