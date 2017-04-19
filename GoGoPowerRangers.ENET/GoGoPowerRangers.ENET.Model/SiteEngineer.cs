using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class SiteEngineer : User
    {
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
        public List<Client> ListClientsInDistrict()
        {
            FakeDatabase fakeDb = new FakeDatabase();
            List<Client> clientList = new List<Client>();
            var clients = from c in fakeDb._clients
                          where c.District == this.District
                          select c;
            foreach (Client c in clients)
                clientList.Add(c);
            
            return clientList;
        }
        public List<Intervention> GetInterventions()
        {
            FakeDatabase fakeDb = new FakeDatabase();
            List<Intervention> interventions = new List<Intervention>();
            var clients = from i in fakeDb._interventions
                          where i.Requester == this
                          select i;
            foreach (Intervention i in interventions)
                interventions.Add(i);

            return interventions;
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