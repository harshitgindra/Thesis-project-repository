﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "";
            if (Session["username"] != null)
            {//session active

                if (!Page.IsPostBack)
                {

                    username = (Session["username"].ToString());
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }

        }
    }
}