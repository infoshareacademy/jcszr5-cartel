using MoviesPortal.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer
{
    public class ActorsAgent
    {
        static List<Actor>  _actors = new List<Actor>();

        public static void AddActors(Actor newActor)
        {
            _actors.Add(newActor);
        }
    }
}
