using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public bool ServiceAvailable{ get; set; }

        public ICollection<SubscriptionCategory> SubscriptionCategories{ get; set; }

        public override string ToString()
        {
            return ($"Id - {Id} \n" +
                $"Name - {Name}\n" +
                $"Description - {Description}\n" +
                $"Price per day - {PricePerDay}\n" +
                $"Service available - {ServiceAvailable}");
        }

       
    }
}
