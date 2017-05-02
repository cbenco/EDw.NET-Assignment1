using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class Accountant : User
    {
        public Accountant(User user) : base(user) { }
        public Accountant(string userName, string password, string name) : base(userName, password, name, Type.Accountant) { }

        /// <summary>
        /// Changes district of given user 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="districtId"></param>
        public void ChangeUserDistrict(User user, int districtId)
        {
            UserTypeTableAdapter userTypeTable = new UserTypeTableAdapter();
            userTypeTable.UpdateUserDistrictId(districtId, user.Id, user.Id);
        }

        /// <summary>
        /// Converts InterventionType from database to local object
        /// </summary>
        /// <param name="dbInterventionType"></param>
        /// <returns></returns>
        public InterventionType ConvertDbInterventionTypeToInterventionType(Data.ENET.InterventionTypeRow dbInterventionType)
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
        /// Converts Intervention from database to local object
        /// </summary>
        /// <param name="dbIntervention"></param>
        /// <returns></returns>
        public Intervention ConvertDbInterventionToIntervention(Data.ENET.InterventionRow dbIntervention)
        {

            InterventionType iType = new InterventionType();
            UserTableAdapter userTable = new UserTableAdapter();
            UserTypeTableAdapter userTypeTable = new UserTypeTableAdapter();
            DistrictTableAdapter districtTable = new DistrictTableAdapter();
            InterventionTypeTableAdapter iTypeTable = new InterventionTypeTableAdapter();
            var dbInterventionType = iTypeTable.GetInterventionTypeById(dbIntervention.TypeID).FirstOrDefault();
            
            Intervention i = new Intervention();
            i.InterventionType = ConvertDbInterventionTypeToInterventionType(dbInterventionType);
            i.Id = dbIntervention.InterventionID;
            i.LastVisited = dbIntervention.LastVisited;
            i.ManHours = (double)dbIntervention.Hours;
            i.MaterialCost = (double)dbIntervention.MaterialCost;
            i.Notes = dbIntervention.Notes;
            i.RemainingLife = dbIntervention.RemainingLife;
            i.RequestDate = dbIntervention.Date;
            i.Requester = new SiteEngineer(ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ProposedBy).FirstOrDefault()));
            if (dbIntervention.ApprovedBy >= 1)
                i.Approver = new User(ConvertDbUserToUser(userTable.GetUserById(dbIntervention.ApprovedBy).FirstOrDefault()));
            else
                i.Approver = null;
            var dbDistrict = districtTable.GetDistrictById(userTypeTable.GetUserTypeByUserID(dbIntervention.ProposedBy).FirstOrDefault().DistrictID).FirstOrDefault();
            i.Requester.District = ConvertDbDistricttoDistrict(dbDistrict);

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

        /// <summary>
        /// Converts client from database to local object
        /// </summary>
        /// <param name="dbClient"></param>
        /// <returns></returns>
        public Client ConvertDbClientToClient(Data.ENET.ClientRow dbClient)
        {
            DistrictTableAdapter districtTable = new DistrictTableAdapter();
            var dbDistrict = districtTable.GetDistrictById(dbClient.DistrictID).FirstOrDefault();
            Client client = new Client(dbClient.Name, dbClient.Location, ConvertDbDistricttoDistrict(dbDistrict));
            client.Id = dbClient.ClientID;
            return client;
        }

        /// <summary>
        /// Converts User from database to local object
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts district from database to local object
        /// </summary>
        /// <param name="dbDistrict"></param>
        /// <returns></returns>
        public District ConvertDbDistricttoDistrict(Data.ENET.DistrictRow dbDistrict)
        {
            District district = new District();
            district.Id = dbDistrict.DistrictID;
            district.Name = dbDistrict.DistrictName;
            return district;
        }

    }
}