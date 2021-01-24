using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.SubscriptionActions
{
    public class SubsctiptionDeleteAction : IAction
    {
        private readonly SubscriptionRepository _subscriptionRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Subsctiption";

        public SubsctiptionDeleteAction(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public void Call()
        {
            Console.Clear();
            var subscriptions = _subscriptionRepository.GetAll();
            if(subscriptions.Count == 0)
            {
                Console.WriteLine("There are no subscriptions yet");
                Console.ReadKey();
                return;
            }
            foreach(var subscription in subscriptions)
            {
                Console.WriteLine($"{subscription.ToString()} \n");
            }

            Console.WriteLine($"Enter subscription id to delete, or leave empty to exit");

            var isInputed = ReadHelpers.IntInputValidation(out var searchId);
            if (!isInputed)
                return;

            var response = _subscriptionRepository.Delete(searchId);
            if(response == Domain.ResponseResultType.NotFound)
            {
                Console.WriteLine($"There is no subsctiption with id - {searchId}");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Subscription deleted");
                Console.ReadKey();
                return;
            }
                
        }
    }
}
