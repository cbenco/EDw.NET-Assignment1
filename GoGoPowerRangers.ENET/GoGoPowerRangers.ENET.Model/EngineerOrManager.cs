using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
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
        public double ApprovalLimit { get; set; }

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

        public Intervention ConvertDbInterventionToIntervention(Data.ENET.InterventionRow dbIntervention)
        {

            InterventionType iType = new InterventionType();
            UserTableAdapter userTable = new UserTableAdapter();
            InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
            var dbInterventionType = iTypeTable.GetInterventionTypeById(dbIntervention.TypeID).FirstOrDefault();
            iType.ManHours = (double)dbInterventionType.DefaultHours;
            iType.MaterialCost = (double)dbInterventionType.DefaultMaterialCost;
            iType.Name = dbInterventionType.Name;
            iType.Id = dbInterventionType.TypeID;

            Intervention i = new Intervention();
            i.InterventionType = iType;
            i.Id = dbIntervention.InterventionID;
            i.LastVisited = dbIntervention.LastVisited;
            i.ManHours = (double)dbIntervention.Hours;
            i.MaterialCost = (double)dbIntervention.MaterialCost;
            i.Notes = dbIntervention.Notes;
            i.RemainingLife = dbIntervention.RemainingLife;
            i.RequestDate = dbIntervention.Date;
            i.Requester = new User(ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ProposedBy).FirstOrDefault()));
            var status = dbIntervention.State;
            switch (status)
            {
                case "Pending":
                    i.Status = Status.Pending;
                    break;
                case "Approved":
                    i.Status = Status.Approved;
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
        public Client ConvertDbClientToClient(Data.ENET.ClientRow dbClient)
        {
            Client client = new Client(dbClient.Name, dbClient.Location, this.District);
            client.Id = dbClient.ClientID;
            return client;
        }

        public User ConvertDbUserToUser(Data.ENET.UserRow dbUser)
        {
            User user = new User();
            user.Id = dbUser.UserID;
            user.UserName = dbUser.Username;
            user.Password = dbUser.Password;
            user.FirstName = dbUser.FirstName;
            user.LastName = dbUser.LastName;
            switch (dbUser.Role)
            {
                case ("a"):
                    user.UserType = Type.Accountant;
                    break;
                case ("e"):
                    user.UserType = Type.SiteEngineer;
                    break;
                case ("m"):
                    user.UserType = Type.Manager;
                    break;
            }

            return user;
        }
    }
}