using System;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class WebForm2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CheckListforApproval_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminApprovalList.aspx", false);
        }
    }
}