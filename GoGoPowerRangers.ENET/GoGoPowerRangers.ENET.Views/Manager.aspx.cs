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
    public partial class manager : System.Web.UI.Page
    {
        private List<Intervention> _interventions;
        private Model.Manager _user;
        public GridView clientGrid, interventionGrid;

        protected void btnNewIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx", true);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }
		protected void newClientButton_Click(object sender, EventArgs e)
        {
            string name = newClientName.Text.ToString();
            string location = newClientLocation.Text.ToString();

            _user.CreateClient(name, location);

            BindClients();
            newClientName.Text = "";
            newClientLocation.Text = "";
            UpdateClients.Update();
        }
		
        protected void Page_Load(object sender, EventArgs e)
        {
			_user = (Model.Manager)Session["currentUser"];
			if (!IsPostBack)
            {
                labelFirstName.Text = _user.Name;
                labelDistrictName.Text = "<h2>Clients in " + _user.District.Name + "</h2>";
                labelInterventionsHeader.Text = "<h2>Interventions for " + _user.Name + "</h2";

                BindClients();

                interventionGrid.DataSource = _user.GetInterventions();
                interventionGrid.DataBind();
            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", true);
        }
		
		private void BindClients()
        {
			clientGrid.DataSource = _user.ListClientsInDistrict();
            clientGrid.DataBind();

        }
		
		protected void clientGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "clientNameClick")
            {
                int Id = int.Parse(e.CommandArgument.ToString());
                var client = (Client)FakeDatabase._clients.FirstOrDefault(c => c.Id == Id);
                Session.Add("selectedClient", client);
                Response.Redirect("ClientDetails.aspx");
            }
        }
    }
}