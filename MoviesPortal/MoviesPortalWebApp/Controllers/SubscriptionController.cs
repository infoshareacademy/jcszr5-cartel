using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPortalWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        public IActionResult CreateSubscription()
        {

        }
    }
}
