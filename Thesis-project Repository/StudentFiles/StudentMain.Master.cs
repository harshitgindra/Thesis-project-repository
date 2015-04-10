using System;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class Student : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("../Default.aspx", false);
        }
    }
}