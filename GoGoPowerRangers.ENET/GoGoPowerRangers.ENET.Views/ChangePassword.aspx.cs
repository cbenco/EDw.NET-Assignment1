using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public User _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (User)Session["currentUser"];
            if (!IsPostBack)
            {

            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (_user.Password.Equals(currentPassword.Text))
            {
                if (newPassword.Text.Equals(confirmPassword.Text))
                {
                    _user.ChangePassword(newPassword.Text);

                    switch (_user.UserType)
                    {
                        case (Model.Type.Accountant):
                            Response.Redirect("AccountantScreen.aspx", true);
                            break;
                        case (Model.Type.SiteEngineer):
                            Response.Redirect("Engineer.aspx", true);
                            break;
                        case (Model.Type.Manager):
                            Response.Redirect("Manager.aspx", true);
                            break;
                        default: 
                            Response.Redirect("test.aspx", true);
                            break;
                    }
                }
                else
                {
                    ErrorMessage.Text = "Confirm password field must match new password!";
                }
            }
            else
            { 
                ErrorMessage.Text = "Current password is incorrect!";
            }
        }
    }
}