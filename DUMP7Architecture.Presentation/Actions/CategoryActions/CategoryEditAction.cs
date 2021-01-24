using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using DUMP7Architecture.Presentation.Helpers;
using System;
using System.Linq;

namespace DUMP7Architecture.Presentation.Actions.CategoryActions
{
    public class CategoryEditAction :IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit Category";

        public CategoryEditAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var categories = _categoryRepository.GetAll();
            foreach(var cat in categories)
            {
                Console.WriteLine(cat.ToString() + "\n");
            }
            Console.WriteLine($"Enter Category Id to edit :");
            var isEntered = ReadHelpers.IntInputValidation(out var categoryId);

            if(!isEntered)
            {
                Console.WriteLine("Exitting");
                Console.ReadKey();
                return;
            }

            var categoryToEdit = categories.First(c => c.Id == categoryId);

            if(categoryToEdit != null)
            {
                Console.WriteLine("Enter new category name :");
                categoryToEdit.Name = ReadHelpers.StringNotEmptyValidation();
                var response = _categoryRepository.Edit(categoryToEdit, categoryId);
                Console.WriteLine("\n");
                if(response == Domain.ResponseResultType.AlreadyExists)
                {
                    Console.WriteLine($"There is allready a category with name {categoryToEdit.Name}");
                    return;
                }
                else if (response == Domain.ResponseResultType.NotFound)
                {
                    Console.WriteLine($"Category not found");
                    return;
                }
                else if(response == Domain.ResponseResultType.Success)
                {
                    Console.WriteLine($"Exicuted successfuly\n {categoryToEdit.ToString()}");
                }
                Console.ReadKey();
            }
            Console.WriteLine("Category not found");

        }
    }
}
