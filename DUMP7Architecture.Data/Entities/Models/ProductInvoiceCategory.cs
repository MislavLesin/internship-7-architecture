using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class ProductInvoiceCategory
    {
        public int Id { get; set; }
        public int ProductInvoiceId { get; set; }

        public ProductInvoice ProductInvoice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
