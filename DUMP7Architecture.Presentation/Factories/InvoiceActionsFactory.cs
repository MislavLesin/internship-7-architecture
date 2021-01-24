using DUMP7Architecture.Domain.Factories;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using DUMP7Architecture.Presentation.Actions.InvoiceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Factories
{
    public class InvoiceActionsFactory
    {
        public static InvoiceParentAction GetInvoiceParentAction()
        {
            var invoiceActions = new List<IAction>
            {
                new GetAllInvoices(RepositoryFactory.GetRepository<InvoiceRepository>()),
                new ExitMenuAction()
            };
            var invoiceParentActions = new InvoiceParentAction(invoiceActions);
            return invoiceParentActions;
        }
    }
}
