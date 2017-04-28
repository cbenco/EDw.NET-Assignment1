using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoGoPowerRangers.ENET.Model;
namespace GoGoPowerRangers.ENET.Views
{
    public partial class InterventionDetails : System.Web.UI.Page
    {
        public SiteEngineer _user;
        public Intervention _intervention;

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (SiteEngineer)Session["currentUser"];
            _intervention = (Intervention)Session["selectedIntervention"];
            
            if (!IsPostBack)
            {
                labelType.Text = _intervention.InterventionType.Name;
                labelClient.Text = _intervention.Client.Name + ", " + _intervention.Client.Location;
                labelManHours.Text = _intervention.ManHours.ToString() + " hours";
                labelMatCost.Text = "$" + _intervention.MaterialCost.ToString();
                labelRequester.Text = _intervention.Requester.Name;
                labelDate.Text = _intervention.RequestDate.Date.ToString();
                labelStatus.Text = _intervention.Status.ToString();

                if (_intervention.Status == Status.Approved)
                    labelApprover.Text = _intervention.Approver.Name;
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

            labelChangesSaved.Text = "Changes saved!";
        }

        protected void buttonGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Engineer.aspx");
        }

        protected void buttonApprove_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Approved;
        }

        protected void buttonComplete_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Complete;
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            _intervention.Status = Status.Cancelled;
        }
    }
}