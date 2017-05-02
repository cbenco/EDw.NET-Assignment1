using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class InterventionDetails : System.Web.UI.Page
    {
        //public SiteEngineer _user;
        public EngineerOrManager _user;
        public Intervention _intervention;
        private InterventionTableAdapter interventionTable = new InterventionTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (EngineerOrManager)Session["currentUser"];
                _intervention = (Intervention)Session["selectedIntervention"];
                if (_user == null || _intervention == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }


            if (!IsPostBack)
            {
                labelType.Text = _intervention.InterventionType.Name;
                labelClient.Text = _intervention.Client.Name + ", " + _intervention.Client.Location;
                labelManHours.Text = _intervention.ManHours.ToString() + " hours";
                labelMatCost.Text = "$" + _intervention.MaterialCost.ToString();
                labelRequester.Text = _intervention.Requester.FirstName;
                labelDate.Text = _intervention.RequestDate.Date.ToString();
                labelStatus.Text = _intervention.Status.ToString();

                if (_intervention.Status == Status.Approved)
                    labelApprover.Text = _intervention.Approver.FirstName;
                else
                    labelApprover.Text = "N/A";

                noteBox.Text = _intervention.Notes;

                DateTime lastVisit = _intervention.LastVisited;
                calendarLastVisited.TodaysDate = lastVisit;
                calendarLastVisited.SelectedDate = calendarLastVisited.TodaysDate;

                remainingLifeBox.Text = _intervention.RemainingLife.ToString();
            }
        }

        protected void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            //check inputs

            _intervention.Notes = noteBox.Text;
            _intervention.LastVisited = calendarLastVisited.SelectedDate;
            _intervention.RemainingLife = int.Parse(remainingLifeBox.Text);
            _intervention.SaveChanges();
            labelChangesSaved.Text = "Changes saved!";
        }

        protected void buttonGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Engineer.aspx");
        }

        protected void buttonApprove_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Approved;
            _intervention.Approver = _user;
            interventionTable.UpdateDbInterventionStatus(_user.Id, "Approved", _intervention.Id, _intervention.Id);
        }

        protected void buttonComplete_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Complete;
            _intervention.Approver = _user;
            interventionTable.UpdateDbInterventionStatus(_user.Id, "Complete", _intervention.Id, _intervention.Id);
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Cancelled;
            _intervention.Approver = _user;
            interventionTable.UpdateDbInterventionStatus(_user.Id, "Cancelled", _intervention.Id, _intervention.Id);
        }
    }
}