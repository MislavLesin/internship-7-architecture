﻿using DUMP7Architecture.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Abstractions
{

    public abstract class BaseParentAction : IParentAction
    {
        public int MenuIndex { get; set; }
        public string Label { get; set; }
        public IList<IAction> Actions { get; set; }


        protected BaseParentAction(IList<IAction> actions)
        {
            actions.SetActionIndexes();
            Actions = actions;
        }


        public virtual void Call()
        {
            Actions.PrintActionsAndCall();
        }




    }
}
