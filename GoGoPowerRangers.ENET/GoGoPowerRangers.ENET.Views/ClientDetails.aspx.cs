using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        private Client _client;
        private EngineerOrManager _user;
        public GridView interventionGrid;

        protected void Page_Load(object sender, EventArgs e)
        {
            _client = (Client)Session["selectedClient"];
            _user = (EngineerOrManager)Session["currentUser"];
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
                //var intervention = (Intervention)FakeDatabase._interventions.FirstOrDefault(i => i.Id == id);
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var dbIntervention = interventionTable.GetInterventionById(id).FirstOrDefault();
                if (dbIntervention != null)
                {
                    Session.Add("selectedIntervention", _user.ConvertDbInterventionToIntervention(dbIntervention));
                    Response.Redirect("InterventionDetails.aspx");
                }
            }
        }
    }
}