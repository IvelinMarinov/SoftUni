using System;
using System.Linq;

namespace _02.Collection
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
                try
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "Print":
                            iterator.Print();
                            break;
                        case "PrintAll":
                            iterator.PrintAll();
                            break;

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
