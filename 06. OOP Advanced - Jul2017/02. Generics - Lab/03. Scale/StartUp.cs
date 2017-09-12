using System;

namespace _03.Scale
{
    public class StartUp
    {
        public static void Main()
        {
            Scale<int> intScale = new Scale<int>(3, 5);
            Console.WriteLine(intScale.GetHavier());

            Scale<string> stringScale = new Scale<string>("ab", "abc");
            Console.WriteLine(stringScale.GetHavier());;
        }
    }
}
