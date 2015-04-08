﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckListforApproval_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminApprovalList.aspx", false);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Default.aspx", false);
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx", false);
        }
    }
}