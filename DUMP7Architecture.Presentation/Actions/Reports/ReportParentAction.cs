using DUMP7Architecture.Presentation.Abstractions;
using System.Collections.Generic;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportParentAction : BaseParentAction
    {
        public ReportParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Reports";
        }
    }
}
