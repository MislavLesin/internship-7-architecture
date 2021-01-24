using DUMP7Architecture.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductsEnum ProductType { get; set; }

        public decimal Price { get; set; }

        public int ProductsInStock {get; set;}

        public ICollection<ProductCategory> ProductCategories { get; set; }


        public override string ToString()
        {
            if(ProductType == ProductsEnum.Service)
            {
                return ($"Id - {Id} \n" +
               $"Name - {Name}\n" +
               $"Type - {ProductType}\n" +
               $"Price - {Price}\n" +
               $"In Stock - {IsAvailable(ProductsInStock)}");
            }
            return ($"Id - {Id} \n" +
                $"Name - {Name}\n" +
                $"Type - {ProductType}\n" +
                $"Price - {Price}\n" +
                $"In Stock - {ProductsInStock}");
            
        }

        private bool IsAvailable(int inStock)
        {
            if (inStock > 0)
                return true;
            return false;
        }

    }
}
