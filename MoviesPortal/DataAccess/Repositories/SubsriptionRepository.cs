using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly MoviePortalContext _context;

        public SubscriptionRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task CreateSubscription(SubscriptionModel dbSubscriptionModel)
        {
            _context.Subscriptions.Add(dbSubscriptionModel);
            await _context.SaveChangesAsync();
        }

        public async Task CancelSubscription(Guid id)
        {
            var subscriptions = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
            _context.Subscriptions.Remove(subscriptions);
            await _context.SaveChangesAsync();
        }

        public IQueryable<SubscriptionModel> GetAllSubscriptionEmails()
        {
            return _context.Subscriptions.AsQueryable();
        }
    }
}
