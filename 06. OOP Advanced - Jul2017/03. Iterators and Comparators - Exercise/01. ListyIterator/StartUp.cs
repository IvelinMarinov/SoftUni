using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            var createCommand = Console.ReadLine().Split().ToList();
            createCommand.RemoveAt(0);
            var iterator = new ListyIterator<string>(createCommand);

            var command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
