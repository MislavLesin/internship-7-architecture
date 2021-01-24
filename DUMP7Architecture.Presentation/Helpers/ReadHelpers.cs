using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUMP7Architecture.Presentation.Helpers
{
    public class ReadHelpers
    {
        public static bool IntInputValidationNullable(out int input)
        {
            var isNumber = int.TryParse(Console.ReadLine().Trim(), out var output);
            if(!isNumber)
            {
                input = 0;
                return false;
            }
            input = output;
            return true;

            
           
        }
        public static bool StringInputValidationNullable(out string input)
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
        public static bool ProductTypeInput(out int input)
        {
            var userInput = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(userInput))
            {
                input = 0;
                return false;
            }
            else
            {
                var successful = int.TryParse(userInput, out input);
                if(successful)
                {
                    if (input > 1 || input < 0)
                    {
                        Console.WriteLine("Taking default value");
                        return false;
                    }
                }
                return true;
            }

        }
        public static int IntegerInputBetween(int min, int max)
        {
            int userInput = 0;
            bool verifiedFlag = false;
            do
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine().Trim());
                }
                catch
                {
                    Console.WriteLine("Wrong input! \nTry again");
                }
                if (userInput <= max && userInput >= min)
                    verifiedFlag = true;
                else
                    Console.WriteLine("Try again");
            } while (verifiedFlag == false);

            return userInput;
        }

        public static string StringNotEmptyValidation()
        {
            var input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input can't be empty!");
                input = StringNotEmptyValidation();
            }
               
            else
                return input;
            return input;
        }
    }
}
