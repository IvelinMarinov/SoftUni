using System;

namespace _05.Reflection___Lab
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            var result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
