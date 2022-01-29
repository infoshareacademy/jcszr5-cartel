
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.Menu;

 IMenu adminMenu = new AdminMenu();
 IMenu userMenu = new UserMenu();

adminMenu.InitializeMenu();

var _iOHelper = new IOHelper();


LoginPanel loginPanel = new LoginPanel();
loginPanel.ChooseOption();


