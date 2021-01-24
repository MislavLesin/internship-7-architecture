using DUMP7Architecture.Domain.Models;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.InvoiceActions
{
    public class GetAllInvoices : IAction
    {
        private readonly InvoiceRepository _invoiceRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Show all invoices";

        public GetAllInvoices(InvoiceRepository invoice)
        {
            _invoiceRepository = invoice;
        }

        public void Call()
        {
            Console.Clear();
            var invoicesList = new List<InvoiceModel>();
            var invoices = _invoiceRepository.GetAllInvoices();

            foreach(var invoice in invoices)
            {
                var invoiceModel = new InvoiceModel();
                invoiceModel.Id = invoice.Id;
                invoiceModel.DateOfPutchase = invoice.DateOfPurchase;
                invoiceModel.Employe = invoice.Employe;
                invoiceModel.ModelProductInvoices = _invoiceRepository.GetProductsFromInvocie(invoice.Id);
                invoiceModel.ModelSubscriptionInvoices = _invoiceRepository.GetSubscriptionsFromInvoice(invoice.Id);
                invoicesList.Add(invoiceModel);
            }
            Console.WriteLine($"There are {invoicesList.Count} invoices");
            Console.ReadKey();
            PrintInvoiceModels(invoicesList);
            Console.ReadKey();


        }

        private void PrintInvoiceModels(List<InvoiceModel> invoices)
        {
            foreach(var inv in invoices)
            {
                Console.WriteLine($"Id - {inv.Id} \n" +
                    $"Date of purchase - {inv.DateOfPutchase}\n");
                if(inv.ModelProductInvoices.Count != 0)
                {
                    foreach(var product in inv.ModelProductInvoices)
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
                if(inv.ModelSubscriptionInvoices.Count != 0)
                {
                    foreach(var subscription in inv.ModelSubscriptionInvoices)
                    {
                        Console.WriteLine(subscription.ToString());
                    }
                }
            }
        }
    }
}
