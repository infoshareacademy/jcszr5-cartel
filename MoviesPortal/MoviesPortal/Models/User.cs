
namespace MoviesPortal.Models
{
    public enum Role
    {
        User,
        Admin
    };


    public class User
    {
        internal List<User> UsersList = new List<User>();
        private int _id = 0;

        public int Id { get; init; }

        public string Login { get; set; }
        private string Password { get; init; }
        public Role UserRole { get; set; }

        public User(string login, string password, Enum userRole)
        {
            Login = login;
            Password = password;
            UserRole = (Role)userRole;
            Id = _id++;
        }

        public void GetUserDetails()
        {
            Console.WriteLine("ID:{0} Login: {1}, Role: {2}", Id, Login, UserRole);
        }

        public void AddUser(string login, string password, Role role)
        {
            User user = new User(login, password, role);
            UsersList.Add(user);
        }

        public void DeleteUser(int id, string login)
        {
            var userToRemove = UsersList.Single(u => (u.Id == id && u.Login == login));
            UsersList.Remove(userToRemove);
        }

    }
}
