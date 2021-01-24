using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Domain;
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
    public class SubscriptionEditAction : IAction
    {
        private readonly SubscriptionRepository _subscriptionRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit Subscription";

        public SubscriptionEditAction(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public void Call()
        {
            var subscriptions = _subscriptionRepository.GetAll();

            if(subscriptions.Count == 0)
            {
                Console.WriteLine($"There are no subscriptions yet");
                Console.ReadKey();
                return;
            }

            foreach(var subscription in subscriptions)
            {
                Console.WriteLine($"{subscription.ToString()} \n");
            }

            Console.WriteLine("Enter subscription Id to Edit, leave empty to exit");
            var isSelected = ReadHelpers.IntInputValidation(out var subscriptionId);
            if (!isSelected)
                return;
            var subscriptionToEdit = subscriptions.First(s => s.Id == subscriptionId);

            if (subscriptionToEdit == null)
            {
                Console.WriteLine("Subscription not found");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            Console.WriteLine("Press enter to skip edit");

            Console.WriteLine($"Name: ({subscriptionToEdit.Name})");
            subscriptionToEdit.Name = ReadHelpers.StringInputValidationNullable(out var name)
                ? name
                : subscriptionToEdit.Name;

            Console.WriteLine($"Description: ({subscriptionToEdit.Description})");
            subscriptionToEdit.Description = ReadHelpers.StringInputValidationNullable(out var description)
                ? description
                : subscriptionToEdit.Description;

            Console.WriteLine($"Price per day : ({subscriptionToEdit.PricePerDay})");
            subscriptionToEdit.PricePerDay = ReadHelpers.IntInputValidationNullable(out var price)
                ? price
                : subscriptionToEdit.PricePerDay;

            Console.WriteLine($"Service available :\n" +
                    $"0 - Not available \n" +
                    $"1 - Available");
            var isAvailable = ReadHelpers.IntegerInputBetween(0, 1);
            if (isAvailable == 1)
                subscriptionToEdit.ServiceAvailable = true;
            else
                subscriptionToEdit.ServiceAvailable = false;

            var response = _subscriptionRepository.Edit(subscriptionToEdit, subscriptionId);

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(subscriptionToEdit.ToString());
            Console.ReadKey();
        }
    }
}
