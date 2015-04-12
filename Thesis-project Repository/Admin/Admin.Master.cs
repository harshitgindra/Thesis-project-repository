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

        protected void UserApproval(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 1;
            approvalwaitinglist.Visible = true;
            DetailedInfoApprovalAccount.Visible = true;
            approvalList.SelectCommand =
                "SELECT [username] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'";

        }
    }
}