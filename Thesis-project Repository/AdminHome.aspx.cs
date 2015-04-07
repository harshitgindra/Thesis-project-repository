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
        }

        protected void CheckListforApproval_Click(object sender, EventArgs e)
        {
            approvalwaitinglist.Visible = true;
            DetailedInfoApprovalAccount.Visible = true;
            approvalList.SelectCommand = "SELECT [username], [password] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'";
        }
    }
}