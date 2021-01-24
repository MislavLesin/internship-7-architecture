using DUMP7Architecture.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class SubscriptionRepository : BaseRepository
    {
        public SubscriptionRepository(ModelsDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Subscription subscription)
        {
            if (DbContext.Subscriptions.Find(subscription.Id) != null)
            {
                return ResponseResultType.AlreadyExists;
            }
            else
            {
                DbContext.Subscriptions.Add(subscription);
                return SaveChanges();
            }
        }

        public ICollection<Subscription> GetAll()
        {
            return DbContext.Subscriptions.ToList();
        }

        public ResponseResultType Delete(int subscriptionId)
        {
            var subsription = DbContext.Subscriptions.Find(subscriptionId);
            if (subsription == null)
                return ResponseResultType.NotFound;

            DbContext.Subscriptions.Remove(subsription);
            return SaveChanges();
        }

        public ResponseResultType Edit(Subscription newSubscription, int subscriptionId)
        {
           
            var subscriptionToEdit = DbContext.Subscriptions.Find(subscriptionId);
            if (subscriptionToEdit == null)
                return ResponseResultType.NotFound;
            var exists = NameExists(newSubscription);
            if (exists)
                return ResponseResultType.AlreadyExists;

            subscriptionToEdit.Name = newSubscription.Name;
            subscriptionToEdit.PricePerDay = newSubscription.PricePerDay;
            subscriptionToEdit.Description = newSubscription.Description;
            subscriptionToEdit.ServiceAvailable = newSubscription.ServiceAvailable;

            return SaveChanges();
        }

        private bool NameExists(Subscription subscription)
        {
            var exists = DbContext.Subscriptions.Where(p => p.Name == subscription.Name).ToList();
            if (exists.Count != 0)
                return true;
            return false;
        }
    }
}
