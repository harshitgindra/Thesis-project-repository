using System;
using System.Data;
using System.Data.SqlClient;
using Thesis_project_Repository.Modals;

namespace Thesis_project_Repository
{
    public class DatabaseMethods
    {
        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;"
                                                + "Integrated Security=true";

        public int UpdatePasswordFromSMS(string randomString, string password)
        {
            var _usernameDb = "";
            var result = 0;
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
                    }
                    try
                    {
                        const string query1 = "UPDATE LOGININFO SET RDM_STR = '' , password = @password WHERE username = @username;";
                        var command2 = new SqlCommand(query1, connection);
                        command2.Parameters.AddWithValue("@username", _usernameDb);
                        command2.Parameters.AddWithValue("@password", password);

                        result = command2.ExecuteNonQuery();
                          
                        // MultiView1.ActiveViewIndex = 1;
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
            return result;
        }

        public void UpdateLogininfordmstr(string username, string randomstring)
        {
            const string query = "UPDATE LOGININFO SET RDM_STR = @randomString WHERE USERNAME = @userName;";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userName", username);
                command.Parameters.AddWithValue("@randomString", randomstring);
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

        public int SignUp(UserModels userInfoModels)
        {
            var count = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    var command1 = new SqlCommand("spLoginInfoSignUp", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command1.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));
                    command1.Parameters.Add(new SqlParameter("@password", userInfoModels.Password));
                    command1.Parameters.Add(new SqlParameter("@accttype", userInfoModels.AccountType));
                    command1.Parameters.Add(new SqlParameter("@rndmStr", userInfoModels.RandomString));
                    command1.Parameters.Add(new SqlParameter("@adminapproval", userInfoModels.AdminApproval));
                    command1.Parameters.Add(new SqlParameter("@secquestion", userInfoModels.SecQuestion));
                    command1.Parameters.Add(new SqlParameter("@secanswer", userInfoModels.SecAnswer));
                    var loginInfoSignUpInsert = command1.ExecuteNonQuery();

                    if (userInfoModels.AccountType.Equals('P'))
                    {
                        var command2 = new SqlCommand("spFacultyProfileSignUp", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command2.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));
                        command2.Parameters.Add(new SqlParameter("@firstname", userInfoModels.FirstName));
                        command2.Parameters.Add(new SqlParameter("@lastname", userInfoModels.LastName));
                        command2.Parameters.Add(new SqlParameter("@phonenumber", userInfoModels.PhoneNumber));
                        command2.Parameters.Add(new SqlParameter("@carrier", userInfoModels.Carrier));
                        var facultyProfileSignUpInsert = command2.ExecuteNonQuery();
                        count = loginInfoSignUpInsert + facultyProfileSignUpInsert;
                    }
                    else if (userInfoModels.AccountType.Equals('V'))
                    {
                        var command3 = new SqlCommand("spViewerProfileSignUp", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command3.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));
                        command3.Parameters.Add(new SqlParameter("@firstname", userInfoModels.FirstName));
                        command3.Parameters.Add(new SqlParameter("@lastname", userInfoModels.LastName));
                        command3.Parameters.Add(new SqlParameter("@phonenumber", userInfoModels.PhoneNumber));
                        command3.Parameters.Add(new SqlParameter("@carrier", userInfoModels.Carrier));
                        var viewerProfileSignUpInsert = command3.ExecuteNonQuery();
                        count = loginInfoSignUpInsert + viewerProfileSignUpInsert;
                    }
                    else
                    {
                        var command4 = new SqlCommand("spStudentProfileSignUp", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command4.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));
                        command4.Parameters.Add(new SqlParameter("@firstname", userInfoModels.FirstName));
                        command4.Parameters.Add(new SqlParameter("@lastname", userInfoModels.LastName));
                        command4.Parameters.Add(new SqlParameter("@phonenumber", userInfoModels.PhoneNumber));
                        command4.Parameters.Add(new SqlParameter("@carrier", userInfoModels.Carrier));

                        var command5 = new SqlCommand("spThesisSubmission", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command5.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));

                        var command6 = new SqlCommand("spPreliminaryProjectSubmission", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command6.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));

                        var command7 = new SqlCommand("spFinalProjectProposal", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command7.Parameters.Add(new SqlParameter("@username", userInfoModels.UserName));

                        var studentProfileSignUpInsert = command4.ExecuteNonQuery();
                        var thesisSubmissionInsert = command5.ExecuteNonQuery();
                        var preliminaryProjectSubmissionInsert = command6.ExecuteNonQuery();
                        var finalProjectProposalInsert = command7.ExecuteNonQuery();

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