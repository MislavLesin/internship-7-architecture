using DUMP7Architecture.Data.Entities.Models;
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
    public class SubscriptionAddAction: IAction
    {
        private readonly SubscriptionRepository _subsctiptionRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Subscription";

        public SubscriptionAddAction(SubscriptionRepository subsctiptionRepository)
        {
            _subsctiptionRepository = subsctiptionRepository;
        }

        public void Call()
        {
            var subscription = new Subscription();

            Console.WriteLine("Name :");
            subscription.Name = ReadHelpers.StringNotEmptyValidation();

            Console.WriteLine("Description :");
            subscription.Description = ReadHelpers.StringNotEmptyValidation();

            Console.WriteLine("Price per day :");
            subscription.PricePerDay = ReadHelpers.IntInputValidation(out var price) ? price : -1;

            Console.WriteLine("Is this service available? \n1 - yes\t 0 - no");
            var serviceAvailable = ReadHelpers.IntegerInputBetween(0, 1);
            if (serviceAvailable == 1)
                subscription.ServiceAvailable = true;

            var responseResult = _subsctiptionRepository.Add(subscription);

            if (responseResult == Domain.ResponseResultType.Success)
            {
                Console.WriteLine("Success! \n");
                Console.WriteLine(subscription.ToString());
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Failed to save product, no changes applied.");
            Console.ReadLine();
        }
    }
}
