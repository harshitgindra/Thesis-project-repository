using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class RetrievePassword : System.Web.UI.Page
    {
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string randomString = Request.QueryString["verify"];
            if (!randomString.Equals(""))
            {

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
                            username = reader.GetString(0);
                            
                            ChangePasswordmultiview.ActiveViewIndex = 0;
                            reader.Close();
                        }
                        else
                        {
                            ChangePasswordmultiview.ActiveViewIndex = 1;
                            PasswordChangeNotification.Text = "Invalid Link.";
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


            }
            else
            {
                ChangePassword.ActiveViewIndex = 1;
                PasswordChangeNotification.Text = "Wrong link. Please retry again";
            }
        }

        protected void changepassword_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "UPDATE logininfo set password = @password, rdm_str='' where username = @username ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", newpassword1.Text);
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        ChangePassword.ActiveViewIndex = 1;
                        PasswordChangeNotification.Text = "Password Successfully Changed";
                    }
                    else
                    {
                        ChangePassword.ActiveViewIndex = 1;
                        PasswordChangeNotification.Text = "Something went wrong. Please retry.";
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
        }
    }
}