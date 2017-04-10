using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Intervention
    {
        //private int _id;
        public Intervention()
        {

        }

        public InterventionType InterventionType { get; set; }
        public Client Client { get; set; }
        public double ManHoues { get; set; }
        public double MaterialCost { get; set; }
        public User Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public Status Status { get; set; }
        public User Approver { get; set; }
        public int RemainingLife { get; set; }
        public DateTime LastVisited { get; set; }
        public string Notes { get; set; }
    }
}