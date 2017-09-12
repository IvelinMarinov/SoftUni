using System;

namespace _03.Ferrari
{
    public class StartUp
    {
        public static void Main()
        {
            string ferrariName = typeof(global::Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            var driver = Console.ReadLine();
            ICar ferrari = new global::Ferrari(driver);
            Console.WriteLine(ferrari.ToString());

        }
    }
}
