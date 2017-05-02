using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public User _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (User)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }
               
            if (!IsPostBack)
            {

            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {           
            var password = currentPassword.Text;
            UserTableAdapter usersTable = new UserTableAdapter();
            usersTable.UpdateUserPassword(newPassword.Text, _user.UserName, currentPassword.Text, _user.Id);
        }
    }
}