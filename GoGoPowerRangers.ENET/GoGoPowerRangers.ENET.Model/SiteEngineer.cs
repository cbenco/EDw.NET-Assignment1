using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class SiteEngineer : EngineerOrManager
    {
        const int STANDARD_MAXMANHOURS = 6;
        const int STANDARD_MAXMATCOST = 100;

        public SiteEngineer(string userName, string password, string name, District district) : base(userName, password, name, district, Type.SiteEngineer)
        {
            MaxManHours = STANDARD_MAXMANHOURS;
            MaxMaterialCost = STANDARD_MAXMATCOST;
        }

        /// <summary>
        /// Creates a new client in this engineer's current district.
        /// </summary>
        /// <param name="name">Client's name</param>
        /// <param name="location">Client's location</param>
        public void CreateClient(string name, string location)
        {
            Client c = new Client(name, location, this.District);
            FakeDatabase._clients.Add(c);
        }

        /// <summary>
        /// Creates an intervention using IDs and values passed from user input.
        /// </summary>
        /// <param name="type">The type of intervention being created</param>
        /// <param name="manHours">The required labour in hours</param>
        /// <param name="materialCost">The cost of materials</param>
        /// <param name="client">The client for whom the intervention is being installed</param>
        /// <param name="time">The requested date for the intervention</param>
        /// <param name="notes">Free text input from the user for additional information</param>
        public Intervention CreateIntervention(int type, double manHours, double materialCost, int client, DateTime time, string notes, Status status)
        {
            Intervention i = new Intervention();
            i.InterventionType = FakeDatabase._interventionTypes.FirstOrDefault(s => s.Id == type);
            i.Client = FakeDatabase._clients.FirstOrDefault(s => s.Id == client);
            i.RequestDate = time;
            i.ManHours = manHours;
            i.MaterialCost = materialCost;
            i.Requester = this;
            i.Notes = notes;
            i.Status = status;

            if (i.Client.District == District)
            {
                FakeDatabase._interventions.Add(i);
                return i;
            }
            return null;
        }

        /// <summary>
        /// Lists the clients in the engineer's current district.
        /// </summary>
        /// <returns></returns>
        public List<Client> ListClientsInDistrict()
        {
            List<Client> clientList = new List<Client>();
            var clients = FakeDatabase._clients.Where(c => c.District.Name == this.District.Name);
            foreach (Client c in clients)
                clientList.Add(c);
            
            return clientList;
        }
        /// <summary>
        /// List all interventions requested by this engineer. Excludes Cancelled interventions.
        /// </summary>
        /// <returns></returns>
        public List<Intervention> GetInterventions()
        {
            List<Intervention> interventionList = new List<Intervention>();
            var interventions = FakeDatabase._interventions.Where(i => i.Requester == this);
            foreach (Intervention i in interventions)
                interventionList.Add(i);

            return interventionList;
        }

        public Intervention GetInterventionById(int id)
        {
            //TODO
            return new Intervention();
        }
        
        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}