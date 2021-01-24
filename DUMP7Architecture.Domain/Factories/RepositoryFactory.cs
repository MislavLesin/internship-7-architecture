using DUMP7Architecture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepository<TRepository> () where TRepository : BaseRepository
        {
            var context = DbContextFactory.GetStoreDbContext();
            return (TRepository)Activator.CreateInstance(typeof(TRepository), context);
        }
    }
}
