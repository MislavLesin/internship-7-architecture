using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportSubscriptionsByCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Report all subscriptions in a category";
        public ReportSubscriptionsByCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            var categoryList = _categoryRepository.GetAll();

            Helpers.PrettyPrint.PrintCategories(categoryList);
            Console.WriteLine("Enter Category Id to filter subscriptions by :");
            var isInputed = ReadHelpers.IntInputValidation(out var catId);
            if (!isInputed)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            var categoryName = categoryList.FirstOrDefault(c => c.Id == catId);
            if(categoryName == null)
            {
                Console.WriteLine($"There is no category with Id - {catId}");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"\nCattegory slected - ({categoryName.Name})");
            var subscriptionsList = _categoryRepository.GetSubscriptionsInCategory(catId);

            if (subscriptionsList.Count == 0)
            {
                Console.WriteLine("This category has no subscriptions!");
                Console.ReadKey();
                return;
            }

            Helpers.PrettyPrint.PrintSubscriptions(subscriptionsList);

            Console.ReadKey();
            return;
        }
    }
}
