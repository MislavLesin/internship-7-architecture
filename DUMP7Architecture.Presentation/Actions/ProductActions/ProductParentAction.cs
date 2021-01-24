using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.ProductActions
{
    public class ProductParentAction : BaseParentAction
    {
        public ProductParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "ManageProducts";
        }
        public override void Call()
        {
            Console.WriteLine("Product Management");
            base.Call();
        }
    }
}
