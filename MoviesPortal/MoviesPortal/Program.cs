
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.Menu;
using MoviesPortal.UserService;

MovieStoreService database = new();
database.LoadMoviesFromJson(); //załaduj bazę filmów
LoginPanel.MainPanel();