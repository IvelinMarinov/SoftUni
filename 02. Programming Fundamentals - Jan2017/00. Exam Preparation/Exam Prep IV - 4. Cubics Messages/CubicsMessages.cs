using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam_Prep_IV___4.Cubics_Messages
{
    public class CubicsMessages
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            while (line != "Over!")
            {
                var count = int.Parse(Console.ReadLine());

                Regex regex = new Regex($@"^(\d+)([a-zA-Z]{{{count}}})([^a-zA-Z]*)$");

                var match = regex.Match(line);

                if (match.Success)
                {
                    var left = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var right = match.Groups[3].Value;

                    var indexes = string.Concat(left, right).Where(char.IsDigit).Select(s => s - '0');

                    var result = new StringBuilder();

                    foreach (var index in indexes)
                    {
                        if (index < 0 || index >= message.Length)
                        {
                            result.Append(' ');
                        }
                        else
                        {
                            result.Append(message[index]);
                        }
                    }

                    Console.WriteLine($"{message} == {result}");
                }

                line = Console.ReadLine();
            }
        }
    }
}
