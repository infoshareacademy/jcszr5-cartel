namespace MoviesPortalWebApp.Models
{
    public class ProvidersStoreVM
    {
        public string Link { get; set; }

        public List<ProviderVM> Buy { get; set; }

        public List<ProviderVM> Rent { get; set; }

        public List<ProviderVM> Flatrate { get; set; }
    }
}
