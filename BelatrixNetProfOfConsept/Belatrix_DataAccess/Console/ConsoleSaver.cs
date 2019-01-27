using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix_DataAccess
{
    public class ConsoleSaver: IConsoleSaver
    {
        public void SaveToConsole(string message, string color)
        {
            if (string.Equals(color,"Red"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (string.Equals(color, "Yellow"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (string.Equals(color, "White"))
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
