using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : EngineerOrManager
    {
        const int STANDARD_MAXMANHOURS = 6;
        const int STANDARD_MAXMATCOST = 100;

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
            List<Intervention> interventions = new List<Intervention>();
            var interventionQuery = FakeDatabase._interventions.Where(i => i.Approvable(this));
            foreach (Intervention i in interventionQuery)
                interventions.Add(i);

            return interventions;
        }
        public Intervention GetInterventionById(int id)
        {
            //TODO
            return new Intervention();
        }
        public void ChangeInterventionState(Intervention intervention, Status status)
        {
            intervention.Status = status;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}