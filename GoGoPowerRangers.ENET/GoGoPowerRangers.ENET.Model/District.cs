using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class District
    {
        //private int _id;
        public District() { }
        public District(string name)
        {
            Name = name;
        }

        public District(Data.ENET.DistrictRow dbDistrict)
        {
            Name = dbDistrict.DistrictName;
            Id = dbDistrict.DistrictID;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}