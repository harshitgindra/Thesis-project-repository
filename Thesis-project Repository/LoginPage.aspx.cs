using System;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class LoginPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var databaseMethods = new DatabaseMethods();

            var result = databaseMethods.LoginMethod(UserName.Text, Password.Text);

            if (result.Equals(true))
            {
                Label1.Text = "Successful login";
            }
            else
            {
                Label1.Text = "Unsuccessful login";
            }
        }
    }
}