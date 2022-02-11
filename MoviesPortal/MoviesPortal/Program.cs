
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.Menu;
using MoviesPortal.UserService;


LoginPanel loginPanel = new LoginPanel();
MovieStoreService database = new();
loginPanel.ChooseOption();
database.LoadMoviesFromJson(); //Jeśli nie wykryje pliku MoviesDB.Json , to wyskoczy wyjątek. Może Try - catch?
MenuInitializer.InitializeMenu();
