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

        public int SignUp(UserModels userInfoModels)
        {
            var count = 0;


            const string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                            + "Integrated Security=true";
            using (var connection = new SqlConnection(connectionString))
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