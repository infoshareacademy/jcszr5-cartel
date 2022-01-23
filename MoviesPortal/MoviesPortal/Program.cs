
﻿using MoviesPortal;

UserMenu menu = new UserMenu();
menu.InitializeUserMenu();

var _iOHelper = new IOHelper();
var _movieStore = new MovieStore();

//TODO Menu
//var exit = false;
//while (!exit)
//{
//    AddNewMovie();
//}

LoginPanel loginPanel = new LoginPanel();
loginPanel.ChooseOption();

void AddNewMovie()
{
    var newMovie = new Movie()
    {
        Title = _iOHelper.GetStringFromUser("Enter movie title: "),
        Director = AddPersonsList("director"),
        Genre = _iOHelper.GetStringFromUser("Enter movie genre (action, adventure, animated, comedy, drama, fantasy, historical, horror, sciFi, thriller, western"),
        ProductionYear = _iOHelper.GetProductionYearFromUser("Enter year of production: "),
        Description = _iOHelper.GetStringFromUser("Enter short description of the movie: "),
        IsForKids = _iOHelper.GetBoolFromUser("Is the movie alloved for children? (true/false): "),  //TODO change to Y/N
        ActorList = AddPersonsList("actor")
        //TODO:
        // - add actor => adding new person,
        // - add actor from the list of persons in the system
    };
    _movieStore.AddMovie(newMovie);
}

List<Person> AddPersonsList(string message)
{
    List<Person> persons = new List<Person>();
    var index = "";
    while(_iOHelper.GetBoolFromUser($"Do you want to add {index} {message}? (true/false)"))
    {
        var person = AddPerson(index, message);
        persons.Add(person);
        index = "another";
    }
    return persons;
}

Person AddPerson(string index, string message)
{
    var name = _iOHelper.GetStringFromUser($"Enter name of {index} {message}: ");
    var surName = _iOHelper.GetStringFromUser($"Enter surname of {message}: ");
    var person = new Person(name, surName);
    return person;
}
