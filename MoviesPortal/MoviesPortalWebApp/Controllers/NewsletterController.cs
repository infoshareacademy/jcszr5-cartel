using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class NewsletterController : Controller
    {
        #region Email Newsletter

        // GET: NewsletterController/Create email newsletter
        public ActionResult CreateNewsletterEmail()
        {
            var newsletter = new NewsletterVM();

            return View(newsletter);
        }

        // POST: NewsletterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmail(IFormCollection collection)
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
