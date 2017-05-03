using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comission
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = Console.ReadLine().ToLower();
            var sales = double.Parse(Console.ReadLine());
            var comission = -1.0;

            if (sales >= 0 && sales <= 500)
            {
                if (city == "sofia")
                {
                    comission = 0.05;
                }
                else if (city == "varna")
                {
                    comission = 0.045;
                }
                else if (city == "plovdiv")
                {
                    comission = 0.055;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                if (city == "sofia")
                {
                    comission = 0.07;
                }
                else if (city == "varna")
                {
                    comission = 0.075;
                }
                else if (city == "plovdiv")
                {
                    comission = 0.08;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                if (city == "sofia")
                {
                    comission = 0.08;
                }
                else if (city == "varna")
                {
                    comission = 0.1;
                }
                else if (city == "plovdiv")
                {
                    comission = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 10000)
            {
                if (city == "sofia")
                {
                    comission = 0.12;
                }
                else if (city == "varna")
                {
                    comission = 0.13;
                }
                else if (city == "plovdiv")
                {
                    comission = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            if (comission >= 0)
            {
                Console.WriteLine("{0:f2}", comission * sales);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
