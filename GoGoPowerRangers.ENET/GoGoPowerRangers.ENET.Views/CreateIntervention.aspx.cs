using System;
using System.Data;
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
            _user = (SiteEngineer)Session["currentUser"];

            if (!IsPostBack)
            {
                SetDropDowns(types, FakeDatabase._interventionTypes);
                SetDropDowns(clients, _user.ListClientsInDistrict());
                SetTimeAndCost();
            }
        }

        protected void types_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTimeAndCost();
            UpdateTextBoxes.Update();
        }

        private void SetTimeAndCost()
        {
            InterventionType selectedType = FakeDatabase._interventionTypes[types.SelectedIndex];
            manHours.Text = selectedType.ManHours.ToString();
            materialCost.Text = selectedType.MaterialCost.ToString();
        }
        private void SetDropDowns(DropDownList ddl, Object dataSource)
        {
            ddl.DataSource = dataSource;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Id";
            ddl.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int client, requester, type;
            double mHours, mCost;
            requester = _user.Id;
            DateTime time = calendar.SelectedDate;

            int.TryParse(types.SelectedValue, out type);
            int.TryParse(clients.SelectedValue, out client);
            double.TryParse(materialCost.Text, out mCost);
            double.TryParse(manHours.Text, out mHours);

            string notes = noteBox.Text.ToString();

            //check input

            _user.CreateIntervention(type, mHours, mCost, client, time, notes);

            Response.Redirect("Engineer.aspx", true);
        }
    }
}