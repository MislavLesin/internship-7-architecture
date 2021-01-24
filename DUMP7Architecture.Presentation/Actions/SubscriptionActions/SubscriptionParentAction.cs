using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.SubscriptionActions
{
    public class SubscriptionParentAction : BaseParentAction
    {
        public SubscriptionParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Subscriptins";
        }
        public override void Call()
        {
            Console.WriteLine("Subscriptions Managment");
            base.Call();
        }
    }
}
