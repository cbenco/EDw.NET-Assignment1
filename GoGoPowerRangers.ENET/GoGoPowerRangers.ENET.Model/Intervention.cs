﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Intervention
    {
        private int _id;
        static int current = 0;
        public Intervention()
        {
            Status = Status.Pending;
            RemainingLife = 100;
            LastVisited = DateTime.Now;
        }
        public Intervention(InterventionType type, Client client, User requester, int remainingLife)
        {
            InterventionType = type;
            ManHours = type.ManHours;
            MaterialCost = type.MaterialCost;

            Client = client;
            Requester = requester;
            RemainingLife = remainingLife;

            RequestDate = DateTime.Now;
            LastVisited = DateTime.Now;

            Status = Status.Pending;
            Id = new int();
        }
        
        public Intervention(InterventionType type, double manHours, double materialCost, Client client, User requester, int remainingLife)
            : this(type, client, requester, remainingLife)
        {
            ManHours = manHours;
            MaterialCost = materialCost;
        }

        public InterventionType InterventionType { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }
        public Client Client { get; set; }
        public User Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public Status Status { get; set; }
        public User Approver { get; set; }
        public int RemainingLife { get; set; }
        public DateTime LastVisited { get; set; }
        public string Notes { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = current++; }
        }
        public bool Approvable(User approver)
        {
            if (Status == Status.Pending)
            {
                if (approver.GetType() == typeof(SiteEngineer))
                    return CanBeApprovedByEngineer((SiteEngineer)approver);
                else if (approver.GetType() == typeof(Manager))
                    return CanBeApprovedByManager((Manager)approver);
                else return false;
            }
            else return false;
        }
        //omg
        public Intervention GetThis()
        {
            return this;
        }
        private bool CanBeApprovedByEngineer(SiteEngineer approver)
        {
            if (approver == Requester &&
                approver.MaxManHours >= ManHours &&
                approver.MaxMaterialCost >= MaterialCost &&
                approver.MaxManHours >= InterventionType.ManHours &&
                approver.MaxMaterialCost >= InterventionType.MaterialCost)
                return true;
            else return false;
        }
        private bool CanBeApprovedByManager(Manager approver)
        {
            return (
                  approver.District == Client.District &&
                  approver.MaxManHours >= ManHours &&
                  approver.MaxMaterialCost >= MaterialCost &&
                  approver.MaxManHours >= InterventionType.ManHours &&
                  approver.MaxMaterialCost >= InterventionType.MaterialCost);
        }

        public override string ToString()
        {
            return InterventionType.Name + " for " + Client.Name + ", proposed by " + Requester.Name;
        }

        public Intervention(InterventionType type, Client client, User requester, int remainingLife, User approver, Status status)
        {
            InterventionType = type;
            ManHours = type.ManHours;
            MaterialCost = type.MaterialCost;

            Client = client;
            Requester = requester;
            RemainingLife = remainingLife;
            Approver = approver;

            RequestDate = DateTime.Now.AddYears(-1);
            LastVisited = DateTime.Now;

            Status = status;
            Id = new int();
        }
    }
}