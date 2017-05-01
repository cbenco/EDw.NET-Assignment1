using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;

namespace GoGoPowerRangers.ENET.Model
{
    public static class DbUtilities
    {
        #region Intervention Methods
        /// <summary>
        /// Get all pending interventions a given manager is able to approve
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static List<Intervention> GetPendingInterventionsForManager(Manager manager)
        {
            InterventionTableAdapter interventionTable = new InterventionTableAdapter();
            var dbInterventions = interventionTable.GetInterventionsByStatus("Pending");

            List<Intervention> interventions = new List<Intervention>();
            foreach (var dbInt in dbInterventions)
            {
                var intervention = ConvertDbInterventionToIntervention(dbInt);
                if (intervention.Approvable(manager))
                    interventions.Add(intervention);
            }
            return interventions;
        }

        /// <summary>
        /// Converts Intervention from database to local object
        /// </summary>
        /// <param name="dbIntervention"></param>
        /// <returns></returns>
        public static Intervention ConvertDbInterventionToIntervention(Data.ENET.InterventionRow dbIntervention)
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
            i.Requester = new SiteEngineer(ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ProposedBy).FirstOrDefault()));
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
            //i.Client = ConvertDbClientToClient(clientTable.GetClientById(dbIntervention.ClientID).FirstOrDefault());
            return i;
        }

        /// <summary>
        /// Return all interventions requested by a user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Data.ENET.InterventionDataTable GetInterventionsByRequesterId(int Id)
        {
            try
            {
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var list = interventionTable.GetInterventionsByUserId(Id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Change the state of an intervention in the database
        /// </summary>
        /// <param name="approver"></param>
        /// <param name="intervention"></param>
        /// <param name="status"></param>
        public static void ChangeInterventionState(Manager approver, Intervention intervention, Status status)
        {
            InterventionTableAdapter interventionTable = new InterventionTableAdapter();
            intervention.Status = status;
            string dbStatus;
            int? dbApprover = null;
            switch (status)
            {
                case Status.Pending:
                    dbStatus = "Pending";
                    break;
                case Status.Approved:
                    dbStatus = "Approved";
                    dbApprover = approver.Id;
                    break;
                case Status.Cancelled:
                    dbStatus = "Cancelled";
                    break;
                case Status.Complete:
                    dbStatus = "Complete";
                    break;
                default:
                    dbStatus = "Cancelled";
                    break;
            }

            interventionTable.UpdateDbInterventionStatus(dbApprover, dbStatus, intervention.Id, intervention.Id);
        }

        /// <summary>
        /// Converts InterventionType from database to local object
        /// </summary>
        /// <param name="dbInterventionType"></param>
        /// <returns></returns>
        public static InterventionType ConvertDbInterventionTypeToInterventionType(Data.ENET.InterventionTypeRow dbInterventionType)
        {
            InterventionType iType = new InterventionType();

            InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
            iType.ManHours = (double)dbInterventionType.DefaultHours;
            iType.MaterialCost = (double)dbInterventionType.DefaultMaterialCost;
            iType.Name = dbInterventionType.Name;
            iType.Id = dbInterventionType.TypeID;
            return iType;
        }

        /// <summary>
        /// List all interventions requested by this engineer. Excludes Cancelled interventions.
        /// </summary>
        /// <returns></returns>
        public static Data.ENET.InterventionDataTable GetInterventionsById(int Id)
        {
            
            try
            {
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var list = interventionTable.GetInterventionsByUserId(Id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion Intervention Methods

        #region User methods
        /// <summary>
        /// Converts User from database to local object
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns></returns>
        public static User ConvertDbUserToUser(Data.ENET.UserRow dbUser)
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

        /// <summary>
        /// Changes district of given user 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="districtId"></param>
        public static void ChangeUserDistrict(User user, int districtId)
        {
            UserTypeTableAdapter userTypeTable = new UserTypeTableAdapter();
            userTypeTable.UpdateUserDistrictId(districtId, user.Id, user.Id);
        }
        #endregion User Methods

        #region District methods

        /// <summary>
        /// Lists the clients in the engineer's current district.
        /// </summary>
        /// <returns></returns>
        public static List<Data.ENET.ClientRow> ListClientsInDistrict()
        {
           
            ClientTableAdapter clientTable = new ClientTableAdapter();

            //return clientTable.GetClientsByDistrictId(this.District.Id).ToList();
        }
        /// <summary>
        /// Converts district from database to local object
        /// </summary>
        /// <param name="dbDistrict"></param>
        /// <returns></returns>
        public static District ConvertDbDistricttoDistrict(Data.ENET.DistrictRow dbDistrict)
        {
            District district = new District();
            district.Id = dbDistrict.DistrictID;
            district.Name = dbDistrict.DistrictName;
            return district;
        }
        #endregion District Methods

        #region Client Methods
        /// <summary>
        /// Converts client from database to local object
        /// </summary>
        /// <param name="dbClient"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public static Client ConvertDbClientToClient(Data.ENET.ClientRow dbClient, EngineerOrManager currentUser)
        {
            Client client = new Client(dbClient.Name, dbClient.Location, currentUser.District);
            client.Id = dbClient.ClientID;
            return client;
        }

        /// <summary>
        /// Returns list of clients in district of user
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public static List<Data.ENET.ClientRow> ListClientsInDistrict(EngineerOrManager currentUser)
        {
            ClientTableAdapter clientTable = new ClientTableAdapter();
            return clientTable.GetClientsByDistrictId(currentUser.District.Id).ToList();
        }

        /// <summary>
        /// Creates a new Client in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="currentUser"></param>
        public static void CreateClient(string name, string location, EngineerOrManager currentUser)
        {
            ClientTableAdapter clientTable = new ClientTableAdapter();
            clientTable.AddClient(name, location, currentUser.District.Id);
        }


        #endregion Client Methods
    }
}
