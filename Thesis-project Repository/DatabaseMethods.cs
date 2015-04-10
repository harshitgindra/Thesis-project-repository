using System;
using System.Data;
using System.Data.SqlClient;

namespace Thesis_project_Repository
{
    public class DatabaseMethods
    {
        public Boolean LoginMethod(string username, string password)
        {
            var result = false;
            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
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

        public Boolean SignUp(string username, string password)
        {
            return true;
        }
    }
}