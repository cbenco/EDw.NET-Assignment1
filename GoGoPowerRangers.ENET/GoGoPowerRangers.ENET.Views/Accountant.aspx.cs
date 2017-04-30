using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
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
        private UserTableAdapter _userTable = new UserTableAdapter();
		protected void Page_Load(object sender, EventArgs e)
		{
            _user = (Accountant)Session["currentUser"];
            labelFirstName.Text = "<h3>Hello, " + _user.FirstName + "</h3>";
            //ManagerGrid.DataSource = FakeDatabase._users.Where(i => i.UserType == Model.Type.Manager);
            ManagerGrid.DataSource = _userTable.GetAllManagers();
            ManagerGrid.DataBind();
			ManagerGrid.UseAccessibleHeader = true;
			ManagerGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            //EngineerGrid.DataSource = FakeDatabase._users.Where(i => i.UserType == Model.Type.SiteEngineer);
            EngineerGrid.DataSource = _userTable.GetAllEngineers();
            EngineerGrid.DataBind();
			EngineerGrid.UseAccessibleHeader = true;
			EngineerGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
		}

            //UserTableAdapter userAdapter = new UserTableAdapter();
            //ADOEngineerGrid.DataSource = userAdapter.GetUser();
            //ADOEngineerGrid.DataBind();
        

        //protected void btnViewPeople_Click(object sender, ImageClickEventArgs e)
        //{

        //}

        //protected void btnViewReports_Click(object sender, ImageClickEventArgs e)
        //{

        //}

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
                //var selectedUser = (User)FakeDatabase._users.FirstOrDefault(u => u.Id == id);
                var selectedUser = new User(_userTable.GetUserById(id).FirstOrDefault());
                Session.Add("selectedUser", selectedUser);
                Response.Redirect("ChangeDistrict.aspx");
            }
        }

        protected void report1_Click(object sender, EventArgs e)
        {

        }

        protected void report2_Click(object sender, EventArgs e)
        {

        }

        protected void report3_Click(object sender, EventArgs e)
        {

        }
    }
}