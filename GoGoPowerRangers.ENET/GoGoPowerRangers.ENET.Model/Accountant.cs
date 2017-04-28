using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Accountant : User
    {
        public Accountant(User user) : base(user) { }
        public Accountant(string userName, string password, string name) : base(userName, password, name, Type.Accountant) { }

        public List<SiteEngineer> GetAllSiteEngineers()
        {
            return new List<SiteEngineer>();
        }
        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            engineer.District = district;
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            manager.District = district;
        }
    }
}