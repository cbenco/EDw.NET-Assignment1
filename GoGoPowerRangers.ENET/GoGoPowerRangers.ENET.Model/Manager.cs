using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : User
    {
        public Manager(User user) : base(user)
        {
            //delete later
            District = new District();
            for (int i = 0; i < 12; i++)
            {
                Intervention intervention = new Intervention();
                switch (i % 4)
                {
                    case 0:
                        intervention.Status = Status.Approved;
                        break;
                    case 1:
                        intervention.Status = Status.Pending;
                        break;
                    case 2:
                        intervention.Status = Status.Complete;
                        break;
                    case 3:
                        intervention.Status = Status.Cancelled;
                        break;
                }

                _interventions.Add(intervention);
            }
        }
        public Manager(string userName, string password, string name, District district) : base(userName, password, name, Type.Manager)
        {
            this.District = district;
        }
        public List<Intervention> _interventions = new List<Intervention>();
        
        
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }

        //possibly need to change this to a public property 
        //to bind to datalist in winforms
        public List<Intervention> GetPendingInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            interventions.Where(s => s.Status == Status.Pending);

            return interventions;
        }
        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            throw new NotImplementedException();
            //engineer.District = district;
            engineer.District = district;
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            manager.District = district;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}