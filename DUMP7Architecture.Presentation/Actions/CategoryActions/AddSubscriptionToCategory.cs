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
    public class AddSubscriptionToCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Subscription to Category";

        public AddSubscriptionToCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var subscriptions = _categoryRepository.GetAllSubscriptions();
            Helpers.PrettyPrint.PrintSubscriptions(subscriptions);
            Console.WriteLine($"Enter subscription Id to add to a category :");

            var isEntered = ReadHelpers.IntInputValidation(out var subscriptionId);

            if (!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var subscriptionToAdd = subscriptions.FirstOrDefault(c => c.Id == subscriptionId);

            if (subscriptionToAdd != null)
            {
                var categories = _categoryRepository.GetAll();
                PrettyPrint.PrintCategories(categories);
                Console.WriteLine($"Enter Category Id to add {subscriptionToAdd.Name} to :");
                var isEnteredC = ReadHelpers.IntInputValidation(out var categoryId);

                if (!isEnteredC)
                {
                    Console.WriteLine("Exitting");
                    Console.ReadKey();
                    return;
                }

                var categoryToAddTo = categories.FirstOrDefault(c => c.Id == categoryId);

                if (categoryToAddTo != null)
                {
                    var response = _categoryRepository.AddSubscriptionToCategory(subscriptionToAdd.Id, categoryToAddTo.Id);
                    if (response == Domain.ResponseResultType.Success)
                    {
                        Console.WriteLine($"Executed successfuly! \n" +
                            $"Added {subscriptionToAdd.Name} to {categoryToAddTo.Name} category");
                    }
                    else if (response == Domain.ResponseResultType.AlreadyExists)
                    {
                        Console.WriteLine($"Subscription {subscriptionToAdd.Name} is allready in Category {categoryToAddTo.Name}");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"There is no Category with Id - {categoryId}");
                    Console.WriteLine("Exitting");
                    Console.ReadKey();
                    return;
                }
            }
            else
                Console.WriteLine($"There is no subscription with Id {subscriptionId}");
            Console.ReadKey();
            return;
        }
    }
}
