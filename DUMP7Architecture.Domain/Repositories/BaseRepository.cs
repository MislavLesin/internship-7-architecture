using DUMP7Architecture.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ModelsDbContext DbContext;

        protected BaseRepository(ModelsDbContext dbContext)     //dohvaca DbContext iz data
        {
            DbContext = dbContext;
        }
        
        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;       //provjerava jeli se unilo ista u bazu
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}
