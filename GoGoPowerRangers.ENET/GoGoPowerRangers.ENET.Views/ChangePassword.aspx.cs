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

            if (password != _user.Password)
                ErrorMessage.Text = "Incorrect password";
            else if (password == newPassword.Text)
                ErrorMessage.Text = "New Password must be different";
            else if (newPassword.Text != confirmPassword.Text)
                ErrorMessage.Text = "New passwords must match";
            else if (password.Count() == 0)
                ErrorMessage.Text = "Password must contain characters";
            else
            {
                try
                {
                    UserTableAdapter usersTable = new UserTableAdapter();
                    usersTable.UpdateUserPassword(newPassword.Text, _user.UserName, currentPassword.Text, _user.Id);
                    ErrorMessage.Text = "Password Changed!";

                    _user.Password = newPassword.Text;
                    Session["currentUser"] = _user;

                    if (_user.GetType().Equals(typeof(Accountant)))
                        Response.Redirect("Accountant.aspx", false);

                    if (_user.GetType().Equals(typeof(Manager)))
                        Response.Redirect("Manager.aspx", false);

                    if (_user.GetType().Equals(typeof(SiteEngineer)))
                        Response.Redirect("Engineer.aspx", false);
                }
                catch
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
           


        }
    }
}