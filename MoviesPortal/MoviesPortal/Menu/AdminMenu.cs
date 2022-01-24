using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Menu 
{
    internal class AdminMenu : IMenu
    {
        public List<string> SelectionOptions
        {
            get
            {
                return new List<string>() {
                    "Add Movies",
                    "Edit Movies",
                    "Delete Movie",
                    "Add Actor/Director",
                    "Edit Actor/Director",
                    "Delete Actor/Director",
                    "Exit" };
            }
        }
        public void ListMainOptions()
        {
            throw new NotImplementedException();
        }

        public void GetUserChoiceInMainMenu()
        {
            throw new NotImplementedException();
        }

        public void InitializeMenu()
        {
            throw new NotImplementedException();
        }
    }
}
