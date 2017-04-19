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
        protected void Page_Load(object sender, EventArgs e)
        {
            FakeDatabase db = new FakeDatabase();
            //_interventions = db._interventions.Where(i => i.Requester.Name == _currentUser.Name);
        }
    }
}