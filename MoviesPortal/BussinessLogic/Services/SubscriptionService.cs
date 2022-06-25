using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task CancelSubscription(Guid id)
        {
            await _subscriptionRepository.CancelSubscription(id);
        }

        public async Task CreateSubscription(SubscriptionModel subscription)
        {
            await _subscriptionRepository.CreateSubscription(subscription);
        }

        public IQueryable<SubscriptionModel> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAllSubscriptionEmails();
        }
    }
}
