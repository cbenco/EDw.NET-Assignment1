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
            this.Id = copy.Id;
            this.Name = copy.Name;
        }

        public User(string userName, string password, string name, Type type)
        {
            this.UserName = userName;
            this.Password = password;
            this.Name = name;
            this.UserType = type;
            this.Id = new int(); //sets ID as next free number
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