using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }



        #region Email Newsletter

        // GET: NewsletterController/Create email newsletter
        public ActionResult CreateNewsletterEmail()
        {
            var newsletter = new NewsletterVM();

            return View(newsletter);
        }

        // POST: NewsletterController/Create
        [HttpPost]
        /*        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateNewsletterEmail(NewsletterVM model)
        {
            {
                string message = model.NewsletterContent;
                string subject = model.NewsletterSubject;

                await _newsletterService.SendNewsletterToAllSubscribents(message, subject);

                return RedirectToAction("Admin", "Account");
            }
        }



        #endregion

        #region SMS Newsletter

        // GET: NewsletterController/Create SMS newsletter
        public ActionResult CreateSMS()
        {
            return View();
        }

        // POST: NewsletterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSMS(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }


}

