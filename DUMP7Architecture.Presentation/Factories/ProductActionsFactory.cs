using DUMP7Architecture.Domain.Factories;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Actions.ProductActions;
using DUMP7Architecture.Presentation.Actions.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Factories
{
    public static class ProductActionsFactory
    {
        
        public static ProductParentAction GetProductParentAction()
        {
            var productActions = new List<IAction>
            {
               new ProductAddAction(RepositoryFactory.GetRepository<ProductRepository>()),
               new ProductDeleteAction(RepositoryFactory.GetRepository<ProductRepository>()), 
               new ProductEditAction(RepositoryFactory.GetRepository<ProductRepository>()),
               new ExitMenuAction()
            };

            var productParentAction = new ProductParentAction(productActions);
            return productParentAction;
        }
        
    }
}
