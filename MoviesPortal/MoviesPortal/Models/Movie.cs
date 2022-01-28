public class Movie
{
    public string Title { get; set; }

    public List<Person> Director = new List<Person>();

    public int ProductionYear { get; set; }

    public string Genre { get; set; }  //TODO change to Enum

    public string Description { get; set; }

    public bool IsForKids { get; set; }


    public List<Person> ActorList = new List<Person>(); //TODO - add actor from the list, and add actor from the console



}

