using System;

namespace _03.Mission_Private_Impossible
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            var result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
