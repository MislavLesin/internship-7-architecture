using DUMP7Architecture.Domain.Factories;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Actions.CategoryActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Factories
{
    public class CategoryActionsFactory
    {
        public static CategoryParentAction GetCategoryParentAction()
        {
            var categoryActions = new List<IAction>
            {
                new CategoryAddAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new CategoryDeleteAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new CategoryEditAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new AddProductToCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                new RemoveProductFromCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                new AddSubscriptionToCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                new RemoveSubscriptionFromCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                 new ExitMenuAction()
            };

            var categoryPaerntActions = new CategoryParentAction(categoryActions);
            return categoryPaerntActions;
        }
    }
}
