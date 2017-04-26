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
            Id = new int();
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
            List<Intervention> interventionList = new List<Intervention>();
            var interventions = FakeDatabase._interventions.Where(i => i.Client == this);
            foreach (Intervention i in interventions)
                interventionList.Add(i);

            return interventionList;
        }

        public override string ToString()
        {
            return Name + ", " + Location + ", " + District;
        }
    }
}



