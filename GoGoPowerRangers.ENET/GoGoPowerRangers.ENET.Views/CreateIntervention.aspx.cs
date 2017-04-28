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
        public bool showApproveComplete;

        int client, type;
        double mHours, mCost;
        string notes;
        DateTime time;

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (SiteEngineer)Session["currentUser"];

            if (!IsPostBack)
            {
                showApproveComplete = false;
                SetDropDowns(types, FakeDatabase._interventionTypes);
                SetDropDowns(clients, _user.ListClientsInDistrict());
                SetTimeAndCost();
            }
        }

        protected void types_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTimeAndCost();
            showApproveComplete = false;
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

        private void Create(Status status)
        {
            Intervention i = _user.CreateIntervention(type, mHours, mCost, client, time, notes, status);
            if (status == Status.Approved || status == Status.Complete)
                i.Approver = _user;
            Response.Redirect("Engineer.aspx", true);
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            GetValues();
            
            //check input

            if (!(_user.MaxManHours >= mHours && _user.MaxMaterialCost >= mCost))
            {
                Create(Status.Pending);
            }
            else
                showApproveComplete = true;
        }
        protected void buttonApprove_Click(object sender, EventArgs e)
        {
            GetValues();
            Create(Status.Approved);
        }
        protected void buttonComplete_Click(object sender, EventArgs e)
        {
            GetValues();
            Create(Status.Complete);
        }
        private void GetValues()
        {
            int.TryParse(types.SelectedValue, out type);
            int.TryParse(clients.SelectedValue, out client);
            double.TryParse(materialCost.Text, out mCost);
            double.TryParse(manHours.Text, out mHours);
            time = calendar.SelectedDate;
            notes = noteBox.Text.ToString();
        }
    }
}