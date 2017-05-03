using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine().Split().ToList();

            var rotations = int.Parse(command[1]);
            var shiftedNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var temp = 0;
                temp = numbers[i];
                shiftedNums[(i + numbers.Count - rotations) % numbers.Count] = temp;
            }
        }
    }
}
