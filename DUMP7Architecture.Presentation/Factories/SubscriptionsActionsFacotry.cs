using DUMP7Architecture.Domain.Factories;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Actions.SubscriptionActions;
using System.Collections.Generic;

namespace DUMP7Architecture.Presentation.Factories
{
    public class SubscriptionsActionsFacotry
    {
        public static SubscriptionParentAction GetSubscriptionParentAction()
        {
            var subscriptionActions = new List<IAction>
            {
               new SubscriptionAddAction(RepositoryFactory.GetRepository<SubscriptionRepository>()),
               new SubsctiptionDeleteAction(RepositoryFactory.GetRepository<SubscriptionRepository>()),
               new SubscriptionEditAction(RepositoryFactory.GetRepository<SubscriptionRepository>()),
               new ExitMenuAction()
            };

            var subscriptionParentAction = new SubscriptionParentAction(subscriptionActions);
            return subscriptionParentAction;
        }
    }
}
