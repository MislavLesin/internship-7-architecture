using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(ModelsDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Employe> GetAllEmplyees()
        {
            return DbContext.Employes.ToList();
        }

        public ICollection<Category> GetAllCategories()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            var query = DbContext.Categories
                .Where(c => c.Id == categoryId).FirstOrDefault();
            return query;
        }

        public ICollection<Product> GetProductsByCategory(int categoryId)
        {
            var querry = DbContext.ProductCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Join(DbContext.Products,
                pc => pc.ProductId,
                p => p.Id,
                (pc, p) => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductType = p.ProductType,
                    ProductsInStock = p.ProductsInStock,
                    Price = p.Price
                }
                );
            return querry.ToList();
        }

        public ICollection<Invoice> GetAllInvoices()
        {
            var querry = DbContext.Invoices.ToList();
            return querry;
        }

        public Employe GetEmplyeeFromInvoice(int empId)
        {
            var querry = DbContext.Employes.Where(emp => emp.Id == empId).FirstOrDefault();
            return querry;
        }
       
        public List<ProductInvoice> GetProductsFromInvocie(int invId)
        {
            var querry = DbContext.ProductInvoices.Where(pi => pi.InvoiceId == invId).ToList();
            return querry;
        }

        public List<SubscriptionInvoice> GetSubscriptionsFromInvoice(int invId)
        {
            var querry = DbContext.SubscriptionInvoices.Where(pi => pi.InvoiceId == invId).ToList();
            return querry;
        }
    }
}
