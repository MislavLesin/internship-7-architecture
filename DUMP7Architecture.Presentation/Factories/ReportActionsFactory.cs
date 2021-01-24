using DUMP7Architecture.Domain.Factories;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Actions.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Factories
{
    public static class ReportActionsFactory
    {
        public static ReportParentAction GetReportParentAction()
        {
            var actions = new List<IAction>
            {
                new ReportProducs(RepositoryFactory.GetRepository<ProductRepository>()),
                new ReportCategories(RepositoryFactory.GetRepository<CategoryRepository>()),
                new ReportSubscriptions(RepositoryFactory.GetRepository<SubscriptionRepository>()),
                new ReportEmployes(RepositoryFactory.GetRepository<EmployeRepository>()),
                new ReportProductsByCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                new ReportSubscriptionsByCategory(RepositoryFactory.GetRepository<CategoryRepository>()),       //ako uneses krivi id crasha se, triba napravit provjeru, ali radi
                new ExitMenuAction()
            };

            return new ReportParentAction(actions);
        }
    }
}
