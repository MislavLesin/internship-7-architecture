using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.InvoiceActions
{
    public class InvoiceParentAction : BaseParentAction
    {
        public InvoiceParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Invoices";
        }
        public override void Call()
        {
            Console.WriteLine("Invoices");
            base.Call();
        }
    }
}
