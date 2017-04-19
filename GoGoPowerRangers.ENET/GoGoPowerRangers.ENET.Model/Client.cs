using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class Client
    {
        private int _id;
        private static int current = 0;
        public Client() { }
        public Client(string name, string location, District district)
        {
            Name = name;
            Location = location;
            District = district;
        }
        
        public string Name { get; set; }
        public string Location { get; set; }
        public District District { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = current++; }
        }

        public List<Intervention> GetInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            var clients = from i in FakeDatabase._interventions
                          where i.Client == this
                          select i;
            foreach (Intervention i in interventions)
                interventions.Add(i);

            return interventions;
        }

        public override string ToString()
        {
            return Name + ", " + Location + ", " + District;
        }
    }
}