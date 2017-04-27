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
        private Manager _user;
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
		
        protected void Page_Load(object sender, EventArgs e)
        {
			_user = (Manager)Session["currentUser"];
			if (!IsPostBack)
            {
                labelFirstName.Text = _user.Name;
                labelInterventionsHeader.Text = "<h2>Interventions for " + _user.Name + "</h2";

                interventionGrid.DataSource = _user.GetPendingInterventions();
                interventionGrid.DataBind();
            }
        }
        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", true);
        }		
		protected void interventionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
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