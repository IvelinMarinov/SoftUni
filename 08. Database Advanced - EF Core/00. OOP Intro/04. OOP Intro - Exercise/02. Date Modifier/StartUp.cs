using System;

namespace _02.Date_Modifier
{
    public class StartUp
    {
        public static void Main()
        {
            var firstDateString = Console.ReadLine();
            var secondDateString = Console.ReadLine();

            var dateModifier = new DateModifier(firstDateString, secondDateString);

            Console.WriteLine(dateModifier.difference);
        }
    }
}
