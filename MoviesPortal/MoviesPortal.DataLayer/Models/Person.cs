public class Person
{
    public string Name { get; set; }   

    public string SurName { get; set; }

    public  Person(string name, string surName)
    {
        Name = name;
        SurName = surName;
    }
}