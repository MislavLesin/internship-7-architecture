using DUMP7Architecture.Presentation.Extensions;
using DUMP7Architecture.Presentation.Factories;
using System;

namespace DUMP7Architecture.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 70;
            PrintWelcomeScreen();
            var mainMenuActions = MainMenuFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall(); 

        }
        
        public static void PrintWelcomeScreen()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("-----Welcome to my Store-----");
            Console.WriteLine("=============================");
            Console.ReadKey();
        }
    }
}
