using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public ICollection<ProductInvoice> ProductInvoices { get; set; }

        public ICollection<SubscriptionInvoice> SubscriptionInvoices { get; set; }

        public int EmployeId { get; set; }

        public Employe Employe { get; set; }

       
    }
}
