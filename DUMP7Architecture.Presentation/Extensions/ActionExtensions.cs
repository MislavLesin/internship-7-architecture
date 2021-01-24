﻿using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DUMP7Architecture.Presentation.Extensions
{
    public static class ActionExtensions
    {
        public static void PrintActionsAndCall(this IList<IAction> actions) //radi ovog 'this' svi Ilist<Iaction> imaju metodu PrintActionsAndCall
        {
            var exitActionSelected = false;
            do
            {
                Console.Clear();        
                foreach (var action in actions)
                {
                    Console.WriteLine($"{action.MenuIndex}. {action.Label}");
                }

                var isInputInteger = int.TryParse(Console.ReadLine(), out var actionIndex);
                if (isInputInteger)
                {
                    var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
                    if (action == null)
                    {
                        Console.WriteLine("Please select available action");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        exitActionSelected = action is ExitMenuAction;
                        action.Call();
                    }
                }
                else
                {
                    Console.WriteLine("Please type in number.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (!exitActionSelected);
        }

        public static void SetActionIndexes(this IList<IAction> actions)
        {
            for (var index = 0; index < actions.Count; index++)
            {
                actions[index].MenuIndex = index + 1;
            }
        }
    }
}
