using MoviesPortal.DataLayer;

public class Movie
{
    public string Title { get; set; }

    public List<CreativePerson> Director = new List<CreativePerson>();

    public int ProductionYear { get; set; }

    public  Genre  Genre{ get; set; }  

    public string Description { get; set; }

    public bool IsForKids { get; set; }


    public List<CreativePerson> ActorList = new List<CreativePerson>(); //TODO - add actor from the list, and add actor from the console

}

