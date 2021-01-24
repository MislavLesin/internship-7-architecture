using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(ModelsDbContext dbContext) : base (dbContext)
        {
        }

        public ResponseResultType Add(Category category)
        {
            DbContext.Categories.Add(category);
            return SaveChanges();
        }

        public ICollection<Category> GetAll()
        {
            return DbContext.Categories.ToList();
        }

        public ResponseResultType Delete(int categoryId)
        {
            var category = DbContext.Categories.Find(categoryId);
            if (category == null)
                return ResponseResultType.NotFound;
            DbContext.Categories.Remove(category);
            return SaveChanges();
        }

        public ResponseResultType Edit(Category eCategory, int categoryId)
        {
            var categoryToEdit = DbContext.Categories.Find(categoryId);
            if (categoryToEdit == null)
                return ResponseResultType.NotFound;
            var allreadyExists = DbContext.Categories
                .Where(c => c.Name == eCategory.Name).ToList();
            if (allreadyExists.Count != 0)
                return ResponseResultType.AlreadyExists;

            categoryToEdit.Name = eCategory.Name;
            return SaveChanges();
        }

        public ICollection<ProductsByCategory> GetProductsInCategory(int catId)
        {
            var querry = DbContext.ProductCategories
                .Where(pc => pc.CategoryId == catId)
                .Join(DbContext.Products,
                pc => pc.ProductId,
                p => p.Id,
                (pc, p) => new ProductsByCategory
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

        public ICollection<Subscription> GetSubscriptionsInCategory(int catId)
        {
            var querry = DbContext.SubscriptionCategories
                .Where(sc => sc.CategoryId == catId)
                .Join(DbContext.Subscriptions,
                sc => sc.CategoryId,
                p => p.Id,
                (sc, p) => new Subscription
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ServiceAvailable = p.ServiceAvailable,
                    PricePerDay = p.PricePerDay
                }
                );
            return querry.ToList();
        }

        public ResponseResultType AddProductToCategory(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };
            var allreadyExists = DbContext.ProductCategories.Where(pc => pc.ProductId == productId && pc.CategoryId == categoryId).FirstOrDefault();
            if (allreadyExists != null)
                return ResponseResultType.AlreadyExists;
            DbContext.ProductCategories.Add(productCategory);
            return SaveChanges();
        }

        public ResponseResultType AddSubscriptionToCategory(int subscriptionId, int categoryId)
        {

            var subscriptionCategory = new SubscriptionCategory
            {
                SubscriptionId = subscriptionId,
                CategoryId = categoryId
            };
            var allreadyExists = DbContext.SubscriptionCategories.Where(sc => sc.CategoryId == categoryId && sc.SubscriptionId == subscriptionId).ToList();
            if (allreadyExists.Count != 0)
                return ResponseResultType.AlreadyExists;
            else
            {
                DbContext.SubscriptionCategories.Add(subscriptionCategory);
                return SaveChanges();
            }
           
        }

        public ResponseResultType RemoveProductFromCategory(int productId, int categoryId)
        {
            var productCategory = DbContext.ProductCategories.Where(pc => pc.CategoryId == categoryId).Where(pc => pc.ProductId == productId).First();
            DbContext.ProductCategories.Remove(productCategory);
            return SaveChanges();
        }

        public ResponseResultType RemoveSubscriptionFromCategory(int subscriptionId,int categoryId)
        {
            var subscriptionCategory = DbContext.SubscriptionCategories
                .Where(sc => sc.SubscriptionId == subscriptionId && sc.CategoryId == categoryId).First();
            DbContext.Remove(subscriptionCategory);
            return SaveChanges();
        }

        public ICollection<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }

        public ICollection<Subscription> GetAllSubscriptions()
        {
            return DbContext.Subscriptions.ToList();
        }

        public List<Category> GetAllCategoriesOfSubscription(int subscriptionId)
        {
            var subscriptionCategories = DbContext.SubscriptionCategories.Where(sc => sc.SubscriptionId == subscriptionId)
                .Join(DbContext.Subscriptions,
                sc => sc.CategoryId,
                s => s.Id,
                (sc, s) => new Category
                {
                    Id = s.Id,
                    Name = s.Name
                }
                );
            return subscriptionCategories.ToList();
        }

        public List<Category> GetAllCategoriesOfProduct(int productId)
        {
            var querry = DbContext.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .Join(DbContext.Categories,
                pc => pc.CategoryId,
                p => p.Id,
                (pc, p) => new Category
                {
                    Id = p.Id,
                    Name = p.Name
                }
                );
            return querry.ToList();
        }
    }
}
