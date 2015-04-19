using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Thesis_project_Repository.Models;

namespace Thesis_project_Repository.Viewer
{
    public partial class UpdateViewerProfile : System.Web.UI.Page
    {
        private const string ConnectionString =
      "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;" +
      "Integrated Security=true";

        private string _accountType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    var user = Session["username"].ToString();
                    var getInformationQuery = "";
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
                        if (_accountType.Equals("P"))
                        {
                            getInformationQuery = "SELECT * FROM LOGININFO inner join facultyprofile on " +
                                                  "LOGININFO.username = facultyprofile.username " +
                                                  "WHERE LOGININFO.username = @username;";
                        }
                        else if (_accountType.Equals("S"))
                        {
                            getInformationQuery = "SELECT * FROM LOGININFO inner join studentprofile on " +
                                                     "LOGININFO.username = studentprofile.username " +
                                                     "WHERE LOGININFO.username = @username;";
                        }
                        else if (_accountType.Equals("V"))
                        {
                            getInformationQuery = "SELECT * FROM LOGININFO inner join viewerprofile on " +
                                                         "LOGININFO.username = viewerprofile.username " +
                                                         "WHERE LOGININFO.username = @username;";
                        }
                        var command2 = new SqlCommand(getInformationQuery, connection);
                        command2.Parameters.AddWithValue("@username", user);
                        try
                        {
                            var reader1 = command2.ExecuteReader();
                            if (reader1.Read())
                            {
                                username.Text = reader1.GetString(0);
                                password.Text = reader1.GetString(1);
                                secQuestion.Text = reader1.GetString(5);
                                secAnswer.Text = reader1.GetString(6);
                                fname.Text = reader1.GetString(8);
                                lname.Text = reader1.GetString(9);
                                phnNumber.Text = reader1.GetString(10);
                                provider.Text = reader1.GetString(11);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    var user = Session["username"].ToString();
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
                        connection.Close();
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        protected void UpdateUserProfile(object sender, EventArgs e)
        {
            var result = 0;
            var userName = username.Text;
            var pass = password.Text;
            var securityQuestion = secQuestion.Text;
            var seccurityAnswer = secAnswer.Text;
            var firstName = fname.Text;
            var lastName = lname.Text;
            var phoneNumber = phnNumber.Text;
            var carrier = provider.Text;
            UserModels userModels = new UserModels(userName, pass, securityQuestion, seccurityAnswer, firstName, lastName, phoneNumber, carrier);
            DatabaseMethods updateMethods = new DatabaseMethods();
            result = updateMethods.UpdateUserProfile(userModels, _accountType);
            updateResult.Text = result == 2 ? "Profile has been updated successfully." : "Failed to update the profile.";
        }
    }

}