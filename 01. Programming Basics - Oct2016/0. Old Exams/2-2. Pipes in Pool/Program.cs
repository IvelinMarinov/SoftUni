using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2.Pipes_in_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            var volume = int.Parse(Console.ReadLine());
            var pipe1 = int.Parse(Console.ReadLine());
            var pipe2 = int.Parse(Console.ReadLine());
            var hours = double.Parse(Console.ReadLine());

            var pipe1Work = pipe1 * hours;
            var pipe2Work = pipe2 * hours;
            var totalCompleted = pipe1Work + pipe2Work;

            if (totalCompleted <= volume)
            {
                var pipe1WorkPercentage = Math.Truncate((totalCompleted - pipe2Work) / totalCompleted * 100);
                var pipe2WorkPercentage = Math.Truncate((totalCompleted - pipe1Work) / totalCompleted * 100);
                var totalCompletedPercentage = Math.Truncate((totalCompleted / volume) * 100);
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",totalCompletedPercentage, 
                    pipe1WorkPercentage, pipe2WorkPercentage );
            }
            else
            {
                var overflow = totalCompleted - volume;
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", hours, overflow);
            }
        }
    }
}
