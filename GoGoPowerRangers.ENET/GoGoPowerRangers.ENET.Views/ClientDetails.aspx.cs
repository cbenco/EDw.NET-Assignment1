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
        }
    }
}