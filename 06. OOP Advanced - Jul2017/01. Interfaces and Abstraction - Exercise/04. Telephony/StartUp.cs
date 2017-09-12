using System;

namespace _04.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            Smartphone phone = new Smartphone();

            var numbersToCall = Console.ReadLine().Split();
            var urlsToBrowse = Console.ReadLine().Split();

            foreach (var number in numbersToCall)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var url in urlsToBrowse)
            {
                try
                {
                    Console.WriteLine(phone.Browse(url));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
