using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using System;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportProducs: IAction
    {
        private readonly ProductRepository _productRepository;

        public int MenuIndex { get; set; }

        public string Label { get; set; } = "Show All Products";

        public ReportProducs(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Call()
        {
            var productsList = _productRepository.GetAll();
            if(productsList.Count == 0)
            {
                Console.WriteLine("No products yet");
            }
            else
            {
                foreach (var product in productsList)
                    Console.WriteLine($"{product.ToString()} \n");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
