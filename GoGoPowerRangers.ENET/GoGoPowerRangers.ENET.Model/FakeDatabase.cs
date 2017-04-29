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
        public static List<District> _districts;
        public static List<User> _users;
        public static List<Client> _clients;
        public static List<InterventionType> _interventionTypes;
        public static List<Intervention> _interventions;

        public static void CreateDatabase()
        {
            _districts = new List<District>();
            _users = new List<User>();
            _clients = new List<Client>();
            _interventionTypes = new List<InterventionType>();
            _interventions = new List<Intervention>();

            PopulateDistricts();
            PopulateClients();
            PopulateEngineers();
            PopulateManagers();
            PopulateAccountants();
            PopulateInterventionTypes();
            PopulateInterventions();
            //PopulateCompleteInterventions();

            //PrintDb();
            //DisplayCostReport();
            //DisplayHoursReport();
            //DisplayDistrictCostReport();
        }
        private static void PopulateDistricts()
        {
            _districts.Add(new District("Urban Indonesia"));
            _districts.Add(new District("Rural Indonesia"));
            _districts.Add(new District("Urban PNG"));
            _districts.Add(new District("Rural PNG"));
            _districts.Add(new District("Sydney"));
            _districts.Add(new District("Rural NSW"));
        }
        private static void PopulateEngineers()
        {
            string[] names = { "Chris Benco", "Luke Single", "John Nguyen", "Lyndal Walker",
                               "Richard Banks", "William Leak", "Michael Muller", "Jason King",
                               "Stuart Stevens", "Matt Wood", "Andrew Manny", "Sarah Najjar" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new SiteEngineer((1000 + i).ToString(), "password", names[i], _districts[i % 6]));
            }
        }
        private static void PopulateManagers()
        {
            string[] names = { "Jamie Lannister", "Tyrion Lannister", "Cersei Lannister", "Tywin Lannister",
                               "Robb Stark", "Arya Stark", "Eddard Stark", "Brandon Stark",
                               "Joffrey Baratheon", "Stannis Baratheon", "Tommen Baratheon", "Robert Baratheon" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new Manager((2000+i).ToString(), "password", names[i], _districts[i % 6]));
            }
        }
        private static void PopulateAccountants()
        {
            string[] names = { "Gabriel Landeskog", "Nathan Mackinnon", "Matt Duchene", "Tyson Jost",
                               "Tyson Barrie", "Erik Johnson", "Nate Guenin", "Francois Beauchemin",
                               "Patrick Roy", "Semyon Varlamov", "Calvin Pickard", "Jose Theodore" };
            for (int i = 0; i < names.Length; i++)
            {
                _users.Add(new Accountant((3000 + i).ToString(), "password", names[i]));
            }
        }
        private static void PopulateClients()
        {
            string[] names = { "Alan", "Steve", "Tim", "Tom", "Sam", "Harry",
                               "Bree", "Matlida", "Helga", "Olga", "Hannah", "Emily" };
            string[] locations = { "Up the street", "Round the hill", "Down the pub", "Under the bridge", "Inside", "Outside",
                                   "Underground", "On top of the mountain", "A long way away", "Prefer not to say", "27", "PO Box 2998" };
            for (int i = 0; i < names.Length; i++)
            {
                _clients.Add(new Client(names[i], locations[i], _districts[i % 6]));
            }
        }
        private static void PopulateInterventionTypes()
        {
            _interventionTypes.Add(new InterventionType("Supply Mosquito Net", 0.5, 25.0));
            _interventionTypes.Add(new InterventionType("Supply and Install Portable Toilet", 3.0, 211.0));
            _interventionTypes.Add(new InterventionType("Hepatitis Avoidance Training", 2.5, 38.19));
            _interventionTypes.Add(new InterventionType("Supply and Install Storm-proof Home Kit", 8.0, 279.0));
            _interventionTypes.Add(new InterventionType("Dig Waste Trench", 3.0, 16.0));
            _interventionTypes.Add(new InterventionType("Provide Short Santiation Training Course", 6.0, 45.0));
        }
        private static void PopulateInterventions()
        {
            foreach (SiteEngineer e in _users.Where(u => u is SiteEngineer))
                foreach (InterventionType i in _interventionTypes)
                    foreach (Client c in _clients.Where(c => c.District == e.District))
                        _interventions.Add(new Intervention(i, c, e, 100));
        }
        private static void PrintDb()
        {
            Console.WriteLine("DISTRICTS: ");
            for (int i = 0; i < _districts.Count; i++)
            {
                Console.WriteLine(_districts[i].Name);
            }
            Console.WriteLine();
            Console.WriteLine("USERS: ");
            for (int i = 0; i < _users.Count; i++)
            {
                Console.WriteLine(_users[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine("CLIENTS: ");
            for (int i = 0; i < _clients.Count; i++)
            {
                Console.WriteLine(_clients[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine("INTERVENTIONS: ");
            for (int i = 0; i < _interventions.Count; i++)
            {
                Console.WriteLine(_interventions[i].ToString());
            }
        }

        private static void PopulateCompleteInterventions()
        {
            foreach (SiteEngineer e in _users.Where(u => u is SiteEngineer))
                foreach (Manager m in _users.Where(u => u is Manager))
                    foreach (InterventionType i in _interventionTypes)
                        foreach (Client c in _clients.Where(c => c.District == e.District && c.District == m.District))
                        {
                            Intervention intervention = new Intervention(i, c, e, 0);
                            intervention.Status = Status.Complete;
                            intervention.Approver = m;
                            _interventions.Add(intervention);
                        }
        }

        private static void DisplayCostReport()
        {
            Console.WriteLine("Site Engineer Total Cost Report");
            Console.WriteLine();

            var matCost =
                from i in _interventions
                where i.Status == Status.Complete
                group i.MaterialCost by i.Requester.FirstName into requesterGroup
                select requesterGroup;

            foreach (var engineer in matCost)
                Console.WriteLine("{0} : ${1}", engineer.Key, engineer.Sum());

            Console.WriteLine();
        }

        private static void DisplayHoursReport()
        {
            Console.WriteLine("Site Engineer Average Hours Report");
            Console.WriteLine();

            var hours =
                from i in _interventions
                where i.Status == Status.Complete
                group i.ManHours by i.Requester.FirstName into requesterGroup
                select requesterGroup;

            foreach (var engineer in hours)
                Console.WriteLine("{0} : {1}hrs", engineer.Key, Math.Round(engineer.Average(), 2));

            Console.WriteLine();
        }

        private static void DisplayDistrictCostReport()
        {
            Console.WriteLine("District Costs Report");
            Console.WriteLine();

            var districtCost =
                from i in _interventions
                where i.Status == Status.Complete
                group i.MaterialCost by i.Client.District.Name into costGroup
                select costGroup;

            var districtHours =
                from i in _interventions
                where i.Status == Status.Complete
                group i.ManHours by i.Client.District.Name into hoursGroup
                select hoursGroup;

            foreach (var district in districtCost)
            {
                Console.Write("{0} : ${1}", district.Key, district.Sum());
                foreach (var district2 in districtHours)
                    if (district.Key == district2.Key)
                        Console.WriteLine(" across {0} hrs", district2.Sum());
            }

            var totalCost =
                from i in _interventions
                where i.Status == Status.Complete
                select i.MaterialCost;

            var totalHours =
                from i in _interventions
                where i.Status == Status.Complete
                select i.ManHours;

            Console.WriteLine("Grand Total : ${0} across {1} hrs", totalCost.Sum(), totalHours.Sum());
            Console.WriteLine();
        }

        private static void DisplayDistrictCostReportPerMonth()
        {
            Console.WriteLine("District Costs Report");
            Console.WriteLine();

            var districtCost =
                from i in _interventions
                where i.Status == Status.Complete
                group i.MaterialCost by i.Client.District.Name into costGroup
                select costGroup;

            var districtHours =
                from i in _interventions
                where i.Status == Status.Complete
                group i.ManHours by i.Client.District.Name into hoursGroup
                select hoursGroup;

            foreach (var district in districtCost)
            {
                Console.Write("{0} : ${1}", district.Key, district.Sum());
                foreach (var district2 in districtHours)
                    if (district.Key == district2.Key)
                        Console.WriteLine(" across {0} hrs", district2.Sum());
            }

            var totalCost =
                from i in _interventions
                where i.Status == Status.Complete
                select i.MaterialCost;

            var totalHours =
                from i in _interventions
                where i.Status == Status.Complete
                select i.ManHours;

            Console.WriteLine("Grand Total : ${0} across {1} hrs", totalCost.Sum(), totalHours.Sum());
            Console.WriteLine();
        }
    }
}