using System;
using System.Reflection;

namespace _01.Define_a_Class_Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties
                (BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);
        }
    }
}
