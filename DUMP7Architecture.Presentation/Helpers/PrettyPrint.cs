using DUMP7Architecture.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Helpers
{
    public static class PrettyPrint
    {
        public static void PrintProduct(Product product)
        {
            Console.WriteLine(product.ToString());
        }

        public static void PrintSubscriptions(ICollection<Subscription> subscriptions)
        {
            foreach(var subscription in subscriptions)
                Console.WriteLine($"{subscription.ToString()} \n");
        }
        public static void PrintProducts(ICollection<Product> products)
        {
            foreach(var product in products)
            {
                Console.WriteLine(product.ToString() + "\n");       
            }
        }

        public static void PrintCategories(ICollection<Category> categories)
        {
            foreach(var cat in categories)
            {
                Console.WriteLine(cat.ToString());
            }
        }
        public static void PrintCustomers(ICollection<Customer> customers)
        {
            foreach(var customer in customers)
                Console.WriteLine($"{customer.ToString()}\n");
        }
    }
}
