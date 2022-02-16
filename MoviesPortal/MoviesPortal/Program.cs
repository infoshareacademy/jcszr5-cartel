
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.DataLayer;
using MoviesPortal.Menu;
using MoviesPortal.UserService;

MovieStoreService database = new();
CreativePersonAgency agency = new();
database.LoadMoviesFromJson(); //załaduj bazę filmów
//agency.LoadCreativePersonsFromJson(); // załaduj bazę aktorów/reżyserów
LoginPanel.MainPanel();