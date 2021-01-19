using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Helpers
{
    public class ReadHelpers
    {
        public static bool StringInputValidation(out string input)
        {
            var userInput = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(userInput))
            {
                input = null;
                return false;
            }

            input = userInput;
            return true;
        }
        public static bool IntInputValidation(out int input)
        {
            var userInput = Console.ReadLine().Trim();
            if(!int.TryParse(userInput,out input))
            {
                input = 0;
                Console.WriteLine("Not a number!");
                return false;
            }
            return true;

        }
    }
}
