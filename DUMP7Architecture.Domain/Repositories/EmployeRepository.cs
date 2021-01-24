using DUMP7Architecture.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Domain.Repositories
{
    public class EmployeRepository : BaseRepository
    {
        public EmployeRepository(ModelsDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Employe newEmploye)
        {
            var allEmployees = DbContext.Employes.ToList();
            foreach(var employe in allEmployees)
            {
                if(employe.Oib == newEmploye.Oib)
                {
                    return ResponseResultType.AlreadyExists;
                }
            }
            DbContext.Employes.Add(newEmploye);
            return SaveChanges();
        }

        public ICollection<Employe> GetAll()
        {
            return DbContext.Employes.ToList();
        }

        public ResponseResultType Delete(int employeId)
        {
            var employeToDelete = DbContext.Employes.Find(employeId);
            if (employeToDelete == null)
                return ResponseResultType.NotFound;
            else
            {
                DbContext.Employes.Remove(employeToDelete);
                return SaveChanges();
            }
        }
    }
}
