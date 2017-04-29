using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        private Client _client;
        public GridView interventionGrid;

        protected void Page_Load(object sender, EventArgs e)
        {
            _client = (Client)Session["selectedClient"];

            labelClientName.Text = _client.Name;
            labelClientLocation.Text = _client.Location + ", " + _client.District.Name;

            interventionGrid.DataSource = _client.GetInterventions();
            interventionGrid.DataBind();

			interventionGrid.UseAccessibleHeader = true;

            //causing nul ref when a new client is selected
			interventionGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
		}

        protected void interventionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "viewInterventionClick")
            {
                var intervention = (Intervention)FakeDatabase._interventions.FirstOrDefault(i => i.Id == id);
                Session.Add("selectedIntervention", intervention);
                Response.Redirect("InterventionDetails.aspx");
            }
        }
    }
}