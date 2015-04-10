using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                approvalwaitinglist.Visible = true;
                DetailedInfoApprovalAccount.Visible = true;
                approvalList.SelectCommand = "SELECT [username], [password] FROM [logininfo] WHERE [ADMIN_APPROVAL] = 'N'";
            }

        }
    }
}