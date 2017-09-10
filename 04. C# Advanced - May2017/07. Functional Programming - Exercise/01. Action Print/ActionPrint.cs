using System;
using System.Linq;

namespace _01.Action_Print
{
    public class ActionPrint
    {
        public static void Main()
        {
            Action<string> printer = n => Console.WriteLine(n);

            Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printer);
        }
    }
}
