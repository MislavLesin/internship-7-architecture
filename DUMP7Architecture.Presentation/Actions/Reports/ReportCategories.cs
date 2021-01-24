using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportCategories : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }

        public string Label { get; set; } = "Show All Categories";

        public ReportCategories(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();
            var categories = _categoryRepository.GetAll();
            if(categories.Count() == 0)
                Console.WriteLine("No categories yet!");
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine(category.ToString());
                    Console.WriteLine("\n");
                }
            }

            Console.ReadKey();
            Console.Clear();
            
        }
    }
}
