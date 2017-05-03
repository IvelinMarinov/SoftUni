using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            var hexNum = Console.ReadLine();
            int Num = Convert.ToInt32(hexNum, 16);

            Console.WriteLine(Num);
        }
    }
}
