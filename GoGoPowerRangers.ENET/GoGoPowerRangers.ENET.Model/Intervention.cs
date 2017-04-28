using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Intervention
    {
        private int _id;
        static int current = 0;
        public Intervention()
        {
            Status = Status.Pending;
            RemainingLife = 100;
            LastVisited = DateTime.Now;
        }
        public Intervention(InterventionType type, Client client, User requester, int remainingLife)
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
        
        public Intervention(InterventionType type, double manHours, double materialCost, Client client, User requester, int remainingLife)
            : this(type, client, requester, remainingLife)
        {
            ManHours = manHours;
            MaterialCost = materialCost;
        }

        public InterventionType InterventionType { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }
        public Client Client { get; set; }
        public User Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public Status Status { get; set; }
        public User Approver { get; set; }
        public int RemainingLife { get; set; }
        public DateTime LastVisited { get; set; }
        public string Notes { get; set; }
        //Sets a unique ID - should be removed once ADO is working
        public int Id
        {
            get { return _id; }
            set { _id = current++; }
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
            return InterventionType.Name + " for " + Client.Name + ", proposed by " + Requester.Name;
        }
    }
}