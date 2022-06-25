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
        public async Task<IActionResult> Create(MoviesAndSubscriptionVM model)
        {
            bool IsAlreadySubscribed = _subscriptionService.GetAllSubscriptions().Any(s => s.Email == model.Subscription.Email);
            if (!IsAlreadySubscribed)
            {
                SubscriptionModel subscription = new();
                subscription.Id = Guid.NewGuid();
                subscription.FirstName = model.Subscription.FirstName;
                subscription.Email = model.Subscription.Email;

                await _subscriptionService.CreateSubscription(subscription);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
