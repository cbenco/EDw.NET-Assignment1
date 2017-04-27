using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : User
    {
        public Manager(User user) : base(user)
        {

        }
        public Manager(string userName, string password, string name, District district) : base(userName, password, name, Type.Manager)
        {
            District = district;
            MaxManHours = 30;
            MaxMaterialCost = 1000;
        }
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }
        
        public List<Intervention> GetPendingInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            interventions.Where(s => s.Status == Status.Pending);

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