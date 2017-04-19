using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class Engineer : System.Web.UI.Page
    {
        private List<Intervention> _interventions;
        private User _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (User)Session["currentUser"];
            FakeDatabase db = new FakeDatabase();
            labelFirstName.Text = _user.Name;
            //_interventions = db._interventions.Where(i => i.Requester.Name == _currentUser.Name);
        }
    }
}