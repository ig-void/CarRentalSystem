using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Utilities.Helper
{
    public class InputHelper
    {
        public static int GetInt()
        {
            int value;
            //Console.WriteLine(mess);
            while(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input try again");
            }
            return value;
        }
        public static decimal GetDecimal()
        {
            decimal value;
            //Console.WriteLine(mess);
            while(!decimal.TryParse(Console.ReadLine(),out value))
            {
                Console.WriteLine("Invalid input try again");
            }
            return value;
        }
        public static DateTime GetDateExact()
        {
            DateTime value;
            string format = "dd-MM-yyyy";
            //Console.WriteLine(mess);
            while (!DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                Console.WriteLine($"Invalid Formalt. Use{format}");
            }
            return value;
        }
    }
}
