using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {

            DatabaseMethods databaseMethods = new DatabaseMethods();
            bool result = databaseMethods.LoginMethod(UserName.Text, Password.Text);

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