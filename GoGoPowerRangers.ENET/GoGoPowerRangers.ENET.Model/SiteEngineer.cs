using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class SiteEngineer
    {
        public District District { get; set; }
        private List<Intervention> _interventions;
        public void CreateClient()
        {

        }
        public List<Client> ListClients()
        {
            List<Client> clients = new List<Client>();
            //replace above with 
            //var client = linq query
            return clients;
        }
        public Intervention GetInterventionById(int id)
        {
            //TODO
            return new Intervention();
        }
        public void ChangeInterventionState(Intervention intervention, Status status)
        {
            intervention.Status = status;
        }
    }
}