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
            //if (!IsPostBack)
            //{
                _user = (User)Session["currentUser"];
            //}
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
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
                        default: //need to figure out how to handle no assigned type. Do we need to?
                            Response.Redirect("test.aspx", true);
                            break;
                    }
                }
                else
                {
                    //handle it
                }
            }
            else
            {
                //handle it
            }
        }
    }
}