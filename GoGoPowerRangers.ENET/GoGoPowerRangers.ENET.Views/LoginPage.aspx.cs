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
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
		{
            string name = Login.UserName;
            string password = Login.Password;
            if (UserLogin(name, password) != null)
                e.Authenticated = true;
            else
                e.Authenticated = false;
        }
        
        protected void Logged_In(object sender, EventArgs e)
        {
            Server.Transfer("test.aspx", true);
        }

        public static User UserLogin(string name, string password)
        {
            User user = null;
            FakeDatabase db = new FakeDatabase();
            user = db._users.FirstOrDefault(u => u.Name == name && u.Password == password);
            return user;
        }

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