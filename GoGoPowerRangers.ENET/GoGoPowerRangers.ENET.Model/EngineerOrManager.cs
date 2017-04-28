using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoGoPowerRangers.ENET.Model
{
    public class EngineerOrManager : User
    {
        public EngineerOrManager(string userName, string password, string name, District district, Type type) : base(userName, password, name, type)
        {
            District = district;
            MaxManHours = 6;
            MaxMaterialCost = 100;
        }
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }
    }
}
