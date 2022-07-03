using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class NewsletterVM
    {
        public string NewsletterSubject { get; set; }

        [DataType(DataType.MultilineText)]
        public string NewsletterContent { get; set; }
    }
}
