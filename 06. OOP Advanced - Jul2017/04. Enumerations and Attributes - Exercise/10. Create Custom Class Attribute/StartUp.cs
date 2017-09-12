using System;
using System.Reflection;

namespace _10.Create_Custom_Class_Attribute
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class StartUp
    {
        public static void Main()
        {
            var attrInfo = typeof(StartUp).GetCustomAttribute<CustomAttribute>(false);

            var command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine(attrInfo.GetAuthor());
                        break;
                    case "Revision":
                        Console.WriteLine(attrInfo.GetRevision());
                        break;
                    case "Description":
                        Console.WriteLine(attrInfo.GetDescription());
                        break;
                    case "Reviewers":
                        Console.WriteLine(attrInfo.GetReviewers());
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
