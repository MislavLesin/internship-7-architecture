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
    public class RemoveProductFromCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Remove Product from Category";

        public RemoveProductFromCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var products = _categoryRepository.GetAllProducts();
            Helpers.PrettyPrint.PrintProducts(products);
            Console.WriteLine($"Enter product Id to remove from category :");

            var isEntered = ReadHelpers.IntInputValidation(out var productId);

            if (!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var selectedProduct = products.First(c => c.Id == productId);

            if (selectedProduct != null)
            {
                var categories = _categoryRepository.GetAllCategoriesOfProduct(productId);
                if(categories.Count == 0)
                {
                    Console.WriteLine("This product is not yet in a Category");
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
                    var response = _categoryRepository.RemoveProductFromCategory(selectedProduct.Id, categoryToRemove.Id);
                    if (response == Domain.ResponseResultType.Success)
                    {
                        Console.WriteLine($"Executed successfuly! \n" +
                            $"{selectedProduct.Name} removed from {categoryToRemove.Name} category");
                    }
                }
                else
                {
                    Console.WriteLine($"There is no Category with Id - {categoryId}");
                    Console.ReadKey();
                    return;
                }
            }
            else
                Console.WriteLine($"There is no product with Id {productId}");

            Console.ReadKey();
            return;
        }
    }
}
