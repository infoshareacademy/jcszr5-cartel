using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        public Task CreateSubscription(SubscriptionModel dbSubscriptionModel);
        public Task CancelSubscription(Guid id);

        public IQueryable<SubscriptionModel> GetAllSubscriptionEmails();

    }
}
