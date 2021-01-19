using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class SubscriptionCategory
    {
        public int? SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
