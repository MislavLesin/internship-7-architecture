using DUMP7Architecture.Domain;
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
    public class CategoryDeleteAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Category";

        public CategoryDeleteAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            var allCategories = _categoryRepository.GetAll();
            PrettyPrint.PrintCategories(allCategories);

            Console.WriteLine("Enter Category Id or leave empty to exit");
            var isInputed = ReadHelpers.IntInputValidation(out var searchId);
            if (!isInputed)
                return;

            var response = _categoryRepository.Delete(searchId);
            if (response == ResponseResultType.NotFound)
                Console.WriteLine("Category Not Found");

            if (response == ResponseResultType.Success)
                Console.WriteLine("Category deleted successfully");

            Console.ReadLine();
            Console.Clear();
        }
    }
}
