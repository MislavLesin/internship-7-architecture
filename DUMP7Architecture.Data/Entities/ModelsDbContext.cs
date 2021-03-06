﻿using DUMP7Architecture.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class ModelsDbContext : DbContext
    {
        public ModelsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductInvoice> ProductInvoices { get; set; }

        public DbSet<Employe> Employes { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<SubscriptionInvoice> SubscriptionInvoices { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public class ModelsDbContextFactory : IDesignTimeDbContextFactory<ModelsDbContext>
        {
            public ModelsDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config")
                    .Build();
                configuration
                    .Providers
                    .First()
                    .TryGet("connectionStrings:add:StoreDatabase:connectionString", out var connectionString);

                var options = new DbContextOptionsBuilder<ModelsDbContext>().UseSqlServer(connectionString).Options;
                return new ModelsDbContext(options);
            }
        }
    }
}
