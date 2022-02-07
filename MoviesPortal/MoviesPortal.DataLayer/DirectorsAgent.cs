﻿using MoviesPortal.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer
{
    internal class DirectorsAgent
    {
        static List<Director> _directors = new List<Director>();

        public static void AddActors(Director newDirector)
        {
            _directors.Add(newDirector);
        }
    }
}
