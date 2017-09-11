using System;

namespace _05.Date_Modifier
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
