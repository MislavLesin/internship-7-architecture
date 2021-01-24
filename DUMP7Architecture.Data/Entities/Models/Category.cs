using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public ICollection<SubscriptionCategory> SubscriptionCategories { get; set; }

        public ICollection<ProductInvoiceCategory> ProductInvoiceCategories{ get; set; }

        public ICollection<SubscriptionInvoiceCategory> SubscriptionInvoiceCategories{ get; set; }

        public override string ToString()
        {
            return ($"Category Id - {Id} \n" +
                $"Category Name - {Name} \n");
        }
    }
}
