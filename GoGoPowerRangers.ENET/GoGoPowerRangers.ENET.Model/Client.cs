using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Client
    {
        //private int _id;
        public Client()
        { }
        
        public string Name { get; set; }
        public string Location { get; set; }
        public District District { get; set; }
    }
}