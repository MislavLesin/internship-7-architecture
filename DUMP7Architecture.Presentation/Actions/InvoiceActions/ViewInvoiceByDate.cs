using DUMP7Architecture.Domain.Models;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DUMP7Architecture.Presentation.Actions.InvoiceActions
{
    public class ViewInvoiceByYear : IAction
    {
        private readonly InvoiceRepository _invoiceRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "View invocie By Year";

        public ViewInvoiceByYear(InvoiceRepository invoice)
        {
            _invoiceRepository = invoice;
        }


        public void Call()
        {
            Console.Clear();
            var invoicesList = new List<InvoiceModel>();
            var invoices = _invoiceRepository.GetAllInvoices();

            foreach (var invoice in invoices)
            {
                var invoiceModel = new InvoiceModel();
                invoiceModel.Id = invoice.Id;
                invoiceModel.DateOfPutchase = invoice.DateOfPurchase;
                invoiceModel.Employe = invoice.Employe;
                invoiceModel.ModelProductInvoices = _invoiceRepository.GetProductsFromInvocie(invoice.Id);
                invoiceModel.ModelSubscriptionInvoices = _invoiceRepository.GetSubscriptionsFromInvoice(invoice.Id);
                invoicesList.Add(invoiceModel);
            }
            Console.WriteLine("Enter the year :");
            var valid = ReadHelpers.IntInputValidationNullable(out var year);
            PrintInvoiceModels(invoicesList,year);
            Console.ReadKey();


        }

        private void PrintInvoiceModels(List<InvoiceModel> invoices, int year)
        {
            foreach (var inv in invoices.Where(i => i.DateOfPutchase.Year == year))
            {
                Console.WriteLine($"+++++++++++++++++++++++++++++++++++++++++\n" +
                    $"Id - {inv.Id} \n" +
                    $"Date of purchase - {inv.DateOfPutchase}\n");
                if (inv.ModelProductInvoices.Count != 0)
                {
                    foreach (var product in inv.ModelProductInvoices)
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
                if (inv.ModelSubscriptionInvoices.Count != 0)
                {
                    foreach (var subscription in inv.ModelSubscriptionInvoices)
                    {
                        Console.WriteLine(subscription.ToString());
                    }
                }
            }
        }
    }
}
