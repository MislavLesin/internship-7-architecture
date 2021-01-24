using DUMP7Architecture.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Factories
{
    public static class DbContextFactory
    {
        public static ModelsDbContext GetStoreDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["StoreDatabase"].ConnectionString).Options;
            return new ModelsDbContext(options);
        }
    }
}
