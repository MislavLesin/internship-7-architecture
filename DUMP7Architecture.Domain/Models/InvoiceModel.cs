using DUMP7Architecture.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public DateTime DateOfPutchase { get; set; }

        public Employe Employe {get;set;}

        public Customer Customer { get; set; }

        public ICollection<ProductInvoice> ModelProductInvoices { get; set; }

        public ICollection<SubscriptionInvoice> ModelSubscriptionInvoices { get; set; }

    }
}
