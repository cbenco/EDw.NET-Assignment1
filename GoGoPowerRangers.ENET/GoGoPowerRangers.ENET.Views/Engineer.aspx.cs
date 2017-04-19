using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class Engineer : System.Web.UI.Page
    {
        private List<Intervention> _interventions;
        private SiteEngineer _user;
        public GridView clientGrid, interventionGrid;

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (SiteEngineer)Session["currentUser"];
            FakeDatabase db = new FakeDatabase();
            labelFirstName.Text = _user.Name;

            clientGrid.DataSource = _user.ListClientsInDistrict();
            clientGrid.DataBind();

            interventionGrid.DataSource = _user.GetInterventions();
            interventionGrid.DataBind();

            //_interventions = db._interventions.Where(i => i.Requester.Name == _currentUser.Name);
        }
    }
}