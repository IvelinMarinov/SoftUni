using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3.Operations_With_Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            var N1 = int.Parse(Console.ReadLine());
            var N2 = int.Parse(Console.ReadLine());
            var operation = Console.ReadLine();

            var result = 0;

            if (operation == "+")
            {
                result = N1 + N2;
                Console.Write("{0} {1} {2} = {3} - ", N1, operation, N2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (operation == "-")
            {
                result = N1 - N2;
                Console.Write("{0} {1} {2} = {3} - ", N1, operation, N2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (operation == "*")
            {
                result = N1 * N2;
                Console.Write("{0} {1} {2} = {3} - ", N1, operation, N2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (operation == "/")
            {
                if (N2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", N1);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2} = {3:0.00}", N1, operation, N2, Convert.ToDouble(N1) / N2);
                }
            }
            else if (operation == "%")
            {
                if (N2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", N1);
                }
                else
                {
                    result = N1 % N2;
                    Console.WriteLine("{0} {1} {2} = {3}", N1, operation, N2, result);
                }
            }

        }
    }
}
