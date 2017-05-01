using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Model
{
    public class Client
    {
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
            get;
            set;
        }

        /// <summary>
        /// Gets the interventions that apply to this client.
        /// </summary>
        /// <returns></returns>
        public Data.ENET.InterventionDataTable GetInterventions()
        {
            try
            {
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var list = interventionTable.GetInterventionsByClientId(Id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override string ToString()
        {
            return Name + ", " + Location + ", " + District;
        }
    }
}



