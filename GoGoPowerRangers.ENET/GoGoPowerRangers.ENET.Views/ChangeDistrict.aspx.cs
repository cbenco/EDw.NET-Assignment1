using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ChangeDistrict : System.Web.UI.Page
    {
        public Accountant _user;
        public User _selectedUser;
        DistrictTableAdapter _districtTable = new DistrictTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (Accountant)Session["currentUser"];
                _selectedUser = (User)Session["selectedUser"];
                if (_user == null || _selectedUser == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                labelHeader.Text = "<h1>Change district for " + _selectedUser.FirstName + " " + _selectedUser.LastName + "</h1>";

                var dataSource = _districtTable.GetDistricts();
                districtButtons.DataSource = dataSource;
                if (dataSource.Count != 0 && districtButtons.DataSource != null)
                {
                    districtButtons.DataTextField = "DistrictName";
                    districtButtons.DataValueField = "DistrictID";
                    districtButtons.DataBind();
                }
            }
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            //var district = FakeDatabase._districts.FirstOrDefault(d => d.Name == districtButtons.SelectedValue.ToString());
            int selectedId;
            var selected = districtButtons.SelectedValue;
            int.TryParse(selected, out selectedId);
            _user.ChangeUserDistrict(_selectedUser, selectedId);
            Response.Redirect("Accountant.aspx");
        }
    }
}