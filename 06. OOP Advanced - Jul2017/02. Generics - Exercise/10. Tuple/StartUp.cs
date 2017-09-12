using System;

namespace _10.Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var firstTuple = new Tuple<string,string>(string.Concat(input[0], " ", input[1]), input[2]);
            Console.WriteLine(firstTuple.ToString());

            input = Console.ReadLine().Split();
            var secondTuple = new Tuple<string,int>(input[0], int.Parse(input[1]));
            Console.WriteLine(secondTuple.ToString());

            input = Console.ReadLine().Split();
            var thirdTuple = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
