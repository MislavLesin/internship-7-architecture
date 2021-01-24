using DUMP7Architecture.Domain.Repositories;
using DUMP7Architecture.Presentation.Abstractions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Actions.Reports
{
    public class ReportEmployes : IAction
    {
        private readonly EmployeRepository _employeRepository;

        public int MenuIndex { get; set; }

        public string Label { get; set; } = "Show All Employes";

        public ReportEmployes(EmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }
        public void Call()
        {
            Console.Clear();
            var emplyes = _employeRepository.GetAll();
            if (emplyes.Count() == 0)
                Console.WriteLine("No emplyes yet!");
            else
            {
                foreach (var emplye in emplyes)
                {
                    Console.WriteLine(emplye.ToString());
                    Console.WriteLine("\n");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
}
