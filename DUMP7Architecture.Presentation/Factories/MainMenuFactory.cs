using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Factories
{
    public static class MainMenuFactory
    {
        
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                CategoryActionsFactory.GetCategoryParentAction(),
                ProductActionsFactory.GetProductParentAction(),
                ReportActionsFactory.GetReportParentAction(),
                SubscriptionsActionsFacotry.GetSubscriptionParentAction(),
                InvoiceActionsFactory.GetInvoiceParentAction(),
                new ExitMenuAction()
                
            };

            actions.SetActionIndexes();
            return actions;
        }
        
    }
}
