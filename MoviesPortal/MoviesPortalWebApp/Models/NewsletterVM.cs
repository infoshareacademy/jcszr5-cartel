using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class NewsletterVM
    {
        public string NewsletterSubject { get; set; }

        [BindProperty, MaxLength(300)]
        public string NewsletterContent { get; set; }
    }
}
