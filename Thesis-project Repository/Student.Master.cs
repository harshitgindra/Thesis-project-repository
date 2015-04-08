using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Default.aspx", false);
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx", false);
        }

        protected void preliminaryProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPreliminaryProject.aspx", false);
        }

        protected void finalProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx", false);
        }
    }
}