using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Data.Entities.Models
{
    public class Employe
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Oib { get; set; }

        public string WorkHoursStart { get; set; }

        public TimeSpan WorkShiftTime { get; set; }

        public override string ToString()
        {
            return ($"Id - {Id} \n" +
                $"First Name - {FirstName} \n" +
                $"Last Name - {LastName} \n" +
                $"Oib - {Oib} \n" +
                $"Starts Work at - {WorkHoursStart} \n" +
                $"Works for -{WorkShiftTime}");
        }

    }
}
