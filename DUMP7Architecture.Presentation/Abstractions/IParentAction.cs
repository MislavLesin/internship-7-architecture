using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Abstractions
{
    public interface IParentAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }
}
