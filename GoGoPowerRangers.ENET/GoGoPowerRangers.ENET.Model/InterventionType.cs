using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class InterventionType
    {
        private int _id;
        static int current = 0;
        public InterventionType() { }
        public string Name { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = current++; }
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