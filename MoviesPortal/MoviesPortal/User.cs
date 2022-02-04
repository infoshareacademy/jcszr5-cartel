namespace MoviesPortal
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
