﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using static GoGoPowerRangers.ENET.Data.ENET;
using System.Data;

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

        public SiteEngineer(User user) : base(user) 
        {

        }

        /// <summary>
        /// Creates a new client in this engineer's current district.
        /// </summary>
        /// <param name="name">Client's name</param>
        /// <param name="location">Client's location</param>
        public void CreateClient(string name, string location)
        {
            ClientTableAdapter clientTable = new ClientTableAdapter();
            clientTable.AddClient(name, location, District.Id);
            //Client c = new Client(name, location, this.District);
            //FakeDatabase._clients.Add(c);

        }

        /// <summary>
        /// Converts client from database to local object
        /// </summary>
        /// <param name="dbClient"></param>
        /// <returns></returns>
        public new Client ConvertDbClientToClient(Data.ENET.ClientRow dbClient)
        {
            Client client = new Client(dbClient.Name, dbClient.Location, this.District);
            client.Id = dbClient.ClientID;
            return client;
        }
        public new District District { get; set; }

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
        /// Converts InterventionType from database to local object
        /// </summary>
        /// <param name="dbInterventionType"></param>
        /// <returns></returns>
        public InterventionType ConvertDbInterventionTypeToInterventionType(Data.ENET.InterventionTypeRow dbInterventionType)
        {
            InterventionType iType = new InterventionType();

            InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
            iType.ManHours = (double)dbInterventionType.DefaultHours;
            iType.MaterialCost = (double)dbInterventionType.DefaultMaterialCost;
            iType.Name = dbInterventionType.Name;
            iType.Id = dbInterventionType.TypeID;
            return iType;
        }

        /// <summary>
        /// Converts Intervention from database to local object
        /// </summary>
        /// <param name="dbIntervention"></param>
        /// <returns></returns>
        public new Intervention ConvertDbInterventionToIntervention(Data.ENET.InterventionRow dbIntervention)
        {

            InterventionType iType = new InterventionType();

            InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
            UserTableAdapter userTable = new UserTableAdapter();
            var dbInterventionType = iTypeTable.GetInterventionTypeById(dbIntervention.TypeID).FirstOrDefault();

            Intervention i = new Intervention();
            i.InterventionType = ConvertDbInterventionTypeToInterventionType(dbInterventionType);
            i.Id = dbIntervention.InterventionID;
            i.LastVisited = dbIntervention.LastVisited;
            i.ManHours = (double)dbIntervention.Hours;
            i.MaterialCost = (double)dbIntervention.MaterialCost;
            i.Notes = dbIntervention.Notes;
            i.RemainingLife = dbIntervention.RemainingLife;
            i.RequestDate = dbIntervention.Date;
            i.Requester = this;
            if (dbIntervention.ApprovedBy >= 1)
                i.Approver = new User(ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ApprovedBy).FirstOrDefault()));
            else
                i.Approver = null;
            var status = dbIntervention.State;
            switch (status)
            {
                case "Pending":
                    i.Status = Status.Pending;
                    break;
                case "Approved":
                    i.Status = Status.Approved;
                    i.Approver = ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ApprovedBy).FirstOrDefault());
                    break;
                case "Cancelled":
                    i.Status = Status.Cancelled;
                    break;
                case "Complete":
                    i.Status = Status.Complete;
                    break;
                default:
                    i.Status = Status.Cancelled;
                    break;
            }
            ClientTableAdapter clientTable = new ClientTableAdapter();
            i.Client = ConvertDbClientToClient(clientTable.GetClientById(dbIntervention.ClientID).FirstOrDefault());
            return i;
        }

        /// <summary>
        /// Lists the clients in the engineer's current district.
        /// </summary>
        /// <returns></returns>
        public List<Data.ENET.ClientRow> ListClientsInDistrict()
        {
            ClientTableAdapter clientTable = new ClientTableAdapter();
            return clientTable.GetClientsByDistrictId(this.District.Id).ToList();
        }
        /// <summary>
        /// List all interventions requested by this engineer. Excludes Cancelled interventions.
        /// </summary>
        /// <returns></returns>
        public Data.ENET.InterventionDataTable GetInterventions()
        {
            try
            {
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var list = interventionTable.GetInterventionsByUserId(Id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

      
        public override string ToString()
        {
            return base.ToString() + ", " + District.ToString();
        }
    }
}