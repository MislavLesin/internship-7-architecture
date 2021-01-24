using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportSubscriptions : IAction
    {
        private readonly SubscriptionRepository _subscriptionRepository;

        public int MenuIndex { get; set; }

        public string Label { get; set; } = "Show All Subsctiptions";
        public ReportSubscriptions(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public void Call()
        {
            Console.Clear();
            var subscriptions = _subscriptionRepository.GetAll();
            if (subscriptions.Count() == 0)
                Console.WriteLine("No Subscriptions yet!");
            else
            {
                foreach (var subcription in subscriptions)
                {
                    Console.WriteLine(subcription.ToString());
                    Console.WriteLine("\n");
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
