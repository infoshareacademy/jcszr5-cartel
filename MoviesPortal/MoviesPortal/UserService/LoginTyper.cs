using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This class set flag on prop LoginType (admin or user) - interface IMenu know what menu has to initialize
 */
namespace MoviesPortal.UserService
{
    internal static class LoginTyper
    {
        public static string LoginType { get; set; }
    }
}
