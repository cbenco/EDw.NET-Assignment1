using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
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
        //only changing this in database, so only need userID
        public void ChangeUserDistrict(User user, int districtId)
        {
            UserTypeTableAdapter userTypeTable = new UserTypeTableAdapter();
            userTypeTable.UpdateUserDistrictId(districtId, user.Id, user.Id);
        }
    }
}