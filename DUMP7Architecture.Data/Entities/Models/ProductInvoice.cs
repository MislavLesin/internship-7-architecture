using DUMP7Architecture.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class ProductInvoice
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductsEnum ProductType { get; set; }

        public decimal Price { get; set; }

        public int NumberOfProducts { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public ProductInvoice()
        {

        }

        public ProductInvoice(ProductInvoice pi)
        {
            Id = pi.Id;
            Name = pi.Name;
            ProductType = pi.ProductType;
            Price = pi.Price;
            NumberOfProducts = pi.NumberOfProducts;
        }

        public ProductInvoice(Product product)
        {
            Name = product.Name;
            ProductType = product.ProductType;
            Price = product.Price;
        }
        public override string ToString()
        {
            return ($"Product Name - {Name} \n" +
                $"Product Type - {ProductType}\n" +
                $"Price for {NumberOfProducts} products - {Price * NumberOfProducts} \n" +
                $"Number of products - {NumberOfProducts} \n" +
                $"===============================================\n");
        }
    }
}
