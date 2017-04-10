using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : User
    {
        public Manager(User user) : base(user) { }
        public Manager(string userName, string password, string name, int id, District district) : base(userName, password, name, id, Type.Manager)
        {
            this.District = district;
        }
        public District District { get; set; }

        public List<Intervention> GetProposedInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            //replace above with 
            //var Intervention = linq query
            return interventions;
        }
        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            throw new NotImplementedException();
            //engineer.District = district;
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            //manager.District = district;
        }
    }
}