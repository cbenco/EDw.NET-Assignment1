using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoPowerRangers.ENET.Model
{
    public class User
    {
        //private int _id; 
        public User()
        {

        }
        public User(User copy)
        {
            this.Id = copy.Id;
            this.Name = copy.Name;
        }

        public User(string userName, string password, string name, int id, Type type)
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public Type UserType { get; set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}