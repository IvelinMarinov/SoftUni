using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _02.Line_Numbers
{
    class LineNumbers
    {
        static void Main()
        {
            var inputText = File.ReadAllLines("Input.txt");

            var outputText = new List<string>();

            for (int i = 0; i < inputText.Length; i++)
            {
                outputText.Add($"{i + 1}. {inputText[i]}");
            }

            File.WriteAllLines("output.txt", outputText);
        }
    }
}
