using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Data.Enums;
using DUMP7Architecture.Domain.Models;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            foreach (var emplye in emplyes)
            {
                Console.WriteLine($"Name - {emplye.FirstName} {emplye.LastName} \n" +
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
                invoiceModel.Employe = emplyeToAdd;
                if (MakeDecision(invoiceModel) == false)
                    return;
                Console.Clear();
                Console.WriteLine("Save changes");
                Console.ReadKey();
                _invoiceRepository.SaveNewFullInvoice(invoiceModel);
                return;

            }
            else
            {
                Console.WriteLine("Exiting");
                Console.ReadKey();
                return;
            }
        }

        private bool MakeDecision(InvoiceModel model)
        {
            while (true)
            {
                Console.WriteLine("Type :\n1 for Articles / Services");
                Console.WriteLine("2 for Subscriptions");
                Console.WriteLine("0 to exit");
                var decision = ReadHelpers.IntegerInputBetween(0, 2);
                if (decision == 1)
                {
                    Console.Clear();
                    AddingProducts(model);
                }
                else if(decision == 2)
                {
                    Console.Clear();
                    AddingSubscirptions(model);
                }
                else if (decision == 0)
                {
                    if (model.ModelProductInvoices == null && model.ModelSubscriptionInvoices == null)
                        return false;
                    return true;
                }
            }

        }
        private bool AddingSubscirptions(InvoiceModel model)
        {
            var categories = _invoiceRepository.GetAllCategories().ToList();
            
            while (true)
            {
                Console.Clear();
                PrettyPrint.PrintCategories(categories);
                Console.WriteLine("Select Category: ");
                ReadHelpers.IntInputValidation(out var categoryId);
                var selectedCategory = _invoiceRepository.GetCategory(categoryId);
                if (selectedCategory == null)
                {
                    Console.WriteLine("Not valid");
                    return false;
                }
                var subscriptions = _invoiceRepository.GestSubscriptionsByCategory(selectedCategory.Id);
                if(subscriptions.Count == 0)
                {
                    Console.WriteLine("There are no subscriptions in this category!");
                    Console.ReadKey();
                    continue;
                }
                PrettyPrint.PrintSubscriptions(subscriptions);
                Console.WriteLine("Enter subscription Id to add to invoice :");
                var isEntered = ReadHelpers.IntInputValidation(out var subscriptionId);

                if (!isEntered)
                {
                    Console.WriteLine("Exitting");
                    Console.ReadKey();
                    return false;
                }
                var subscriptinToAdd = subscriptions.Where(p => p.Id == subscriptionId).FirstOrDefault();
                if (subscriptinToAdd != null)
                {
                    SetSubscription(model, subscriptinToAdd);
                }

                Console.WriteLine("Do you want to add more Subscriptions?");
                Console.WriteLine("1 - yes");
                Console.WriteLine("2 - no");
                var decision = ReadHelpers.IntegerInputBetween(1, 2);
                if (decision == 2)
                    return true;

            }
        }

        private bool AddingProducts(InvoiceModel model)
        {
            var categories = _invoiceRepository.GetAllCategories();
            if (categories.Count == 0)
            {
                Console.WriteLine("There are no categories!!!");
                Console.ReadKey();
                return false;
            }
            while (true)
            {
                Console.Clear();
                PrettyPrint.PrintCategories(categories);
                Console.WriteLine("Select Category: ");
                ReadHelpers.IntInputValidation(out var categoryId);
                var selectedCategory = _invoiceRepository.GetCategory(categoryId);
                if (selectedCategory == null)
                {
                    Console.WriteLine("Not valid");
                    return false;
                }
                var products = _invoiceRepository.GetProductsByCategory(selectedCategory.Id);
                if(products.Count == 0)
                {
                    Console.WriteLine("There are no products in this category!");
                    Console.ReadKey();
                    continue;
                }
                PrettyPrint.PrintProducts(products);
                Console.WriteLine("Enter product Id to add to invoice :");
                var isEntered = ReadHelpers.IntInputValidation(out var productId);

                if (!isEntered)
                {
                    Console.WriteLine("Exitting");
                    Console.ReadKey();
                    return false;
                }
                var productToAdd = products.Where(p => p.Id == productId).FirstOrDefault();
                if (productToAdd != null)
                {
                    SetProduct(model, productToAdd);
                }

                Console.WriteLine("Do you want to add more products?");
                Console.WriteLine("1 - yes");
                Console.WriteLine("2 - no");
                var decision = ReadHelpers.IntegerInputBetween(1, 2);
                if (decision == 2)
                    return true;

            }
        }

        private bool SetSubscription(InvoiceModel invoiceModel, Subscription newSubscription)
        {
            int customerId;
                Console.WriteLine($"Is this for a new or existing cutomer?\n" +
                    $"1 - new\n" +
                    $"2 - Existing");
                var decision = ReadHelpers.IntegerInputBetween(1, 2);
            if(decision == 1)
            {
                var customer = CreateNewCustomer();
                _invoiceRepository.SaveNewCustomer(customer);
                customerId = customer.Id;
            }
            else
            {
                customerId = SelectCustomer().Id;
            }
                var subscriptionInvoice = new SubscriptionInvoice(newSubscription);
            subscriptionInvoice.CustomerId = customerId;
            subscriptionInvoice.SubscriptionStartDate = DatesInput();
            while(true)
            {
                subscriptionInvoice.SubscriptionEndDate = DatesInput();
                if (subscriptionInvoice.SubscriptionStartDate < subscriptionInvoice.SubscriptionEndDate)
                    break;
                Console.WriteLine("EndDate has to be after start date!");
            }

                invoiceModel.ModelSubscriptionInvoices.Add(subscriptionInvoice);
                return true;

        }
        private DateTime DatesInput()
        {
            DateTime userDateTime;
            while (true)
            {
                Console.WriteLine("Enter a date: ");
                if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                {
                    Console.WriteLine("The date selected is: " + userDateTime.DayOfWeek);
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                }
            }
            return userDateTime;
        }
        private Customer SelectCustomer()
        {
            var customers = _invoiceRepository.GetAllCustomers();
            Customer customer;
            while (true)
            {
                Console.Clear();
                PrettyPrint.PrintCustomers(customers);
                var isEntered = ReadHelpers.IntInputValidation(out var customerId);

                if (!isEntered)
                {
                    Console.WriteLine("Wrong input!");
                    Console.ReadKey();
                }
                customer = customers.Where(c => c.Id == customerId).FirstOrDefault();
                if (customer != null)
                    break;
            }
            return customer;
            
        }
        private Customer CreateNewCustomer()
        {
            var newCustomer = new Customer();
            Console.WriteLine("Enter customer First Name - ");
            newCustomer.FirstName = Console.ReadLine().Trim();
            Console.WriteLine("Enter customer Last Name - ");
            newCustomer.LastName = Console.ReadLine().Trim();
            Console.WriteLine("Enter customer Oib - ");
            newCustomer.Oib = Console.ReadLine().Trim();
            return newCustomer;
        }
        private bool SetProduct(InvoiceModel invoiceModel, Product newProduct)
        {
            if(newProduct.ProductType == ProductsEnum.Article)
            {
                var numberOfAvailableProducts = newProduct.ProductsInStock;
                Console.WriteLine($"There are {numberOfAvailableProducts} products available,\n" +
                    $"How many do you want ?");
                var selectedProducts = ReadHelpers.IntegerInputBetween(1, numberOfAvailableProducts);
                var pi = new ProductInvoice(newProduct);
                _invoiceRepository.AlterProductStock(newProduct.Id, selectedProducts);
                pi.NumberOfProducts = selectedProducts;
                invoiceModel.ModelProductInvoices.Add(pi);
                return true;

            }
            else
            {
                if(newProduct.ProductsInStock > 0)
                {
                    var pi = new ProductInvoice(newProduct);
                    pi.NumberOfProducts = 1;
                    invoiceModel.ModelProductInvoices.Add(pi);
                    return true;
                }
                else
                {
                    Console.WriteLine("Service Unavailable");
                    Console.ReadKey();
                    return false;
                }
            }
        }
    }
}
