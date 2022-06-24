namespace MoviesPortalWebApp.Models
{
    public class SubscriptionVM
    {
        public Guid Id = new Guid();
        public string? FirstName { get; set; }
        public string? Email { get; set; }
    }
}
