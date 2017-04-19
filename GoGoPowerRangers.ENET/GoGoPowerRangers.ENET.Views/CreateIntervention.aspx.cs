using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class CreateIntervention : System.Web.UI.Page
    {
        SiteEngineer _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //_user = (SiteEngineer)Session["currentUser"];
                //FakeDatabase fakeDb = new FakeDatabase();

                _user = (SiteEngineer)FakeDatabase._users[0];
                types.DataSource = FakeDatabase._interventionTypes;
                types.DataTextField = "Name";
                types.DataValueField = "Id";
                types.DataBind();

                clients.DataSource = _user.ListClientsInDistrict();
                clients.DataTextField = "Name";
                clients.DataValueField = "Id";
                clients.DataBind();

                manHours.Text = FakeDatabase._interventionTypes[types.SelectedIndex].ManHours.ToString();
                materialCost.Text = FakeDatabase._interventionTypes[types.SelectedIndex].MaterialCost.ToString();
            }
        }

        protected void types_SelectedIndexChanged(object sender, EventArgs e)
        {
            manHours.Text = "Changed";
            UpdateTextBoxes.Update();
        }
    }
}