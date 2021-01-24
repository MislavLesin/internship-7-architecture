using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Data.Enums;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.ProductActions
{
    public class ProductAddAction : IAction
    {
        private readonly ProductRepository _productRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Product";

        public ProductAddAction(ProductRepository productRepostory)
        {
            _productRepository = productRepostory;  
        }

        public void Call()
        {
            var product = new Product();

            Console.WriteLine("Name :");
            product.Name = ReadHelpers.StringNotEmptyValidation();
            if(CheckIfExists(product.Name))
            {
                Console.WriteLine($"Product with name {product.Name} allready exists!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Is this a : \n1 - Article \n2 - Service?");
            product.ProductType = (ProductsEnum)ReadHelpers.IntegerInputBetween(1, 2) - 1;

            Console.WriteLine("Price :");
            product.Price = ReadHelpers.IntInputValidation(out var price) ? price : -1;

            Console.WriteLine("Number of products in stock : ");
            product.ProductsInStock = ReadHelpers.IntInputValidation(out var stock) ? stock : -1;

            var responseResult = _productRepository.Add(product);

            if(responseResult == Domain.ResponseResultType.Success)
            {
                Console.WriteLine("Success! \n");
                PrettyPrint.PrintProduct(product);
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Failed to save product, no changes applied.");
            Console.ReadLine();
        }
        public bool CheckIfExists(string name)
        {
            var products = _productRepository.GetAll();
            foreach(var product in products)
            {
                if (string.Compare(product.Name, name, comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
            }
            return false;
        }
    }
}
