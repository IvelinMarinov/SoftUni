using System;
using System.Linq;
using System.Reflection;

namespace _02.Black_Box_Integer
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInt);
            BlackBoxInt myInstance =
                (BlackBoxInt)Activator.CreateInstance(classType, true);

            var input = Console.ReadLine().Split('_');

            while (input[0] != "END")
            {
                var methodName = input[0];
                var value = int.Parse(input[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(myInstance, new object[] {value});

                var fieldInnerValue = classType
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First()
                    .GetValue(myInstance);

                Console.WriteLine(fieldInnerValue);
                    
                input = Console.ReadLine().Split('_');
            }
        }
    }
}
