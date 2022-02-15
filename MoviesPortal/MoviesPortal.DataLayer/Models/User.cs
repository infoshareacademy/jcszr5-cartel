using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer.Models
{
    public enum Role
    {
        User,
        PremiumUser,
        Admin
    };


    public class User
    {
        static int nrOfInstances = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }                

        public User()
        {
            nrOfInstances++;
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            UserRole = Role.User;
            nrOfInstances++;
            Id = nrOfInstances;           
        }

       
        public void GetUserDetails()
        {
            Console.WriteLine("ID:{0, -6} Name: {1,-10} Password : {2,-10} Role: {3,-10}", Id, Name, Password, UserRole);
        }
    }
}