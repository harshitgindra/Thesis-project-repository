using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Thesis_project_Repository.ProfessorFiles
{
    public partial class Professor : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    var username = Session["username"].ToString();
                    const string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                    + "Integrated Security=true";
                    const string queryString1 = "SELECT * FROM SUBSCRIPTION WHERE USERNAME = @username;";
                    using (var connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand(queryString1, connection);
                        command.Parameters.AddWithValue("@username", username);
                        try
                        {
                            connection.Open();
                            var reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                FooterMultiView.ActiveViewIndex = 1;
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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //protected void Logout_Click(object sender, EventArgs e)
        //{
        //    Session["username"] = null;
        //    Response.Redirect("../Default.aspx", false);
        //}

        protected void Subscribe(object sender, EventArgs e)
        {
            var username = Session["username"].ToString();
            const string query = "INSERT INTO SUBSCRIPTION (USERNAME, SUBSCRIPTIONSTATUS) VALUES (@USERNAME, 'Y');";
           DatabaseMethods subscribeMethod = new DatabaseMethods();
           var result = subscribeMethod.SubscribeUnsubscribeMethod(query, username);
            if (result == 1)
            {
                FooterMultiView.ActiveViewIndex = 1;
            }
        }

        protected void UnSubscribe(object sender, EventArgs e)
        {
            var username = Session["username"].ToString();
            const string query = "DELETE FROM SUBSCRIPTION WHERE USERNAME = @USERNAME;";
            DatabaseMethods unSubscribeMethod = new DatabaseMethods();
            var result = unSubscribeMethod.SubscribeUnsubscribeMethod(query, username);
            if (result == 1)
            {
                FooterMultiView.ActiveViewIndex = 0;
            }
        }

      
    }
}