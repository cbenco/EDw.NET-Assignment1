using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

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
        Intervention _newIntervention;
        InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
        InterventionTableAdapter interventionTable = new InterventionTableAdapter();
        ClientTableAdapter clientTable = new ClientTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (SiteEngineer)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                showApproveComplete = false;
                SetDropDowns(types, iTypeTable.GetInterventionTypes());
                SetDropDowns(clients, clientTable.GetClientsByDistrictId(_user.District.Id));
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
            //InterventionType selectedType = FakeDatabase._interventionTypes[types.SelectedIndex];
            int selectedId;
            
            var selected = types.SelectedValue;
            int.TryParse(selected, out selectedId);
            var dbSelectedType = iTypeTable.GetInterventionTypeById(selectedId).FirstOrDefault();
            InterventionType selectedType;
            if (dbSelectedType == null)
                dbSelectedType = iTypeTable.GetInterventionTypes().FirstOrDefault();

            selectedType = _user.ConvertDbInterventionTypeToInterventionType(dbSelectedType);
            manHours.Text = selectedType.ManHours.ToString();
            materialCost.Text = selectedType.MaterialCost.ToString();
        }
        private void SetDropDowns(DropDownList ddl, Object dataSource)
        {
            System.Type t = dataSource.GetType();
            ddl.DataSource = dataSource;
            ddl.DataTextField = "Name";
            if (t.Equals(typeof(Data.ENET.ClientDataTable)))
                ddl.DataValueField = "ClientID";
            
            else if (t.Equals(typeof(Data.ENET.InterventionTypeDataTable)))
                ddl.DataValueField = "TypeID";

            ddl.DataBind();
        }

        private void Create(String status)
        {
            string currentDate = DateTime.Now.ToShortDateString();
            int? approver;
            //Intervention i = _user.CreateIntervention(type, mHours, mCost, client, time, notes, status);
            if (status == "Approved" || status == "Complete")
                approver = _user.Id;
            else
                approver = null;

            interventionTable.AddIntervention(type, client, (decimal)mHours, (decimal)mCost, _user.Id, currentDate, status, approver, 100, currentDate, notes);
            
            Response.Redirect("Engineer.aspx", true);
        }

        protected void buttonCreate_Click(object sender, EventArgs e)
        {
            GetValues();
            //check input

            if ((_user.MaxManHours >= mHours && _user.MaxMaterialCost >= mCost)) //If both the user's max material cost and manhours are high enough to approve
                showApproveComplete = true;
            else
                Create("Pending");
        }
        protected void buttonApprove_Click(object sender, EventArgs e)
        {
            GetValues();
            Create("Approved");
        }

        protected void buttonConfirmPending_Click(object sender, EventArgs e)
        {
            GetValues();
            Create("Pending");
        }

        protected void buttonComplete_Click(object sender, EventArgs e)
        {
            GetValues();
            Create("Complete");
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