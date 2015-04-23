using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository.Admin
{
    public partial class AdminUserApproval : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                var username = Request.QueryString["username"];
                const string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";
               
                const string query = "update logininfo set admin_approval = 'Y' where username = @username;";
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    try
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            //    Response.Redirect("../Admin/AdminHomePage.aspx");

                            // approvalStatus.Text = "User: " + username + " has been approved ";
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
                //need to test.
                Response.Redirect("../Default.aspx", false);
            }

        }

        protected void UserApproval(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 1;
            approvalwaitinglist.Visible = true;
            
            approvalList.SelectCommand =
                "SELECT [username] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'";

        }
    }
}