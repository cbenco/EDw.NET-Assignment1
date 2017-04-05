using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager
    {
        public List<Intervention> GetProposedInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            //replace above with 
            //var Intervention = linq query
            return interventions;
        }
        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            //engineer.District = district;
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            //manager.District = district;
        }


    }
}