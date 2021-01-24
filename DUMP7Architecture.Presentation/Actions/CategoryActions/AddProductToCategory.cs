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
    public class AddProductToCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Product to Category";

        public AddProductToCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var products = _categoryRepository.GetAllProducts();
            Helpers.PrettyPrint.PrintProducts(products);
            Console.WriteLine($"Enter product Id to add to a category :");

            var isEntered = ReadHelpers.IntInputValidation(out var productId);

            if (!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var productToAdd = products.FirstOrDefault(c => c.Id == productId);

            if (productToAdd != null)
            {
                var categories = _categoryRepository.GetAll();
                PrettyPrint.PrintCategories(categories);
                Console.WriteLine($"Enter Category Id to add{productToAdd.Name} to :");
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
                   var response = _categoryRepository.AddProductToCategory(productToAdd.Id, categoryToAddTo.Id);
                    if(response == Domain.ResponseResultType.Success)
                    {
                        Console.WriteLine($"Executed successfuly! \n" +
                            $"Added {productToAdd.Name} to {categoryToAddTo.Name} category");
                    }
                    else if (response == Domain.ResponseResultType.AlreadyExists)
                    {
                        Console.WriteLine($"Product {productToAdd.Name} is allready in Category {categoryToAddTo.Name}");
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
                Console.WriteLine($"There is no product with Id {productId}");
            Console.ReadKey();
            return;
        }
    }
}
