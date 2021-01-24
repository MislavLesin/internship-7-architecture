using DUMP7Architecture.Data.Entities.Models;
using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.CategoryActions
{
    public class CategoryAddAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Category";

        public CategoryAddAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            var category = new Category();

            Console.WriteLine("Enter category Name :");
            category.Name = ReadHelpers.StringNotEmptyValidation();

            var responseResult = _categoryRepository.Add(category);

            if(responseResult == Domain.ResponseResultType.Success)
            {
                Console.WriteLine("Success! \n");
                Console.WriteLine( category.ToString());
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Failed to save product, no changes applied.");
            Console.ReadLine();
        }
    }
}
