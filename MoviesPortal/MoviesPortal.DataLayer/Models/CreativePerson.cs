
using MoviesPortal.DataLayer;

public class CreativePerson
{
    public string Name { get; set; }   

    public string SurName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public CreativeRole  Role { get; set; }

    public  CreativePerson(string name, string surName, DateTime birthDate, CreativeRole role)
    {
        Name = name;
        SurName = surName;
        DateOfBirth = birthDate;
        Role = role;
    }
}