using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OmniSearchButton(object sender, EventArgs e)
        {
            SearchResults.ActiveViewIndex = 1;
        }
    }
}