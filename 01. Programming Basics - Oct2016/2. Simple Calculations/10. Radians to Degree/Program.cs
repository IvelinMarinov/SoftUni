using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad_To_Deg
{
    class Program
    {
        static void Main(string[] args)
        {
            var rad = double.Parse(Console.ReadLine());
            var deg = rad * 180 / Math.PI;
            var degRounded = Math.Round(deg,0);
            Console.WriteLine(degRounded);
        }
    }
}
