using DUMP7Architecture.Data.Enums;
using DUMP7Architecture.Domain;
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
    public class ProductEditAction : IAction
    {
        private readonly ProductRepository _productRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit Product";

        public ProductEditAction(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Call()
        {
            var products = _productRepository.GetAll();

            foreach(var product in products)
                Console.WriteLine($"{product.ToString()} \n");

            Console.WriteLine("Enter product Id to Edit, leave empty to exit");

            var isSelected = ReadHelpers.IntInputValidation(out var productId);
            if (!isSelected)
                return;

            var productToEdit = products.First(p => p.Id == productId);

            if(productToEdit == null)
            {
                Console.WriteLine("Product not found");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Press enter to skip edit");

            Console.WriteLine($"Name: ({productToEdit.Name})");
            productToEdit.Name = ReadHelpers.StringInputValidationNullable(out var name)
                ? name
                : productToEdit.Name;

            Console.WriteLine($"Price : ({productToEdit.Price})");
            productToEdit.Price = ReadHelpers.IntInputValidationNullable(out var price)
                ? price
                : productToEdit.Price;

            Console.WriteLine($"Product type - ({productToEdit.ProductType})");
            Console.WriteLine($"0 - {ProductsEnum.Article}");
            Console.WriteLine($"1 - {ProductsEnum.Service}");
            productToEdit.ProductType = ReadHelpers.ProductTypeInput(out int productType)
                ? (ProductsEnum)productType
                : productToEdit.ProductType;

            if(productToEdit.ProductType == ProductsEnum.Service)
            {
                Console.WriteLine($"Product available :\n" +
                    $"0 - Not available \n" +
                    $"1 - Available");
                productToEdit.ProductsInStock = ReadHelpers.IntegerInputBetween(0, 1);
            }
            else
            {
                Console.WriteLine($"Number of articles in stock ({productToEdit.ProductsInStock})");
                productToEdit.ProductsInStock = ReadHelpers.IntInputValidation(out int input)
                    ? input
                    : productToEdit.ProductsInStock;
            }

            var response = _productRepository.Edit(productToEdit, productId);

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
                Console.ReadKey();
                return;
            }
           
            Console.WriteLine(productToEdit.ToString());
            Console.ReadKey();
        }
    }
}
