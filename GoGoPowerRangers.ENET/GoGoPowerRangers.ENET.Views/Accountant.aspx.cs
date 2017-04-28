using GoGoPowerRangers.ENET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.UI
{
	public partial class AccountantScreen : System.Web.UI.Page
	{
        public Accountant _user;

		protected void Page_Load(object sender, EventArgs e)
		{
            _user = (Accountant)Session["currentUser"];
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

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", true);
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "changeDistrictClick")
            {
                var selectedUser = (User)FakeDatabase._users.FirstOrDefault(u => u.Id == id);
                Session.Add("selectedUser", selectedUser);
                Response.Redirect("ChangeDistrict.aspx");
            }
        }
    }
}