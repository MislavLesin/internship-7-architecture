using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.CategoryActions
{
    public class CategoryParentAction : BaseParentAction
    {
        public CategoryParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage Categories";
        }

        public override void Call()
        {
            Console.WriteLine("Category Management");
            base.Call();
        }
    }
}
