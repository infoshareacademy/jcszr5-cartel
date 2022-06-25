using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ISubscriptionService
    {
        public IQueryable<SubscriptionModel> GetAllSubscriptions();

        public Task CancelSubscription(Guid id);
        public Task CreateSubscription(SubscriptionModel subscription);
    }
}
