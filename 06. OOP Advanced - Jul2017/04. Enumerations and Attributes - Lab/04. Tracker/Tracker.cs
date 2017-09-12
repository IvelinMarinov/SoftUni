using System;
using System.Linq;
using System.Reflection;
using _04.Tracker;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance |
                                      BindingFlags.Public | BindingFlags.Static);
        foreach (var mInfo in methods)
        {
            if (mInfo.CustomAttributes
                .Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = mInfo.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{mInfo.Name} is written by {attr.Name}");
                }
            }
        }

    }
}