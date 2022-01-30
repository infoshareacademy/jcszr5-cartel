namespace MoviesPortal.Interface
{
    public interface IUserReader
    {
        public void GetUser();
    }

    interface IUserWriter
    {
        public void AddUser();
    }

    interface IUserPremium
    {
        public void GetPremium();
    }
}