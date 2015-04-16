using System;
using System.Data;
using System.Data.SqlClient;
using Thesis_project_Repository.Models;

namespace Thesis_project_Repository
{
    public class DatabaseMethods
    {
        private const string ConnectionString =
            "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;"
            + "Integrated Security=true";

        public int UpdateUserProfile(UserModels userModels, string accountType)
        {
            var username = userModels.UserName;
            var password = userModels.Password;
            var secQuestion = userModels.SecQuestion;
            var secAnswer = userModels.SecAnswer;
            var firstName = userModels.FirstName;
            var lastName = userModels.LastName;
            var phoneNumber = userModels.PhoneNumber;
            var carrier = userModels.Carrier;
            var result = 0;
            var updateQuery2 = "";

            const string query = "UPDATE LOGININFO SET " +
                                 "PASSWORD = @PASSWORD, SECQUES = @SECQUES, SECANS = @SECANS " +
                                 "WHERE USERNAME = @USERNAME ;";

            if (accountType.Equals("P"))
            {
                updateQuery2 = "UPDATE FACULTYPROFILE SET " +
                    "FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, PHONENUMBER = @PHONENUMBER, CARRIER = @CARRIER " +
                                  "WHERE USERNAME = @USERNAME ;";
            }
            else if (accountType.Equals("S"))
            {
                updateQuery2 = "UPDATE STUDENTPROFILE SET " +
                                "FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, PHONENUMBER = @PHONENUMBER, CARRIER = @CARRIER " +
                                  "WHERE USERNAME = @USERNAME ;";
            }
            else if (accountType.Equals("V"))
            {
                updateQuery2 = "UPDATE VIEWERPROFILE SET " +
                                  "FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, PHONENUMBER = @PHONENUMBER, CARRIER = @CARRIER " +
                                 "WHERE USERNAME = @USERNAME ;";
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command1 = new SqlCommand(query, connection);
                command1.Parameters.AddWithValue("@USERNAME", username);
                command1.Parameters.AddWithValue("@PASSWORD", password);
                command1.Parameters.AddWithValue("@SECQUES", secQuestion);
                command1.Parameters.AddWithValue("@SECANS", secAnswer);

                var command2 = new SqlCommand(updateQuery2, connection);
                command2.Parameters.AddWithValue("@USERNAME", username);
                command2.Parameters.AddWithValue("@FIRSTNAME", firstName);
                command2.Parameters.AddWithValue("@LASTNAME", lastName);
                command2.Parameters.AddWithValue("@PHONENUMBER", phoneNumber);
                command2.Parameters.AddWithValue("@CARRIER", carrier);
                try
                {
                    connection.Open();
                    result = command1.ExecuteNonQuery();
                    result += command2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
            return result;
        }

        public int SubscribeUnsubscribeMethod(string query, string username)
        {
            const string connectionString =
                "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;" +
                "Integrated Security=true";
            var reader = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@USERNAME", username);

                try
                {
                    connection.Open();
                    reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
            return reader;
        }
        public int UpdatePasswordFromSms(string randomString, string password)
        {
            var usernameDb = "";
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
                        usernameDb = reader.GetString(0);
                    }
                    try
                    {
                        const string query1 =
                            "UPDATE LOGININFO SET RDM_STR = '' , password = @password WHERE username = @username;";
                        var command2 = new SqlCommand(query1, connection);
                        command2.Parameters.AddWithValue("@username", usernameDb);
                        command2.Parameters.AddWithValue("@password", password);
                        result = command2.ExecuteNonQuery();
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
                finally
                {
                    connection.Close();
                }
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