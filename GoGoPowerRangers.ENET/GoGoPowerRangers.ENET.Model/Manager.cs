﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class Manager : User
    {
        public Manager(User user) : base(user)
        {

        }
        public Manager(string userName, string password, string name, District district) : base(userName, password, name, Type.Manager)
        {
            District = district;
            MaxManHours = 30;
            MaxMaterialCost = 1000;
        }
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }

        public void CreateClient(string name, string location)
        {
            Client c = new Client(name, location, this.District);
            FakeDatabase._clients.Add(c);
        }
        public void CreateIntervention(int type, double manHours, double materialCost, int client, DateTime time, string notes)
        {
            Intervention i = new Intervention();
            i.InterventionType = FakeDatabase._interventionTypes.FirstOrDefault(s => s.Id == type);
            i.Client = FakeDatabase._clients.FirstOrDefault(s => s.Id == client);
            i.RequestDate = time;
            i.ManHours = manHours;
            i.MaterialCost = materialCost;
            i.Requester = this;
            i.Notes = notes;

            FakeDatabase._interventions.Add(i);
        }

        public List<Client> ListClientsInDistrict()
        {
            List<Client> clientList = new List<Client>();
            var clients = FakeDatabase._clients.Where(c => c.District.Name == this.District.Name);
            foreach (Client c in clients)
                clientList.Add(c);

            return clientList;
        }
        public List<Intervention> GetInterventions()
        {
            List<Intervention> interventionList = new List<Intervention>();
            var interventions = FakeDatabase._interventions.Where(i => i.Requester == this);
            foreach (Intervention i in interventions)
                interventionList.Add(i);

            return interventionList;
        }

        public List<Intervention> GetPendingInterventions()
        {
            List<Intervention> interventions = new List<Intervention>();
            interventions.Where(s => s.Status == Status.Pending);

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

        public void ChangeSiteEngineerDistrict(SiteEngineer engineer, District district)
        {
            throw new NotImplementedException();
            //engineer.District = district;
            
        }
        public void ChangeManagerDistrict(Manager manager, District district)
        {
            manager.District = district;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}