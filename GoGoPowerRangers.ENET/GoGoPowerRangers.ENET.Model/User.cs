using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class User
    {
        private int _id; 
        private static int current = 1; //remove this when the DB is in place, it just holds the highest ID number currently held.
        public User()
        {

        }
        public User(User copy)
        {
            Id = copy.Id;
            Name = copy.Name;
        }

        public User(string userName, string password, string name, Type type)
        {
            UserName = userName;
            Password = password;
            Name = name;
            UserType = type;
            Id = new int(); //sets ID as next free number
        }
        public int Id
        {
            get { return _id; }
            set { _id = current++; }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public Type UserType { get; set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public override string ToString()
        {
            return Id + " " + Name + ", " + UserType;
        }
    }
}