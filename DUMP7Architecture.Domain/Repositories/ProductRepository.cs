using DUMP7Architecture.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(ModelsDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Product product)
        {
            if(DbContext.Products.Find(product.Id) == null)
            {
                DbContext.Products.Add(product);
                return SaveChanges();
            }
            else
            {
                return ResponseResultType.AlreadyExists;
            }
           
        }

        public ICollection<Product> GetAll()
        {
            return DbContext.Products.ToList();
        }

        public ResponseResultType Delete(int productId)
        {
            var product = DbContext.Products.Find(productId);
            if (product == null)
                return ResponseResultType.NotFound;

            DbContext.Products.Remove(product);
            return SaveChanges();
        }

        public ResponseResultType Edit(Product eProduct,int productId)
        {
            var productInDb = DbContext.Products.Find(productId);

            if (productInDb == null)
                return ResponseResultType.NotFound;
            var exists = NameExists(eProduct);
            if (exists)
                return ResponseResultType.AlreadyExists;

            productInDb.Name = eProduct.Name;
            productInDb.Price = eProduct.Price;
            productInDb.ProductsInStock = eProduct.ProductsInStock;
            productInDb.ProductType = eProduct.ProductType;

            return SaveChanges();
        }

        private bool NameExists(Product product)
        {
            var exists = DbContext.Products.Where(p => p.Name == product.Name).ToList();
            if (exists.Count != 0)
                return true;
            return false;
        }
    }
}
