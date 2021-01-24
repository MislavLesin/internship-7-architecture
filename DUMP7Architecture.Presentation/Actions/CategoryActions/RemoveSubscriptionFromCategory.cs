using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.CategoryActions
{
    public class RemoveSubscriptionFromCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Remove Subscription from Category";

        public RemoveSubscriptionFromCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var subscriptions = _categoryRepository.GetAllSubscriptions();
            Helpers.PrettyPrint.PrintSubscriptions(subscriptions);
            Console.WriteLine($"Enter subscription Id to remove from category :");

            var isEntered = ReadHelpers.IntInputValidation(out var subscriptionId);

            if (!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var selectedSubscription = subscriptions.First(c => c.Id == subscriptionId);

            if (selectedSubscription != null)
            {
                SelectCategory(subscriptionId);
            }
            else
                Console.WriteLine($"There is no subscription with Id {subscriptionId}");

            Console.ReadKey();
            return;


        }

        public void SelectCategory(int subscriptionId)
        {
            var categories = _categoryRepository.GetAllCategoriesOfSubscription(subscriptionId);
            if (categories.Count == 0)
            {
                Console.WriteLine("This Subscription is not yet in a Category");
                Console.ReadKey();
                return;
            }
            Helpers.PrettyPrint.PrintCategories(categories);

            Console.WriteLine($"Enter Category Id to remove from :");
            var isEnteredC = ReadHelpers.IntInputValidation(out var categoryId);
            if (!isEnteredC)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var categoryToRemove = categories.First(c => c.Id == categoryId);

            if (categoryToRemove != null)
            {
                var response = _categoryRepository.RemoveSubscriptionFromCategory(subscriptionId,categoryId);
                if (response == Domain.ResponseResultType.Success)
                {
                    Console.WriteLine($"Executed successfuly!");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine($"There is no Category with Id - {categoryId}");
                Console.ReadKey();
                return;
            }
        }
    }
}
