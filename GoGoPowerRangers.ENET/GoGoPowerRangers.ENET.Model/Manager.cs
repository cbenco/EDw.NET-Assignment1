using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : EngineerOrManager
    {
        const int STANDARD_MAXMANHOURS = 6;
        const int STANDARD_MAXMATCOST = 100;

        public Manager(User user) : base(user) { }

        public Manager(string userName, string password, string name, District district) : base(userName, password, name, district, Type.Manager)
        {
            MaxManHours = STANDARD_MAXMANHOURS;
            MaxMaterialCost = STANDARD_MAXMATCOST;
        }
        /// <summary>
        /// Returns a list of interventions which the Manager can approve.
        /// </summary>
        /// <returns></returns>
        public List<Intervention> GetPendingInterventions()
        {
            InterventionTableAdapter interventionTable = new InterventionTableAdapter();
            var dbInterventions = interventionTable.GetInterventionsByStatus("Pending");

            List<Intervention> interventions = new List<Intervention>();
            foreach (var dbInt in dbInterventions)
            {
                var intervention = base.ConvertDbInterventionToIntervention(dbInt);
                if (intervention.Approvable(this))
                    interventions.Add(intervention);
            }
            //var interventionQuery = interventions.Where(i => i.Approvable(this));

            //foreach (Intervention i in interventionQuery)
            //    interventions.Add(i);


            return interventions;
        }
        public Intervention GetInterventionById(int id)
        {
            //TODO
            return new Intervention();
        }
        public void ChangeInterventionState(Intervention intervention, Status status)
        {
            InterventionTableAdapter interventionTable = new InterventionTableAdapter();
            intervention.Status = status;
            string dbStatus;
            int? approver = null;
            switch (status)
            {
                case Status.Pending:
                    dbStatus = "Pending";
                    break;
                case Status.Approved:
                    dbStatus = "Approved";
                    approver = this.Id;
                    break;
                case Status.Cancelled:
                    dbStatus = "Cancelled";
                    break;
                case Status.Complete:
                    dbStatus = "Complete";
                    break;
                default:
                    dbStatus = "Cancelled";
                    break;
            }

            interventionTable.UpdateDbInterventionStatus(approver, dbStatus, intervention.Id, intervention.Id);

        }

        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}