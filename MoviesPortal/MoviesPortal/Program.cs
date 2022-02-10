
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.Menu;
using MoviesPortal.UserService;

//IMenu adminMenu = new AdminMenu();
//adminMenu.InitializeMenu();

LoginPanel loginPanel = new LoginPanel();
loginPanel.ChooseOption();
MenuInitializer.InitializeMenu();
