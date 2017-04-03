using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class InterventionType
    {
        private int _id;
        public InterventionType() { }
        public string Name { get; set; }
        public double ManHours { get; set; }
        public double MaterialCost { get; set; }

    }
}