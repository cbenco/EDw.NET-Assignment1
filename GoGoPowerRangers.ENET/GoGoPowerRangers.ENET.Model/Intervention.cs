using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Intervention
    {
        
        public Intervention()
        {
            Id = new int();
            Status = Status.Pending;
            RemainingLife = 100;
            LastVisited = DateTime.Now;
        }
        public Intervention(InterventionType type, Client client, SiteEngineer requester, int remainingLife)
        {
            InterventionType = type;
            ManHours = type.ManHours;
            MaterialCost = type.MaterialCost;

            Client = client;
            Requester = requester;
            RemainingLife = remainingLife;

            RequestDate = DateTime.Now;
            LastVisited = DateTime.Now;

            Status = Status.Pending;
            Id = new int();
        }
        
        public Intervention(InterventionType type, double manHours, double materialCost, Client client, SiteEngineer requester, int remainingLife)
            : this(type, client, requester, remainingLife)
        {
            ManHours = manHours;
            MaterialCost = materialCost;
        }

        public void SaveChanges()
        {
            InterventionTableAdapter interventionTable = new InterventionTableAdapter();
            string status;
            switch (Status)
            {
                case Status.Pending:
                    status = "Pending";
                    break;
                case Status.Approved:
                    status = "Approved";
                    break;
                case Status.Cancelled:
                    status = "Cancelled";
                    break;
                case Status.Complete:
                    status = "Complete";
                    break;
                default:
                    status = "ancelled";
                    break;
            }
            int? approverId;
            if (Approver == null)
                approverId = null;
            else
                approverId = Approver.Id;
            interventionTable.UpdateInterventionById(InterventionType.Id, Client.Id, (decimal)ManHours, (decimal)MaterialCost, Requester.Id, RequestDate.ToShortDateString(), status, approverId, RemainingLife, LastVisited.ToShortDateString(), Notes, Id, Id);
        }
        public InterventionType InterventionType { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }
        public Client Client { get; set; }
        public SiteEngineer Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public Status Status { get; set; }
        public User Approver { get; set; }
        public int RemainingLife { get; set; }
        public DateTime LastVisited { get; set; }
        public string Notes { get; set; }
        //Sets a unique ID - should be removed once ADO is working
        public int Id
        {
            get; set;
        }
        public string RequestDateString {
            get { return RequestDate.ToShortDateString(); }
            set { }
        }
        public string LastVisitedString
        {
            get { return LastVisited.ToShortDateString(); }
            set { }
        }
        public void UpdateInformation(string notes, DateTime lastVisited, int remLife)
        {
            Notes = notes;
            LastVisited = lastVisited;
            RemainingLife = remLife;
        }
        private bool Modifiable(SiteEngineer modifier)
        {
            return (modifier.District == Client.District);
        }
        /// <summary>
        /// Tests to see if the user can approve this intervention according to the business rules.
        /// </summary>
        /// <param name="approver">The user wishing to approve the intervention</param>
        /// <returns></returns>
        public bool Approvable(EngineerOrManager approver)
        {
            if (approver.MaxManHours >= ManHours &&
                approver.MaxMaterialCost >= MaterialCost &&
                approver.MaxManHours >= InterventionType.ManHours &&
                approver.MaxMaterialCost >= InterventionType.MaterialCost &&
                Status == Status.Pending)
                {
                    if (approver.GetType() == typeof(SiteEngineer))
                        return approver == Requester;
                    else if (approver.GetType() == typeof(Manager))
                        return approver.District == Client.District;
                }
            return false;
        }
        //omg
        /// <summary>
        /// Returns the current object - required for some front-end hack.
        /// </summary>
        /// <returns></returns>
        public Intervention GetThis()
        {
            return this;
        }
        public override string ToString()
        {
            return InterventionType.Name + " for " + Client.Name + ", proposed by " + Requester.FirstName + " " + Requester.LastName;
        }
    }
}