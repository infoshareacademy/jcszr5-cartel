using MoviesPortal.Data;
using MoviesPortal.Interface;
using MoviesPortal.Methods;

namespace MoviesPortal.UserService
{
    public class AdminUserService : IUserReader
    {
        public void GetUser()
        {
            // Read BD with admins accounts from json file
            var database = ReadData.ReadAdminsFromFile();

            // Check input admin login with DB
            var login = ValidateUser.ValidateUserLogin(database);

            // Check input admin password with DB
            ValidateUser validateUser = new ValidateUser();
            validateUser.ValidateUserPassword(login);
            LoginTyper.LoginType = "admin";
        }
    }
}
