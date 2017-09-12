using System;

namespace _02.High_Quality_Mistakes
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            var result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
