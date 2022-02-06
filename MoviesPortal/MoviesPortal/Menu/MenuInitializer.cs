using MoviesPortal.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Menu
{
    internal static class MenuInitializer
    {
        

        public static void InitializeMenu()
        {
            IMenu adminMenu = new AdminMenu();
            IMenu userMenu = new UserMenu();

            if (LoginTyper.LoginType == "admin")
            {
                adminMenu.InitializeMenu();
            }
            else if (LoginTyper.LoginType == "user")
            {
                userMenu.InitializeMenu();
            }
            else Console.WriteLine("Error while loading menu!!");
        }
    }
}
