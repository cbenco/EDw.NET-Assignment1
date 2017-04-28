using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoGoPowerRangers.ENET.Model
{
    public class EngineerOrManager : User
    {
        public EngineerOrManager(User user) : base(user) { }
        public EngineerOrManager(string userName, string password, string name, District district, Type type) : base(userName, password, name, type)
        {
            District = district;
            MaxManHours = 6;
            MaxMaterialCost = 100;
        }
        public District District { get; set; }
        public double MaxManHours { get; set; }
        public double MaxMaterialCost { get; set; }

        /// <summary>
        /// Changes the status of an intervention.
        /// </summary>
        /// <param name="intervention">The intervention to be changed</param>
        /// <param name="status">The desired status</param>
        public void ChangeInterventionState(Intervention intervention, Status status)
        {
            if (CanChangeStatus(intervention, status))
                intervention.Status = status;
        }

        private bool CanChangeStatus(Intervention i, Status s)
        {
            return !((i.Status == Status.Pending && s == Status.Complete) || 
                     (i.Status == Status.Approved && s == Status.Pending) || 
                     (i.Status == Status.Cancelled || i.Status == Status.Complete));
        }
    }
}