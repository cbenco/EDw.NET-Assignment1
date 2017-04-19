using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Intervention
    {
        private int _id;
        public Intervention()
        {

        }
        public Intervention(InterventionType type, Client client, User requester, int remainingLife)
        {
            InterventionType = type;
            ManHours = type.ManHours;
            MaterialCost = type.MaterialCost;

            Client = client;
            Requester = requester;
            RemainingLife = remainingLife;

            RequestDate = DateTime.Now.Date;
            LastVisited = DateTime.Now.Date;

            Status = Status.Pending;
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

        private bool CanBeApprovedByEngineer(SiteEngineer approver)
        {
            if ((approver == Requester) &&
                  approver.MaxManHours >= ManHours &&
                  approver.MaxMaterialCost >= MaterialCost &&
                  approver.MaxManHours >= InterventionType.ManHours &&
                  approver.MaxMaterialCost >= InterventionType.MaterialCost)
                return true;
            else return false;
        }
        private bool CanBeApprovedByManager(Manager approver)
        {
            return ((approver.District == Client.District) &&
                  approver.MaxManHours >= ManHours &&
                  approver.MaxMaterialCost >= MaterialCost &&
                  approver.MaxManHours >= InterventionType.ManHours &&
                  approver.MaxMaterialCost >= InterventionType.MaterialCost);
        }

        public override string ToString()
        {
            return InterventionType.Name + " for " + Client.Name + ", proposed by " + Requester.Name;
        }
    }
}