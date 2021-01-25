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

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }


        public SubscriptionInvoice()
        {

        }

        public SubscriptionInvoice(Subscription subscription)
        {
            Name = subscription.Name;
            Description = subscription.Description;
            PricePerDay = subscription.PricePerDay;
        }
        public SubscriptionInvoice(SubscriptionInvoice si)
        {
            Name = si.Name;
            Description = si.Description;
            PricePerDay = si.PricePerDay;
            SubscriptionStartDate = si.SubscriptionStartDate;
            SubscriptionEndDate = si.SubscriptionEndDate;
            CustomerId = si.CustomerId;
        }

        public override string ToString()
        {
            if(Customer != null)
            {
                return ($"Subscription Name - {Name} \n" +
               $"Subscription Description - {Description} \n" +
               $"Subscription Start Date - {SubscriptionStartDate}\n" +
               $"Subscription end Date - {SubscriptionEndDate}\n" +
               $"Price - {PricePerDay} \n" +
               $"Customer - {Customer.FirstName} {Customer.LastName}" +
               $"===============================================\n");
            }
            else
            {
                return ($"Subscription Name - {Name} \n" +
              $"Subscription Description - {Description} \n" +
              $"Subscription Start Date - {SubscriptionStartDate}\n" +
              $"Subscription end Date - {SubscriptionEndDate}\n" +
              $"Price - {PricePerDay } \n" +
              $"===============================================\n");
            }
           
        }
    }
}
