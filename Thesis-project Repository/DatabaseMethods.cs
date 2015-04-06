using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Thesis_project_Repository
{
    public class DatabaseMethods
    {

        public Boolean LoginMethod(string username, string password)
        {
            bool result = false;
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command1 = new SqlCommand("Getstudentname", connection);
                command1.CommandType = CommandType.StoredProcedure;


                command1.Parameters.Add(new SqlParameter("@username", username));
                try
                {
                    connection.Open();
                    SqlDataReader rd = command1.ExecuteReader();
                    while (rd.Read())
                    {
                        string dbusername = rd.GetString(0);
                        string dbpassword = rd.GetString(1);
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

    }
}