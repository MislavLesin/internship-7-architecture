using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
   public class SubscriptionInvoice
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public DateTime SubscriptionStartDate { get; set; }

        public DateTime SubscriptionEndDate { get; set; }

        public ICollection<Category> ProductCategories { get; set; }
    }
}
