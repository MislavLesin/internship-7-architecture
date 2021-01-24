using DUMP7Architecture.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Seeds
{
    public static class DbSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Category>()
                 .HasData(new List<Category>
            { new Category
                    {
                        Id = 1,
                        Name = "Electronics"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Car"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Home"
                    },
                       new Category
                    {
                        Id = 4,
                        Name = "Garden"
                    },
                        new Category
                    {
                        Id = 5,
                        Name = "Entertainment"
                    },
                         new Category
                    {
                        Id = 6,
                        Name = "Kids"
                    },
                          new Category
                    {
                        Id = 7,
                        Name = "Furniture"
                    }

            });

            builder.Entity<Employe>()
                .HasData(new List<Employe> {
                new Employe
                {
                     Id = 1,
                     FirstName = "Mate",
                     LastName = "Matić",
                     Oib = "123456111",
                     WorkHoursStart = "8:00",
                     WorkShiftTime = TimeSpan.Parse("8:00")
                },
                 new Employe
                {
                     Id = 2,
                     FirstName = "Ivo",
                     LastName = "Ivic",
                     Oib = "123456112",
                     WorkHoursStart = "14:00",
                     WorkShiftTime = TimeSpan.Parse("6:00")
                },
                  new Employe
                {
                     Id = 3,
                     FirstName = "Petar",
                     LastName = "Petricic",
                     Oib = "123456113",
                     WorkHoursStart = "8:00",
                     WorkShiftTime = TimeSpan.Parse("8:00")
                },

                });

            builder.Entity<Customer>()
                .HasData(new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Ante",
                        LastName = "Antić",
                        Oib = "123456111"
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Mate",
                        LastName = "Matic",
                        Oib = "123456112"
                    },
                    new Customer
                    {
                        Id = 3,
                        FirstName = "Karlo",
                        LastName = "Karlic",
                        Oib = "123456113"
                    },
                    new Customer
                    {
                        Id = 4,
                        FirstName = "Roko",
                        LastName = "Rokelic",
                        Oib = "123456114"
                    }
                });

            builder.Entity<Product>()
                .HasData(new List<Product>
                {
                    new Product
                {
                    Id = 1,
                    Name = "Phone Charger",
                    Price = 90,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                     new Product
                {
                    Id = 2,
                    Name = "Phone Case",
                    Price = 60,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 9
                },
                    new Product
                {
                    Id = 3,
                    Name = "Car Shampoo",
                    Price = 110,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 12
                },
                    new Product
                {
                    Id = 4,
                    Name = "Frisbee",
                    Price = 30,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 5
                },
                    new Product
                {
                    Id = 5,
                    Name = "Water Hose",
                    Price = 130,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 6,
                    Name = "Bucket",
                    Price = 160,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 7,
                    Name = "Massage",
                    Price = 65,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
                },
                    new Product
                {
                    Id = 8,
                    Name = "Car Detailing",
                    Price = 90,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
                },
                    new Product
                {
                    Id = 9,
                    Name = "Flower Bowl",
                    Price = 40,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 10,
                    Name = "House Wifi Upgrade",
                    Price = 300,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
                }
                });

            builder.Entity<ProductCategory>()
                .HasData(new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        Id = 1,
                        ProductId = 1,
                        CategoryId = 1
                    },
                    new ProductCategory
                    {
                        Id = 2,
                        ProductId = 2,
                        CategoryId = 1
                    },
                    new ProductCategory
                    {
                        Id = 3,
                        ProductId = 3,
                        CategoryId = 2
                    },
                    new ProductCategory
                    {
                        Id = 4,
                        ProductId = 4,
                        CategoryId = 5
                    },
                    new ProductCategory
                    {
                        Id = 5,
                        ProductId = 4,
                        CategoryId = 6
                    },
                    new ProductCategory
                    {
                        Id = 6,
                        ProductId = 5,
                        CategoryId = 3
                    },
                    new ProductCategory
                    {
                        Id = 7,
                        ProductId = 5,
                        CategoryId = 4
                    },
                    new ProductCategory
                    {
                        Id = 8,
                        ProductId = 6,
                        CategoryId = 3
                    },
                    new ProductCategory
                    {
                        Id = 9,
                        ProductId = 7,
                        CategoryId = 5
                    },
                    new ProductCategory
                    {
                        Id = 10,
                        ProductId = 8,
                        CategoryId = 2
                    },
                    new ProductCategory
                    {
                        Id = 11,
                        ProductId = 9,
                        CategoryId = 3
                    },
                    new ProductCategory
                    {
                        Id = 12,
                        ProductId = 10,
                        CategoryId = 5
                    }
                });

            builder.Entity<Subscription>()
               .HasData(new List<Subscription>
               {
                   new Subscription
                   {
                       Id = 1,
                       Name = "Database maintenance",
                       Description = "Professional database maintenance",
                       PricePerDay = 30,
                       ServiceAvailable = true,
                       
                   },
                    new Subscription
                   {
                       Id = 2,
                       Name = "Home maintenance",
                       Description = "Cleaning lady",
                       PricePerDay = 50,
                       ServiceAvailable = true,

                   },
                     new Subscription
                   {
                       Id = 3,
                       Name = "Personal Cheff",
                       Description = "Daily Brekfast and Lunch",
                       PricePerDay = 200,
                       ServiceAvailable = true,

                   },
                      new Subscription
                   {
                       Id = 4,
                       Name = "Personal Cheff +",
                       Description = "Daily Brekfast, Lunch and Dinner",
                       PricePerDay = 350,
                       ServiceAvailable = true,

                   }
               });

            builder.Entity<SubscriptionCategory>()
                .HasData(new List<SubscriptionCategory>
                {
                    new SubscriptionCategory
                    {
                        Id = 1,
                        SubscriptionId = 1,
                        CategoryId = 1
                        
                    },
                     new SubscriptionCategory
                    {
                        Id = 2,
                        SubscriptionId = 2,
                        CategoryId = 3

                    },
                      new SubscriptionCategory
                    {
                        Id = 3,
                        SubscriptionId = 3,
                        CategoryId = 3

                    },
                       new SubscriptionCategory
                    {
                        Id = 4,
                        SubscriptionId = 4,
                        CategoryId = 3

                    }

                }) ;

            builder.Entity<Invoice>()
                .HasData(new List<Invoice> {
                
                    new Invoice
                    {
                        Id = 1,
                        DateOfPurchase = new DateTime(2020,01,24),
                        EmployeId = 1
                        
                    },
                    new Invoice
                    {
                        Id = 2,
                        DateOfPurchase = new DateTime(2020,02,12),
                        EmployeId = 2
                    },
                    new Invoice
                    {
                        Id = 3,
                        DateOfPurchase = new DateTime(2020,07,12),
                        EmployeId = 3
                    },
                    new Invoice
                    {
                        Id = 4,
                        DateOfPurchase = new DateTime(2020,6,14),
                        EmployeId = 1
                    },
                    new Invoice
                    {
                        Id = 5,
                        DateOfPurchase = new DateTime(2020,9,12),
                        EmployeId = 2
                    },
                    new Invoice
                    {
                        Id = 6,
                        DateOfPurchase = new DateTime(2020,3,19),
                        EmployeId = 3
                    },
                    new Invoice
                    {
                        Id = 7,
                        DateOfPurchase = new DateTime(2020,07,10),
                        EmployeId = 1
                    },
                    new Invoice
                    {
                        Id = 8,
                        DateOfPurchase = new DateTime(2020,5,12),
                        EmployeId = 2
                    },
                    new Invoice
                    {
                        Id = 9,
                        DateOfPurchase = new DateTime(2020,6,1),
                        EmployeId = 1
                    },
                    new Invoice
                    {
                        Id = 10,
                        DateOfPurchase = new DateTime(2020,5,13),
                        EmployeId = 1
                    },new Invoice
                    {
                        Id = 11,
                        DateOfPurchase = new DateTime(2020,04,11),
                        EmployeId = 2
                    },
                    new Invoice
                    {
                        Id = 12,
                        DateOfPurchase = new DateTime(2020,03,03),
                        EmployeId = 3
                    },
                    new Invoice
                    {
                        Id = 13,
                        DateOfPurchase = new DateTime(2020,01,02),
                        EmployeId = 1
                    },
                    new Invoice
                    {
                        Id = 14,
                        DateOfPurchase = new DateTime(2020,03,24),
                        EmployeId = 2
                    }
                });

            builder.Entity<ProductInvoice>()
                .HasData(new List<ProductInvoice>
                {
                    new ProductInvoice
                    {
                        Id = 1,
                        Name = "Frisbee",
                        Description = "Kids frisbee",
                        Price = 30,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 2,
                        InvoiceId = 1
                    },
                    new ProductInvoice
                    {
                        Id = 2,
                        Name = "Flower Bowl",
                        Description = "Classic bowl",
                        Price = 40,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 2
                    },
                    new ProductInvoice
                    {
                        Id = 3,
                        Name = "Water Hose",
                        Description = "10m",
                        Price = 130,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 3
                        
                    },
                    new ProductInvoice
                    {
                        Id = 4,
                        Name = "Phone Case",
                        Description = "Silocone case Iphone 10x",
                        Price = 60,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 4

                    },
                    new ProductInvoice
                    {
                        Id = 5,
                        Name = "Water Hose",
                        Description = "10m",
                        Price = 130,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 5

                    },
                    new ProductInvoice
                    {
                        Id = 6,
                        Name = "Bucket",
                        Description = "6L bucket Wooden",
                        Price = 160,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 5

                    },
                    new ProductInvoice
                    {
                        Id = 7,
                         Name = "Car Shampoo",
                        Description = "Vanilla car shampoo, 0.5l",
                        Price = 110,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 6

                    },
                    new ProductInvoice
                    {
                        Id = 8,
                        Name = "Phone Case",
                        Description = "Silocone case Iphone 10x",
                        Price = 60,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 7

                    },
                    new ProductInvoice
                    {
                        Id = 9,
                        Name = "Phone Charger",
                        Description = "2 amp charger",
                        Price = 90,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 8

                    },
                    new ProductInvoice
                    {
                        Id = 10,
                         Name = "Flower Bowl",
                        Description = "Classic bowl",
                        Price = 40,
                        ProductType = Enums.ProductsEnum.Article,
                        NumberOfProducts = 1,
                        InvoiceId = 9

                    },
                    new ProductInvoice
                    {
                        Id = 11,
                        Name = "Car Detailing",
                        Description = "Outside and inside",
                        Price = 90,
                        ProductType = Enums.ProductsEnum.Service,
                        NumberOfProducts = 1,
                        InvoiceId = 10

                    },
                    new ProductInvoice
                    {
                        Id = 12,
                        Name = "House Wifi Upgrade",
                        Description = "Professional installation on WiFi",
                        Price = 300,
                        ProductType = Enums.ProductsEnum.Service,
                        NumberOfProducts = 1,
                        InvoiceId = 11

                    }
                });

            builder.Entity<ProductInvoiceCategory>()
                .HasData(new List<ProductInvoiceCategory>
                {
                    new ProductInvoiceCategory
                    {
                        Id = 1,
                        ProductInvoiceId = 1,
                        CategoryId = 6
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 2,
                        ProductInvoiceId = 2,
                        CategoryId = 4
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 3,
                        ProductInvoiceId = 3,
                        CategoryId = 4
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 4,
                        ProductInvoiceId = 4,
                        CategoryId = 1
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 5,
                        ProductInvoiceId = 5,
                        CategoryId = 4
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 6,
                        ProductInvoiceId = 6,
                        CategoryId = 4
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 7,
                        ProductInvoiceId = 7,
                        CategoryId = 2
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 8,
                        ProductInvoiceId = 8,
                        CategoryId = 1
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 9,
                        ProductInvoiceId = 9,
                        CategoryId = 1
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 10,
                        ProductInvoiceId = 10,
                        CategoryId = 3
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 11,
                        ProductInvoiceId = 11,
                        CategoryId = 2
                    },
                    new ProductInvoiceCategory
                    {
                        Id = 12,
                        ProductInvoiceId = 12,
                        CategoryId = 3
                    }

                });

            builder.Entity<SubscriptionInvoice>()
                .HasData(new List<SubscriptionInvoice> 
                {
                    new SubscriptionInvoice
                    {
                        Id = 1,
                        Name = "Database maintenance",
                        Description = "Professional database maintenance",
                        PricePerDay = 30,
                        SubscriptionStartDate = new DateTime (2020,3,15),
                        SubscriptionEndDate = new DateTime (2020,4,2),
                        CustomerId = 1,
                        InvoiceId = 12
                        
                    },
                    new SubscriptionInvoice
                    {
                        Id = 2,
                       Name = "Home maintenance",
                       Description = "Cleaning lady",
                       PricePerDay = 50,
                        SubscriptionStartDate = new DateTime (2020,4,13),
                        SubscriptionEndDate = new DateTime (2020,5,2),
                        CustomerId = 2,
                        InvoiceId = 13

                    },
                    new SubscriptionInvoice
                    {
                        Id = 3,
                         Name = "Personal Cheff +",
                       Description = "Daily Brekfast, Lunch and Dinner",
                       PricePerDay = 350,
                        SubscriptionStartDate = new DateTime (2020,6,15),
                        SubscriptionEndDate = new DateTime (2020,6,20),
                        CustomerId = 3,
                        InvoiceId = 14

                    }
                });

            builder.Entity<SubscriptionInvoiceCategory>()
                .HasData(new List<SubscriptionInvoiceCategory>
                {
                    new SubscriptionInvoiceCategory
                    {
                        Id = 1,
                        SubscriptionInvoiceId = 1,
                        CategoryId = 1
                    },
                    new SubscriptionInvoiceCategory
                    {
                        Id = 2,
                        SubscriptionInvoiceId = 2,
                        CategoryId = 1
                    },
                    new SubscriptionInvoiceCategory
                    {
                        Id = 3,
                        SubscriptionInvoiceId = 3,
                        CategoryId = 1
                    },
                    new SubscriptionInvoiceCategory
                    {
                        Id = 4,
                        SubscriptionInvoiceId = 3,
                        CategoryId = 5
                    }
                });
        }
    }
}
