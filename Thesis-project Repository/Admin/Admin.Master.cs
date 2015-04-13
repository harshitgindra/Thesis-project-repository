using System;
using System.Web.UI;

namespace Thesis_project_Repository.Admin
{
    public partial class Admin : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
          
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("../Default.aspx", false);
        }

       
    }
}