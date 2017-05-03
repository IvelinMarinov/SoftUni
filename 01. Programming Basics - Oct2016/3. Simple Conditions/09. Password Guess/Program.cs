using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else if (input != "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine ("Wrong password!");
            }
        }
    }
}
