using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            SqlDataSource1.SelectCommand = "SELECT [username], [password] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'";

        }

        protected void CheckListforApproval_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "SELECT * FROM LOGININFO WHERE ADMIN_APPROVAL = 'N'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    //in case of duplicate user id

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