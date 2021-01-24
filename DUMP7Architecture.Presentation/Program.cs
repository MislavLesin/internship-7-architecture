
using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Data.Enums;
using DUMP7Architecture.Presentation.Extensions;
using DUMP7Architecture.Presentation.Factories;
using DUMP7Architecture.Presentation.Helpers;
using System;

namespace DUMP7Architecture.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.ReadKey();
            PrintWelcomeScreen();
            var mainMenuActions = MainMenuFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall();

        }
        static void Main1(string[] args)
        {
            var productToEdit = new Product();
            productToEdit.ProductType = Data.Enums.ProductsEnum.Article;
            Console.WriteLine($"product type is {productToEdit.ProductType}");
            Console.WriteLine($"enter ili 0 1 ");

            productToEdit.ProductType = ReadHelpers.ProductTypeInput(out int productType)
                ? (ProductsEnum)productType
                : productToEdit.ProductType;

            Console.WriteLine($"{productToEdit.ProductType}");
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
