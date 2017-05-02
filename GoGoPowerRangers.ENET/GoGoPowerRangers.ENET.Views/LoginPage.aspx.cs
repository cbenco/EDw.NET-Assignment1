using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.UI
{
	public partial class LoginPage : System.Web.UI.Page
	{
        private static User _currentUser;
        private static UserTableAdapter usersTable = new UserTableAdapter();
        private static UserTypeTableAdapter userTypeTable = new UserTypeTableAdapter();
        private static DistrictTableAdapter districtTable = new DistrictTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
		{
            var user = Session["currentUser"];

            if (user != null)
            {
                ErrorMessage.Text = "An error occurred";
                Session["currentUser"] = null;
            }
		}

		protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
		{
            string name = Login.UserName;
            string password = Login.Password; //change to gethashcode
            User _currentUser = UserLogin(name, password);

            if (_currentUser != null)
            {
                e.Authenticated = true;
            }
            else
                e.Authenticated = false;
        }
        
        protected void Logged_In(object sender, EventArgs e)
        {
            switch (_currentUser.UserType)
            {
                case (Model.Type.Accountant):
                    Session["currentUser"] = new Accountant(_currentUser);
                    Response.Redirect("Accountant.aspx", true);
                    break;
                case (Model.Type.SiteEngineer):
                    Session["currentUser"] = CreateEngineer(_currentUser);
                    Response.Redirect("Engineer.aspx", true);
                    break;
                case (Model.Type.Manager):
                    Session["currentUser"] = CreateManager(_currentUser);
                    Response.Redirect("Manager.aspx", true);
                    break;
            }
        }

        private Manager CreateManager(User currentUser)
        {
            Manager manager = new Manager(currentUser);
            manager.District = GetDistrictFromDB(currentUser);
            manager.MaxMaterialCost = GetCostLimitFromDB(currentUser);
            manager.ApprovalLimit = GetApprovalLimitFromDB(currentUser);
            manager.MaxManHours = 500;
            return manager;
        }

        private SiteEngineer CreateEngineer(User currentUser)
        {
            SiteEngineer engineer = new SiteEngineer(currentUser);
            engineer.District = GetDistrictFromDB(currentUser);
            engineer.MaxMaterialCost = GetCostLimitFromDB(currentUser);
            engineer.ApprovalLimit = GetApprovalLimitFromDB(currentUser);
            engineer.MaxManHours = 500;
            return engineer;
        }


        private District GetDistrictFromDB(User currentUser)
        {
            var dbUserType = userTypeTable.GetUserTypeByUserID(currentUser.Id).FirstOrDefault();
            var dbDistrict = districtTable.GetDistrictById(dbUserType.DistrictID).FirstOrDefault();
            return new District(dbDistrict);
        }

        private double GetApprovalLimitFromDB(User currentUser)
        {
            var dbUserType = userTypeTable.GetUserTypeByUserID(currentUser.Id).FirstOrDefault();
            return (double)dbUserType.ApprovalLimit;
        }

        private double GetCostLimitFromDB(User currentUser)
        {
            var dbUserType = userTypeTable.GetUserTypeByUserID(currentUser.Id).FirstOrDefault();
            return (double)dbUserType.CostLimit;
        }

        public static User UserLogin(string name, string password)
        {
            var dbUser = usersTable.GetUserByUsername(name).FirstOrDefault();
            if (dbUser == null)
                return null;
            _currentUser = new User(dbUser);
            if (_currentUser.Password != password)
                return null;
            else
                return _currentUser;
        }

        //delete these buttons eventually

        protected void InterventionApprovalButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Approval.aspx", true);

        }
        
    }
}