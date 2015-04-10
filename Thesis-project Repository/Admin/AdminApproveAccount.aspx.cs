using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class AdminApproveAccount : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var adminUsername = "";
            var username = "";
            if (Session["username"] != null)
            {
//session active

                if (!Page.IsPostBack)
                {
                    adminUsername = (Session["username"].ToString());
                    username = Request.QueryString["username"];
                    var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                           + "Integrated Security=true";
                    var query = "update logininfo set admin_approval = 'Y' where username = '" + username + "';";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            if (command.ExecuteNonQuery() == 1)
                            {
                                approvalStatus.Text = "User: " + username + " has been approved ";
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
            else
            {
                //need to test.
                Response.Redirect("../Default.aspx", false);
            }
        }
    }
}