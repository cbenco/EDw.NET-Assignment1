using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoGoPowerRangers.ENET.Model;

namespace GoGoPowerRangers.ENET.Data
{
    public class FakeDatabase
    {
        public List<User> _users = new List<User>();
        List<Intervention> _interventions = new List<Intervention>();

        public FakeDatabase()
        {
            PopulateUsers();
            //PopulateInterventions();
        }

        private void PopulateUsers()
        {
            string[] names = { "Chris Benco", "Luke Single", "John Nguyen", "Lyndal Walker", "Richard Banks", "William Leak", "Michael Muller", "Jason King", "Stuart Stevens" };
            int username = 1000;

            for (int i = 1; i < names.Length + 1; i++)
            {
                _users.Add(new User((username + i).ToString(), "password", names[i - 1], i, PickType(i)));
            }
        }

        private GoGoPowerRangers.ENET.Model.Type PickType(int i)
        {
            if (i % 3 == 0)
                return GoGoPowerRangers.ENET.Model.Type.Accountant;
            else if (i % 3 == 1)
                return GoGoPowerRangers.ENET.Model.Type.Manager;
            else
                return GoGoPowerRangers.ENET.Model.Type.SiteEngineer;
        }
        private void PopulateInterventions()
        {

        }
    }
}
