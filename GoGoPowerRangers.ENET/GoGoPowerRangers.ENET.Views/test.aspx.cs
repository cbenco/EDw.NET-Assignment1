using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class test : System.Web.UI.Page
    {
        private User _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (User)Session["currentUser"];
        }
    }
}