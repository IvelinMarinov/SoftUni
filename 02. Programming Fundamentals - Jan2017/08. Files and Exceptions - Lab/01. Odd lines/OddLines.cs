using System.Collections.Generic;
using System.IO;

namespace _01.Odd_lines
{
    public class OddLines
    {
        public static void Main()
        {
            var inputText = File.ReadAllLines("Input.txt");

            var oddLines = new List<string>();

            for (int i = 0; i < inputText.Length; i++)
            {
                var currentLine = inputText[i];

                if (i % 2 != 0)
                {
                    oddLines.Add(currentLine);
                }
            }

            File.WriteAllLines("output.txt", oddLines);
        }
    }
}
