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

            builder.Entity<Category>()
                .HasNoKey()
                .HasData(new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Electronics",
                    },
                     new Category
                    {
                        Id = 2,
                        Name = "Car",
                    },
                      new Category
                    {
                        Id = 3,
                        Name = "Home",
                    },
                       new Category
                    {
                        Id = 4,
                        Name = "Garden",
                    },
                        new Category
                    {
                        Id = 5,
                        Name = "Entertainment",
                    },
                         new Category
                    {
                        Id = 6,
                        Name = "Kids",
                    },
                          new Category
                    {
                        Id = 7,
                        Name = "Furniture",
                    }
                }
                );

            builder.Entity<Product>()
                .HasData(new List<Product>
                {
                    new Product
                {
                    Id = 1,
                    Name = "Phone Charger",
                    Description = "2 amp charger",
                    Price = 90,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                     new Product
                {
                    Id = 2,
                    Name = "Phone Case",
                    Description = "Silocone case Iphone 10x",
                    Price = 60,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 9
                },
                    new Product
                {
                    Id = 3,
                    Name = "Car Shampoo",
                    Description = "Vanilla car shampoo, 0.5l",
                    Price = 110,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 12
                },
                    new Product
                {
                    Id = 4,
                    Name = "Frisbee",
                    Description = "Kiss frisbee",
                    Price = 30,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 5
                },
                    new Product
                {
                    Id = 5,
                    Name = "Water Hose",
                    Description = "10m",
                    Price = 130,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 6,
                    Name = "Bucket",
                    Description = "6L bucket Wooden",
                    Price = 160,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 7,
                    Name = "Massage",
                    Description = "30 min",
                    Price = 65,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
                },
                    new Product
                {
                    Id = 8,
                    Name = "Car Detailing",
                    Description = "Outside and inside",
                    Price = 90,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
                },
                    new Product
                {
                    Id = 9,
                    Name = "Flower Bowl",
                    Description = "Claccis bowl",
                    Price = 40,
                    ProductType = Enums.ProductsEnum.Article,
                    ProductsInStock = 6
                },
                    new Product
                {
                    Id = 10,
                    Name = "House Wifi Upgrade",
                    Description = "Professional installation on WiFi",
                    Price = 300,
                    ProductType = Enums.ProductsEnum.Service,
                    ProductsInStock = 1
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
           


        }
    }
}
