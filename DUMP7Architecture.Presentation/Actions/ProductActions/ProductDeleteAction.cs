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
    public class ProductDeleteAction : IAction
    {
        private readonly ProductRepository _productRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Product";

        public ProductDeleteAction(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Call()
        {
            Console.Clear();
            var allProducts = _productRepository.GetAll();
            if(allProducts.Count == 0)
            {
                Console.WriteLine("No products to delete");
                return;
            }
            PrettyPrint.PrintProducts(allProducts);

            Console.WriteLine("Enter Product Id or leave empty to exit");
            var isInputed = ReadHelpers.IntInputValidation(out var searchId);
            if (!isInputed)
                return;

            var response = _productRepository.Delete(searchId);
            if(response == ResponseResultType.NotFound)
                Console.WriteLine("Product Not Found");

            if(response == ResponseResultType.Success)
                Console.WriteLine("Product deleted successfully");

            Console.ReadLine();
            Console.Clear();
        }
    }
}
