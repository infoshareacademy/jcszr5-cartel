using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using MoviesPortal.DataLayer.Models;

namespace MoviesPortal.UserService
{
    public class UsersService
    {
        private const string csvPath = @"..\..\..\..\MoviesPortal.DataLayer\Database\UsersList.csv";
        internal List<User> UsersList = new List<User>();
        private int currentIdInDB = 0;

        /// <summary>
        /// Adds user to list of users used by application during runtime.
        /// </summary>
        public void AddUserToList(User user)
        {
            UsersList.Add(user);
        }

        /// <summary>
        /// Deletes user from list of users used by application during runtime
        /// </summary>
        public void DeleteUser(int id, string name)
        {
            var userToRemove = UsersList.Single(u => (u.Id == id && u.Name == name));
            UsersList.Remove(userToRemove);
        }

        /// <summary>
        /// Prints out all existing users in system.
        /// </summary>
        public void PresentAllUsers()
        {
            Console.WriteLine($"List of All Users in DB");
            foreach (var user in UsersList)
            {
                user.GetUserDetails();
            }
        }

        /// <summary>
        /// Method will create csv file containing List of Users
        /// Method will override any existing records in file.
        /// </summary>
        public void SaveUsersListToCSV()
        {
            StringBuilder csv = new StringBuilder();
            foreach (var u in UsersList)
            {
                csv.AppendLine($"{u.Id};{u.Name};{u.Password};{u.UserRole}");
            }
            File.WriteAllText(csvPath, csv.ToString());
        }

        /// <summary>
        /// Method loads existing users from CSV file to Users' list used by application during runtime.
        /// </summary>
        public void LoadUsersListFromCSV()
        {
            List<string> lines = File.ReadAllLines(csvPath).ToList();
            List<User> output = new();

            foreach (var line in lines)
            {
                string[] entries = line.Split(";");
                User user = new();
                user.Id = Int32.Parse(entries[0]);
                user.Name = entries[1];
                user.Password = entries[2];
                user.UserRole = (Role)Enum.Parse(typeof(Role), entries[3]);
                output.Add(user);
            }
            UsersList = output;
        }

    }
}
