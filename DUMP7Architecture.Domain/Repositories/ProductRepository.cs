using DUMP7Architecture.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(ModelsDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Product product)
        {
            DbContext.Products.Add(product);
            return SaveChanges();
        }



    }
}
