using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionVM model)
        {
            SubscriptionModel subscription = new();

            subscription.Id = new Guid();
            subscription.FirstName = model.FirstName;
            subscription.Email = model.Email;

            await _subscriptionService.CreateSubscription(subscription);

            return RedirectToAction("Index");
        }
    }
}
