using MoviesPortal.Interface;

namespace MoviesPortal.UserService
{
    public class PremiumUserService : IUserReader, IUserWriter, IUserPremium
    {
        // TODO ...

        public void AddUser() { }
        
        public void GetPremium()
        {
            Console.WriteLine($"The cost of the premium package is 10 USD.");
        }

        public void GetUser() { }
    }
}
