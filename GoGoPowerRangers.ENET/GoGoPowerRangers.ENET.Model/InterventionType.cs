using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class InterventionType
    {
        public InterventionType() { }
        public string Name { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }
        public int Id
        {
            get;
            set;
        }

        public InterventionType(string name, double manHours, double materialCost)
        {
            Name = name;
            ManHours = manHours;
            MaterialCost = materialCost;
            Id = new int();
        }
    }
}