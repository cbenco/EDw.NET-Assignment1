using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        public Client _client;
        protected void Page_Load(object sender, EventArgs e)
        {
            _client = (Client)Session["selectedClient"];

            labelClientName.Text = _client.Name;
            labelClientLocation.Text = _client.Location + ", " + _client.District.Name;
        }
    }
}