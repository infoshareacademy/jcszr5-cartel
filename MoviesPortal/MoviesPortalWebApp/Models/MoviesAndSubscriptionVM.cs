namespace MoviesPortalWebApp.Models
{
    public class MoviesAndSubscriptionVM
    {
        public IEnumerable<MovieVM> Movies { get; set; }

        public SubscriptionVM Subscription { get; set; }

    }
}
