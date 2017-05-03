using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                var line = new string(' ', n - i);
                
                for (int j = 1; j <= i; j++)
                {
                    line += "* ";                    
                }
                Console.WriteLine(line);
            }
            for (int i = n-1; i >= 1; i--)
            {
                var line = new string(' ', n - i) + '*';
                for (int j = 1; j < i; j++)
                {
                    line += " *";
                }                
                Console.WriteLine(line);
            }
        }
    }
}
