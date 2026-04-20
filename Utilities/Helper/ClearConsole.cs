using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public static class ClearConsole
    {
        public static void ConsoleCleaner()
        {
            Console.Write("Press any key to continue: ");
            Console.ReadKey();  
            Console.Clear();
        }
    }
}
