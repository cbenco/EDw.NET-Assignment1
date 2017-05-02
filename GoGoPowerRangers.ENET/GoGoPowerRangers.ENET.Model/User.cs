using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using GoGoPowerRangers.ENET.Data;

namespace GoGoPowerRangers.ENET.Model
{
    public class User
    {
        public User()
        {

        }
        public User(User copy)
        {
            Id = copy.Id;
            UserName = copy.UserName;
            Password = copy.Password;
            FirstName = copy.FirstName;
            LastName = copy.LastName;
            UserType = copy.UserType;
        }

        public User(string userName, string password, string name, Type type)
        {
            UserName = userName;
            Password = password;
            FirstName = name;
            UserType = type;
            Id = new int(); //sets ID as next free number
        }
        public User(Data.ENET.UserRow dbUser)
        {

            UserName = dbUser.Username;
            Password = dbUser.Password;
            FirstName = dbUser.FirstName;
            LastName = dbUser.LastName;
            Id = dbUser.UserID;
            var type = dbUser.Role;
            type = type.Trim();
            switch (type)
            {
                case ("e"):
                    UserType = Type.SiteEngineer;
                    break;
                case ("a"):
                    UserType = Type.Accountant;
                    break;
                case ("m"):
                    UserType = Type.Manager;
                    break;
            }
        }
       
        public int Id
        {
            get;
            set;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Type UserType { get; set; }

        
        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + ", " + UserType;
        }
    }
}