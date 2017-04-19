using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
namespace GoGoPowerRangers.ENET.UI
{
	public partial class LoginPage : System.Web.UI.Page
	{
        private static User _user;
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
		{
            string name = Login.UserName;
            string password = Login.Password;
            User currentUser = UserLogin(name, password);
            if (currentUser != null)
            {
                e.Authenticated = true;
                Session["currentUser"] = currentUser;
            }
            else
                e.Authenticated = false;
        }
        
        protected void Logged_In(object sender, EventArgs e)
        {
            switch (_user.UserType)
            {
                case (Model.Type.Accountant):
                    Server.Transfer("AccountantScreen.aspx", true);
                    break;
                case (Model.Type.SiteEngineer):
                    Server.Transfer("Engineer.aspx", true);
                    break;
                case (Model.Type.Manager):
                    Server.Transfer("Manager.aspx", true);
                    break;
                default: //need to figure out how to handle no assigned type. Do we need to?
                    Server.Transfer("test.aspx", true);
                    break;
            }
        }

        public static User UserLogin(string name, string password)
        {
            FakeDatabase db = new FakeDatabase();
            _user = db._users.FirstOrDefault(u => u.Name == name && u.Password == password);
            return _user;
        }

        //delete these buttons eventually
        protected void AccountantButton_OnClick (object sender, EventArgs e)
        {
            Server.Transfer("AccountantScreen.aspx", true);
        }
        protected void InterventionApprovalButton_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("Approval.aspx", true);

        }
        protected void ManagerButton_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("Manager.aspx", true);

        }
        protected void SiteEngineerButton_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("Engineer.aspx", true);

        }
    }
}