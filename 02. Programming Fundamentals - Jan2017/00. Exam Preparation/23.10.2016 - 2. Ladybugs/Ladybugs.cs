using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._10._2016___2.Ladybugs
{
    public class Ladybugs
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());

            var initialIndexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var field = new int[fieldSize];

            for (int i = 0; i < field.Length; i++)
            {
                if (initialIndexes.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }

            var line = Console.ReadLine();

            while (line != "end")
            {
                var command = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var index = int.Parse(command[0]);
                var direction = command[1];
                var flyLenght = int.Parse(command[2]);

                if (index < 0 || index >= field.Length || field[index] == 0)
                {
                    line = Console.ReadLine();
                    continue;
                }

                else
                {
                    if (direction == "right")
                    {
                        field[index] = 0;
                        for (int i = index + flyLenght; i < field.Length; i = i + flyLenght)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }

                    else if (direction == "left")
                    {
                        field[index] = 0;
                        for (int i = index - flyLenght; i >= 0; i = i - flyLenght)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }
                }                

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
