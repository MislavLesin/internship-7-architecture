using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Domain.Models;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.InvoiceActions
{
    public class AddNewInvoice : IAction
    {
        private readonly InvoiceRepository _invoiceRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Create new invoice";

        public AddNewInvoice(InvoiceRepository invoice)
        {
            _invoiceRepository = invoice;
        }

        public void Call()
        {
            Console.Clear();
            var invoiceModel = new InvoiceModel();
            Console.WriteLine($"Who is entering an invoice?");
            Thread.Sleep(1000);
            var emplyes = _invoiceRepository.GetAllEmplyees();
            foreach(var emplye in emplyes)
            {
                Console.WriteLine($"Name - {emplye.FirstName} {emplye.LastName} \n)" +
                    $"Id - {emplye.Id}\n");
            }
            var isEntered = ReadHelpers.IntInputValidation(out var emplyeId);

            if (!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }
            var emplyeToAdd = emplyes.FirstOrDefault(c => c.Id == emplyeId);

            if (emplyeToAdd != null)
            {
                SetEmplyeToModel(invoiceModel, emplyeToAdd);
                Console.WriteLine("Type :\n1 for Articles / Services/\n");
                Console.WriteLine("2 for Subscriptions");
                var decision = ReadHelpers.IntegerInputBetween(1, 2);
                if(decision == 1)
                {
                    /////////////ode ide
                }
                
            }
            else
            {
                Console.WriteLine("Exiting");
                Console.ReadKey();
                return;
            }
        }

        private bool AddingProducts(InvoiceModel model)     //selecting category
        {
            var categories = _invoiceRepository.GetAllCategories();
            PrettyPrint.PrintCategories(categories);
            Console.WriteLine("Select Category: ");
            while( ReadHelpers.IntInputValidation(out var categoryId))
            {
                var selectedCategory = _invoiceRepository.GetCategory(categoryId);
                if(selectedCategory == null)
                {
                    Console.WriteLine("Not valid");
                    return false;
                }
                var products = _invoiceRepository.GetProductsByCategory(selectedCategory.Id);

            }
        }
        
        private bool SetProduct(List<Product> products, Product newProduct)
        {
            var valid =  ReadHelpers.IntInputValidation(out var Id);
            var selectedProduct = products.Where(p => p.Id == Id).FirstOrDefault();
            if(selectedProduct == null)
            {
                Console.WriteLine("No product Selected!");
                Console.ReadKey();

            }
        }

        private void SetEmplyeToModel(InvoiceModel model, Employe employe)
        {
            model.Employe.Id = employe.Id;
            model.Employe.FirstName = employe.FirstName;
            model.Employe.LastName = employe.LastName;
            model.Employe.Oib = employe.Oib;
            model.Employe.WorkHoursStart = employe.WorkHoursStart;
            model.Employe.WorkShiftTime = employe.WorkShiftTime;
        }
    }
}
