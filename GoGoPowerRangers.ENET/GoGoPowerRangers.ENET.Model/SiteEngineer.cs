using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class SiteEngineer : User
    {
        //private List<Intervention> _interventions;
        public SiteEngineer(User user):base(user)
        {

        }
        public SiteEngineer(string userName, string password, string name, District district):base(userName, password, name, Type.SiteEngineer)
        {
            this.District = district;
        }
        public District District { get; set; }
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
        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}