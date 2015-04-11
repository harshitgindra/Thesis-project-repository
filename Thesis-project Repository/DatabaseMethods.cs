using System;
using System.Data;
using System.Data.SqlClient;
using Thesis_project_Repository.Modals;

namespace Thesis_project_Repository
{
    public class DatabaseMethods
    {
        public Boolean LoginMethod(string username, string password)
        {
            var result = false;
            const string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                            + "Integrated Security=true";

            using (var connection = new SqlConnection(connectionString))
            {
                var command1 = new SqlCommand("Getstudentname", connection);
                command1.CommandType = CommandType.StoredProcedure;
                command1.Parameters.Add(new SqlParameter("@username", username));
                try
                {
                    connection.Open();
                    var rd = command1.ExecuteReader();
                    while (rd.Read())
                    {
                        var dbusername = rd.GetString(0);
                        var dbpassword = rd.GetString(1);
                        if (username.Equals(dbusername) && password.Equals(dbpassword))
                        {
                            result = true;
                        }
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

        public int SignUp(FacultyModels _facultyLogininfoModels)
        {
            var count = 0;


            const string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                            + "Integrated Security=true";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command1 = new SqlCommand("loginInfoSignUp", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Password));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.AccountType));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.RandomString));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.AdminApproval));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.SecQuestion));
                    command1.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.SecAnswer));
                    var loginInfoSignUpInsert = command1.ExecuteNonQuery();

                    if (_facultyLogininfoModels.AccountType.Equals('P'))
                    {
                        var command2 = new SqlCommand("facultyProfileSignUp", connection);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command2.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command2.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command2.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command2.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));
                        var facultyProfileSignUpInsert = command2.ExecuteNonQuery();
                        count = loginInfoSignUpInsert + facultyProfileSignUpInsert;
                    }
                    else if (_facultyLogininfoModels.AccountType.Equals('V'))
                    {
                        var command3 = new SqlCommand("viewerProfileSignUp", connection);
                        command3.CommandType = CommandType.StoredProcedure;
                        command3.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command3.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command3.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command3.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command3.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));
                        var viewerProfileSignUpInsert = command3.ExecuteNonQuery();
                        count = loginInfoSignUpInsert + viewerProfileSignUpInsert;
                    }
                    else
                    {
                        var command4 = new SqlCommand("studentProfileSignUp", connection);
                        command4.CommandType = CommandType.StoredProcedure;
                        command4.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command4.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command4.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command4.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command4.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));

                        var command5 = new SqlCommand("thesisSubmission", connection);
                        command5.CommandType = CommandType.StoredProcedure;
                        command5.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command5.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command5.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command5.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command5.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));

                        var command6 = new SqlCommand("preliminaryProjectSubmission", connection);
                        command6.CommandType = CommandType.StoredProcedure;
                        command6.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command6.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command6.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command6.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command6.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));

                        var command7 = new SqlCommand("finalProjectProposal", connection);
                        command7.CommandType = CommandType.StoredProcedure;
                        command7.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.UserName));
                        command7.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.FirstName));
                        command7.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.LastName));
                        command7.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.PhoneNumber));
                        command7.Parameters.Add(new SqlParameter("@username", _facultyLogininfoModels.Carrier));



                        var studentProfileSignUpInsert = command4.ExecuteNonQuery();
                        var thesisSubmissionInsert = command5.ExecuteNonQuery();
                        var preliminaryProjectSubmissionInsert = command6.ExecuteNonQuery();
                        var finalProjectProposalInsert = command6.ExecuteNonQuery();

                        count = loginInfoSignUpInsert + studentProfileSignUpInsert + thesisSubmissionInsert
                            + preliminaryProjectSubmissionInsert + finalProjectProposalInsert;
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
            return count;
        }
    }
}