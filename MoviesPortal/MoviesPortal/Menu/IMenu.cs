using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Menu
{
    public interface IMenu
    {
        public List<string> SelectionOptions { get; }
        public void ListMainOptions();
        public void GetUserChoiceInMainMenu();
        public void InitializeMenu();

    }
}
