using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Console.Model
{
    /// <summary>
    /// Validates user input
    /// </summary>
    public static class Validate
    {
        public static bool IsValid(string input)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(input))
            {
                isValid = false;
            }

            //Add more validation rules below


            return isValid;
        }
    }
}
