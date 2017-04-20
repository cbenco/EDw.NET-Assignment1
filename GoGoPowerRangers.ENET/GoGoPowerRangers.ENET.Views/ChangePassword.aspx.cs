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
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            _user.ChangePassword(newPassword.Text.ToString());

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
                default: //need to figure out how to handle no assigned type. Do we need to?
                    Response.Redirect("test.aspx", true);
                    break;
            }
        }
    }
}