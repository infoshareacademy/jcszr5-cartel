using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Data
{
    public class LoggedUser
    {
        private static string userName = "no user logged";

        public static string UserName
        {
            get { return userName; }
            set { userName = value; }

        }

        public static void WhoIsLogged()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"USER LOGIN: {LoggedUser.UserName}");            
            Console.WriteLine("========================================");
            Console.ResetColor();
        }


    }





}
