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
            try
            {
                _user = (Accountant)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");

            }

            labelFirstName.Text = "<h3>Hello, " + _user.FirstName + "</h3>";

            var dataSource = _userTable.GetAllManagers();
            ManagerGrid.DataSource = dataSource;
            if (dataSource.Count != 0 && ManagerGrid.DataSource != null)
            {
                ManagerGrid.DataBind();
                ManagerGrid.UseAccessibleHeader = true;
                ManagerGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            dataSource = _userTable.GetAllEngineers();
            EngineerGrid.DataSource = dataSource;
            if (dataSource.Count != 0 && EngineerGrid.DataSource != null)
            {
                EngineerGrid.DataBind();
                EngineerGrid.UseAccessibleHeader = true;
                EngineerGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
                var selectedUser = new User(_userTable.GetUserById(id).FirstOrDefault());
                Session.Add("selectedUser", selectedUser);
                Response.Redirect("ChangeDistrict.aspx");
            }
        }

        protected void EngineerTotalCostReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("EngineerCostReport.aspx");

        }

        protected void EngineerAverageCostReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("EngineerAverageCostReport.aspx");
        }

        protected void DistrictTotalCostReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("DistrictCostReport.aspx");
        }

        protected void MonthlyDistrictCostReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("DistrictMonthlyCostReport.aspx");
        }
    }
}