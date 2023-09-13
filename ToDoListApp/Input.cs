using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public static class Input
    {
        private static string input;

        public static string InputStringInConsole()
        {
            while (true)
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Write command!");
                    continue;
                }
                return input;
            }
            
        }
    }
}
