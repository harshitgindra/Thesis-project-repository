using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class VerificationLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting the random string 
            string randomString = Request.QueryString["verify"];

            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "SELECT * FROM LOGININFO WHERE RDM_STR = '" + randomString + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string query2 = "UPDATE LOGININFO SET RDM_STR = '' WHERE RDM_STR = '" + randomString + "';";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        reader.Close();
                        try
                        {
                            if (command2.ExecuteNonQuery() == 1)
                            {
                                verificationstatus.Text = "Congratulations";
                            }
                            else
                            {
                                verificationstatus.Text = "Something went wrong. Please contact admin";
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        verificationstatus.Text = "invalid Link";
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
}