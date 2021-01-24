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

        public ICollection<SubscriptionInvoiceCategory> SubscriptionInvoiceCategories { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public int InvoiceId { get; set; }

        public override string ToString()
        {
            return ($"Subscription Name - {Name} \n" +
                $"Subscription Description - {Description} \n" +
                $"Subscription Start Date - {SubscriptionStartDate}\n" +
                $"Subscription end Date - {SubscriptionEndDate}" +
                $"Price - {PricePerDay} \n" +
                $"===============================================\n");
        }
    }
}
