
﻿using MoviesPortal;
using MoviesPortal.BusinessLayer;
using MoviesPortal.Menu;

 IMenu adminMenu = new AdminMenu();
 IMenu userMenu = new UserMenu();

adminMenu.InitializeMenu();

LoginPanel loginPanel = new LoginPanel();
loginPanel.ChooseOption();


