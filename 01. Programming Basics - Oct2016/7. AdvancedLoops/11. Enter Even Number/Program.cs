using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Enter_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter even number: ");
            var n = int.Parse(Console.ReadLine());

            try
            {
                while (n % 2 == 1)
                {
                    Console.WriteLine("The number is not even.");
                    Console.Write("Enter even number: ");
                    n = int.Parse(Console.ReadLine());

                    if (n % 2 == 0)
                    {
                        Console.WriteLine("Even number entered: {0}", n);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number!");
            }

        }

    }
}