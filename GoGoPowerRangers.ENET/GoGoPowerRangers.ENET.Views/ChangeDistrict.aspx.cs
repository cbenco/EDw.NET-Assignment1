using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ChangeDistrict : System.Web.UI.Page
    {
        public Accountant _user;
        public User _selectedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (Accountant)Session["currentUser"];
            _selectedUser = (User)Session["selectedUser"];
            
            if (!IsPostBack)
            {
                labelHeader.Text = "<h1>Change district for " + _selectedUser.FirstName + "</h1>";

                districtButtons.DataSource = FakeDatabase._districts;
                districtButtons.DataTextField = "Name";
                districtButtons.DataValueField = "Name";
                districtButtons.DataBind();
            }
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            var district = FakeDatabase._districts.FirstOrDefault(d => d.Name == districtButtons.SelectedValue.ToString());
            if (_selectedUser.GetType() == typeof(SiteEngineer))
                _user.ChangeSiteEngineerDistrict((SiteEngineer)_selectedUser, district);
            else
                _user.ChangeManagerDistrict((Manager)_selectedUser, district);

            Response.Redirect("Accountant.aspx");
        }
    }
}