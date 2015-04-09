using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class AdminApproveAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string adminUsername = "";
            string username = "";
            if (Session["username"] != null)
            {//session active

                if (!Page.IsPostBack)
                {

                    adminUsername = (Session["username"].ToString());
                    username = Request.QueryString["username"];
                    string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
                    string query = "update logininfo set admin_approval = 'Y' where username = '" + username + "';";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
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
