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
        List<District> _districts = new List<District>();
        public List<User> _users = new List<User>();
        List<Intervention> _interventions = new List<Intervention>();

        public FakeDatabase()
        {
            PopulateDistricts();
            PopulateEngineers();
            PopulateManagers();
            PopulateAccountants();
            //PopulateInterventions();

            PrintDb();
        }

        private void PopulateDistricts()
        {
            _districts.Add(new District("Urban Indonesia"));
            _districts.Add(new District("Rural Indonesia"));
            _districts.Add(new District("Urban PNG"));
            _districts.Add(new District("Rural PNG"));
            _districts.Add(new District("Sydney"));
            _districts.Add(new District("Rural NSW"));
        }

        private void PopulateEngineers()
        {
            string[] names = { "Chris Benco", "Luke Single", "John Nguyen", "Lyndal Walker",
                               "Richard Banks", "William Leak", "Michael Muller", "Jason King",
                               "Stuart Stevens", "Matt Wood", "Andrew Manny", "Sarah Najjar" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new SiteEngineer((1000 + i).ToString(), "password", names[i], _districts[i % 6]));
            }
        }
        private void PopulateManagers()
        {
            string[] names = { "Jamie Lannister", "Tyrion Lannister", "Cersei Lannister", "Tywin Lannister",
                               "Robb Stark", "Arya Stark", "Eddard Stark", "Brandon Stark",
                               "Joffrey Baratheon", "Stannis Baratheon", "Tommen Baratheon", "Robert Baratheon" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new Manager((2000+i).ToString(), "password", names[i], _districts[i%6]));
            }
        }
        private void PopulateAccountants()
        {
            string[] names = { "Gabriel Landeskog", "Nathan Mackinnon", "Matt Duchene", "Tyson Jost",
                               "Tyson Barrie", "Erik Johnson", "Nate Guenin", "Francois Beauchemin",
                               "Patrick Roy", "Semyon Varlamov", "Calvin Pickard", "Jose Theodore" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new Accountant((2000 + i).ToString(), "password", names[i]));
            }
        }

        private void PopulateInterventions()
        {

        }

        private void PrintDb()
        {
            Console.WriteLine("DISTRICTS: ");
            for (int i = 0; i < _districts.Count; i++)
            {
                Console.WriteLine(_districts[i].Name);
            }
            Console.WriteLine("USERS: ");
            for (int i = 0; i < _users.Count; i++)
            {
                Console.WriteLine(_users[i].ToString());
            }
        }
    }
}