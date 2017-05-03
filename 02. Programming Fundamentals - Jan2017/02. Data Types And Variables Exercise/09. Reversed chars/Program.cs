using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Reversed_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLetter = Console.ReadLine();
            string secondLetter = Console.ReadLine();
            string thirdLetter = Console.ReadLine();

            Console.WriteLine("{0}{1}{2}", thirdLetter, secondLetter, firstLetter);     
        }
    }
}
