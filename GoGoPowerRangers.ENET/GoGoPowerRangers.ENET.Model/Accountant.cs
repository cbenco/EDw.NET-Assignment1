using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Accountant :User
    {
        public Accountant(User user) : base(user) { }
        public List<SiteEngineer> GetAllSiteEngineers()
        {
            return new List<SiteEngineer>();
        }
        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            engineer.District = new District();
            engineer.District.Name = district.Name;
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            manager.District = new District();
            manager.District = district;
        }
    }
}