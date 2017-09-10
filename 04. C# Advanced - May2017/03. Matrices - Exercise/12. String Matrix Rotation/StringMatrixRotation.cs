using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12.String_Matrix_Rotation
{
    public class StringMatrixRotation
    {
        public static void Main()
        {
            var rotationUserInput = Console.ReadLine();

            Regex regex = new Regex(@"Rotate\((\d+)\)"); 
            
            var match = regex.Match(rotationUserInput);
            int rotationAngle = 0;

            if (match.Success)
            {
                rotationAngle = int.Parse(match.Groups[1].Value) % 360;
            }

            List<string> entries = new List<string>();

            string input = Console.ReadLine();
            while (input.ToUpper() != "END")
            {
                entries.Add(input);
                input = Console.ReadLine();
            }

            var result = Rotate(entries, rotationAngle / 90); 
            foreach (var row in result)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        static char[][] Rotate(List<string> entries, int times)
        {
            var rows = entries.Count; 
            var cols = entries.Max(x => x.Length);

            for (int i = 0; i < entries.Count; i++)
            {
                entries[i] = entries[i] + new string(' ', cols - entries[i].Length);
            }

            if (times % 2 == 0) 
            {
                if (times == 2) 
                {
                    entries.Reverse();
                    entries = entries.Select(x => new string(x.Reverse().ToArray())).ToList();
                }

                char[][] result = new char[rows][];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = entries[i].ToCharArray();
                }

                return result;
            }
            else
            {
                char[][] result = new char[cols][]; 

                for (int i = 0; i < cols; i++)
                {
                    result[i] = new char[rows];
                    for (int j = 0; j < rows; j++)
                    {
                        result[i][j] = entries[times == 3 ? j : rows - 1 - j][times == 3 ? cols - 1 - i : i]; 
                    }
                }

                return result;
            }
        }
    }
}
