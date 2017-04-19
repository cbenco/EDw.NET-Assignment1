using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class SiteEngineer : User
    {
        //private List<Intervention> _interventions;
        public SiteEngineer(User user):base(user)
        {

        }
        public SiteEngineer(string userName, string password, string name, District district) : base(userName, password, name, Type.SiteEngineer)
        {
            District = district;
            MaxManHours = 6;
            MaxMaterialCost = 100;
        }
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }
        public void CreateClient()
        {

        }
        public List<Client> ListClients()
        {
            FakeDatabase fakeDb = new FakeDatabase();
            List<Client> clients = new List<Client>();
            /*replace above with 
            var client = from _clientsList
                         where District = this.district*/

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