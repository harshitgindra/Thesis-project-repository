using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository.Admin
{
    public partial class WebForm2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check whether session is working or not. As session checking method is imlemented in masterpage.
            if (Session["username"] != null)
            {
                if (IsPostBack)
                {
                    var username = Request.QueryString["username"];
                    var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                           + "Integrated Security=true";
                    //need to make this 
                    var query = "update logininfo set admin_approval = 'Y' where username = '" + username + "';";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand(query, connection);
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
            }

            else
            {
                //need to test.
                Response.Redirect("../Default.aspx", false);
            }
        }

       
    }
}