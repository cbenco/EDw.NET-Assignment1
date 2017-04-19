using GoGoPowerRangers.ENET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.UI
{
	public partial class AccountantScreen : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ManagerGrid.DataSource = FakeDatabase._users.Where(i => i.UserType == Model.Type.Manager);
            ManagerGrid.DataBind();
            EngineerGrid.DataSource = FakeDatabase._users.Where(i => i.UserType == Model.Type.SiteEngineer);
            EngineerGrid.DataBind();
        }

        protected void btnViewPeople_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnViewReports_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }
    }
}