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

        protected void btnNewIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx", true);
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }

        protected void newClientButton_Click(object sender, EventArgs e)
        {
            string name = newClientName.Text.ToString();
            string location = newClientLocation.Text.ToString();
            //check inputs

            _user.CreateClient(name, location);

            BindClients();
            newClientName.Text = "";
            newClientLocation.Text = "";
            UpdateClients.Update();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (SiteEngineer)Session["currentUser"];
            if (!IsPostBack)
            {
                labelFirstName.Text = _user.Name;
                labelDistrictName.Text = "<h2>Clients in " + _user.District.Name + "</h2>";
                labelInterventionsHeader.Text = "<h2>Interventions created by " + _user.Name + "</h2";

                BindClients();

                interventionGrid.DataSource = _user.GetInterventions();
                interventionGrid.DataBind();
            }

            //_interventions = db._interventions.Where(i => i.Requester.Name == _currentUser.Name);
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword", true);
        }

        private void BindClients()
        {
            clientGrid.DataSource = _user.ListClientsInDistrict();
            clientGrid.DataBind();
        }

        protected void clientGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "clientNameClick")
            {
                var client = (Client)FakeDatabase._clients.FirstOrDefault(c => c.Id == id);
                Session.Add("selectedClient", client);
                Response.Redirect("ClientDetails.aspx");
            }
            else if (e.CommandName == "viewInterventionClick")
            {
                var intervention = (Intervention)FakeDatabase._interventions.FirstOrDefault(i => i.Id == id);
                Session.Add("selectedIntervention", intervention);
                Response.Redirect("InterventionDetails.aspx");
            }
        }
    }
}
